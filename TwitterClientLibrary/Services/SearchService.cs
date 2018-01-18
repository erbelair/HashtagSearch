using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClientLibrary.Services
{
	/// <summary>
	/// Service to search tweets.
	/// </summary>
	public class SearchService : BaseTwitterService, ISearchService
	{
		/// <summary>
		/// Initializes a new <see cref="SearchService"/>.
		/// </summary>
		/// <param name="client">Client to send our requests.</param>
		public SearchService(TwitterClient client) : base(client)
		{ }

		/// <summary>
		/// Search for tweets containing a hashtag.
		/// </summary>
		/// <param name="hashtag">Hashtag to search for.</param>
		/// <param name="count">Number of tweets to return.</param>
		/// <param name="maxId">Tweet ID to end at.</param>
		/// <returns>List of matching tweets.</returns>
		public async Task<SearchResponse> GetByHashtagAsync(string hashtag, int count, long? maxId)
		{
			if (string.IsNullOrWhiteSpace(hashtag))
			{
				return null;
			}

			if (hashtag.Substring(0, 1) != "#")
			{
				hashtag = "#" + hashtag;
			}

			var request = new SearchRequest(hashtag, count, maxId);

			var response = await Client.GetResponseAsync(Endpoints.Search, request.ToDictionary());

			if (response.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<SearchResponse>(await response.Content.ReadAsStringAsync());
			}
			else
			{
				return null;
			}
		}
	}
}
