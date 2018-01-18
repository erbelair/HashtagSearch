using Newtonsoft.Json;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents search metadata.
	/// </summary>
    public class SearchMetadata
    {
		/// <summary>
		/// Maximum ID;
		/// </summary>
		[JsonProperty("max_id")]
		public long? MaxId { get; set; }

		/// <summary>
		/// Since ID
		/// </summary>
		[JsonProperty("since_id")]
		public long? SinceId { get; set; }

		/// <summary>
		/// Query string.
		/// </summary>
		public string Query { get; set; }
    }
}
