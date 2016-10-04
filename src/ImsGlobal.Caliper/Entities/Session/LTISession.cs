using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Session {
	using ImsGlobal.Caliper.Entities.Foaf;

	public class LtiSession : Session {

		public LtiSession( string id )
			: base( id ) {
			this.Type = EntityType.LtiSession;
		}

		[JsonProperty("launchParameters ", Order = 31 )]
		public Object LaunchParameters { get; set; }

	}

}
