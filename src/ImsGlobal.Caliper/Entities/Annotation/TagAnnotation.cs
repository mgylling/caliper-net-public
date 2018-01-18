using System.Collections.Generic;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {

	public class TagAnnotation : Annotation {

		public TagAnnotation( string id )
			: base( id ) {
			this.Type = EntityType.Tag;
			this.Tags = new List<string>();
		}

		[JsonProperty( "tags", Order = 31 )]
		public IList<string> Tags { get; set; }

	}
}
