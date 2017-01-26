using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Collection {

	/// <summary>
	/// Default base class for Caliper Digital Resource Collection.
	/// </summary>
	public class DigitalResourceCollection : ICollection, IResource {

        public DigitalResourceCollection(string id)
        {
            this.Id = id;
			this.Type = EntityType.DigitalResourceCollection;
			this.Extensions = new List<object>();
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
        public IList<object> Extensions { get; set; }

        [JsonProperty("dateCreated", Order = 52)]
        public Instant? DateCreated { get; set; }

        [JsonProperty("dateModified", Order = 53)]
        public Instant? DateModified { get; set; }

        [JsonProperty("isPartOf", Order = 61)]
        public Entity IsPartOf { get; set; }

        [JsonProperty("items", Order = 62)]
        public IList<DigitalResource> Items { get; set; }

    }

}
