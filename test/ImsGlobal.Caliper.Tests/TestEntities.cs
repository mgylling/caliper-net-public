using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NodaTime;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Entities;
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Assessment;
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Lis;
	using ImsGlobal.Caliper.Entities.Media;
	using ImsGlobal.Caliper.Entities.Outcome;
	using ImsGlobal.Caliper.Entities.Reading;
	using ImsGlobal.Caliper.Entities.Response;
	using ImsGlobal.Caliper.Entities.Session;
	using ImsGlobal.Caliper.Entities.W3c;

	internal static class TestEntities {

		public static readonly string User554433_Id = "https://example.edu/user/554433";
		public static readonly string AmRev101_CourseOffering_Id = "https://example.edu/politicalScience/2015/american-revolution-101";
		public static readonly string AmRev101_CourseSection001_Id = "https://example.edu/politicalScience/2015/american-revolution-101/section/001";
		public static readonly string AmRev101_Group001_Id = "https://example.edu/politicalScience/2015/american-revolution-101/section/001/group/001";

		public static readonly Instant DefaultDateCreated = Instant.FromUtc( 2015, 8, 1, 6, 0, 0 );
		public static readonly Instant DefaultDateModified = Instant.FromUtc( 2015, 9, 2, 11, 30, 0 );
		public static readonly Instant DefaultDatePublished = Instant.FromUtc( 2015, 8, 15, 9, 30, 0 );
		public static readonly Instant DefaultDateToActivate = Instant.FromUtc( 2015, 8, 16, 5, 0, 0 );
		public static readonly Instant DefaultDateToShow = DefaultDateToActivate;
		public static readonly Instant DefaultDateToStartOn = DefaultDateToActivate;
		public static readonly Instant DefaultDateToSubmit = Instant.FromUtc( 2015, 9, 28, 11, 59, 59 );
		public static readonly Instant DefaultStartedAtTime = Instant.FromUtc( 2015, 9, 15, 10, 15, 0 );
		public static readonly Instant DefaultEndedAtTime = Instant.FromUtc( 2015, 9, 15, 11, 05, 0 );
		public static readonly Instant DefaultSendTime = Instant.FromUtc( 2015, 9, 15, 11, 05, 1 );

		public static CourseOffering AmRev101_CourseOffering = new CourseOffering( AmRev101_CourseOffering_Id ) {
			CourseNumber = "POL101",
			Name = "Political Science 101: The American Revolution",
			AcademicSession = "Fall-2015",
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static CourseSection AmRev101_CourseSection001 = new CourseSection( AmRev101_CourseSection001_Id ) {
			CourseNumber = "POL101",
			Name = "American Revolution 101",
			AcademicSession = "Fall-2015",
			SubOrganizationOf = AmRev101_CourseOffering,
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static Group AmRev101_Group001 = new Group( AmRev101_Group001_Id ) {
			Name = "Discussion Group 001",
			SubOrganizationOf = AmRev101_CourseSection001,
			DateCreated = DefaultDateCreated
		};

		public static Person User554433 = new Person( User554433_Id ) {
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static readonly Membership User554433_AmRev101_CourseSection001_Membership =
			new Membership( "https://example.edu/politicalScience/2015/american-revolution-101/roster/554433" ) {
				Name = "American Revolution 101",
				Description = "Roster entry",
				Member = User554433,
				Organization = AmRev101_CourseSection001,
				Roles = new IRole[] { Role.Learner },
				Status = Status.Active,
				DateCreated = DefaultDateCreated
			};


		public static WebPage AmRev101LandingPage = new WebPage( AmRev101_CourseOffering_Id + "/index.html" ) {
			Name = "American Revolution 101 Landing Page",
			Version = "1.0",
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static SoftwareApplication EpubViewerApp = new SoftwareApplication( "https://example.com/viewer" ) {
			Name = "ePub",
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		//public static EPubVolume EpubVolume43 = new EPubVolume( "https://example.com/viewer/book/34843#epubcfi(/4/3)" ) {
		//	Name = "The Glorious Cause: The American Revolution, 1763-1789 (Oxford History of the United States)",
		//	Version = "2nd ed.",
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static EPubSubChapter EpubSubChap431 = new EPubSubChapter( "https://example.com/viewer/book/34843#epubcfi(/4/3/1)" ) {
		//	Name = "Key Figures: George Washington",
		//	Version = "2nd ed.",
		//	IsPartOf = EpubVolume43,
		//	DateModified = DefaultDateModified
		//};

		//public static Frame EpubSubChap431_Frame = new Frame( EpubSubChap431.Id ) {
		//	Name = EpubSubChap431.Name,
		//	Version = EpubSubChap431.Version,
		//	IsPartOf = EpubVolume43,
		//	Index = 1,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static EPubSubChapter EpubSubChap432 = new EPubSubChapter( "https://example.com/viewer/book/34843#epubcfi(/4/3/2)" ) {
		//	Name = "Key Figures: Lord North",
		//	Version = "2nd ed.",
		//	IsPartOf = EpubVolume43,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static Frame EpubSubChap432_Frame = new Frame( EpubSubChap432.Id ) {
		//	Name = EpubSubChap432.Name,
		//	Version = EpubSubChap432.Version,
		//	IsPartOf = EpubSubChap432.IsPartOf,
		//	Index = 2,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static EPubSubChapter EpubSubChap433 = new EPubSubChapter( "https://example.com/viewer/book/34843#epubcfi(/4/3/3)" ) {
		//	Name = "Key Figures: John Adams",
		//	Version = "2nd ed.",
		//	IsPartOf = EpubVolume43,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static Frame EpubSubChap433_Frame = new Frame( EpubSubChap433.Id ) {
		//	Name = EpubSubChap433.Name,
		//	Version = EpubSubChap433.Version,
		//	IsPartOf = EpubVolume43,
		//	Index = 3,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		//public static EPubSubChapter EpubSubChap434 = new EPubSubChapter( "https://example.com/viewer/book/34843#epubcfi(/4/3/4)" ) {
		//	Name = "The Stamp Act Crisis",
		//	Version = "2nd ed.",
		//	IsPartOf = EpubVolume43,
		//	DateModified = DefaultDateModified
		//};

		//public static Frame EpubSubChap434_Frame = new Frame( EpubSubChap434.Id ) {
		//	Name = EpubSubChap434.Name,
		//	Version = EpubSubChap434.Version,
		//	IsPartOf = EpubVolume43,
		//	Index = 4,
		//	DateCreated = DefaultDateCreated,
		//	DateModified = DefaultDateModified
		//};

		public static SoftwareApplication SuperMediaTool = new SoftwareApplication( "https://example.com/super-media-tool" ) {
			Name = "Super Media Tool",
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static VideoObject VideoWithLearningObjective = new VideoObject( "https://example.com/super-media-tool/video/1225" ) {
			Name = "American Revolution - Key Figures Video",
			LearningObjectives = new[] { 
				new LearningObjective( "https://example.edu/american-revolution-101/personalities/learn" ) {
					DateCreated = DefaultDateCreated
				}
			},
			Duration = 1420,
			Version = "1.0",
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static MediaLocation VideoWithLearningObjective_Location710 = new MediaLocation( VideoWithLearningObjective.Id ) {
			CurrentTime = Period.FromSeconds( 710 ),
			Version = "1.0",
			DateCreated = DefaultDateCreated
		};

		public static SoftwareApplication SuperAssessmentTool = new SoftwareApplication( "https://example.com/super-assessment-tool" ) {
			Name = "Super Assessment Tool",
			DateCreated = DefaultDateCreated
		};

		private static string Assessment1_Id = "https://example.edu/politicalScience/2015/american-revolution-101/assessment/001";

		public static Assessment Assessment1 = new Assessment( Assessment1_Id ) {
			Name = "American Revolution - Key Figures Assessment",
			Version = "1.0",
			DatePublished = DefaultDatePublished,
			DateToActivate = DefaultDateToActivate,
			DateToShow = DefaultDateToShow,
			DateToStartOn = DefaultDateToStartOn,
			DateToSubmit = DefaultDateToSubmit,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 3.0,
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified
		};

		public static AssessmentItem AssessmentItem1 =
			new AssessmentItem( Assessment1_Id + "/item/001" ) {
				Name = "Assessment Item 1",
				Version = "1.0",
				IsPartOf = Assessment1,
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 1.0,
				IsTimeDependent = false
			};
		public static AssessmentItem AssessmentItem2 =
			new AssessmentItem( Assessment1_Id + "/item/002" ) {
				Name = "Assessment Item 2",
				Version = "1.0",
				IsPartOf = Assessment1,
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 1.0,
				IsTimeDependent = false
			};
		public static AssessmentItem AssessmentItem3 =
			new AssessmentItem( Assessment1_Id + "/item/003" ) {
				Name = "Assessment Item 3",
				Version = "1.0",
				IsPartOf = Assessment1,
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 1.0,
				IsTimeDependent = false
			};

		public static Attempt Assessment1_Attempt1 = new Attempt( Assessment1_Id + "/attempt/5678" ) {
			Assignable = Assessment1,
			Actor = User554433,
			Count = 1,
			DateCreated = DefaultDateCreated,
			StartedAtTime = DefaultStartedAtTime
		};

		public static Attempt Assessment1_Item1_Attempt1 = new Attempt( AssessmentItem1.Id + "/attempt/789" ) {
			Assignable = Assessment1,
			Actor = User554433,
			Count = 1,
			DateCreated = DefaultDateCreated,
			StartedAtTime = DefaultStartedAtTime
		};

		public static FillInBlankResponse Assessment1_Item1_Attempt1_Response = new FillInBlankResponse( AssessmentItem1.Id + "/response/001" ) {
			Assignable = Assessment1,
			Actor = User554433,
			Attempt = Assessment1_Item1_Attempt1,
			Values = new [] { "2 July 1776" },
			DateCreated = DefaultDateCreated,
			StartedAtTime = DefaultStartedAtTime
		};

		public static Result Assessment1_Attempt1_Result = new Result( Assessment1_Attempt1.Id + "/result" ) {
			Assignable = Assessment1,
			Actor = User554433,
			NormalScore = 3.0,
			PenaltyScore = 0.0,
			ExtraCreditScore = 0.0,
			TotalScore = 3.0,
			CurvedTotalScore = 3.0,
			CurveFactor = 0.0,
			Comment = "Well done.",
			ScoredBy = SuperAssessmentTool,
			DateCreated = DefaultDateCreated
		};

		public static Session SessionStart = new Session( "https://example.com/viewer/session-123456789" ) {
			Name = "session-123456789",
			Actor = User554433,
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified,
			StartedAt = DefaultStartedAtTime
		};

		public static Session SessionEnd = new Session( "https://example.com/viewer/session-123456789" ) {
			Name = "session-123456789",
			Actor = User554433,
			DateCreated = DefaultDateCreated,
			DateModified = DefaultDateModified,
			StartedAt = DefaultStartedAtTime,
			EndedAt = DefaultEndedAtTime,
			Duration = Period.FromSeconds( 3000 )
		};

		public static Session FederatedSession = new Session( "https://example.edu/lms/federatedSession/123456789" ) {
			Actor = User554433,
			DateCreated = DefaultDateCreated,
			StartedAt = DefaultStartedAtTime
		};

	}

}
