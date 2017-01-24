using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation
{
	using ImsGlobal.Caliper.Util;

	[JsonConverter(typeof(JsonValueConverter<PositionSelectorType>))]
	public sealed class PositionSelectorType : IType, IJsonValue
	{

		public static readonly PositionSelectorType Text = new PositionSelectorType("TextPositionSelector");

		public PositionSelectorType() { }

		public PositionSelectorType(string uri) {
			this.Value = uri;
		}

		public string Value { get; set; }

	}

}