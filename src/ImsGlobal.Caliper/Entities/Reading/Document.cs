namespace ImsGlobal.Caliper.Entities.Reading {

	public class Document : DigitalResource {

		public Document ( string id )
			: base( id ) {
			this.Type = EntityType.Document;
		}

	}
}