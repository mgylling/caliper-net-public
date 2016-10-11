using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Forum {

	/// <summary>
	/// Default base class for Caliper entities.
	/// </summary>
	public class Message : DigitalResource {

        public Message(string id) : base(id)
        {
            this.Id = id;
            this.Type = EntityType.Message;
        }

        [JsonProperty("@replyTo", Order = 20)]
        public Message ReplyTo { get; set; }

        [JsonProperty("@content", Order = 21)]
        public string Content { get; set; }

        [JsonProperty("@attachments", Order = 22)]
        public IList<DigitalResource> Attachments { get; set; }

    }

}
