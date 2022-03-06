using System;
using Newtonsoft.Json;

namespace ArchPocketAPI.Tokens
{
	/// <summary>
	/// DataContract class that is used to serialize body
	/// of the request to get Pocket Request Token
	/// </summary>
	[JsonObjectAttribute]
	public sealed class RequestToken_Request
	{
		/// <summary>
		/// The Consumer Key for your application
		/// </summary>
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }

		/// <summary>
		/// The URL to be called when the authorization process has been completed. 
		/// This URL should direct back to your application. 
		/// </summary>
		[JsonPropertyAttribute("redirect_uri")]
		public string RedirectUri { get; set; }

		/// <summary>
		/// A string of metadata used by your app. 
		/// This string will be returned in all subsequent authentication responses.
		/// </summary>
		[JsonPropertyAttribute("state")]
		public string State { get; set; }
	}

	/// <summary>
	/// DataContract class that is used to deserialize body
	/// from response that contains Request Token from Pocket
	/// </summary>
	[JsonObjectAttribute]
	public sealed class RequestToken_Response
	{
		/// <summary>
		/// Pocket Request Token
		/// </summary>
		[JsonPropertyAttribute("code")]
		public string RequestToken { get; set; }
	}

	/// <summary>
	/// DataContract class that is used to serialize body
	/// of the request to get Pocket Access Token
	/// </summary>
	[JsonObjectAttribute]
	public sealed class AccessToken_Request
	{
		/// <summary>
		/// The Consumer Key for your application
		/// </summary>
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }

		/// <summary>
		/// Pocket Request Token
		/// </summary>
		[JsonPropertyAttribute("code")]
		public string RequestToken { get; set; }
	}

	/// <summary>
	/// DataContract class that is used to deserialize body
	/// from response that contains Access Token from Pocket
	/// </summary>
	[JsonObjectAttribute]
	public sealed class AccessToken_Response
	{
		/// <summary>
		/// Pocket Access Token
		/// </summary>
		[JsonPropertyAttribute("access_token")]
		public string AccessToken { get; set; }

		/// <summary>
		/// Username of the authorized user
		/// </summary>
		[JsonPropertyAttribute("username")]
		public string Username { get; set; }
	}
}