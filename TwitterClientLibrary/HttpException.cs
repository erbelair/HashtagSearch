using System;
using System.Net;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Represents an exception that contains a status code and reason phrase.
	/// </summary>
    public class HttpException : Exception
    {
		/// <summary>
		/// HTTP status code.
		/// </summary>
		public HttpStatusCode StatusCode { get; private set; }

		/// <summary>
		/// Reason phrase.
		/// </summary>
		public string ReasonPhrase { get; private set; }
		
		/// <summary>
		/// Initializes a new <see cref="HttpException"/>.
		/// </summary>
		public HttpException() : this(string.Empty, HttpStatusCode.BadRequest, string.Empty)
		{ }

		/// <summary>
		/// Initializes a new <see cref="HttpException"/> with the supplied parameters.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode">HTTP status code.</param>
		/// <param name="reasonPhrase">Reason phrase.</param>
		public HttpException(string message, HttpStatusCode statusCode, string reasonPhrase) : base(message)
		{
			StatusCode = statusCode;
			ReasonPhrase = reasonPhrase;
		}
    }
}
