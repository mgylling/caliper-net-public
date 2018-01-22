namespace ImsGlobal.Caliper.Events.Session {

	public class SessionEvent : Event {

		public SessionEvent( string id, Action action ) 
			:base ( id ) {
			this.Type = EventType.Session;
			this.Action = action;
		}

	}

}
