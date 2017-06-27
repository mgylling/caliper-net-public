namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Represents a learning objective.
	/// </summary>
	public class LearningObjective : Entity {

		public LearningObjective( string id )
			: base( id ) {
			this.Type = EntityType.LearningObjective;
		}

	}

}
