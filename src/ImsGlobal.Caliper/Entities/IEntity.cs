using NodaTime;
using System;
using ImsGlobal.Caliper.Util;

namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Provides an entity with its JSON-LD type identifier.
	/// </summary>
	public interface IEntity : IJsonId {
        
        string Context { get; set; }
       
        IType Type { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Object Extensions { get; set; }

        Instant? DateCreated { get; set; }

        Instant? DateModified { get; set; }
    }

}