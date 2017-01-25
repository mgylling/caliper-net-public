using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using ImsGlobal.Caliper.Events;
	using ImsGlobal.Caliper.Events.Reading;
	using ImsGlobal.Caliper.Protocol;

	[TestFixture]
	public class SensorSendEventsTest {

		[Test]
		public void CaliperMessage_MatchesReferenceJson() {

			var navigationEvent = new NavigationEvent {
				Actor = TestEntities.User554433,
				//Object = TestEntities.EpubVolume43,
				//Target = TestEntities.EpubSubChap431_Frame,
				//FromResource = TestEntities.AmRev101LandingPage,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership,
				FederatedSession = TestEntities.FederatedSession
			};

			var caliperMessage = new CaliperMessage<Event> {
				SensorId = "https://example.edu/sensor/001",
				SendTime = TestEntities.DefaultSendTime,
				Data = new [] {navigationEvent}
			};

			JsonAssertions.AssertSameObjectJson( caliperMessage, "eventStorePayload" );
		}

	}

}
