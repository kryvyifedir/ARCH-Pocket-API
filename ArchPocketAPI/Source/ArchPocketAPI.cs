using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using ArchPocketAPI.Tokens;
using ArchPocketAPI.Articles;

namespace ArchPocketAPI
{
	/// <summary>
	/// Pocket API wrapper class
	/// </summary>
	class ArchPocketAPI
	{
		public static String requestTokenURL = "https://getpocket.com/v3/oauth/request";
		public static String accessTokenURL = "https://getpocket.com/v3/oauth/authorize";
		public static String articlesURL = "https://getpocket.com/v3/get";

		String accessToken;
		String consumerKey;

		/// <summary>
		/// ArchPocketAPI constructor
		/// </summary>
		/// <param name="consumerKey">The Consumer Key for your application</param>
		/// <param name="accessToken">Pocket Request Token</param>
		public ArchPocketAPI(String consumerKey, String accessToken) {
			this.consumerKey = consumerKey;
			this.accessToken = accessToken;
		}

		/// <summary>
		/// Static method used to get Request Token from Pocket
		/// before navigating user to https://getpocket.com/auth/authorize for authorization
		/// </summary>
		/// <param name="consumerKey">The Consumer Key for your application</param>
		/// <param name="redirectUri">Redirect Url for your app</param>
		/// <param name="state">A string of metadata used by your app. This string will be returned in all subsequent authentication responses. Optional</param>
		/// <returns>Pocket Request Token</returns>
		public static async Task<String> GetRequestToken(String consumerKey, String redirectUri, String state)
		{
			RequestToken_Request request = new RequestToken_Request { ConsumerKey = consumerKey, RedirectUri = redirectUri, State = state};
			HttpResponseMessage httpResponseMessage = await SendHttpPostRequest(requestTokenURL, request);

			if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Unable to obtain Request Token. Http status code: " + httpResponseMessage.StatusCode.ToString());
			}

			String responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
			RequestToken_Response response = JsonConvert.DeserializeObject<RequestToken_Response>(responseContent);

			if (response == null)
			{
				throw new Exception("Unable to Deserialize response body");
			}

			return response.RequestToken;
		}

		/// <summary>
		/// Static method used to get Access Token from Pocket after
		/// user successfully authorizes the app and Pocket redirects user
		/// to URL provided in "redirect url" for the app
		/// </summary>
		/// <param name="consumerKey">The Consumer Key for your application</param>
		/// <param name="requestToken">Request Token retrieved from GetRequestToken method</param>
		/// <returns>Pocket Access Token</returns>
		public static async Task<String> GetAccessToken(String consumerKey, String requestToken)
		{
			AccessToken_Request request = new AccessToken_Request { ConsumerKey = consumerKey, RequestToken = requestToken };
			HttpResponseMessage httpResponseMessage = await SendHttpPostRequest(accessTokenURL, request);

			if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Unable to obtain Request Token. Http status code: " + httpResponseMessage.StatusCode.ToString());
			}

			String responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
			AccessToken_Response response = JsonConvert.DeserializeObject<AccessToken_Response>(responseContent);

			if (response == null)
			{
				throw new Exception("Unable to Deserialize response body");
			}

			return response.AccessToken;
		}

		/// <summary>
		/// Get the set of articles from Pocket
		/// </summary>
		/// <param name="state">Filter retrieved articles by article state</param>
		/// <param name="detailsType">simple/complete</param>
		/// <param name="sort">simple/complete</param>
		/// <param name="timestamp">
		/// Filters items returned by "Get Articles" request that were
		/// modified (added, edited, deleted) since the given since unix timestamp
		/// 
		/// Whenever possible, you should use the since parameter, or count and and offset 
		/// parameters when retrieving a user's list. After retrieving the list, you should 
		/// store the current time (which is provided along with the list response) and 
		/// pass that in the next request for the list. This way the server only needs to return 
		/// a small set (changes since that time) instead of the user's entire list every time.
		/// </param>
		/// <returns>List of ArticleDC retrieved from Pocket</returns>
		public async Task<List<ArticleDC>> GetArticles(StateFilter state, DetailType detailsType, Sort sort, long timestamp)
		{
			GetArticles_Request request = new GetArticles_Request {
				ConsumerKey = consumerKey,
				AccessToken = accessToken,
				Since = timestamp,
				State = state,
				// video and image types are not yet supported by API
				ContentType = ContentTypeFilter.video,
				DetailType = detailsType,
				Sort = sort
			};

			HttpResponseMessage httpResponseMessage = await SendHttpPostRequest(articlesURL, request);

			if (httpResponseMessage.StatusCode != HttpStatusCode.OK) {
				throw new Exception("Unable to retrieve articles list. Http status code: " + httpResponseMessage.StatusCode.ToString());
			}

			String responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
			GetArticles_Response response = JsonConvert.DeserializeObject<GetArticles_Response>(responseContent);

			if (response == null)
			{
				throw new Exception("Unable to Deserialize response body");
			}

			return response.Articles.Values.ToList();
		}

		private static async Task<HttpResponseMessage> SendHttpGetRequest(string requestUrl)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
				HttpResponseMessage response = await httpClient.SendAsync(request);
				return response;
			}
		}

		private static async Task<HttpResponseMessage> SendHttpPostRequest(string requestUrl, Object dataContract)
		{
			var requestJson = JsonConvert.SerializeObject(dataContract, Formatting.Indented);
			return await SendHttpPostRequest(requestUrl, requestJson);
		}

		private static async Task<HttpResponseMessage> SendHttpPostRequest(string requestUrl, String json)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
				{
					Content = new StringContent(json, Encoding.UTF8, "application/json")
				};
				request.Content.Headers.Add("X-Accept", "application/json");

				HttpResponseMessage response = await httpClient.SendAsync(request);

				return response;
			}
		}
	}
}