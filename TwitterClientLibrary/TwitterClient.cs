using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TwitterClientLibrary.Models;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents a client used to access twitter.
	/// </summary>
	public class TwitterClient : HttpClient
	{
		private Token _bearerToken;

		/// <summary>
		/// Indicates whether the client currently has a bearer token.
		/// </summary>
		public bool HasToken
		{
			get
			{
				return _bearerToken != null;
			}
		}

		/// <summary>
		/// Gets a <see cref="HttpResponseMessage"/> from a twitter endpoint with the provided name-value pair dictionary.
		/// </summary>
		/// <param name="uri">Twitter endpoint.</param>
		/// <param name="parameters">Name-value pair dictionary.</param>
		/// <returns><see cref="HttpResponseMessage"/> containing our response.</returns>
		public async Task<HttpResponseMessage> GetResponseAsync(string uri, IDictionary<string, string> parameters)
		{
			// If we don't have a token yet, let's get one now.
			if (_bearerToken == null)
			{
				try
				{
					await GetTokenAsync();
				}
				catch (HttpException ex)
				{
					return new HttpResponseMessage(ex.StatusCode)
					{
						ReasonPhrase = ex.ReasonPhrase
					};
				}
			}

			int count = 0;

			foreach (var parameter in parameters)
			{
				uri += string.Format("{0}{1}={2}", count == 0 ? "?" : "&", parameter.Key, Uri.EscapeDataString(parameter.Value));

				count++;
			}

			var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

			return await SendAsync(requestMessage);
		}

		/// <summary>
		/// Gets a bearer token from the twitter API.
		/// </summary>
		private async Task GetTokenAsync()
		{
			var nameValueCollection = new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("grant_type", "client_credentials")
			};

			DefaultRequestHeaders.Clear();
			DefaultRequestHeaders.Authorization = Authorization.GetBasicAuth(WellKnownData.ConsumerKey, WellKnownData.ConsumerSecret);

			var content = new FormUrlEncodedContent(nameValueCollection);

			var response = await PostAsync(Endpoints.Token, content);

			if (response.IsSuccessStatusCode)
			{
				var responseContent = await response.Content.ReadAsStringAsync();

				_bearerToken = JsonConvert.DeserializeObject<Token>(responseContent);

				DefaultRequestHeaders.Authorization = Authorization.GetOAuth(_bearerToken.AccessToken);
			}
			else
			{
				throw new HttpException(string.Format("Server responded with {0} {1}.", response.StatusCode.ToString("D"), response.ReasonPhrase), response.StatusCode, response.ReasonPhrase);
			}
		}
	}
}
