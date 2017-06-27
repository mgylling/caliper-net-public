using System;
using ImsGlobal.Caliper.Entities;
using ImsGlobal.Caliper.Entities.Agent;
using ImsGlobal.Caliper.Entities.Assessment;
using ImsGlobal.Caliper.Entities.Assignable;
using ImsGlobal.Caliper.Entities.Forum;
using ImsGlobal.Caliper.Entities.Lis;
using ImsGlobal.Caliper.Entities.Media;
using ImsGlobal.Caliper.Entities.Outcome;
using ImsGlobal.Caliper.Entities.Reading;
using ImsGlobal.Caliper.Entities.Session;
using ImsGlobal.Caliper.Events.Outcome;
using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Tests {

	internal static class Caliper11TestEntities {

		public static Instant EnvelopeDefaultSendTime = Instant.FromUtc(2016, 11, 15, 11, 05, 01);

		public static string EnvelopeDefaultSensorId = "https://example.edu/sensors/1";

		public static Instant Instant20160801060000 = Instant.FromUtc(2016, 08, 01, 06, 00, 00);
		public static Instant Instant20160902113000 = Instant.FromUtc(2016, 09, 02, 11, 30, 00);
		public static Instant Instant20161001060000 = Instant.FromUtc(2016, 10, 01, 06, 00, 00);
		public static Instant Instant20161112100000 = Instant.FromUtc(2016, 11, 12, 10, 00, 00);
		public static Instant Instant20161112101500 = Instant.FromUtc(2016, 11, 12, 10, 15, 00);
		public static Instant Instant20161112101000 = Instant.FromUtc(2016, 11, 12, 10, 10, 00);
		public static Instant Instant20161115101500 = Instant.FromUtc(2016, 11, 15, 10, 15, 00);
		public static Instant Instant20161115101530 = Instant.FromUtc(2016, 11, 15, 10, 15, 30);
		public static Instant Instant20161115100000 = Instant.FromUtc(2016, 11, 15, 10, 00, 00);
		public static Instant Instant20161115101512 = Instant.FromUtc(2016, 11, 15, 10, 15, 12);
		public static Instant Instant20161115101502 = Instant.FromUtc(2016, 11, 15, 10, 15, 02);
		public static Instant Instant20161114050000 = Instant.FromUtc(2016, 11, 14, 05, 00, 00);
		public static Instant Instant20161115101430 = Instant.FromUtc(2016, 11, 15, 10, 14, 30);
		public static Instant Instant20161115102530 = Instant.FromUtc(2016, 11, 15, 10, 25, 30);
		public static Instant Instant20161118115959 = Instant.FromUtc(2016, 11, 18, 11, 59, 59);
		public static Instant Instant20161112071500 = Instant.FromUtc(2016, 11, 12, 07, 15, 00);
		public static Instant Instant20161113110000 = Instant.FromUtc(2016, 11, 13, 11, 00, 00);
		public static Instant Instant20160914110000 = Instant.FromUtc(2016, 09, 14, 11, 00, 00);
		public static Instant Instant20161115101600 = Instant.FromUtc(2016, 11, 15, 10, 16, 00);
		public static Instant Instant20161115101200 = Instant.FromUtc(2016, 11, 15, 10, 12, 00);
		public static Instant Instant20160801090000 = Instant.FromUtc(2016, 08, 01, 09, 00, 00);
		public static Instant Instant20161115105706 = Instant.FromUtc(2016, 11, 15, 10, 57, 06);
		public static Instant Instant20161115105505 = Instant.FromUtc(2016, 11, 15, 10, 55, 05);
		public static Instant Instant20161115100500 = Instant.FromUtc(2016, 11, 15, 10, 05, 00);
		public static Instant Instant20161115105512 = Instant.FromUtc(2016, 11, 15, 10, 55, 12);
		public static Instant Instant20161115201115 = Instant.FromUtc(2016, 11, 15, 20, 11, 15);
		public static Instant Instant20161115111500 = Instant.FromUtc(2016, 11, 15, 11, 15, 00);
		public static Instant Instant20161115110500 = Instant.FromUtc(2016, 11, 15, 11, 05, 00);
		public static Instant Instant20161115102000 = Instant.FromUtc(2016, 11, 15, 10, 20, 00);
		public static Instant Instant20161115102100 = Instant.FromUtc(2016, 11, 15, 10, 21, 00);
		public static Instant Instant20160815093000 = Instant.FromUtc(2016, 08, 15, 09, 30, 00);
		public static Instant Instant20160816050000 = Instant.FromUtc(2016, 08, 16, 05, 00, 00);
		public static Instant Instant20160928115959 = Instant.FromUtc(2016, 09, 28, 11, 59, 59);
		public static Instant Instant20161115105600 = Instant.FromUtc(2016, 11, 15, 10, 56, 00);

		public static Person Person778899 = new Person("https://example.edu/users/778899");
		public static Person Person554433 = new Person("https://example.edu/users/554433");
		public static Person Person112233 = new Person("https://example.edu/users/112233");
		public static Person Person554433dates = new Person("https://example.edu/users/554433") {
			DateCreated = Instant20160801060000,
			DateModified = Instant20160902113000
		};


		public static Membership EntityMembership554433Learner = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/554433"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Learner },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

		public static Membership EntityMembership778899Learner = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/778899"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Learner },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

		public static Membership EntityMembership112233Instructor = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/112233"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Instructor },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

		public static CourseSection CourseSectionCPS43501Fall16 = new CourseSection
			("https://example.edu/terms/201601/courses/7/sections/1") {
			CourseNumber = "CPS 435-01",
			AcademicSession = "Fall 2016"
		};

		public static Session Session6259 = new Session("https://example.com/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000
		};

		public static Session Session6259b = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000,
			DateCreated = Instant20161115100000,
			User = Person554433
		};

		public static Session Session6259c = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115201115,
			DateCreated = Instant20161115201115,
			User = Person554433
		};

		public static Session Session6259d = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000,
			DateCreated = Instant20161115100000,
			EndedAt = Instant20161115110500,
			User = Person554433,
			Duration = Period.FromSeconds(3000)
		};


		public static Session Session6259edu = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000
		};

		public static Session Session6259edu2 = new Session("https://example.edu/sessions/f095bbd391ea4a5dd639724a40b606e98a631823") {
			StartedAt = Instant20161112100000
		};

		public static Session SessionCd50 = new Session("https://example.edu/sessions/1d6fa9adf16f4892650e4305f6cf16610905cd50") {
			StartedAt = Instant20161115101200
		};

		public static Session Session1241 = new Session("https://example.com/sessions/c25fd3da-87fa-45f5-8875-b682113fa5ee") {
			StartedAt = Instant20161115100000
		};


		public static SoftwareApplication EpubReader123 = new SoftwareApplication("https://example.com/reader") {
			Name = "ePub Reader",
			Version = "1.2.3"
		};

		public static SoftwareApplication SoftwareAppV2 = new SoftwareApplication("https://example.edu") {
			Version = "v2"
		};

		public static SoftwareApplication ForumAppV2 = new SoftwareApplication("https://example.edu/forums") {
			Version = "v2"
		};

		public static AssessmentItem AssessmentItem2 = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2") {
			Name = "Assessment Item 2",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 1.0,
			IsTimeDependent = false,
			Version = "1.0"
		};

		public static AssessmentItem AssessmentItem3 = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
			Name = "Assessment Item 3",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
		};

		public static AssessmentItem AssessmentItem3b = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
			Name = "Assessment Item 3",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 1.0,
			IsTimeDependent = false,
			Version = "1.0"
		};

		public static Assessment AssessmentQuizOne = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
			Name = "Quiz One",
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 25.0,
			Version = "1.0"
		};

		public static Assessment AssessmentQuizOneB = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
			Name = "Quiz One",
			DateCreated = Instant20160801060000,
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			DateModified = Instant20160902113000,
			DatePublished = Instant20161112101000,
			DateToActivate = Instant20161112101500,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 25.0,
			Version = "1.0"
		};

		public static Attempt Attempt1 = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentItem3,
			IsPartOf = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			Count = 1,
			DateCreated = Instant20161115101502,
			StartedAtTime = Instant20161115101502,
			EndedAtTime = Instant20161115101512
		};

		public static Attempt Attempt2 = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentQuizOne,
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500,
			EndedAtTime = Instant20161115102530,
			Duration = Period.FromMinutes(10) + Period.FromSeconds(30)
		};

		public static Attempt Attempt1b = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentItem3,
			IsPartOf = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500
		};

		public static Attempt Attempt1c = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500
		};

		public static Attempt Attempt1d = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			Count = 1,
			DateCreated = Instant20161115100500,
			StartedAtTime = Instant20161115100500,
			EndedAtTime = Instant20161115105512,
			Duration = Period.FromMinutes(50) + Period.FromSeconds(12)

		};

		public static SoftwareApplication AutoGraderV2 = new SoftwareApplication(
			"https://example.edu/autograder") {
			Version = "v2"
		};

		public static Result Result1 = new Result(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/results/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxResultScore = 15.0,
			ResultScore = 10.0,
			ScoredBy = AutoGraderV2,
			Comment = "Consider retaking the assessment.",
			DateCreated = Instant20161115105505
		};

		public static Score Score1 = new Score(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1/scores/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxScore = 15.0,
			ScoreGiven = 10.0,
			ScoredBy = AutoGraderV2,
			Comment = "auto-graded exam",
			DateCreated = Instant20161115105600		
		};

		public readonly static GradeEvent GradeEvent1 = new GradeEvent(
						"urn:uuid:a50ca17f-5971-47bb-8fca-4e6e6879001d", Events.Action.Graded) {
			Actor = AutoGraderV2,
			Object = Attempt1d,
			Generated = Score1,
			EventTime = Instant20161115105706,
			EdApp = new SoftwareApplication("https://example.edu"),
			Group = CourseSectionCPS43501Fall16
		};

		public static Forum Forum1Caliper = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
			Name = "Caliper Forum",
			IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1"),
			DateCreated = Instant20160914110000
		};

		public static VideoObject VideoObject1 = new VideoObject("https://example.edu/UQVK-dsU7-Y") {
			Name = "Information and Welcome",
			MediaType = "video/ogg",
			Duration = Period.FromMinutes(20) + Period.FromSeconds(20)
		};

		public static MediaLocation MediaLocation1 = new MediaLocation("https://example.edu/UQVK-dsU7-Y?t=321") {
			CurrentTime = Period.FromMinutes(05) + Period.FromSeconds(21)
		};

		public static Message Message2 = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2") {
			Creators = new[] { Person554433 },
			Body = "Are the Caliper Sensor reference implementations production-ready?",
			IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
				Name = "Caliper Adoption",
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2") {
					Name = "Caliper Forum"
				}
			},
			DateCreated = Instant20161115101500

		};

		public static Message Message3 = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/3") {
			Creators = new[] { new Person("https://example.edu/users/778899") },
			ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2"),
			IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2")
			},
			DateCreated = Instant20161115101530
		};

		public static WebPage WebPage2 = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/2") {
			Name = "Learning Analytics Specifications",
			Description = "Overview of Learning Analytics Specifications with particular emphasis on IMS Caliper.",
			DateCreated = Instant20160801090000
		};

		public static Document Epub202 = new Document("https://example.com/lti/reader/202.epub") {
			Name = "Caliper Case Studies",
			MediaType = "application/epub+zip",
			DateCreated = Instant20160801090000
		};

		public static Document Epub201 = new Document("https://example.edu/etexts/201.epub") {
			Name = "IMS Caliper Implementation Guide",
			DateCreated = Instant20160801060000,
			DatePublished = Instant20161001060000,
			Version = "1.1"
		};

		public static Document Epub200 = new Document("https://example.edu/etexts/200.epub") {
			Name = "IMS Caliper Specification",
			Version = "1.1"
		};

		public static Result Result1b = new Result(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/results/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1"),
			ResultScore = 1.0,
			MaxResultScore = 1.0,
			ScoredBy = new SoftwareApplication("https://example.edu/autograder"),
			DateCreated = Instant20161115105505
		};

		public static Score Score1b = new Score(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1/scores/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxScore = 5.0,
			ScoreGiven = 5.0,
			ScoredBy = new SoftwareApplication("https://example.edu/autograder"),
			Comment = "auto-graded exam",
			DateCreated = Instant20161115105505		
		};

		public static Thread Thread1 = new Thread(
			"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1") {
			Name = "Caliper Information Model",
			IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
				Name = "Caliper Forum",
				DateCreated = Instant20161115101500
			},
			DateCreated = Instant20161115101600
		};

		public static VideoObject VideoObject_1 = new VideoObject("https://example.edu/videos/1225") {
			MediaType = "video/ogg",
			Name = "Introduction to IMS Caliper",
			DateCreated = Instant20160801060000,
			Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27),
			Version = "1.1"
		};


		public static VideoObject VideoObject_2 = new VideoObject("https://example.edu/videos/5629") {
			MediaType = "video/ogg",
			Name = "IMS Caliper Activity Profiles",
			DateCreated = Instant20160801060000,
			Duration = Period.FromMinutes(55) + Period.FromSeconds(13),
			Version = "1.1.1"
		};

		public class LtiParams {

			public string lti_message_type = "basic-lti-launch-request";

			public string lti_version = "LTI-2p0";

			public string resource_link_id = "88391-e1919-bb3456";

			public string context_id = "8213060-006f-27b2066ac545";

			public string launch_presentation_document_target = "iframe";

			public int launch_presentation_height = 240;

			public string launch_presentation_return_url = "https://example.edu/terms/201601/courses/7/sections/1/pages/5";

			public int launch_presentation_width = 320;

			public string roles = "Learner,Student";

			public string tool_consumer_instance_guid = "example.edu";

			public string user_id = "0ae836b9-7fc9-4060-006f-27b2066ac545";

			public string context_type = "CourseSection";

			public string launch_presentation_locale = "en-US";

			public string launch_presentation_css_url = "https://example.edu/css/tool.css";

			public string role_scope_mentor = "f5b2cc6c-8c5c-24e8-75cc-fac5,dc19e42c-b0fe-68b8-167e-4b1a";

			public string custom_caliper_session_id = "https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259";

			public string custom_context_title = "CPS 435 Learning Analytics";

			public string custom_context_label = "CPS 435";

			public string custom_resource_link_title = "LTI tool";

			public string custom_user_image = "https://example.edu/users/554433/profile/avatar.jpg";

			public object ext_vnd_instructor = new LtiExtClass();

		}

		class LtiExtClass {

			[JsonProperty("@context")]
			public object context = new {				
				sdo = "http://schema.org/",
				xsd = "http://www.w3.org/2001/XMLSchema#",
				jobTitle = new JobTitleClass(),
				givenName = new GivenNameClass(),
				familyName = new FamilyNameClass(),
				email = new EmailClass(),
				url = new UrlClass()
			};
			public string id = "https://example.edu/faculty/trighaversine";
			public string type = "Person";
			public string jobTitle = "Professor";
			public string givenName = "Trig";
			public string familyName = "Haversine";
			public string email = "trighaversine@example.edu";
			public string url = "https://example.edu/faculty/trighaversine";
		}

		class JobTitleClass {
			[JsonProperty("@id")]
			public string Id = "sdo:jobTitle";

			[JsonProperty("@type")]
			public string Type = "xsd:string";
		}	

		class GivenNameClass {
			[JsonProperty("@id")]
			public string Id = "sdo:givenName";

			[JsonProperty("@type")]
			public string Type = "xsd:string";
		}

		class FamilyNameClass {
			[JsonProperty("@id")]
			public string Id = "sdo:familyName";

			[JsonProperty("@type")]
			public string Type = "xsd:string";
		}

		class EmailClass {
			[JsonProperty("@id")]
			public string Id = "sdo:email";

			[JsonProperty("@type")]
			public string Type = "xsd:string";
		}

		class UrlClass {
			[JsonProperty("@id")]
			public string Id = "sdo:url";

			[JsonProperty("@type")]
			public string Type = "xsd:string";
		}
/*
		public class SessionExtension1 {
			public string requestId = "d71016dc-ed2f-46f9-ac2c-b93f15f38fdc";
			public string hostname = "example.com";
			public string userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36";
		}

		public class SessionExtension2 {
			[JsonProperty("@context")]
			public object context = new {
				id = "@id",
				type = "@type",
				sdo = "http://schema.org",
				xsd = "http://www.w3.org/2001/XMLSchema#",
				GeoCoordinates = "sdo:GeoCoordinates",
				latitude = new { id = "sdo:latitude", type = "xsd:decimal" },
				longitude = new { id = "sdo:longitude", type = "xsd:decimal" }
			};
			public string id = "https://example.com/maps/@42.27611,-83.73778,19z";
			public string type = "GeoCoordinates";
			public double latitude = 42.2761100;
			public double longitude = -83.7377800;

		}

		public class ViewExtension1 {
			[JsonProperty("@context")]
			public object context = new {
				id = "@id",
				type = "@type",
				example = "http://example.edu/ctx/edu",
				xsd = "http://www.w3.org/2001/XMLSchema#",
				ChronJob = "example:ChronJob",
				job = "example:job",
				jobTag = new { id = "example:jobTag", type = "xsd:string" },
				jobDate = new { id = "example:jobDate", type = "xsd:dateTime" }
			};

			public object job = new {
				id = "https://example.edu/data/jobs/08c1233d-9ba3-40ac-952f-004c47a50ff7",
				type = "ChronJob",
				jobTag = "caliper",
				jobDate = "2016-11-16T01:01:00.000Z"
			};

		}
*/


	};

}
