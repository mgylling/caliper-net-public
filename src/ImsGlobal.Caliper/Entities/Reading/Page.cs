namespace ImsGlobal.Caliper.Entities.Reading {

	public class Page : DigitalResource {

		public Page( string id ) 
			: base( id ) {
			this.Type = EntityType.Page;
		}

	}
}
