namespace ImsGlobal.Caliper.Events.Outcome {

	/// <summary>
	/// Event raised when actions related to an outcome are performed.
	/// </summary>
	public class OutcomeEvent : Event {

		public OutcomeEvent( string id, Action action ) 
			:base( id ) {
			this.Type = EventType.Outcome;
			this.Action = action;
		}

	}

}
