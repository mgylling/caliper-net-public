using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Assignable {
	using ImsGlobal.Caliper.Entities.Foaf;
	using ImsGlobal.Caliper.Util;

	/// <summary>
	/// Representation of an Attempt. Attempts are generated as part of or
	/// are the object of an interaction represented by an AssignableEvent.
	/// </summary>
	public class Attempt : Entity {

		public Attempt( string id )
			: base( id ) {
			this.Type = EntityType.Attempt;
		}

		[JsonProperty( "assignable", Order = 11 )]
		[JsonConverter( typeof( JsonIdConverter<DigitalResource> ) )]
		public DigitalResource Assignable { get; set; }

		[JsonProperty( "actor", Order = 12 )]
		[JsonConverter( typeof( JsonIdConverter<IAgent> ) )]
		public IAgent Actor { get; set; }

		[JsonProperty( "count", Order = 13 )]
		public int Count { get; set; }

		[JsonProperty( "startedAtTime", Order = 14 )]
		public Instant? StartedAtTime { get; set; }

		[JsonProperty( "endedAtTime", Order = 15 )]
		public Instant? EndedAtTime { get; set; }

		[JsonProperty( "duration", Order = 16 )]
		public Period Duration { get; set; }

	}

}
