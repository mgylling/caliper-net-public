
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Lis {
	using ImsGlobal.Caliper.Entities.W3c;
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<Role> ) )]
	public sealed class Role : IRole, IJsonValue {

		public static readonly Role  Learner = new Role( "Learner" );
		public static readonly Role  ExternalLearner = new Role( "ExternalLearner" );
		public static readonly Role  GuestLearner = new Role( "GuestLearner" );
		public static readonly Role  LearnerInstructor = new Role( "Instructor" );
		public static readonly Role  LearnerLearner = new Role( "Learner" );
		public static readonly Role  NoncreditLearner = new Role( "NonCreditLearner" );

		public static readonly Role  Instructor = new Role( "Instructor" );
		public static readonly Role  ExternalInstructor = new Role( "ExternalInstructor" );
		public static readonly Role  GuestInstructor = new Role( "GuestInstructor" );
		public static readonly Role  Lecturer = new Role( "Lecturer" );
		public static readonly Role  PrimaryInstructor = new Role( "PrimaryInstructor" );

		public static readonly Role  Administrator = new Role( "Administrator" );
		public static readonly Role  AdministratorAdministrator = new Role( "Administrator" );
		public static readonly Role  AdministratorDeveloper = new Role( "Developer" );
		public static readonly Role  AdministratorSupport = new Role( "Support" );
		public static readonly Role  AdministratorSystemAdministrator = new Role( "SystemAdministrator" );

		public static readonly Role  AdministratorExternalDeveloper = new Role( "ExternalSupport" );
		public static readonly Role  AdministratorExternalSupport = new Role( "ExternalDeveloper" );
		public static readonly Role  AdministratorExternalSystemAdministrator = new Role( "ExternalSystemAdministrator" );

		public static readonly Role  ContentDeveloper = new Role( "ContentDeveloper" );
		public static readonly Role  ContentDeveloperContentDeveloper = new Role( "ContentDeveloper" );
		public static readonly Role  ContentDeveloperLibrarian = new Role( "Librarian" );
		public static readonly Role  ContentDeveloperContentExpert = new Role( "ContentExpert" );
		public static readonly Role  ContentDeveloperExternalContentExpert = new Role( "ExternalContentExpert" );

		public static readonly Role  Manager = new Role( "Manager" );
		public static readonly Role  ManagerAreaManager = new Role( "AreaManager" );
		public static readonly Role  ManagerCourseCoordinator = new Role( "CourseCoordinator" );
		public static readonly Role  ManagerObserver = new Role( "Observer" );
		public static readonly Role  ManagerExternalObserver = new Role( "ExternalObserver" );

		public static readonly Role  Member = new Role( "Member" );
		public static readonly Role  MemberMember = new Role( "http://purl.imsglobal.org/vocab/lis/v2/membership/Member#Member" );

		public static readonly Role  Mentor = new Role( "Mentor" );
		public static readonly Role  MentorMentor = new Role( "Mentor" );
		public static readonly Role  MentorAdvisor = new Role( "Advisor" );
		public static readonly Role  MentorAuditor = new Role( "Auditor" );
		public static readonly Role  MentorReviewer = new Role( "Reviewer" );
		public static readonly Role  MentorTutor = new Role( "Tutor" );
		public static readonly Role  MentorLearningFacilitator = new Role( "LearningFacilitator" );

		public static readonly Role  MentorExternalMentor = new Role( "ExternalMentor" );
		public static readonly Role  MentorExternalAdvisor = new Role( "ExternalAdvisor" );
		public static readonly Role  MentorExternalAuditor = new Role( "ExternalAuditor" );
		public static readonly Role  MentorExternalReviewer = new Role( "ExternalReviewer" );
		public static readonly Role  MentorExternalTutor = new Role( "ExternalTutor" );
		public static readonly Role  MentorExternalLearningFacilitator = new Role( "ExternalLearningFacilitator" );

		public static readonly Role  TeachingAssistant = new Role( "TeachingAssistant" );
		public static readonly Role  TeachingAssistantTeachingAssistant = new Role( "TeachingAssistant" );
		public static readonly Role  TeachingAssistantGrader = new Role( "Grader" );
		public static readonly Role  TeachingAssistantTeachingAssistantSection = new Role( "TeachingAssistantSection" );
		public static readonly Role  TeachingAssistantTeachingAssistantSectionAssociation = new Role( "TeachingAssistantSectionAssociation" );
		public static readonly Role  TeachingAssistantTeachingAssistantOffering = new Role( "TeachingAssistantOffering" );
		public static readonly Role  TeachingAssistantTeachingAssistantTemplate = new Role( "TeachingAssistantTemplate" );
		public static readonly Role  TeachingAssistantTeachingAssistantGroup = new Role( "TeachingAssistantGroup" );

		public Role() {}

		public Role( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }
	}

}
