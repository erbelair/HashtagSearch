namespace TwitterClientLibrary
{
	/// <summary>
	/// Contains all of our twitter endpoints.
	/// </summary>
	public static class Endpoints
	{
		/// <summary>
		/// Base URI.
		/// </summary>
		public const string BaseUri = "https://api.twitter.com";

		/// <summary>
		/// API URI.
		/// </summary>
		public const string ApiUri = BaseUri + "/1.1";

		/// <summary>
		/// Token endpoint.
		/// </summary>
		public const string Token = BaseUri + "/oauth2/token";

		/// <summary>
		/// Search endpoint.
		/// </summary>
		public const string Search = ApiUri + "/search/tweets.json";
	}
}
