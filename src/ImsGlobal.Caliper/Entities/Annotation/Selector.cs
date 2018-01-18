using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {

	/// <summary>
	/// Base type for all PositionSelector types. As of Caliper 1.1, 
	/// only TextPositionSelector is defined.
	/// </summary>
	public abstract class Selector {

		public Selector(SelectorType type) {
			this.Type = type;
		}

		[JsonProperty("type", Order = 0)]
		public IType Type { get; set; }

	}
}
