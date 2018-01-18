namespace TwitterClientLibrary
{
	/// <summary>
	/// Contains all of our twitter endpoints.
	/// </summary>
	public static class Endpoints
	{
		/// <summary>
		/// Base URL.
		/// </summary>
		public const string BaseUrl = "https://twitter.com";

		/// <summary>
		/// Reply URL.
		/// </summary>
		public const string ReplyUrl = BaseUrl + "/intent/tweet";

		/// <summary>
		/// Retweet URL.
		/// </summary>
		public const string RetweetUrl = BaseUrl + "/intent/retweet";

		/// <summary>
		/// Like URL.
		/// </summary>
		public const string LikeUrl = BaseUrl + "/intent/like";

		/// <summary>
		/// Base API URI.
		/// </summary>
		public const string BaseApiUri = "https://api.twitter.com";

		/// <summary>
		/// API URI.
		/// </summary>
		public const string ApiUri = BaseApiUri + "/1.1";

		/// <summary>
		/// Token endpoint.
		/// </summary>
		public const string Token = BaseApiUri + "/oauth2/token";

		/// <summary>
		/// Search endpoint.
		/// </summary>
		public const string Search = ApiUri + "/search/tweets.json";
	}
}
