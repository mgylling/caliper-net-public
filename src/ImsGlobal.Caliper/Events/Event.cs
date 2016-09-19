using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Events {
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Lis;
	using ImsGlobal.Caliper.Entities.W3c;
	using ImsGlobal.Caliper.Util;

	/// <summary>
	/// Default base class for Caliper events.
	/// </summary>
	public class Event : BaseEvent {
        //test
		/// <summary>
		/// Optional - "target" - from Metric Profile
		/// </summary>
		[JsonProperty( "target", Order = 6 )]
		public dynamic Target { get; set; }

		/// <summary>
		/// Optional - entity "generated" as result of action - from Metric Profile
		/// </summary>
		[JsonProperty( "generated", Order = 7 )]
		public dynamic Generated { get; set; }

		/// <summary>
		/// EdApp context
		/// </summary>
		[JsonProperty( "edApp", Order = 11 )]
		public SoftwareApplication EdApp { get; set; }

		/// <summary>
		/// Group context
		/// </summary>
		[JsonProperty( "group", Order = 12 )]
		public IOrganization Group { get; set; }

		/// <summary>
		/// Group context
		/// </summary>
		[JsonProperty( "membership", Order = 13 )]
		public Membership Membership { get; set; }

		/// <summary>
		/// Group context
		/// </summary>
		[JsonProperty( "federatedSession", Order = 14 )]
		[JsonConverter( typeof( JsonIdConverter<Entities.Session.Session> ) )]
		public Entities.Session.Session FederatedSession { get; set; }

	}

}
