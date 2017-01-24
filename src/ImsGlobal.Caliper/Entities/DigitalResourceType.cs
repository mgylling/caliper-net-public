using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<DigitalResourceType> ) )]
	public sealed class DigitalResourceType : IType, IJsonValue {

		public static readonly DigitalResourceType AssignableDigitalResource = new DigitalResourceType( "AssignableDigitalResource" );
		public static readonly DigitalResourceType Frame = new DigitalResourceType( "Frame" );
		public static readonly DigitalResourceType MediaLocation = new DigitalResourceType( "MediaLocation" );
		public static readonly DigitalResourceType MediaObject = new DigitalResourceType( "MediaObject" );
		public static readonly DigitalResourceType WebPage = new DigitalResourceType( "WebPage" );

		public DigitalResourceType() {}

		public DigitalResourceType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }

	}

}