namespace ImsGlobal.Caliper.Entities.W3c {
	using ImsGlobal.Caliper.Util;

	/// <summary>
	/// A collection of people organized together into a community or other
	/// social, commercial or political structure. The group has some common
	/// purpose or reason for existence which goes beyond the set of people
	/// belonging to it and can act as an Agent. Organizations are often
	/// decomposable into hierarchical structures.
	/// </summary>
	public interface IOrganization : IJsonId {

		/// <summary>
		/// Equivalent of W3C Organization Ontology org:subOrganizationOf
		/// property. Represents hierarchical containment of Organizations
		/// or OrganizationalUnits; indicates an Organization which
		/// contains this Organization.
		/// </summary>
		IOrganization SubOrganizationOf { get; }

	}

}
