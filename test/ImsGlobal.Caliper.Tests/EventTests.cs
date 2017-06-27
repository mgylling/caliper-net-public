
using ImsGlobal.Caliper.Entities;
using ImsGlobal.Caliper.Entities.Agent;
using ImsGlobal.Caliper.Entities.Annotation;
using ImsGlobal.Caliper.Entities.Assessment;
using ImsGlobal.Caliper.Entities.Reading;
using ImsGlobal.Caliper.Entities.Response;
using ImsGlobal.Caliper.Entities.Session;
using ImsGlobal.Caliper.Events;
using ImsGlobal.Caliper.Events.Annotation;
using ImsGlobal.Caliper.Events.Assessment;
using ImsGlobal.Caliper.Events.Assignable;
using ImsGlobal.Caliper.Events.Forum;
using ImsGlobal.Caliper.Events.Media;
using ImsGlobal.Caliper.Events.Outcome;
using ImsGlobal.Caliper.Events.Reading;
using ImsGlobal.Caliper.Events.Session;
using ImsGlobal.Caliper.Events.Tool;
using ImsGlobal.Caliper.Tests.SimpleHelpers;
using Newtonsoft.Json;
using NodaTime;
using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	public class Caliper11EventTests {

		[Test]
		public void EventAnnotationBookmarked_MatchesReferenceJson() {

			var page = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
				Name = "IMS Caliper Implementation Guide, pg 5",
				Version = "1.1"
			};

			var annotation = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = page,
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities"
				+ " that facilitate learning.",
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var bookmarkEvent = new AnnotationEvent("urn:uuid:d4618c23-d612-4709-8d9a-478d87808067", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = page,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(bookmarkEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationBookmarked");
		}

		[Test]
		public void EventAnnotationHighlighted_MatchesReferenceJson() {

			var doc = new Document("https://example.com/#/texts/imscaliperimplguide") {
				Name = "IMS Caliper Implementation Guide",
				DateCreated = Caliper11TestEntities.Instant20161001060000,
				Version = "1.1"
			};

			var annotation = new HighlightAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/highlights?start=2300&end=2370") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				Selection = new TextPositionSelector {
					Start = 2300,
					End = 2370
				},
				SelectionText = "ISO 8601 formatted date and time expressed with millisecond precision.",
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var highlightEvent = new AnnotationEvent("urn:uuid:0067a052-9bb4-4b49-9d1a-87cd43da488a", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(highlightEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationHighlighted");
		}

		[Test]
		public void EventAnnotationShared_MatchesReferenceJson() {
			var doc = new Document("https://example.com/#/texts/imscaliperimplguide") {
				Name = "IMS Caliper Implementation Guide",
				Version = "1.1"
			};

			var annotation = new ShareAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/shares/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				WithAgents = new[] {
					new Person( "https://example.edu/users/657585" ) {
					},
					new Person( "https://example.edu/users/667788" ) {
					}
				},
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var shareEvent = new AnnotationEvent("urn:uuid:3bdab9e6-11cd-4a0f-9d09-8e363994176b", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(shareEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationShared");
		}

		[Test]
		public void EventAnnotationTagged_MatchesReferenceJson() {
			var doc = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
				Name = "IMS Caliper Implementation Guide, pg 5",
				Version = "1.1"
			};

			var annotation = new TagAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/tags/3") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				Tags = new[] { "profile", "event", "entity" },
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var tagEvent = new AnnotationEvent("urn:uuid:b2009c63-2659-4cd2-b71e-6e03c498f02b", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(tagEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationTagged");
		}

		[Test]
		public void EventAssessmentItemCompleted_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:e5891791-3d27-4df1-a272-091806a43dfb", Action.Completed) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
					Name = "Assessment Item 3",
					IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
					DateToStartOn = Caliper11TestEntities.Instant20161114050000, 
					DateToSubmit = Caliper11TestEntities.Instant20161118115959, 
					MaxAttempts = 2,
					MaxSubmits = 2,
					MaxScore = 1.0,
					IsTimeDependent = false,
					Version = "1.0"
						
				},
				Generated = new FillInBlankResponse(
					"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/responses/1") {
					Attempt = Caliper11TestEntities.Attempt1,
					DateCreated = Caliper11TestEntities.Instant20161115101512,
					StartedAtTime = Caliper11TestEntities.Instant20161115101502,
					EndedAtTime = Caliper11TestEntities.Instant20161115101512,
					Values = new[] { "subject", "object", "predicate" }
				},

				EventTime = Caliper11TestEntities.Instant20161115101512,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..attempt.assignee", "..attempt.isPartOf", "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemCompleted");
		}

		[Test]
		public void EventAssessmentItemSkipped_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:04e27704-73bf-4d3c-912c-1b2da40aef8f", Action.Skipped) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentItem2,
				EventTime = Caliper11TestEntities.Instant20161115101430,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemSkipped");
		}

		[Test]
		public void EventAssessmentItemStarted_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:1b557176-ba67-4624-b060-6bee670a3d8e", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentItem3b,
				Generated = Caliper11TestEntities.Attempt1b,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemStarted");
		}

		[Test]
		public void EventAssessmentStarted_MatchesReferenceJson() {

			var assessmentEvent = new AssessmentEvent(
				"urn:uuid:27734504-068d-4596-861c-2315be33a2a2", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentQuizOne,
				Generated = Caliper11TestEntities.Attempt1c,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};


			var coerced = JsonAssertions.coerce(assessmentEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentStarted");
		}

		[Test]
		public void EventAssessmentSubmitted_MatchesReferenceJson() {

			var assessmentEvent = new AssessmentEvent(
				"urn:uuid:dad88464-0c20-4a19-a1ba-ddf2f9c3ff33", Action.Submitted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentQuizOne,
				Generated = Caliper11TestEntities.Attempt2,
				EventTime = Caliper11TestEntities.Instant20161115102530,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentEvent,
				new string[] { "..generated.assignable", "..generated.assignee", "..membership.member", "..membership.organization",
							"..object.assignee" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentSubmitted");
		}

		[Test]
		public void EventAssignableActivated_MatchesReferenceJson() {
			var assignableEvent = new AssignableEvent(
				"urn:uuid:2635b9dd-0061-4059-ac61-2718ab366f75",  Action.Activated) {
				Actor = Caliper11TestEntities.Person112233,
				Object = Caliper11TestEntities.AssessmentQuizOneB,
				EventTime = Caliper11TestEntities.Instant20161112101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership112233Instructor,
				Session = Caliper11TestEntities.Session6259edu2
			};

			var coerced = JsonAssertions.coerce(assignableEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssignableActivated");
		}

		[Test]
		public void EventBasicCreated_MatchesReferenceJson() {
			var evnt = new Event("urn:uuid:3a648e68-f00d-4c08-aa59-8738e1884f2c") {
				Action =  Action.Created,
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.edu/terms/201601/courses/7/sections/1/resources/123") {
					Name = "Course Syllabus",
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					Version = "1"
				},
				EventTime = Caliper11TestEntities.Instant20161115101500
			};
			JsonAssertions.AssertSameObjectJson(evnt, "caliperEventBasicCreated");
		}

		[Test]
		public void EventBasicModifiedExtended_MatchesReferenceJson() {
			var evnt = new Event("urn:uuid:5973dcd9-3126-4dcc-8fd8-8153a155361c") {
				Action =  Action.Modified,
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.edu/terms/201601/courses/7/sections/1/resources/123") {
					Name = "Course Syllabus",
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					DateModified = Caliper11TestEntities.Instant20161115101500,
					Version = "2"
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Extensions = new[] { new ExtensionObject1() }

			};
			JsonAssertions.AssertSameObjectJson(evnt, "caliperEventBasicModifiedExtended");
		}

		class ExtensionObject1 {

			[JsonProperty("@context", Order = 90)]
			public object Context = new {
				id = "@id",
				type = "@type",
				example = "http://example.edu/ctx/edu/",
				//previousVersion = new { @id = "example:previousVersion", @type = "@id" }
				previousVersion = new previousVersionExtensionObject1()
			};

			[JsonProperty("previousVersion", DefaultValueHandling = DefaultValueHandling.Include, Order = 91)]
			public object previousVersion = new {
				id = "https://example.edu/terms/201601/courses/7/sections/1/resources/123?version=1",
				type = "Document"
			};
		}

		class previousVersionExtensionObject1 {
			[JsonProperty("@id", Order = 91)]
			public string id = "example:previousVersion";

			[JsonProperty("@type", Order = 92)]
			public string type = "@id";
		}



		[Test]
		public void EventForumSubscribed_MatchesReferenceJson() {
			var forumEvent = new ForumEvent(
				"urn:uuid:a2f41f9c-d57d-4400-b3fe-716b9026334e",  Action.Subscribed) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Forum1Caliper,
				EventTime = Caliper11TestEntities.Instant20161115101600,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(forumEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventForumSubscribed");
		}

		[Test]
		public void EventMediaPausedVideo_MatchesReferenceJson() {
			var mediaEvent = new MediaEvent(
				"urn:uuid:956b4a02-8de0-4991-b8c5-b6eebb6b4cab",  Action.Paused) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.VideoObject1,
				Target = Caliper11TestEntities.MediaLocation1,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = new SoftwareApplication("https://example.edu/player"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(mediaEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMediaPausedVideo");
		}

		[Test]
		public void EventMessagePosted_MatchesReferenceJson() {
			var messageEvent = new MessageEvent(
				"urn:uuid:0d015a85-abf5-49ee-abb1-46dbd57fe64e",  Action.Posted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Message2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(messageEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMessagePosted");
		}

		[Test]
		public void EventMessageReplied_MatchesReferenceJson() {
			var messageEvent = new MessageEvent(
				"urn:uuid:aed54386-a3fb-45ff-90f9-a35d3daaf031",  Action.Posted) {
				Actor = Caliper11TestEntities.Person778899,
				Object = Caliper11TestEntities.Message3,
				EventTime = Caliper11TestEntities.Instant20161115101530,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership778899Learner,
				Session = Caliper11TestEntities.SessionCd50
			};

			var coerced = JsonAssertions.coerce(messageEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMessageReplied");
		}

		[Test]
		public void EventNavigationNavigatedTo_MatchesReferenceJson() {
			var navEvent = new NavigationEvent(
				"urn:uuid:ff9ec22a-fc59-4ae1-ae8d-2c9463ee2f8f") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.WebPage2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(navEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventNavigationNavigatedTo");
		}

		[Test]
		public void EventNavigationNavigatedToFedSession_MatchesReferenceJson() {
			var navEvent = new NavigationEvent(
				"urn:uuid:4be6d29d-5728-44cd-8a8f-3d3f07e46b61") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub202,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/4"),
				EdApp = new SoftwareApplication("https://example.com"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session1241,
				FederatedSession = new LtiSession(
					"https://example.com/sessions/b533eb02823f31024e6b7f53436c42fb99b31241") {
					User = Caliper11TestEntities.Person554433,
					LaunchParameters = new Caliper11TestEntities.LtiParams(),
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAt = Caliper11TestEntities.Instant20161115101500
				}
			};

			var coerced = JsonAssertions.coerce(navEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..edApp", "..federatedSession.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventNavigationNavigatedToFedSession");
		}

		[Test]
		public void EventNavigationNavigatedToThinned_MatchesReferenceJson() {
			var navEvent = new NavigationEvent(
				"urn:uuid:71657137-8e6e-44f8-8499-e1c3df6810d2") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.WebPage2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(navEvent,
				new string[] { "..actor", "..object", "..referrer", "..edApp",
				"..group", "..membership", "..session" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventNavigationNavigatedToThinned");
		}

		[Test]
		public void EventOutcomeGraded_MatchesReferenceJson() {
			var outcomeEvent = Caliper11TestEntities.OutcomeEvent1;

			var coerced = JsonAssertions.coerce(outcomeEvent,
				new string[] { "..edApp", "..scoredBy", "..generated.attempt" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventOutcomeGraded");
		}

		[Test]
		public void EventOutcomeGradedItem_MatchesReferenceJson() {
			var outcomeEvent = new OutcomeEvent(
				"urn:uuid:12c05c4e-253f-4073-9f29-5786f3ff3f36",  Action.Graded) {

				Actor = Caliper11TestEntities.AutoGraderV2,
				Object = Caliper11TestEntities.Attempt1,
				EventTime = Caliper11TestEntities.Instant20161115105706,
				EdApp = new SoftwareApplication("https://example.edu"),
				Generated = Caliper11TestEntities.Result1b,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16
			};

			var coerced = JsonAssertions.coerce(outcomeEvent,
				new string[] { "..edApp", "..scoredBy", "..generated.attempt",
							"..object.isPartOf" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventOutcomeGradedItem");
		}

		[Test]
		public void EventSessionLoggedIn_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:fcd495d0-3740-4298-9bec-1154571dc211",  Action.LoggedIn) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259b
			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedIn");
		}

		[Test]
		public void EventSessionLoggedInExtended_MatchesReferenceJson() {

			var sessionEvent = new SessionEvent(
				"urn:uuid:4ec2c31e-3ec0-4fe1-a017-b81561b075d7",  Action.LoggedIn) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115201115,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259c,
				Extensions = new object[] { new Caliper11TestEntities.SessionExtension1(),
					new Caliper11TestEntities.SessionExtension2()  }
			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedInExtended");
		}

		[Test]
		public void EventSessionLoggedOut_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:a438f8ac-1da3-4d48-8c86-94a1b387e0f6",  Action.LoggedOut) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115110500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259d
			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedOut");
		}

		[Test]
		public void EventSessionTimedOut_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:4e61cf6c-ffbe-45bc-893f-afe7ad4079dc",  Action.TimedOut) {

				Actor = new SoftwareApplication("https://example.edu"),
				Object = new Session(
					"https://example.edu/sessions/7d6b88adf746f0692e2e873308b78c60fb13a864") {
					User = Caliper11TestEntities.Person112233,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAt = Caliper11TestEntities.Instant20161115101500,
					EndedAt = Caliper11TestEntities.Instant20161115111500,
					Duration = Period.FromSeconds(3600)

				},
				EventTime = Caliper11TestEntities.Instant20161115111500,
				EdApp = Caliper11TestEntities.SoftwareAppV2

			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionTimedOut");
		}

		[Test]
		public void EventThreadMarkedAsRead_MatchesReferenceJson() {
			var threadEvent = new ThreadEvent(
				"urn:uuid:6b20c5ba-301c-4e56-85a0-2f3d9a94c249",  Action.MarkedAsRead) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Thread1,
				EventTime = Caliper11TestEntities.Instant20161115101600,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(threadEvent,
				new string[] { "..membership.member", "..membership.organization" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventThreadMarkedAsRead");
		}

		[Test]
		public void EventToolUseUsed_MatchesReferenceJson() {
			var toolUseEvent = new ToolUseEvent(
				"urn:uuid:7e10e4f3-a0d8-4430-95bd-783ffae4d916",  Action.Used) {

				Actor = Caliper11TestEntities.Person554433,
				Object = new SoftwareApplication("https://example.edu"),
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(toolUseEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventToolUseUsed");
		}

		[Test]
		public void EventViewViewed_MatchesReferenceJson() {
			var viewEvent = new ViewEvent(
				"urn:uuid:cd088ca7-c044-405c-bb41-0b2a8506f907") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub201,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(viewEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventViewViewed");
		}

		[Test]
		public void EventViewViewedExtended_MatchesReferenceJson() {
			var viewEvent = new ViewEvent(
				"urn:uuid:3a9bd869-addc-48b1-80f6-a14b2ff591ed") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub200,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu,
				Extensions = new object[] { new Caliper11TestEntities.ViewExtension1() }
			};

			var coerced = JsonAssertions.coerce(viewEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });
			
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventViewViewedExtended");
		}


	}
}
