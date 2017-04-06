using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using ImsGlobal.Caliper.Events;
	using ImsGlobal.Caliper.Events.Outcome;

	[TestFixture]
	public class AssessmentOutcomeEventsTests {

		[Test]
		public void AssessmentOutcomeEvent_MatchesReferenceJson() {

			var outcomeEvent = new OutcomeEvent( Action.Graded ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.Assessment1_Attempt1,
				//Generated = TestEntities.Assessment1_Attempt1_Result,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.SuperAssessmentTool,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( outcomeEvent, "caliperAssessmentOutcomeEvent" );
		}

	}

}
