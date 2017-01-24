using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Entities.Reading
{

	public class Document : DigitalResource
	{

		public Document(string id) : base(id)
		{
			this.Type = EntityType.Document;
		}

	}

}