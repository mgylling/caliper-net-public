using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Entities.Media {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;

	/// <summary>
	/// An image object embedded in a web page.
	/// </summary>
	public class ImageObject : MediaObject, IImageObject {

		public ImageObject( string id )
			: base( id, EntityType.ImageObject ) {
		}

	}

}
