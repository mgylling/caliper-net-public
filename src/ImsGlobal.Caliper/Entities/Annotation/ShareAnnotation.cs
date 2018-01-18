using System.Collections.Generic;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {
	using ImsGlobal.Caliper.Entities.Foaf;

	public class ShareAnnotation : Annotation {

		public ShareAnnotation(string id)
			: base( id ) {
			this.Type = EntityType.Share;
			this.WithAgents = new List<IAgent>();
		}

		[JsonProperty( "withAgents", Order = 31 )]
		public IList<IAgent> WithAgents { get; set; }

	}
}
