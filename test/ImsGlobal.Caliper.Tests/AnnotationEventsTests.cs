using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Annotation;
	using ImsGlobal.Caliper.Events.Annotation;

	[TestFixture]
	public class AnnotationEventsTests {

		[Test]
		public void BookmarkAnnotationEvent_MatchesReferenceJson() {

			var bookmarkAnnotation = new BookmarkAnnotation( "https://example.edu/bookmarks/00001" ) {
				Annotated = TestEntities.EpubSubChap432,
				BookmarkNotes = "The Intolerable Acts (1774)--bad idea Lord North",
				DateCreated = TestEntities.DefaultDateCreated,
				DateModified = TestEntities.DefaultDateModified
			};

			var bookmarkEvent = new AnnotationEvent( bookmarkAnnotation ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubSubChap432_Frame,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( bookmarkEvent, "caliperBookmarkAnnotationEvent" );
		}

		[Test]
		public void HighlightAnnotationEvent_MatchesReferenceJson() {

			var highlightAnnotation = new HighlightAnnotation( "https://example.edu/highlights/12345" ) {
				Annotated = TestEntities.EpubSubChap431,
				Selection = new TextPositionSelector { Start = 455, End = 489 },
				SelectionText = "Life, Liberty and the pursuit of Happiness",
				DateCreated = TestEntities.DefaultDateCreated,
				DateModified = TestEntities.DefaultDateModified
			};

			var highlightEvent = new AnnotationEvent( highlightAnnotation ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubSubChap431_Frame,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( highlightEvent, "caliperHighlightAnnotationEvent" );
		}

		[Test]
		public void ShareAnnotationEvent_MatchesReferenceJson() {

			var shareAnnotation = new ShareAnnotation( "https://example.edu/shared/9999" ) {
				Annotated = TestEntities.EpubSubChap433,
				WithAgents = new [] {
					new Person( "https://example.edu/user/657585" ) {
						DateCreated = TestEntities.DefaultDateCreated,
						DateModified = TestEntities.DefaultDateModified
					},
					new Person( "https://example.edu/user/667788" ) {
						DateCreated = TestEntities.DefaultDateCreated,
						DateModified = TestEntities.DefaultDateModified
					}
				},
				DateCreated = TestEntities.DefaultDateCreated,
				DateModified = TestEntities.DefaultDateModified
			};

			var shareEvent = new AnnotationEvent( shareAnnotation ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubSubChap433_Frame,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( shareEvent, "caliperSharedAnnotationEvent" );
		}

		[Test]
		public void TagAnnotationEvent_MatchesReferenceJson() {

			var tagAnnotation = new TagAnnotation( "https://example.edu/tags/7654" ) {
				Annotated = TestEntities.EpubSubChap434,
				Tags = new [] { "to-read", "1765", "shared-with-project-team" },
				DateCreated = TestEntities.DefaultDateCreated,
				DateModified = TestEntities.DefaultDateModified
			};

			var tagEvent = new AnnotationEvent( tagAnnotation ) {
				Actor = TestEntities.User554433,
				Object = TestEntities.EpubSubChap434_Frame,
				EventTime = TestEntities.DefaultStartedAtTime,
				EdApp = TestEntities.EpubViewerApp,
				Group = TestEntities.AmRev101_Group001,
				Membership = TestEntities.User554433_AmRev101_CourseSection001_Membership
			};

			JsonAssertions.AssertSameObjectJson( tagEvent, "caliperTagAnnotationEvent" );
		}

	}

}
