//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Newtonsoft.Json;

//namespace ImsGlobal.Caliper.Entities.Reading {
//	using ImsGlobal.Caliper.Entities.Foaf;

//	/// <summary>
//	/// Representation of a View. Views are generated as part of or
//	/// are the object of an interaction with a Reading.
//	/// </summary>
//	public class View : Entity {

//		public View( string id )
//			: base( id ) {
//			this.Type = EntityType.View;
//		}

//		[JsonProperty( "frame", Order = 11 )]
//		public Frame Frame { get; set; }

//		[JsonProperty( "actor", Order = 12 )]
//		public IAgent Actor { get; set; }

//		[JsonProperty( "startedAtTime", Order = 13 )]
//		public long StartedAt { get; set; }

//		[JsonProperty( "endedAtTime", Order = 14 )]
//		public long EndedAt { get; set; }

//		/// <summary>
//		/// An xsd:duration (http://books.xmlschemata.org/relaxng/ch19-77073.html)
//		/// <remarks>The format is expected to be PnYnMnDTnHnMnS
//		/// Valid values include PT1004199059S, PT130S, PT2M10S, P1DT2S, -P1Y, or P1Y2M3DT5H20M30.123S.
//		/// The following values are invalid: 1Y (leading P is missing), P1S (T separator is missing), 
//		/// P-1Y (all parts must be positive), P1M2Y (parts order is significant and Y must precede M), 
//		/// or P1Y-1M (all parts must be positive).</remarks>
//		/// </summary>
//		[JsonProperty( "duration", Order = 15 )]
//		public string Duration { get; set; }

//	}

//}
