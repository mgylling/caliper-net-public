using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Tests {

	internal static class TestUtils {

		public static string LoadReferenceJsonFile( string refJsonName ) {

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "ImsGlobal.Caliper.Tests.ReferenceJson." + refJsonName + ".json";

			string content = null;

			using (Stream stream = assembly.GetManifestResourceStream( resourceName ))
			using (StreamReader reader = new StreamReader( stream )) {
				content = reader.ReadToEnd();
			}

			return content;
		}

	}

}
