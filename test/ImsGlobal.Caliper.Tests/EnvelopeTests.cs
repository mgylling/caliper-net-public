using ImsGlobal.Caliper.Entities;
using ImsGlobal.Caliper.Entities.Agent;
using ImsGlobal.Caliper.Entities.Annotation;
using ImsGlobal.Caliper.Entities.Collection;
using ImsGlobal.Caliper.Entities.Lis;
using ImsGlobal.Caliper.Entities.Reading;
using ImsGlobal.Caliper.Events;
using ImsGlobal.Caliper.Events.Annotation;
using ImsGlobal.Caliper.Events.Assessment;
using ImsGlobal.Caliper.Events.Reading;
using ImsGlobal.Caliper.Protocol;
using ImsGlobal.Caliper.Tests.SimpleHelpers;
using ImsGlobal.Caliper.Util;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Entities.Assessment;
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Events.Outcome;
	using NodaTime;
	using static JsonSerializeUtils;

	[TestFixture]
	public class Caliper11EnvelopeTests {

		[Test]
		public void EnvelopeEntityBatch_MatchesReferenceJson() {

			var Person554433 = Caliper11TestEntities.Person554433dates;

			var Epub201 = new Document("https://example.edu/etexts/201.epub") {
				Name = "IMS Caliper Implementation Guide",
				Creators = new[] { new Person("https://example.edu/people/12345"),
					new Person("https://example.com/staff/56789") },
				DateCreated = Caliper11TestEntities.Instant20161001060000,
				Version = "1.1"
			};

			var VideoCollection = new DigitalResourceCollection(
				"https://example.edu/terms/201601/courses/7/sections/1/resources/2") {
				Name = "Video Collection",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				Items = new[] { Caliper11TestEntities.VideoObject_1, Caliper11TestEntities.VideoObject_2 },
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Caliper11TestEntities.Instant20160902113000
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(Person554433)),
					clean(toJobject(Epub201)),
					clean(toJobject(VideoCollection))
				}
			};

			JsonAssertions.AssertSameObjectJson(envelope, "caliperEnvelopeEntityBatch", false);
		}

		[Test]
		public void EnvelopeEntitySingle_MatchesReferenceJson() {

			var envelope = new CaliperMessage<Entity> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] { Caliper11EntityTests.DigitalResourceSyllabusPDF }
			};

			JsonAssertions.AssertSameObjectJson(envelope, "caliperEnvelopeEntitySingle");
		}


		[Test]
		public void EnvelopeEventBatch_MatchesReferenceJson() {

			var NavigationEvent = new NavigationEvent(
				"urn:uuid:72f66ce5-d2ec-44cc-bce5-41602e1015dc") {
				Actor = Caliper11TestEntities.Person554433,
				Object = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/2") {
					Name = "Learning Analytics Specifications",
					Description = "Overview of Learning Analytics Specifications with particular emphasis on IMS Caliper.",
					DateCreated = Caliper11TestEntities.Instant20160801090000
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var BookmarkAnnotation = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities that facilitate learning.",
				DateCreated = Caliper11TestEntities.Instant20161115102000

			};

			var AnnotationEvent = new AnnotationEvent(
				"urn:uuid:c0afa013-64df-453f-b0a6-50f3efbe4cc0", BookmarkAnnotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.com/#/texts/imscaliperimplguide") {
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				},
				EventTime = Caliper11TestEntities.Instant20161115102000,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259

			};

			var ViewEvent = new ViewEvent(
							"urn:uuid:94bad4bd-a7b1-4c3e-ade4-2253efe65172") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub201,
				EventTime = Caliper11TestEntities.Instant20161115102100,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(NavigationEvent)),
					clean(toJobject(AnnotationEvent)),
					clean(toJobject(ViewEvent))
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..membership.member", "..membership.organization",
					"..generated.annotator", "..generated.annotated" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeEventBatch", false);
		}


		[Test]
		public void EnvelopeEventSingle_MatchesReferenceJson() {

			var envelope = new CaliperMessage<Event> {
				SensorId = "https://example.edu/sensors/1",
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] { new AssessmentEvent(
					"urn:uuid:c51570e4-f8ed-4c18-bb3a-dfe51b2cc594", Action.Started) {
						Actor = Caliper11TestEntities.Person554433,
						Object = Caliper11TestEntities.AssessmentQuizOne,
						Generated = Caliper11TestEntities.Attempt1c,
						EventTime = Caliper11TestEntities.Instant20161115101500,
						EdApp = Caliper11TestEntities.SoftwareAppV2,
						Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
						Membership = Caliper11TestEntities.EntityMembership554433Learner,
						Session = Caliper11TestEntities.Session6259edu
					}
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeEventSingle");
		}


		[Test]
		public void EnvelopeMixedBatch_MatchesReferenceJson() {

			var Assessment = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0") {
				Name = "Quiz One",
				Items = new[] {
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1"),
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2"),
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateToStartOn = Caliper11TestEntities.Instant20160816050000,
				DateToSubmit = Caliper11TestEntities.Instant20160928115959,
				DateModified = Caliper11TestEntities.Instant20160902113000,
				DatePublished = Caliper11TestEntities.Instant20160815093000,
				DateToActivate = Caliper11TestEntities.Instant20160816050000,
				DateToShow = Caliper11TestEntities.Instant20160816050000,
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 15.0,
				Version = "1.0"
			};

			var CourseSection = new CourseSection
				("https://example.edu/terms/201601/courses/7/sections/1") {
				CourseNumber = "CPS 435-01",
				AcademicSession = "Fall 2016",
				Name = "CPS 435 Learning Analytics, Section 01",
				Category = "seminar",
				SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7") {
					CourseNumber = "CPS 435"
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000
			};

			var AssessmentEventStarted = new AssessmentEvent(
				"urn:uuid:c51570e4-f8ed-4c18-bb3a-dfe51b2cc594", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
				Generated = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAtTime = Caliper11TestEntities.Instant20161115101500
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var AssessmentEventSubmitted = new AssessmentEvent(
				"urn:uuid:dad88464-0c20-4a19-a1ba-ddf2f9c3ff33", Action.Submitted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAtTime = Caliper11TestEntities.Instant20161115101500,
					EndedAtTime = Caliper11TestEntities.Instant20161115102530,
					Duration = Period.FromMinutes(10) + Period.FromSeconds(30)
				},
				EventTime = Caliper11TestEntities.Instant20161115102530,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var OutcomeEvent = new OutcomeEvent(
						"urn:uuid:a50ca17f-5971-47bb-8fca-4e6e6879001d", Action.Graded) {
				Actor = Caliper11TestEntities.AutoGraderV2,
				Object = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115100500,
					StartedAtTime = Caliper11TestEntities.Instant20161115100500,
					EndedAtTime = Caliper11TestEntities.Instant20161115105512,
					Duration = Period.FromMinutes(50) + Period.FromSeconds(12)
				},
				Generated = Caliper11TestEntities.Result1,
				EventTime = Caliper11TestEntities.Instant20161115105706,
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(Caliper11TestEntities.Person554433dates)),
					clean(toJobject(Assessment)),
					clean(toJobject(Caliper11TestEntities.SoftwareAppV2)),
					clean(toJobject(CourseSection)),
					clean(toJobject(AssessmentEventStarted)),
					clean(toJobject(AssessmentEventSubmitted)),
					clean(toJobject(OutcomeEvent))
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..generated.assignable", "..generated.assignee",
				"..membership.member", "..membership.organization",
				"..edApp", "..group", "..object.assignable", "..object.assignee",
				"..generated.attempt", "..generated.scoredBy", "$.data[:6].actor", "$.data[:5].object"});
			
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeMixedBatch", false);
		}





	}
}