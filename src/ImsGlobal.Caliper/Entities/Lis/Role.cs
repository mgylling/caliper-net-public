
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Lis {
	using ImsGlobal.Caliper.Entities.W3c;
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<Role> ) )]
	public sealed class Role : IRole, IJsonValue {

		public static readonly Role  Learner = new Role( "Learner" );
		public static readonly Role  ExternalLearner = new Role( "Learner#ExternalLearner" );
		public static readonly Role  GuestLearner = new Role( "Learner#GuestLearner" );
		public static readonly Role  LearnerInstructor = new Role( "Learner#Instructor" );
		public static readonly Role  LearnerLearner = new Role( "Learner#Learner" );
		public static readonly Role  NoncreditLearner = new Role( "Learner#NonCreditLearner" );

		public static readonly Role  Instructor = new Role( "Instructor" );
		public static readonly Role  ExternalInstructor = new Role( "Instructor#ExternalInstructor" );
		public static readonly Role  GuestInstructor = new Role( "Instructor#GuestInstructor" );
		public static readonly Role  Lecturer = new Role( "Instructor#Lecturer" );
		public static readonly Role  PrimaryInstructor = new Role( "Instructor#PrimaryInstructor" );

		public static readonly Role  Administrator = new Role( "Administrator" );
		public static readonly Role  AdministratorAdministrator = new Role( "Administrator#Administrator" );
		public static readonly Role  AdministratorDeveloper = new Role( "Administrator#Developer" );
		public static readonly Role  AdministratorSupport = new Role( "Administrator#Support" );
		public static readonly Role  AdministratorSystemAdministrator = new Role( "Administrator#SystemAdministrator" );

		public static readonly Role  AdministratorExternalDeveloper = new Role( "Administrator#ExternalSupport" );
		public static readonly Role  AdministratorExternalSupport = new Role( "Administrator#ExternalDeveloper" );
		public static readonly Role  AdministratorExternalSystemAdministrator = new Role( "Administrator#ExternalSystemAdministrator" );

		public static readonly Role  ContentDeveloper = new Role( "ContentDeveloper" );
		public static readonly Role  ContentDeveloperContentDeveloper = new Role( "ContentDeveloper#ContentDeveloper" );
		public static readonly Role  ContentDeveloperLibrarian = new Role( "ContentDeveloper#Librarian" );
		public static readonly Role  ContentDeveloperContentExpert = new Role( "ContentDeveloper#ContentExpert" );
		public static readonly Role  ContentDeveloperExternalContentExpert = new Role( "ContentDeveloper#ExternalContentExpert" );

		public static readonly Role  Manager = new Role( "Manager" );
		public static readonly Role  ManagerAreaManager = new Role( "Manager#AreaManager" );
		public static readonly Role  ManagerCourseCoordinator = new Role( "Manager#CourseCoordinator" );
		public static readonly Role  ManagerObserver = new Role( "Manager#Observer" );
		public static readonly Role  ManagerExternalObserver = new Role( "Manager#ExternalObserver" );

		public static readonly Role  Member = new Role( "Member" );
		public static readonly Role  MemberMember = new Role( "Member#Member" );

		public static readonly Role  Mentor = new Role( "Mentor" );
		public static readonly Role  MentorMentor = new Role( "Mentor#Mentor" );
		public static readonly Role  MentorAdvisor = new Role( "Mentor#Advisor" );
		public static readonly Role  MentorAuditor = new Role( "Mentor#Auditor" );
		public static readonly Role  MentorReviewer = new Role( "Mentor#Reviewer" );
		public static readonly Role  MentorTutor = new Role( "Mentor#Tutor" );
		public static readonly Role  MentorLearningFacilitator = new Role( "Mentor#LearningFacilitator" );

		public static readonly Role  MentorExternalMentor = new Role( "Mentor#ExternalMentor" );
		public static readonly Role  MentorExternalAdvisor = new Role( "Mentor#ExternalAdvisor" );
		public static readonly Role  MentorExternalAuditor = new Role( "Mentor#ExternalAuditor" );
		public static readonly Role  MentorExternalReviewer = new Role( "Mentor#ExternalReviewer" );
		public static readonly Role  MentorExternalTutor = new Role( "Mentor#ExternalTutor" );
		public static readonly Role  MentorExternalLearningFacilitator = new Role( "Mentor#ExternalLearningFacilitator" );

		public static readonly Role  TeachingAssistant = new Role( "TeachingAssistant" );
		public static readonly Role  TeachingAssistantTeachingAssistant = new Role( "TeachingAssistant#TeachingAssistant" );
		public static readonly Role  TeachingAssistantGrader = new Role( "TeachingAssistant#Grader" );
		public static readonly Role  TeachingAssistantTeachingAssistantSection = new Role( "TeachingAssistant#TeachingAssistantSection" );
		public static readonly Role  TeachingAssistantTeachingAssistantSectionAssociation = new Role( "TeachingAssistant#TeachingAssistantSectionAssociation" );
		public static readonly Role  TeachingAssistantTeachingAssistantOffering = new Role( "TeachingAssistant#TeachingAssistantOffering" );
		public static readonly Role  TeachingAssistantTeachingAssistantTemplate = new Role( "TeachingAssistant#TeachingAssistantTemplate" );
		public static readonly Role  TeachingAssistantTeachingAssistantGroup = new Role( "TeachingAssistant#TeachingAssistantGroup" );

		public Role() {}

		public Role( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }
	}

}
