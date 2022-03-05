using System;
using Newtonsoft.Json;

namespace ArchPocketAPI
{
	/*
	[DataContract]
    public sealed class AddArticle_Request
    {
        [DataMember(Name = "url")]
        public string ArticleUrl { get; set; }
        [DataMember(Name = "tags")]
        public string Tags { get; set; }
        [DataMember(Name = "consumer_key")]
        public string ConsumerKey { get; set; }
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
    }

    [DataContract]
    public sealed class AddArticle_Response
    {
        [DataMember(Name = "item")]
        public PocketArticle Item { get; set; }
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }

    [DataContract]
    public class ActionsList_Response
    {
        [DataMember(Name = "action_results")]
        public List<bool> Results { get; set; }
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }

    [DataContract]
    public abstract class PocketAction
    {
        [DataMember(Name = "action")]
        public string ActionName { get; set; }
    }

    /// <summary>
    /// action = "archive" - archive article
    /// action = "readd" - un-archive
    /// action = "favorite" - favorite article
    /// action = "unfavorite" - un-favorite article
    /// action = "delete" - delete item
    /// </summary>
    [DataContract]
    public class PocketArticleAction : PocketAction
    {
        [DataMember(Name = "item_id")]
        public Int64 ItemId { get; set; }
    }

    /// <summary>
    /// action = "tags_add" - add one or more tags to an item
    /// action = "tags_remove" - remove one or more tags from an item
    /// </summary>
    [DataContract]
    public class PocketItemTagAction : PocketArticleAction
    {
        [DataMember(Name = "tags")]
        public string Tags { get; set; }
    }

    /// <summary>
    /// action = "tag_rename" - rename a tag
    /// </summary>
    [DataContract]
    public class PocketTagRenameAction : PocketAction
    {
        [DataMember(Name = "old_tag")]
        public string OldTagName { get; set; }
        [DataMember(Name = "new_tag")]
        public string NewTagName { get; set; }
    }

    /// <summary>
    /// action = "tag_delete" - delete a tag
    /// </summary>
    [DataContract]
    public class PocketTagDeleteAction : PocketAction
    {
        [DataMember(Name = "tag")]
        public string Tag { get; set; }
    }
	*/
}