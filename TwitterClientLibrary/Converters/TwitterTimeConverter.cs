using System;
using Newtonsoft.Json;
using System.Globalization;

namespace TwitterClientLibrary
{
	/// <summary>
	/// Converts from Twitter date/time string to <see cref="DateTime"/>.
	/// </summary>
	public class TwitterTimeConverter : JsonConverter
	{
		/// <summary>
		/// Indicates if value can be converted.
		/// </summary>
		/// <param name="objectType">Type of object.</param>
		/// <returns>Whether object can be converted.</returns>
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		/// <summary>
		/// Converts value from string to <see cref="DateTime"/>.
		/// </summary>
		/// <param name="reader">JSON Reader.</param>
		/// <param name="objectType">Object type.</param>
		/// <param name="existingValue">Existing value.</param>
		/// <param name="serializer">JSON Serializer.</param>
		/// <returns>Value as <see cref="DateTime"/>.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return DateTime.ParseExact(reader.Value.ToString(), WellKnownData.TwitterDateTemplate, CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Converts from <see cref="DateTime"/> to string.
		/// </summary>
		/// <param name="writer">JSON Writer.</param>
		/// <param name="value"><see cref="DateTime"/> value.</param>
		/// <param name="serializer">JSON Serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((DateTime)value).ToString(WellKnownData.TwitterDateTemplate));
		}
	}
}
