using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NodaTime;

namespace ImsGlobal.Caliper.Entities.Assignable {

	public interface IAssignable {

		Instant? DateToActivate { get; }
		Instant? DateToShow { get; }
		Instant? DateToStartOn { get; }
		Instant? DateToSubmit { get; }
		int MaxAttempts { get; }
		int MaxSubmits { get; }
		int MaxScore { get; }


	}

}
