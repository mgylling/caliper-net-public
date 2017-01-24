using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Media {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<MediaObjectType> ) )]
	public sealed class MediaObjectType : IType, IJsonValue {

		public static readonly MediaObjectType AudioObject = new MediaObjectType( "AudioObject" );
		public static readonly MediaObjectType ImageObject = new MediaObjectType( "ImageObject" );
		public static readonly MediaObjectType VideoObject = new MediaObjectType( "VideoObject" );

		public MediaObjectType() {}

		public MediaObjectType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }
	}
}