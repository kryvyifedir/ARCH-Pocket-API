using System;
using Newtonsoft.Json;

namespace ArchPocketAPI.DataContracts
{
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