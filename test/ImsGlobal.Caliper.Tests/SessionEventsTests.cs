using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using ImsGlobal.Caliper.Events;
	using ImsGlobal.Caliper.Events.Session;

	[TestFixture]
	public class SessionEventsTests {

		[Test]
		public void SessionLoggedInEvent_MatchesReferenceJson() {

			var loggedInEvent = new SessionEvent( Action.LoggedIn ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubViewerApp,
				//Target = TestEntities.EpubSubChap431_Frame,
				Generated = TestEntities.SessionStart,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( loggedInEvent, "caliperSessionLoginEvent" );
		}

		[Test]
		public void SessionLoggedOutEvent_MatchesReferenceJson() {

			var loggedOutEvent = new SessionEvent( Action.LoggedOut ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubViewerApp,
				Target = TestEntities.SessionEnd,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( loggedOutEvent, "caliperSessionLogoutEvent" );
		}

		[Test]
		public void SessionTimedOutEvent_MatchesReferenceJson() {

			var timedOutEvent = new SessionEvent( Action.TimedOut ) {
				Actor = TestEntities.EpubViewerApp,
				Object = TestEntities.SessionEnd,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001
			};

			JsonAssertions.AssertSameObjectJson( timedOutEvent, "caliperSessionTimeoutEvent" );
		}

	}

}
