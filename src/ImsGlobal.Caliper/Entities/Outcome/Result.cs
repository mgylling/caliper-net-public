
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Outcome {
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Foaf;

	public class Result : Entity {

		public Result( string id )
			: base( id ) {
			this.Type = EntityType.Result;
		}

		[JsonProperty("attempt", Order = 11)]
 		public Attempt Attempt { get; set; }

		[JsonProperty( "maxResultScore", Order = 12 )]
		public double MaxResultScore { get; set; } 

		[JsonProperty("resultScore", Order = 13)]
		public double ResultScore { get; set; } 

		/* deprecated
		[JsonProperty( "normalScore", Order = 12 )]
		public double NormalScore { get; set; } */

		/* deprecated
		[JsonProperty("penaltyScore", Order = 13 )]
		public double PenaltyScore { get; set; } */

		/* deprecated
		[JsonProperty( "extraCreditScore", Order = 14 )]
		public int ExtraCreditScore { get; set; } */

		/* deprecated
		[JsonProperty( "totalScore", Order = 15 )]
		public double TotalScore { get; set; } */

		/* deprecated
		[JsonProperty( "curvedTotalScore", Order = 16 )]
		public int CurvedTotalScore { get; set; } */

		/* deprecated
		[JsonProperty( "curveFactor", Order = 17 )]
		public int CurveFactor { get; set; } */

		[JsonProperty( "comment", Order = 18 )]
		public string Comment { get; set; }

		[JsonProperty( "scoredBy", Order = 19 )]
		public IAgent ScoredBy { get; set; }

	}

}
