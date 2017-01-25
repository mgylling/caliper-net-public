using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation
{
	using ImsGlobal.Caliper.Util;

	[JsonConverter(typeof(JsonValueConverter<SelectorType>))]
	public sealed class SelectorType : IType, IJsonValue
	{

		public static readonly SelectorType Text = new SelectorType("TextPositionSelector");

		public SelectorType() { }

		public SelectorType(string uri) {
			this.Value = uri;
		}

		public string Value { get; set; }

	}

}