using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArchPocketAPI.Articles
{
	/// <summary>
	/// State filter options for "Get Articles" request
	/// </summary>
	public enum StateFilter {
		unread,
		archive,
		all
	}

	/// <summary>
	/// Content type filter options for "Get Articles" request
	/// </summary>
	public enum ContentTypeFilter {
		article,
		video,
		image
	}

	/// <summary>
	/// Defines the amount of information returned about articles
	/// Use "complete" option to get Images and Excerp of the articles
	/// </summary>
	public enum DetailType {
		simple,
		complete
	}

	/// <summary>
	/// Order of articles returned by "Get Articles" request
	/// </summary>
	public enum Sort {
		/// return items in order of newest to oldest
		newest,
		/// return items in order of oldest to newest
		oldest,
		/// return items in order of title alphabetically
		title,
		/// return items in order of url alphabetically
		site
	}

	/// <summary>
	/// Article state
	/// </summary>
	public enum State {
		unread,
		archive,
		deleted
	}

	/// <summary>
	/// DataContract class that is used to serialize 
	/// "Get Articles" request body
	/// </summary>
	[JsonObjectAttribute]
	public sealed class GetArticles_Request
	{
		/// <summary>
		/// The Consumer Key for your application
		/// </summary>
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }

		/// <summary>
		/// Pocket Access Token
		/// </summary>
		[JsonPropertyAttribute("access_token")]
		public string AccessToken { get; set; }

		/// <summary>
		/// Filters "Get Article" response by article state
		/// </summary>
		/// <value>ArchPocketAPI.Articles.StateFilter</value>
		[JsonPropertyAttribute("state")]
		[JsonConverter(typeof(StringEnumConverter))]
		public StateFilter State { get; set; }

		/// <summary>
		/// Filters "Get Article" response by article content type
		/// </summary>
		/// <value>ArchPocketAPI.Articles.ContentTypeFilter</value>
		[JsonPropertyAttribute("contentType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ContentTypeFilter ContentType { get; set; }

		/// <summary>
		/// Detalization of each Article returned by "Get Articles" request
		/// </summary>
		/// <value>ArchPocketAPI.Articles.DetailType</value>
		[JsonPropertyAttribute("detailType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public DetailType DetailType { get; set; }

		/// <summary>
		/// Sort order of articles returned by "Get Articles" request
		/// </summary>
		/// <value>ArchPocketAPI.Articles.Sort</value>
		[JsonPropertyAttribute("sort")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Sort Sort { get; set; }

		/// <summary>
		/// Filters items returned by "Get Articles" request that were
		/// modified (added, edited, deleted) since the given since unix timestamp
		/// 
		/// Whenever possible, you should use the since parameter, or count and and offset 
		/// parameters when retrieving a user's list. After retrieving the list, you should 
		/// store the current time (which is provided along with the list response) and 
		/// pass that in the next request for the list. This way the server only needs to return 
		/// a small set (changes since that time) instead of the user's entire list every time.
		/// </summary>
		[JsonPropertyAttribute("since")]
		public long Since { get; set; }
	}

	/// <summary>
	/// DataContract class that is used to deserialize 
	/// "Get Articles" response body
	/// </summary>
	[JsonObjectAttribute]
	public sealed class GetArticles_Response
	{
		/// <summary>
		/// Response Status. "1" if articles were retrieved
		/// </summary>
		[JsonPropertyAttribute("status")]
		public int ResponseStatus { get; set; }

		/// <summary>
		/// Dictionary that includes information about Articles
		/// </summary>
		[JsonPropertyAttribute("list")]
		public Dictionary<string, ArticleDC> Articles { get; set; }
	}

	/// <summary>
	/// Data Contract object that stores data about article
	/// </summary>
	[JsonObjectAttribute(MemberSerialization.OptIn)]
	public sealed class ArticleDC
	{
		/// <summary>
		/// Item Id of the article
		/// </summary>
		[JsonPropertyAttribute("item_id")]
		public string ItemId { get; set; }

		/// <summary>
		/// Resolved Item Id
		/// </summary>
		[JsonPropertyAttribute("resolved_id")]
		public string ResolvedId { get; set; }

		/// <summary>
		/// URL that was used to save article in Pocket
		/// </summary>
		[JsonPropertyAttribute("given_url")]
		public string GivenURL { get; set; }

		/// <summary>
		/// This Property is used only for Deserialization purposes
		/// IsFavorite property should be used instead
		/// </summary>
		[JsonPropertyAttribute("favorite")]
		public int FavoriteValue { get; set; }

		/// <summary>
		/// Defines if article is favorite or not.
		/// True if article is marked as favorite
		/// </summary>
		public Boolean IsFavorite 
		{ 
			get {
				if(FavoriteValue == 1)
				{ 
					return true;
				} else {
					return false;
				}
			}
		}

		/// <summary>
		/// This Property is used only for Deserialization purposes
		/// State property should be used instead
		/// </summary>
		[JsonPropertyAttribute("status")]
		public int StateValue { get; set; }

		/// <summary>
		/// State of the article. 
		/// Read, archived or deleted
		/// </summary>
		public State State 
		{ 
			get {
				State value = State.unread;
				switch (StateValue)
				{
					case 1:
						value= State.archive;
					break;
					case 2:
						value = State.deleted;
					break;
				}
				return value;
			}
		}

		/// <summary>
		/// Article title
		/// </summary>
		[JsonPropertyAttribute("resolved_title")]
		public string Title { get; set; }

		/// <summary>
		/// Resolved URL of article
		/// </summary>
		[JsonPropertyAttribute("resolved_url")]
		public string Url { get; set; }

		/// <summary>
		/// Article Excerpt
		/// </summary>
		[JsonPropertyAttribute("excerpt")]
		public string Excerpt { get; set; }

		/// <summary>
		/// TimeAdded property
		/// </summary>
		[JsonPropertyAttribute("time_added")]
		public long TimeAdded { get; set; }

		/// <summary>
		/// TimeUpdated property
		/// </summary>
		[JsonPropertyAttribute("time_updated")]
		public long TimeUpdated { get; set; }


		/// <summary>
		/// Number of words in article
		/// </summary>
		[JsonPropertyAttribute("word_count")]
		public int WordCount { get; set; }

		/// <summary>
		/// Estimated number of minutes required to read an article
		/// </summary>
		[JsonPropertyAttribute("time_to_read")]
		public int TimeToRead { get; set; }

		/// <summary>
		/// Dictionary of Images from the Article. 
		/// Retrieved only when "Get Articles" request is sent 
		/// using "complete" detail type option
		/// </summary>
		[JsonPropertyAttribute("images")]
		public Dictionary<string, ImageDC> Images { get; set; }
		
		/// <summary>
		/// Dictionary with tags that article is tagged with. 
		/// Retrieved only when "Get Articles" request is sent 
		/// using "complete" detail type option
		/// </summary>
		[JsonPropertyAttribute("tags")]
		public Dictionary<string, TagDC> Tags { get; set; }

		/// <summary>
		/// Header image of the Article
		/// </summary>
		[JsonPropertyAttribute("top_image_url")]
		public string TopImageURL { get; set; }

		///Authors and Videos are not yet supported by API 
	}

	/// <summary>
	/// Data Contract object that stores data about individual images in the article
	/// </summary>
	[JsonObjectAttribute]
    public sealed class ImageDC
    {
		/// <summary>
		/// Item Id of the image
		/// </summary>
        [JsonPropertyAttribute("item_id")]
        public string ItemId { get; set; }

		/// <summary>
		/// Image Id
		/// </summary>
        [JsonPropertyAttribute("image_id")]
        public int ImageId { get; set; }

		/// <summary>
		/// Source URL for the Image
		/// </summary>
        [JsonPropertyAttribute("src")]
        public string ImageSource { get; set; }

		/// <summary>
		/// Image width
		/// </summary>
        [JsonPropertyAttribute("width")]
        public int Width { get; set; }
		
		/// <summary>
		/// Image height
		/// </summary>
        [JsonPropertyAttribute("height")]
        public int Height { get; set; }

		/// <summary>
		/// Credit to the image source
		/// </summary>
        [JsonPropertyAttribute("credit")]
        public string Credit { get; set; }

		/// <summary>
		/// Image caption
		/// </summary>
        [JsonPropertyAttribute("caption")]
        public string Caption { get; set; }
    }

	/// <summary>
	/// Data Contract class that stores information about article tags
	/// </summary>
    [JsonObjectAttribute]
    public sealed class TagDC
    {
		/// <summary>
		/// Article tag name
		/// </summary>
        [JsonPropertyAttribute("tag")]
        public string Tag { get; set; }
    }
}