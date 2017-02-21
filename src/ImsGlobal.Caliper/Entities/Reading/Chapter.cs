namespace ImsGlobal.Caliper.Entities.Reading {

	public class Chapter : DigitalResource {

		public Chapter ( string id )
			: base( id ) {
			this.Type = EntityType.Chapter;
		}

	}
}