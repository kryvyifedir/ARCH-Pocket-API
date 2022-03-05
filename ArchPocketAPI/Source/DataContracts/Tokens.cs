using System;
using Newtonsoft.Json;

namespace ArchPocketAPI
{
	[JsonObjectAttribute]
	public sealed class RequestToken_Request
	{
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }
		[JsonPropertyAttribute("redirect_uri")]
		public string RedirectUri { get; set; }
		[JsonPropertyAttribute("state")]
		public string State { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class RequestToken_Response
	{
		[JsonPropertyAttribute("code")]
		public string Code { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class AccessToken_Request
	{
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }
		[JsonPropertyAttribute("code")]
		public string RequestToken { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class AccessToken_Response
	{
		[JsonPropertyAttribute("access_token")]
		public string AccessToken { get; set; }
		[JsonPropertyAttribute("username")]
		public string Username { get; set; }
	}
}