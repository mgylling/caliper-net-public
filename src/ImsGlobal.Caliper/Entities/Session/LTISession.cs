using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Session {
	using ImsGlobal.Caliper.Entities.Foaf;

	public class LTISession : Session {

		public LTISession( string id )
			: base( id ) {
			this.Type = EntityType.LTISession;
		}

		[JsonProperty("launchParameters ", Order = 31 )]
		public Object LaunchParameters { get; set; }
        
	}

}
