using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Entities.Media {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;

	/// <summary>
	/// A video object embedded in a web page.
	/// </summary>
	public class VideoObject : MediaObject, IVideoObject {

		public VideoObject( string id )
			: base( id, EntityType.VideoObject ) {
		}

	}

}
