
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Session {
	public class LtiSession : Session {

		public LtiSession(string id)
			: base(id) {
			this.Type = EntityType.LtiSession;
		}

		[JsonProperty("messageParameters", Order = 31)]
		public object MessageParameters { get; set; }

	}

}
