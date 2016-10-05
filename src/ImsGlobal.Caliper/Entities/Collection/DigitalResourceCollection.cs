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
	public class DigitalResourceCollection : Collection {

		public DigitalResourceCollection( string id )
            : base(id)
        {
            this.Type = EntityType.Collection;
            this.Items = new List<DigitalResource>();
        }

        
        [JsonProperty("items", Order = 12)]
        new public IList<DigitalResource> Items { get; set; }

        
    }

}
