using System;
using System.Runtime.Serialization;

namespace ArchPocketAPI.DataContracts
{
	[DataContract]
    public sealed class AccessToken_Request
    {
        [DataMember(Name = "consumer_key")]
        public string ConsumerKey { get; set; }
        [DataMember(Name = "code")]
        public string RequestToken { get; set; }
    }

	[DataContract]
    public sealed class AccessToken_Response
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
    }

}