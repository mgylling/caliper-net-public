namespace ImsGlobal.Caliper.Events.Assessment {

	/// <summary>
	/// Event raised when an actor interacts with an assessment resource.
	/// </summary>
	public class AssessmentEvent : Event {

		public AssessmentEvent(string id,  Action action ) 
			: base( id ) {
			this.Type = EventType.Assessment;
			this.Action = action;
		}

	}

}
