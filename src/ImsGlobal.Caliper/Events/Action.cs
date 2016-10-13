using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Events {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<Action> ) )]
	public sealed class Action : IJsonValue {

		public static readonly Action Abandoned = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Abandoned" );
		public static readonly Action Activated = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Activated" );
		public static readonly Action Attached = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Attached" );
		public static readonly Action Bookmarked = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Bookmarked" );
		public static readonly Action ChangedResolution = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ChangedResolution" );
		public static readonly Action ChangedSize = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ChangedSize" );
		public static readonly Action ChangedSpeed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ChangedSpeed" );
		public static readonly Action ChangedVolume = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ChangedVolume" );
		public static readonly Action Classified = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Classified" );
		public static readonly Action ClosedPopout = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ClosedPopout" );
		public static readonly Action Commented = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Commented" );
		public static readonly Action Completed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Completed" );
		public static readonly Action Deactivated = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Deactivated" );
		public static readonly Action Described = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Described" );
		public static readonly Action Disliked = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Disliked" );
		public static readonly Action DisabledClosedCaptioning = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#DisabledClosedCaptioning" );
		public static readonly Action EnabledClosedCaptioning = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#EnabledClosedCaptioning" );
		public static readonly Action Ended = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Ended" );
		public static readonly Action EnteredFullscreen = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#EnteredFullscreen" );
		public static readonly Action ExitedFullscreen = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ExitedFullscreen" );
		public static readonly Action ForwardedTo = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#ForwardedTo" );
		public static readonly Action Graded = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Graded" );
		public static readonly Action Hid = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Hid" );
		public static readonly Action Highlighted = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Highlighted" );
		public static readonly Action JumpedTo = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#JumpedTo" );
		public static readonly Action Identified = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Identified" );
		public static readonly Action Liked = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Liked" );
		public static readonly Action Linked = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Linked" );
		public static readonly Action LoggedIn = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#LoggedIn" );
		public static readonly Action LoggedOut = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#LoggedOut" );
        public static readonly Action MarkedAsRead = new Action("http://purl.imsglobal.org/vocab/caliper/v1/action#MarkedAsRead");
        public static readonly Action MarkedAsUnread = new Action("http://purl.imsglobal.org/vocab/caliper/v1/action#MarkedAsUnread");
        public static readonly Action Muted = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Muted" );
		public static readonly Action NavigatedTo = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#NavigatedTo" );
		public static readonly Action OpenedPopout = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#OpenedPopout" );
		public static readonly Action Paused = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Paused" );
        public static readonly Action Posted = new Action("http://purl.imsglobal.org/vocab/caliper/v1/action#Posted");
        public static readonly Action Ranked = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Ranked" );
		public static readonly Action Questioned = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Questioned" );
		public static readonly Action Recommended = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Recommended" );
		public static readonly Action Replied = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Replied" );
		public static readonly Action Restarted = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Restarted" );
		public static readonly Action Resumed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Resumed" );
		public static readonly Action Reviewed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Reviewed" );
		public static readonly Action Rewound = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Rewound" );
		public static readonly Action Searched = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Searched" );
		public static readonly Action Shared = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Shared" );
		public static readonly Action Showed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Showed" );
		public static readonly Action Skipped = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Skipped" );
		public static readonly Action Started = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Started" );
		public static readonly Action Submitted = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Submitted" );
		public static readonly Action Subscribed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Subscribed" );
		public static readonly Action Tagged = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Tagged" );
		public static readonly Action TimedOut = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#TimedOut" );
		public static readonly Action Viewed = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Viewed" );
		public static readonly Action Unmuted = new Action( "http://purl.imsglobal.org/vocab/caliper/v1/action#Unmuted" );

		public Action() {}

		public Action( string action ) {
			this.Value = action;
		}

		public string Value { get; set; }

	}

}

