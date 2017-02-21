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

		[JsonProperty( "count", Order = 11 )]
		public int Count { get; set; }

		[JsonProperty( "startedAtTime", Order = 12 )]
		public Instant? StartedAtTime { get; set; }

		[JsonProperty( "endedAtTime", Order = 13 )]
		public Instant? EndedAtTime { get; set; }

		[JsonProperty( "duration", Order = 14 )]
		public Period Duration { get; set; }

	}

}
