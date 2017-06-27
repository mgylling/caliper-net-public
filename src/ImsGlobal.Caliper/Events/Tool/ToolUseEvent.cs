namespace ImsGlobal.Caliper.Events.Tool {

	public class ToolUseEvent : Event {

		public ToolUseEvent( string id, Action action ) 
			:base( id ){
			this.Type = EventType.ToolUse;
			this.Action = action;
		}

    }

}
