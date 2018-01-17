using System.Collections.Generic;

namespace TwitterClientLibrary.Models
{
	/// <summary>
	/// Represents a request to search tweets.
	/// </summary>
    public class SearchRequest
    {
		/// <summary>
		/// The search query.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Indicates whether to request the entities node.
		/// </summary>
		public bool IncludeEntities { get; set; } = true;

		/// <summary>
		/// Initializes a new SearchRequest.
		/// </summary>
		/// <param name="query">Query to search for.</param>
		public SearchRequest(string query)
		{
			Query = query;
		}

		/// <summary>
		/// Converts the request to a name-value pair dictionary.
		/// </summary>
		/// <returns>Request as a dictionary.</returns>
		public Dictionary<string, string> ToDictionary()
		{
			return new Dictionary<string, string>
			{
				{ "q", Query },
				{ "include_entities", IncludeEntities.ToString() }
			};
		}
    }
}
