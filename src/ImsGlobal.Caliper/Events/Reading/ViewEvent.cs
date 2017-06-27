namespace ImsGlobal.Caliper.Events.Reading {

	/// <summary>
	/// Event raised when an actor views a resource.
	/// </summary>
	public class ViewEvent : Event {

		public ViewEvent(string id) 
			:base( id ) {
			this.Type = EventType.View;
			this.Action = Action.Viewed;
		}

	}
}
