using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {

	public class HighlightAnnotation : Annotation {

		public HighlightAnnotation( string id )
			: base( id ) {
			this.Type = EntityType.Highlight;
			this.Selection = new TextPositionSelector();
		}

		[JsonProperty( "selection", Order = 31 )]
		public TextPositionSelector Selection { get; set; }

		[JsonProperty( "selectionText", Order = 32 )]
		public string SelectionText { get; set; }

	}
}
