namespace ImsGlobal.Caliper.Entities.Agent {
	using ImsGlobal.Caliper.Entities.Foaf;

	public class Person : Entity, IAgent {

		public Person( string id )
			: base( id ) {
			this.Type = EntityType.Person;
		}

	}

}
