using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterClientLibrary.Models;

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
		/// <returns>List of matching tweets.</returns>
		Task<IEnumerable<Tweet>> GetByHashtagAsync(string hashtag);
    }
}
