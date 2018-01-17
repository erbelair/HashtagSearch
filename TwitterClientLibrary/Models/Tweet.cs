using Newtonsoft.Json;

namespace TwitterClientLibrary.Models
{
	/// <summary>
	/// Represents a tweet (status).
	/// </summary>
    public class Tweet
    {
		/// <summary>
		/// ID of the tweet.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Text of the tweet.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Author of the tweet.
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
    }
}
