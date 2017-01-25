using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;
    using ImsGlobal.Caliper.Entities.Agent;

	/// <summary>
	/// Caliper representation of a CreativeWork (https://schema.org/CreativeWork)
	/// </summary>
	public class DigitalResource : IResource, ICreativeWork {

		public DigitalResource( string id )
        {
			this.Type = EntityType.DigitalResource;
			this.AlignedLearningObjectives = new List<LearningObjective>();
			this.Keywords = new List<string>();
            this.Creators = new List<Person>();
			this.Id = id;
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


		/// <summary>
		/// List of learning objectives aligned with this resource.
		/// </summary>
		[JsonProperty( "alignedLearningObjective", Order = 12 )]
		public IList<LearningObjective> AlignedLearningObjectives { get; set; }

		/// <summary>
		/// List of keywords that describe this resource.
		/// </summary>
		[JsonProperty( "keywords", Order = 13 )]
		public IList<string> Keywords { get; set; }

        /// <summary>
		/// List of creators that describe this resource.
		/// </summary>
		[JsonProperty("creators", Order = 14)]
        public IList<Person> Creators { get; set; }

        /// <summary>
		/// IANA media type
		/// </summary>
		[JsonProperty("mediaType", Order = 15)]
        public string MediaType { get; set; }

        /// <summary>
        /// A reference to the parent resource, if any.
        /// </summary>
        [JsonProperty( "isPartOf", Order = 61 )]
		public DigitalResource IsPartOf { get; set; }

		/// <summary>
		/// The date the digital resource was published.
		/// </summary>
		[JsonProperty( "datePublished", Order = 62 )]
		public Instant? DatePublished { get; set; }

		/// <summary>
		/// The current version of the digital resource.
		/// </summary>
		[JsonProperty( "version", Order = 63 )]
		public string Version { get; set; }

	}
}
