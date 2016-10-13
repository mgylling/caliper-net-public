using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImsGlobal.Caliper.Entities.Forum;
using ImsGlobal.Caliper.Entities.Session;
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Events.Forum {

	/// <summary>
	/// Event raised when an actor interacts with a media resource.
	/// </summary>
	public class MessageEvent : Event {

		public MessageEvent( Action action ) {
			this.Type = EventType.Message;
			this.Action = action;
		}

        [JsonProperty("object", Order = 5)]
        public new Message Object { get; set; }

        [JsonProperty("federatedSession", Order = 14)]
        public new LtiSession FederatedSession { get; set; }

    }

}
