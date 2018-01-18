using Newtonsoft.Json;
using System;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents a tweet (status).
	/// </summary>
    public class Tweet
    {
		/// <summary>
		/// ID of the tweet.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Text of the tweet.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Author of the tweet.
		/// </summary>
		public User User { get; set; }

		/// <summary>
		/// Timestamp of the tweet.
		/// </summary>
		[JsonProperty("created_at")]
		[JsonConverter(typeof(TwitterTimeConverter))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Number of retweets.
		/// </summary>
		[JsonProperty("retweet_count")]
		public int Retweets { get; set; }

		/// <summary>
		/// Number of favorites.
		/// </summary>
		[JsonProperty("favorite_count")]
		public int Favorites { get; set; }

		/// <summary>
		/// Link to favorite the tweet.
		/// </summary>
		public string TweetUrl
		{
			get { return string.Format("{0}/{1}/status/{2}", Endpoints.BaseUrl, User.ScreenName, Id.ToString()); }
		}

		/// <summary>
		/// Link to reply to the tweet.
		/// </summary>
		public string ReplyUrl
		{
			get { return string.Format("{0}?in_reply_to={1}", Endpoints.ReplyUrl, Id.ToString()); }
		}

		/// <summary>
		/// Link to retweet to the tweet.
		/// </summary>
		public string RetweetUrl
		{
			get { return string.Format("{0}?tweet_id={1}", Endpoints.RetweetUrl, Id.ToString()); }
		}

		/// <summary>
		/// Link to like the tweet.
		/// </summary>
		public string LikeUrl
		{
			get { return string.Format("{0}?tweet_id={1}", Endpoints.LikeUrl, Id.ToString()); }
		}
    }
}
