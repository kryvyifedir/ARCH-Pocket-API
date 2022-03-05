using System;
using System.Runtime.Serialization;

namespace ArchPocketAPI.DataContracts
{
	[DataContract]
	public sealed class RequestToken_Request
	{
		[DataMember(Name = "consumer_key")]
		public string ConsumerKey { get; set; }
		[DataMember(Name = "redirect_uri")]
		public string RedirectUri { get; set; }
		[DataMember(Name = "state")]
		public string State { get; set; }
	}

	[DataContract]
	public sealed class RequestToken_Response
	{
		[DataMember(Name = "code")]
		public string Code { get; set; }
	}
}