namespace ImsGlobal.Caliper.Events.Assignable {

	/// <summary>
	/// Event raised when an actor interacts with an assignable resource.
	/// </summary>
	public class AssignableEvent : Event {

		public AssignableEvent(string id, Action action ) 
			:base ( id ) {
			this.Type = EventType.Assignable;
			this.Action = action;
		}

	}

}
