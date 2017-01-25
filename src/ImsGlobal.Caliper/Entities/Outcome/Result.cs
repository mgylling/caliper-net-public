using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Outcome {
	using ImsGlobal.Caliper.Entities.Foaf;
	using ImsGlobal.Caliper.Util;

	public class Result : Entity {

		public Result( string id )
			: base( id ) {
			this.Type = EntityType.Result;
		}

		[JsonProperty( "assignable", Order = 11 )]
		[JsonConverter( typeof( JsonIdConverter<DigitalResource> ) )]
		public DigitalResource Assignable { get; set; }

		[JsonProperty( "actor", Order = 12 )]
		[JsonConverter( typeof( JsonIdConverter<IAgent> ) )]
		public IAgent Actor { get; set; }

		[JsonProperty( "normalScore", Order = 11 )]
		public double NormalScore { get; set; }

		[JsonProperty( "penaltyScore", Order = 12 )]
		public double PenaltyScore { get; set; }

		[JsonProperty( "extraCreditScore", Order = 13 )]
		public double ExtraCreditScore { get; set; }

		[JsonProperty( "totalScore", Order = 14 )]
		public double TotalScore { get; set; }

		[JsonProperty( "curvedTotalScore", Order = 15 )]
		public double CurvedTotalScore { get; set; }

		[JsonProperty( "curveFactor", Order = 16 )]
		public double CurveFactor { get; set; }

		[JsonProperty( "comment", Order = 17 )]
		public string Comment { get; set; }

		[JsonProperty( "scoredBy", Order = 18 )]
		public IAgent ScoredBy { get; set; }

	}

}
