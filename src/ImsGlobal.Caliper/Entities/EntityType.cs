using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<EntityType> ) )]
	public class EntityType : IType, IJsonValue {

		public static readonly EntityType Annotation = new EntityType( "http://purl.imsglobal.org/caliper/v1/Annotation" );
		public static readonly EntityType Attempt = new EntityType( "http://purl.imsglobal.org/caliper/v1/Attempt" );
        public static readonly EntityType Collection = new EntityType("http://purl.imsglobal.org/caliper/v1/Collection");
        public static readonly EntityType CourseOffering = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/CourseOffering" );
		public static readonly EntityType CourseSection = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/CourseSection" );
		public static readonly EntityType DigitalResource = new EntityType( "http://purl.imsglobal.org/caliper/v1/DigitalResource" );
		public static readonly EntityType Entity = new EntityType( "http://purl.imsglobal.org/caliper/v1/Entity" );
		public static readonly EntityType Group = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/Group" );
		public static readonly EntityType LearningObjective = new EntityType( "http://purl.imsglobal.org/caliper/v1/LearningObjective" );
		public static readonly EntityType Membership = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/Membership" );
		public static readonly EntityType Person = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/Person" );
		public static readonly EntityType Organization = new EntityType( "http://purl.imsglobal.org/caliper/v1/lis/Organization" );
		public static readonly EntityType Response = new EntityType( "http://purl.imsglobal.org/caliper/v1/Response" );
		public static readonly EntityType Result = new EntityType( "http://purl.imsglobal.org/caliper/v1/Result" );
		public static readonly EntityType Session = new EntityType( "http://purl.imsglobal.org/caliper/v1/Session" );
        public static readonly EntityType LtiSession = new EntityType("http://purl.imsglobal.org/caliper/v1/LtiSession");
        public static readonly EntityType SoftwareApplication = new EntityType( "http://purl.imsglobal.org/caliper/v1/SoftwareApplication" );
		public static readonly EntityType View = new EntityType( "http://purl.imsglobal.org/caliper/v1/View" );

		public EntityType() {}

		public EntityType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }

	}

}