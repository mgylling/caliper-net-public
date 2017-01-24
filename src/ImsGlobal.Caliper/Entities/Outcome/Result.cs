using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Outcome {
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Foaf;
	using ImsGlobal.Caliper.Util;

	public class Result : Entity {

		public Result( string id )
			: base( id ) {
			this.Type = EntityType.Result;
		}

		[JsonProperty("attempt", Order = 11)]
		public Attempt Attempt { get; set; }

		[JsonProperty( "normalScore", Order = 12 )]
		public double NormalScore { get; set; }

		[JsonProperty( "penaltyScore", Order = 13 )]
		public double PenaltyScore { get; set; }

		[JsonProperty( "extraCreditScore", Order = 14 )]
		public double ExtraCreditScore { get; set; }

		[JsonProperty( "totalScore", Order = 15 )]
		public double TotalScore { get; set; }

		[JsonProperty( "curvedTotalScore", Order = 16 )]
		public double CurvedTotalScore { get; set; }

		[JsonProperty( "curveFactor", Order = 17 )]
		public double CurveFactor { get; set; }

		[JsonProperty( "comment", Order = 18 )]
		public string Comment { get; set; }

		[JsonProperty( "scoredBy", Order = 19 )]
		public IAgent ScoredBy { get; set; }

	}

}
