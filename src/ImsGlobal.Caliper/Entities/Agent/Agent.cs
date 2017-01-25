using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Agent {
	using ImsGlobal.Caliper.Entities.Foaf;

	public class Agent : IEntity, IAgent {

		public Agent( string id ){
		}

        [JsonProperty("@context", Order = 0)]
        public string Context { get; set; }

        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type", Order = 2)]
        public IType Type { get; set; }

        [JsonProperty("name", Order = 3)]
        public string Name { get; set; }

        [JsonProperty("description", Order = 4)]
        public string Description { get; set; }

        [JsonProperty("extensions", Order = 51)]
        public Object Extensions { get; set; }

        [JsonProperty("dateCreated", Order = 52)]
        public Instant? DateCreated { get; set; }

        [JsonProperty("dateModified", Order = 53)]
        public Instant? DateModified { get; set; }
    }

}
