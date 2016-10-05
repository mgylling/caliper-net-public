using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Default base class for Caliper entities.
	/// </summary>
	public class Collection : Entity {

		public Collection( string id )
            : base(id)
        {
            this.Type = EntityType.Collection;
        }

        [JsonProperty("isPartOf", Order = 11)]
        public Entity IsPartOf { get; set; }

        [JsonProperty("items", Order = 11)]
        public IList<Entity> Items { get; set; }

    }

}
