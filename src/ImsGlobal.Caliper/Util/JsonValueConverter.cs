using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImsGlobal.Caliper.Util {

	internal sealed class JsonValueConverter<T> : JsonConverter
		where T : IJsonValue, new() {

		public override bool CanConvert( Type objectType ) {
			return objectType == typeof( T );
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer ) {

			return new T {
				Value = JToken.Load( reader ).ToString()
			};
		}

		public override void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer ) {

			var obj = (T)value;
			JToken.FromObject( obj.Value ).WriteTo( writer );
		}

	}

}
