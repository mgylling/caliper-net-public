namespace ImsGlobal.Caliper.Events.Reading {
	using ImsGlobal.Caliper.Events;

	/// <summary>
	/// Event raised when an actor navigates from one resource to another.
	/// </summary>
	public class NavigationEvent : Event {

		public NavigationEvent(string id) 
			:base( id ) {
			this.Type = EventType.Navigation;
			this.Action = Action.NavigatedTo;
		}
        
	}

}
