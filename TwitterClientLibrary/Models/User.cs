using Newtonsoft.Json;

namespace TwitterClientLibrary.Models
{
	/// <summary>
	/// Represents a user on Twitter.
	/// </summary>
    public class User
    {
		/// <summary>
		/// User's profile image URL.
		/// </summary>
		[JsonProperty("profile_image_url")]
		public string ProfileImageUrl { get; set; }
    }
}
