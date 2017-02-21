using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Assessment {
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Qti;


	public class Assessment : AssignableDigitalResource, IAssignable, IAssessment {

		public Assessment( string id )
			: base( id ) {
			this.Type = EntityType.Assessment;
			this.Items = new List<AssessmentItem>();
		}

		[JsonProperty("items", Order = 1)]
		public IList<AssessmentItem> Items { get; set; }
	}

}
