
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Lis {
	using ImsGlobal.Caliper.Entities.W3c;

	/// <summary>
	/// A Caliper LIS Group represents a Course substructure that a Person
	/// is able to join as a member.
	/// </summary>
	public class Group : Entity, IOrganization {

		public Group( string id )
			: base( id ) {
			this.Type = EntityType.Group;
		}

		[JsonProperty( "subOrganizationOf", Order = 22 )]
		public IOrganization SubOrganizationOf { get; set; }

	}

}
