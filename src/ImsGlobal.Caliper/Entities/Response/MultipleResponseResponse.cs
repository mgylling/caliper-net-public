using System.Collections.Generic;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Response {

	public class MultipleResponseResponse : Response {

		public MultipleResponseResponse( string id )
			: base( id ) {
			this.Type = EntityType.MultipleResponse;
		}

		[JsonProperty( "values", Order = 31 )]
		public IList<string> Values { get; set; }

	}

}