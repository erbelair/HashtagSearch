namespace TwitterClientLibrary.Services
{
	/// <summary>
	/// Base class that all twitter services should inherit.
	/// </summary>
    public abstract class BaseTwitterService
    {
		/// <summary>
		/// Client to send our requests.
		/// </summary>
		protected TwitterClient Client { get; private set; }

		/// <summary>
		/// Initializes a new <see cref="BaseTwitterService"/>.
		/// </summary>
		/// <param name="client">Client to send our requests.</param>
		public BaseTwitterService(TwitterClient client)
		{
			Client = client;
		}
    }
}
