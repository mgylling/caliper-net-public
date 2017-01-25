using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImsGlobal.Caliper.Tests {

	internal static class TestUtils {

		/// <summary>
		/// Loads the reference json file from the caliper-common-fixtures project, which must be
		/// a sibling to the caliper-net project on the filesystem.
		/// </summary>
		/// <returns>The reference json file.</returns>
		/// <param name="refJsonName">Reference json name.</param>
		public static string LoadReferenceJsonFile( string refJsonName ) {

			//get the parent dir of the caliper-net dir
			var startDir = new DirectoryInfo(Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location));

			while (startDir.Parent != null) {
				startDir = startDir.Parent;
				if (startDir.Name.Equals("caliper-net")) {
					startDir = startDir.Parent;
					break;
				}	
			}

			//find the caliper-common-fixtures sibling to caliper-net
			var dirs = startDir.GetDirectories();

			var fixturesDirInfo = Array.Find(dirs, (DirectoryInfo obj) => obj.Name.Equals("caliper-common-fixtures"));

			//get and read the json file from deep inside the fixtures dir
			var path = Path.Combine(new string[5] { fixturesDirInfo.FullName, "src", "test", "resources", "fixtures" });

			var stream = new FileStream(path + Path.DirectorySeparatorChar + refJsonName + ".json", FileMode.Open); 

			string content = null;

			using (StreamReader reader = new StreamReader( stream )) {
				content = reader.ReadToEnd();
			}

			return content;
		}

	}

}
