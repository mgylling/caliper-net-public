using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImsGlobal.Caliper.Entities.Collection;
using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Forum {

	/// <summary>
	/// Default base class for Caliper entities.
	/// </summary>
	public class Forum : DigitalResourceCollection {

        public Forum(string id) : base(id)
        {
            this.Id = id;
            this.Type = EntityType.Forum;
        }

        [JsonProperty("items", Order = 10)]
        public new IList<Thread> Items { get; set; }

    }

}
