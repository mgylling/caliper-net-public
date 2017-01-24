using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {

	public class BookmarkAnnotation : Annotation {

		public BookmarkAnnotation( string id )
			: base( id ) {
			this.Type = EntityType.Bookmark;
		}

		[JsonProperty( "bookmarkNotes", Order = 31 )]
		public string BookmarkNotes { get; set; }

	}
}
