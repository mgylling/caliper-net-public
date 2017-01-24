using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Entities.Reading {

	public class Page : DigitalResource {

		public Page(string id) : base(id) {
			this.Type = EntityType.Page;
		}

	}

}