using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterClientLibrary.Services
{
	/// <summary>
	/// Contract for a service to search tweets.
	/// </summary>
    public interface ISearchService
    {
		/// <summary>
		/// Search for tweets containing a hashtag.
		/// </summary>
		/// <param name="hashtag">Hashtag to search for.</param>
		/// <param name="count">Number of tweets to return.</param>
		/// <param name="maxId">Tweet ID to start at.</param>
		/// <returns>List of matching tweets.</returns>
		Task<SearchResponse> GetByHashtagAsync(string hashtag, int count, long? maxId);
    }
}
