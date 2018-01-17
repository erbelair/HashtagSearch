using System;
using System.Text;
using System.Net.Http.Headers;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Contains static methods to obtain Authentication header values.
	/// </summary>
	public static class Authorization
	{
		/// <summary>
		/// Returns a new Basic uthentication header value from username and password.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		/// <returns>Basic Authentication header value.</returns>
		public static AuthenticationHeaderValue GetBasicAuth(string username, string password)
		{
			var authCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));

			return new AuthenticationHeaderValue("Basic", authCredentials);
		}

		/// <summary>
		/// Returns a new OAuth 2.0 header value from token.
		/// </summary>
		/// <param name="token">Token.</param>
		/// <returns>OAuth 2.0 Authentication header value.</returns>
		public static AuthenticationHeaderValue GetOAuth(string token)
		{
			return new AuthenticationHeaderValue("Bearer", token);
		}
	}
}
