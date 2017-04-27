
using NodaTime;

namespace ImsGlobal.Caliper.Entities.Assignable {

	public interface IAssignable {

		Instant? DateToActivate { get; }
		Instant? DateToShow { get; }
		Instant? DateToStartOn { get; }
		Instant? DateToSubmit { get; }
		int MaxAttempts { get; }
		int MaxSubmits { get; }
		double MaxScore { get; }


	}

}
