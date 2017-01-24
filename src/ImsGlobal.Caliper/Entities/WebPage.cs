using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Entities {

	public class WebPage : DigitalResource {

		public WebPage( string id )
			: base( id ) {
			this.Type = EntityType.WebPage;
		}

	}

}
