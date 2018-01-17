using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClientLibrary.Models;

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
		/// <returns>List of matching tweets.</returns>
		public async Task<IEnumerable<Tweet>> GetByHashtagAsync(string hashtag)
		{
			if (hashtag.Substring(0, 1) != "#")
			{
				hashtag = "#" + hashtag;
			}

			var request = new SearchRequest(hashtag);

			var response = await Client.GetResponseAsync(Endpoints.Search, request.ToDictionary());

			if (response.IsSuccessStatusCode)
			{
				return JObject.Parse(await response.Content.ReadAsStringAsync()).SelectToken("statuses").ToObject<IEnumerable<Tweet>>();
			}
			else
			{
				return new List<Tweet> { new Tweet() { Id = 0, Text = await response.Content.ReadAsStringAsync() } };
				//return Enumerable.Empty<Tweet>();
			}
		}
	}
}
