namespace ImsGlobal.Caliper.Events.Assessment {

	/// <summary>
	/// Event raised when an actor interacts with an assessment item resource.
	/// </summary>
	public class AssessmentItemEvent : Event {

		public AssessmentItemEvent(string id, Action action ) 
			: base( id ) {
			this.Type = EventType.AssessmentItem;
			this.Action = action;
		}

	}

}
