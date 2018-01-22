
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Media {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;
	using NodaTime;

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
		public Period Duration { get; set; }

	}

}
