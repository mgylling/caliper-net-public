using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Response {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<ResponseType> ) )]
	public sealed class ResponseType : IType, IJsonValue {

		public static readonly ResponseType FillInBlank = new ResponseType( "FillinBlankResponse" );
		public static readonly ResponseType MultipleChoice = new ResponseType( "MultipleChoiceResponse" );
		public static readonly ResponseType MultipleResponse = new ResponseType( "MultipleResponseResponse" );
		public static readonly ResponseType SelectText = new ResponseType( "SelectTextResponse" );
		public static readonly ResponseType TrueFalse = new ResponseType( "TrueFalseResponse" );

		public ResponseType() {}

		public ResponseType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }
	}
}