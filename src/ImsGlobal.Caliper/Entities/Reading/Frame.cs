using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Reading {

	public class Frame : DigitalResource {

		public Frame( string id )
			: base( id ) {
			this.Type = DigitalResourceType.Frame;
		}

		/// <summary>
		/// Numeric index of the location relative to sibling locations in the content.
		/// </summary>
		[JsonProperty( "index", Order = 21 )]
		public int Index { get; set; }

	}

}
