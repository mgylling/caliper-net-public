using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<EntityType> ) )]
	public class EntityType : IType, IJsonValue {

		public static readonly EntityType Annotation = new EntityType( "Annotation" );
		public static readonly EntityType Attempt = new EntityType( "Attempt" );
        public static readonly EntityType Collection = new EntityType("Collection");
        public static readonly EntityType CourseOffering = new EntityType( "CourseOffering" );
		public static readonly EntityType CourseSection = new EntityType( "CourseSection" );
		public static readonly EntityType DigitalResource = new EntityType( "DigitalResource" );
		public static readonly EntityType Entity = new EntityType( "Entity" );
        public static readonly EntityType Forum = new EntityType("Forum");
        public static readonly EntityType Group = new EntityType( "Group" );
		public static readonly EntityType LearningObjective = new EntityType( "LearningObjective" );
		public static readonly EntityType Membership = new EntityType( "Membership" );
        public static readonly EntityType Message = new EntityType("Message");
        public static readonly EntityType Person = new EntityType( "Person" );
		public static readonly EntityType Organization = new EntityType( "Organization" );
		public static readonly EntityType Response = new EntityType( "Response" );
		public static readonly EntityType Result = new EntityType( "Result" );
		public static readonly EntityType Session = new EntityType( "Session" );
        public static readonly EntityType LtiSession = new EntityType("LtiSession");
        public static readonly EntityType SoftwareApplication = new EntityType( "SoftwareApplication" );
        public static readonly EntityType Thread = new EntityType("Thread");
        public static readonly EntityType View = new EntityType( "View" );

		public EntityType() {}

		public EntityType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }

	}

}