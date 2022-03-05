using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace ArchPocketAPI
{
	class ArchPocketAPI
	{
		public static String requestTokenURL = "https://getpocket.com/v3/oauth/request";
		public static String accessTokenURL = "https://getpocket.com/v3/oauth/authorize";

		public static async Task<String> GetRequestToken(String consumerKey, String redirectUri)
		{
			RequestToken_Request request = new RequestToken_Request { ConsumerKey = consumerKey, RedirectUri = redirectUri };
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

			return response.Code;
		}

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