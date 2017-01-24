using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<AnnotationType> ) )]
	public sealed class AnnotationType : IType, IJsonValue {

		public static readonly AnnotationType Bookmark = new AnnotationType( "BookmarkAnnotation" );
		public static readonly AnnotationType Highlight = new AnnotationType( "HighlightAnnotation" );
		public static readonly AnnotationType Share = new AnnotationType( "SharedAnnotation" );
		public static readonly AnnotationType Tag = new AnnotationType( "TagAnnotation" );

		public AnnotationType() {}

		public AnnotationType( string uri ) {
			this.Value = uri;
		}

		public string Value { get; set; }

	}

}