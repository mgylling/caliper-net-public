
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Util;

	/// <summary>
	/// Core base class for Caliper entities. Analogous to a schema.org Thing.
	/// </summary>
	public class BaseEntity : IJsonId {

		public BaseEntity( string id ) {
			this.Id = id;
			this.Type = EntityType.Entity;
		}

		[JsonProperty( "id", Order = 1 )]
		public string Id { get; set; }

		[JsonProperty( "type", Order = 2 )]
		public IType Type { get; set; }

	}

}
