using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents a search response from Twitter API.
	/// </summary>
    public class SearchResponse
    {
		/// <summary>
		/// List of statuses.
		/// </summary>
		[JsonProperty("statuses")]
		public List<Tweet> Statuses { get; set; }

		/// <summary>
		/// Search metadata.
		/// </summary>
		[JsonProperty("search_metadata")]
		public SearchMetadata SearchMetadata { get; set; }
    }
}
