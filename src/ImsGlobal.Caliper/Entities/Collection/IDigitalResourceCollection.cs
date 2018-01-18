using System;
using System.Collections.Generic;

namespace ImsGlobal.Caliper.Entities.Collection {

	public interface IDigitalResourceCollection : ICollection {

		IList<DigitalResource> Items { get; }

	}
}
