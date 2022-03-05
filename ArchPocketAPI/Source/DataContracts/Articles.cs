using System;
using Newtonsoft.Json;

namespace ArchPocketAPI
{
	[JsonObjectAttribute]
	public sealed class GetArticles_Request
	{
		[JsonPropertyAttribute("consumer_key")]
		public string ConsumerKey { get; set; }
		[JsonPropertyAttribute("access_token")]
		public string AccessToken { get; set; }

		//unix timestamp
		[JsonPropertyAttribute("since")]
		public long Since { get; set; }

		//unread = only return unread items(default)
		//archive = only return archived items
		//all = return both unread and archived items
		[JsonPropertyAttribute("state")]
		public string State { get; set; }

		//article = only return articles
		//video = only return videos or articles with embedded videos
		//image = only return images
		[JsonPropertyAttribute("contentType")]
		public string ContentType { get; set; }

		//simple = return basic information about each item, including title, url, status, and more   
		//complete = return all data about each item, including tags, images, authors, videos, and more
		[JsonPropertyAttribute("detailType")]
		public string DetailType { get; set; }

		//newest = return items in order of newest to oldest
		//oldest = return items in order of oldest to newest
		//title = return items in order of title alphabetically
		//site = return items in order of url alphabetically
		[JsonPropertyAttribute("sort")]
		public string Sort { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class GetArticles_Response
	{
		[JsonPropertyAttribute("status")]
		public int Status { get; set; }
		[JsonPropertyAttribute("list")]
		public List<PocketArticle> Articles { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class PocketArticle
	{
		[JsonPropertyAttribute("item_id")]
		public string ItemId { get; set; }
		[JsonPropertyAttribute("resolved_id")]
		public string ResolvedId { get; set; }
		[JsonPropertyAttribute("given_url")]
		public string GivenURL { get; set; }
		[JsonPropertyAttribute("favorite")]
		public int Favorite { get; set; }
		[JsonPropertyAttribute("status")]
		public int Status { get; set; }
		[JsonPropertyAttribute("resolved_title")]
		public string ResolvedTitle { get; set; }
		[JsonPropertyAttribute("resolved_url")]
		public string ResolvedUrl { get; set; }
		[JsonPropertyAttribute("excerpt")]
		public string Excerpt { get; set; }
		[JsonPropertyAttribute("time_added")]
		public long TimeAdded { get; set; }
		[JsonPropertyAttribute("time_updated")]
		public long TimeUpdated { get; set; }
		[JsonPropertyAttribute("word_count")]
		public int WordCount { get; set; }
		[JsonPropertyAttribute("time_to_read")]
		public int TimeToRead { get; set; }
		[JsonPropertyAttribute("images")]
		public List<PocketArticleImage> Images { get; set; }
		[JsonPropertyAttribute("tags")]
		public List<String> Tags { get; set; }
		[JsonPropertyAttribute("top_image_url")]
		public string TopImage { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class PocketArticleImage
	{
		[JsonPropertyAttribute("item_id")]
		public string ItemId { get; set; }
		[JsonPropertyAttribute("image_id")]
		public int ImageId { get; set; }
		[JsonPropertyAttribute("src")]
		public string Src { get; set; }
		[JsonPropertyAttribute("width")]
		public int Width { get; set; }
		[JsonPropertyAttribute("height")]
		public int Height { get; set; }
		[JsonPropertyAttribute("credit")]
		public string Credit { get; set; }
		[JsonPropertyAttribute("caption")]
		public string Caption { get; set; }
	}

	[JsonObjectAttribute]
	public sealed class PocketArticleTag
	{
		[JsonPropertyAttribute("tag")]
		public string Tag { get; set; }
	}

	[JsonObjectAttribute]
	public class PocketArticleView_Response
	{
		[JsonPropertyAttribute("article")]
		public string ArticleHTML { get; set; }
	}
}