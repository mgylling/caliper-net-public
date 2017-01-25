using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Media {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;

	public class MediaObject : DigitalResource, IMediaObject {

		public MediaObject( string id )
			: base( id ) {
			this.Type = EntityType.MediaObject;
		}

		public MediaObject( string id, EntityType type )
			: base( id ) {
			this.Type = type;
		}

		[JsonProperty( "duration", Order = 71 )]
		public long Duration { get; set; }

	}

}
