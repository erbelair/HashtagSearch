using Newtonsoft.Json;

namespace TwitterClientLibrary.Models
{
	/// <summary>
	/// Represents a web token.
	/// </summary>
    public class Token
    {
		/// <summary>
		/// Type of the token.
		/// </summary>
		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		/// <summary>
		/// Value of the token.
		/// </summary>
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
	}
}
