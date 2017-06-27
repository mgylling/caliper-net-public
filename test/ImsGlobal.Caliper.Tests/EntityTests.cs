
using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using System;
	using ImsGlobal.Caliper.Entities;
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Annotation;
	using ImsGlobal.Caliper.Entities.Assessment;
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Collection;
	using ImsGlobal.Caliper.Entities.Forum;
	using ImsGlobal.Caliper.Entities.Lis;
	using ImsGlobal.Caliper.Entities.Media;
	using ImsGlobal.Caliper.Entities.Outcome;
	using ImsGlobal.Caliper.Entities.Reading;
	using ImsGlobal.Caliper.Entities.Response;
	using ImsGlobal.Caliper.Entities.Session;
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using Newtonsoft.Json;
	using NodaTime;

	[TestFixture]
	public class Caliper11EntityTests {

		[Test]
		public void EntityAssessment_MatchesReferenceJson() {

			string itemUrlBase = "https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/";

			var entity = new Assessment(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
				Name = "Quiz One",
				Items = new[] {
					new AssessmentItem( itemUrlBase + "1" ),
					new AssessmentItem( itemUrlBase + "2" ),
					new AssessmentItem( itemUrlBase + "3" )
				},
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0),
				DateModified = Instant.FromUtc(2016, 9, 2, 11, 30, 0),
				DatePublished = Instant.FromUtc(2016, 8, 15, 9, 30, 0),
				DateToActivate = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToShow = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToStartOn = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToSubmit = Instant.FromUtc(2016, 9, 28, 11, 59, 59),
				MaxAttempts = 2,
				MaxScore = 15.0, //TODO is set as int in spec
				MaxSubmits = 2,
				Version = "1.0"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssessment");
		}

		[Test]
		public void EntityAssessmentItemExtended_MatchesReferenceJson() {

			var entity = new AssessmentItem(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {

				IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0),
				DatePublished = Instant.FromUtc(2016, 8, 15, 9, 30, 0),
				IsTimeDependent = false,
				MaxScore = 1.0,
				MaxSubmits = 2,
				Extensions = new ExtensionObject()
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssessmentItemExtended");
		}

		class ExtensionObject {
			[JsonProperty("questionType", Order = 91)]
			public string QuestionType = "Dichotomous";

			[JsonProperty("questionText", Order = 92)]
			public string QuestionText = "Is a Caliper SoftwareApplication a subtype of Caliper Agent?";

			[JsonProperty("correctResponse", Order = 93)]
			public string CorrectResponse = "yes";
		}			
/*
		class ExtensionObject {

			[JsonProperty("@context", Order = 90)]
			public object Context = new {
				id = "@id",
				type = "@type",
				example = "http://example.edu/ctx/edu",
				xsd = "http://www.w3.org/2001/XMLSchema#",
				itemType = new { id = "example:itemType", type = "xsd:string" },
				itemText = new { id = "example:itemText", type = "xsd:string" },
				itemCorrectResponse = new { id = "example:itemCorrectResponse", type = "xsd:boolean" }
			};

			[JsonProperty("itemType", Order = 91)]
			public string ItemType = "true/false";

			[JsonProperty("itemText", Order = 92)]
			public string ItemText = "In Caliper event actors are limited to people only.";

			[JsonProperty("itemCorrectResponse", DefaultValueHandling = DefaultValueHandling.Include, Order = 93)]
			public bool ItemCorrectResponse;

		}

*/
		[Test]
		public void EntityAssignableDigitalResource_MatchesReferenceJson() {

			var entity = new AssignableDigitalResource(
				"https://example.edu/terms/201601/courses/7/sections/1/assign/2") {

				Name = "Week 9 Reflection",
				Description = "3-5 page reflection on this week's assigned readings.",
				DateCreated = Instant.FromUtc(2016, 11, 1, 06, 0, 0),
				DateToActivate = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToShow = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToStartOn = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToSubmit = Instant.FromUtc(2016, 11, 14, 11, 59, 59),
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 50.0
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssignableDigitalResource");
		}

		[Test]
		public void EntityAttempt_MatchesReferenceJson() {

			var entity = new Attempt(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {

				Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
				Assignee = new Person("https://example.edu/users/554433"),
				Count = 1,
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 55, 30),
				Duration = Period.FromMinutes(50) + Period.FromSeconds(30)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAttempt");
		}

		[Test]
		public void EntityAudioObject_MatchesReferenceJson() {

			var entity = new AudioObject(
				"https://example.edu/audio/765") {
				Name = "Audio Recording: IMS Caliper Sensor API Q&A.",
				MediaType = "audio/ogg",
				DatePublished = Instant.FromUtc(2016, 12, 01, 06, 00, 00),
				Duration = Period.FromMinutes(55) + Period.FromSeconds(13)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAudioObject");
		}

		[Test]
		public void EntityBookmarkAnnotation_MatchesReferenceJson() {

			var entity = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities that facilitate learning.",
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityBookmarkAnnotation");
		}

		[Test]
		public void EntityChapter_MatchesReferenceJson() {

			var entity = new Chapter(
				"https://example.com/#/texts/imscaliperimplguide/cfi/6/10") {
				Name = "The Caliper Information Model",
				IsPartOf = new Document("https://example.com/#/texts/imscaliperimplguide") {
					DateCreated = Instant.FromUtc(2016, 10, 01, 6, 00, 00),
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				}
			};
			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityChapter");
		}


		[Test]
		public void EntityCourseOffering_MatchesReferenceJson() {

			var entity = new CourseOffering(
					"https://example.edu/terms/201601/courses/7") {
				CourseNumber = "CPS 435",
				AcademicSession = "Fall 2016",
				Name = "CPS 435 Learning Analytics",
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityCourseOffering");
		}

		[Test]
		public void EntityCourseSection_MatchesReferenceJson() {

			var entity = new CourseSection(
					"https://example.edu/terms/201601/courses/7/sections/1") {
				AcademicSession = "Fall 2016",
				CourseNumber = "CPS 435-01",
				Name = "CPS 435 Learning Analytics, Section 01",
				Category = "seminar",
				SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7") {
					CourseNumber = "CPS 435"
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityCourseSection");
		}

		[Test]
		public void EntityDigitalResource_MatchesReferenceJson() {

			var entity = DigitalResourceSyllabusPDF;

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDigitalResource");
		}


		public static DigitalResource DigitalResourceSyllabusPDF = new DigitalResource(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/1/syllabus.pdf") {
			Name = "Course Syllabus",
			MediaType = "application/pdf",
			Creators = new[] { new Person("https://example.edu/users/223344") },
			IsPartOf = new DigitalResourceCollection(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/1") {
				Name = "Course Assets",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1")
			},
			DateCreated = Instant.FromUtc(2016, 08, 02, 11, 32, 00)
		};

		[Test]
		public void EntityDigitalResourceCollection_MatchesReferenceJson() {

			var entity = new DigitalResourceCollection(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/2") {
				Name = "Video Collection",
				Keywords = new[] { "collection", "videos" },
				Items = new[] {
					new VideoObject("https://example.edu/videos/1225"){
						MediaType = "video/ogg",
						Name = "Introduction to IMS Caliper",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00),
						Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27),
						Version = "1.1"
					},
					new VideoObject("https://example.edu/videos/5629"){
						MediaType = "video/ogg",
						Name = "IMS Caliper Activity Profiles",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00),
						Duration = Period.FromMinutes(55) + Period.FromSeconds(13),
						Version = "1.1.1"
					}
				},
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDigitalResourceCollection");
		}

		[Test]
		public void EntityDocument_MatchesReferenceJson() {

			var entity = new Document(
					"https://example.edu/etexts/201.epub") {
				Name = "IMS Caliper Implementation Guide",
				MediaType = "application/epub+zip",
				Creators = new[] {
					new Person("https://example.edu/people/12345"),
					new Person("https://example.com/staff/56789")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DatePublished = Instant.FromUtc(2016, 10, 01, 06, 00, 00),
				Version = "1.1"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDocument");
		}


		[Test]
		public void EntityFillInBlankResponse_MatchesReferenceJson() {

			var entity = new FillInBlankResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 02),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 12)
				},

				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 12),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 02),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 12),
				Values = new[] { "data interoperability", "semantic interoperability" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityFillinBlankResponse");
		}


		[Test]
		public void EntityForum_MatchesReferenceJson() {

			var entity = new Forum(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
				Name = "Caliper Forum",
				Items = new[] {
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1"){
						Name = "Caliper Information Model",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					},
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/2"){
						Name = "Caliper Sensor API",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					},
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/3"){
						Name = "Caliper Certification",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					}
				},
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") { 
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},

				DateCreated = Instant.FromUtc(2016, 08, 01, 6, 0, 0),
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityForum");
		}

		[Test]
		public void EntityFrame_MatchesReferenceJson() {

			var entity = new Frame(
				"https://example.edu/etexts/201?index=2502") {
				DateCreated = Instant.FromUtc(2016, 08, 01, 6, 0, 0),
				Index = 2502,
				IsPartOf = new Document("https://example.edu/etexts/201") {
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityFrame");
		}


		//caliperEntityGroup
		//caliperEntityHighlightAnnotation





		[Test]
		public void EntityImageObject_MatchesReferenceJson() {

			var entity = new ImageObject(
				"https://example.edu/images/caliper_lti.jpg") {
				Name = "IMS Caliper/LTI Integration Work Flow",
				MediaType = "image/jpeg",
				DateCreated = Instant.FromUtc(2016, 09, 01, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityImageObject");
		}


		[Test]
		public void EntityLearningObjective_MatchesReferenceJson() {

			var entity = new AssignableDigitalResource(
				"https://example.edu/terms/201601/courses/7/sections/1/assign/2") {
				Name = "Caliper Profile Design",
				Description = "Choose a learning activity and describe the actions, entities and events that comprise it.",
				LearningObjectives = new[] {
					new LearningObjective("https://example.edu/terms/201601/courses/7/sections/1/objectives/1") {
						Name = "Research techniques",
						Description = "Demonstrate ability to model a learning activity as a Caliper profile.",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00)
					}
				},

				DateToActivate = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToShow = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateCreated = Instant.FromUtc(2016, 11, 01, 06, 00, 00),
				DateToStartOn = Instant.FromUtc(2016, 11, 15, 11, 59, 59),
				DateToSubmit = Instant.FromUtc(2016, 11, 14, 11, 59, 59),
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 50.0
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityLearningObjective");
		}

		[Test]
		public void EntityLtiSession_MatchesReferenceJson() {

			var entity = new LtiSession(
				"https://example.com/sessions/b533eb02823f31024e6b7f53436c42fb99b31241") {
				User = new Person("https://example.edu/users/554433"),
				LaunchParameters = new Caliper11TestEntities.LtiParams(),
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 00),
				StartedAt = Instant.FromUtc(2016, 11, 15, 10, 15, 00)

			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityLtiSession");
		}



		[Test]
		public void EntityMediaLocation_MatchesReferenceJson() {

			var entity = new MediaLocation(
				"https://example.edu/videos/1225") {
				CurrentTime = Period.FromMinutes(30) + Period.FromSeconds(54),
				DateCreated = Instant.FromUtc(2016, 08, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMediaLocation");
		}

		[Test]
		public void EntityMembership_MatchesReferenceJson() {

			var entity = new Membership(
				"https://example.edu/terms/201601/courses/7/sections/1/rosters/1/members/554433") {
				Member = new Person("https://example.edu/users/554433"),
				Organization = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				Roles = new[] { Role.Learner },
				Status = Status.Active,
				DateCreated = Instant.FromUtc(2016, 11, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMembership");
		}


		[Test]
		public void EntityMessage_MatchesReferenceJson() {

			var entity = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/3") {
				Creators = new[] { new Person("https://example.edu/users/778899") },
				Body = "The Caliper working group provides a set of Caliper Sensor reference implementations for"
					+ " the purposes of education and experimentation.  They have not been tested for use in a "
					+ "production environment.  See the Caliper Implementation Guide for more details.",
				ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2"),
				IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
					IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2")
				},	
				Attachments = new[] { new Document("https://example.edu/etexts/201.epub") { 
						Name = "IMS Caliper Implementation Guide",
						DateCreated = Instant.FromUtc(2016,10,01,06,00,00),
      					Version = "1.1"
					} 
				},
				DateCreated = Instant.FromUtc(2016,11,15,10,15,30)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMessage");

		}

		[Test]
		public void EntityMultipleChoiceResponse_MatchesReferenceJson() {

			var entity = new MultipleChoiceResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2/users/554433/responses/1") {

				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2/users/554433/attempts/1") { 
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2") { 
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016,11,15,10,15,14),
					EndedAtTime = Instant.FromUtc(2016,11,15,10,15,20)

				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 20),
				StartedAtTime = Instant.FromUtc(2016,11,15,10,15,14),
				EndedAtTime = Instant.FromUtc(2016,11,15,10,15,20),
				Value = "C"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMultipleChoiceResponse");
		}

		[Test]
		public void EntityMultipleResponseResponse_MatchesReferenceJson() {

			var entity = new MultipleResponseResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/responses/1") {


				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 30)

				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 30),
				Values = new[] { "A", "D", "E" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMultipleResponseResponse");
		}

		[Test]
		public void EntityOrganization_MatchesReferenceJson() {

			var entity = new Organization(
							"https://example.edu/colleges/1/depts/1") {
				Name = "Computer Science Department",
				SubOrganizationOf = new Organization("https://example.edu/colleges/1") {
					Name = "College of Engineering"
				}		
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityOrganization");
		}


		[Test]
		public void EntityPage_MatchesReferenceJson() {

			var entity = new Page(
				"https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
					Name = "Page 5",
					IsPartOf = new Chapter("https://example.com/#/texts/imscaliperimplguide/cfi/6/10") { 
						Name = "Chapter 1",
						IsPartOf = new Document("https://example.com/#/texts/imscaliperimplguide") {
							Name = "IMS Caliper Implementation Guide",
							DateCreated = Instant.FromUtc(2016, 10, 01, 06, 00, 00),
							Version = "1.1"
							                     
						}	
					}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityPage");
		}


		[Test]
		public void EntityPerson_MatchesReferenceJson() {

			var entity = new Person(
				"https://example.edu/users/554433") {
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityPerson");
		}

		[Test]
		public void EntityResult_MatchesReferenceJson() {

			var entity = new Result(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1/results/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
					Count = 1,
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 55, 30),
					Duration = Period.FromMinutes(50) + Period.FromSeconds(30)

				},
				Comment = "Consider retaking the assessment.",
				MaxResultScore = 15.0,
				ResultScore = 10.0,
				/*
				NormalScore = 15.0,
				PenaltyScore = 0.0,
				TotalScore = 15.0, */
				ScoredBy = new SoftwareApplication("https://example.edu/autograder") {
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 55, 58)
				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 56, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityResult");
		}

		[Test]
		public void EntitySelectTextResponse_MatchesReferenceJson() {

			var entity = new SelectTextResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 38)
				},

				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 38),
				Values = new[] { "Information Model", "Sensor API", "Profiles" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySelectTextResponse");
		}


		[Test]
		public void EntitySession_MatchesReferenceJson() {

			var entity = new Session(
				"https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
				User = new Person("https://example.edu/users/554433"),
				StartedAt = Instant.FromUtc(2016, 9, 15, 10, 00, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySession");
		}

		[Test]
		public void EntitySharedAnnotation_MatchesReferenceJson() {

			var entity = new ShareAnnotation(
				"https://example.edu/users/554433/etexts/201/shares/1") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Document("https://example.edu/etexts/201.epub"),
				WithAgents = new[] {
					new Person("https://example.edu/users/657585"),
					new Person("https://example.edu/users/667788")
				},
				DateCreated = Instant.FromUtc(2016, 08, 01, 9, 00, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySharedAnnotation");
		}

		[Test]
		public void EntitySoftwareApplication_MatchesReferenceJson() {

			var entity = new SoftwareApplication(
				"https://example.edu/autograder") {
				Name = "Auto Grader",
				Description = "Automates assignment scoring.",
				Version = "2.5.2"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySoftwareApplication");
		}

		[Test]
		public void EntityTagAnnotation_MatchesReferenceJson() {

			var entity = new TagAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/tags/3") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				Tags = new[]{"profile", "event", "entity"},
				DateCreated = Instant.FromUtc(2016, 08, 01, 9, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityTagAnnotation");
		}

		[Test]
		public void EntityThread_MatchesReferenceJson() {

			var msg1 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/1");
			var msg2 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/2") { ReplyTo = msg1 };
			var msg3 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/3") { 
				ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/2")};

			var entity = new Thread(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1") {
				Name = "Caliper Information Model",
				Items = new[] { msg1, msg2, msg3 },
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") { 
					Name = "Caliper Forum",
					IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") { 
						SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
					}
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityThread");
		}

		[Test]
		public void EntityTrueFalseResponse_MatchesReferenceJson() {

			var entity = new TrueFalseResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 40),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 45)
				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 45),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 40),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 45),
				Value = "true"

			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityTrueFalseResponse");
		}


		[Test]
		public void EntityVideoObject_MatchesReferenceJson() {

			var entity = new VideoObject(
				"https://example.edu/videos/1225") {
				MediaType = "video/ogg",
				Name = "Introduction to IMS Caliper",
				Version = "1.1",
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00),
				Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27)
				                     
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityVideoObject");
		}

		[Test]
		public void EntityWebPage_MatchesReferenceJson() {

			var entity = new WebPage(
				"https://example.edu/terms/201601/courses/7/sections/1/pages/index.html") {
				Name = "CPS 435-01 Landing Page",
				MediaType = "text/html",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") { 
					CourseNumber = "CPS 435-01",
					AcademicSession = "Fall 2016"
				}		                     
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityWebPage");
		}

	}
}