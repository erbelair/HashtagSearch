using System.Collections.Generic;

namespace TwitterClientLibrary
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
		/// The amount of tweets to return.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// ID to start from.
		/// </summary>
		public long? MaxId { get; set; }

		/// <summary>
		/// Indicates whether to request the entities node.
		/// </summary>
		public bool IncludeEntities { get; set; } = true;

		/// <summary>
		/// Initializes a new SearchRequest.
		/// </summary>
		/// <param name="query">Query to search for.</param>
		/// <param name="count">Amount of tweets to return.</param>
		/// <param name="maxId">Tweet ID to start frum.</param>
		public SearchRequest(string query, int count, long? maxId)
		{
			Query = query;
			Count = count;
			MaxId = maxId;
		}

		/// <summary>
		/// Converts the request to a name-value pair dictionary.
		/// </summary>
		/// <returns>Request as a dictionary.</returns>
		public Dictionary<string, string> ToDictionary()
		{
			var dictionary = new Dictionary<string, string>
			{
				{ "q", Query },
				{ "include_entities", IncludeEntities.ToString() },
				{ "count", Count.ToString() }
			};

			if (MaxId != null)
			{
				dictionary.Add("max_id", MaxId.ToString());
			}

			return dictionary;
		}
    }
}
