using Newtonsoft.Json;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents a user on Twitter.
	/// </summary>
    public class User
    {
		/// <summary>
		/// User's ID.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// User's Name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// User's Screen Name.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }

		/// <summary>
		/// User's profile image URL.
		/// </summary>
		[JsonProperty("profile_image_url")]
		public string ProfileImageUrl { get; set; }

		/// <summary>
		/// Indicates whether user is verified.
		/// </summary>
		public bool Verified { get; set; }
    }
}
