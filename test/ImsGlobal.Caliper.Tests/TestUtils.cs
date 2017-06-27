using System;
using System.IO;
using System.Reflection;

namespace ImsGlobal.Caliper.Tests {

	internal static class TestUtils {

		private static string fixturesPath = GetFixturesPath();

		/// <summary>
		/// Loads a reference json file from the caliper-common-fixtures project. The
		/// fixtures project must be a sibling to the caliper-net project on the filesystem.
		/// </summary>
		/// <returns>The reference json file content as a string.</returns>
		/// <param name="refJsonName">Reference json name, without extension.</param>
		public static string LoadReferenceJsonFixture(string refJsonName) {

			var stream = new FileStream(fixturesPath + Path.DirectorySeparatorChar
				+ refJsonName + ".json", FileMode.Open);

			string content = null;

			using (StreamReader reader = new StreamReader(stream)) {
				content = reader.ReadToEnd();
			}

			return content;
		}

		private static string GetFixturesPath() {

			//get the parent dir of the caliper-net dir
			var startDir = new DirectoryInfo(Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location));

			//given different IDEs and runtime modes, we don't know exactly 
			//where we are, so iterate upwards
			while (startDir.Parent != null) {
				startDir = startDir.Parent;
				if (startDir.Name.Equals("caliper-net")) {
					startDir = startDir.Parent;
					break;
				}
			}

			//find the caliper-common-fixtures sibling to caliper-net
			var dirs = startDir.GetDirectories();

			var fixturesDirInfo = Array.Find(dirs, (DirectoryInfo obj)
			   => obj.Name.Equals("caliper-common-fixtures"));

			return Path.Combine(new string[5]
				{ fixturesDirInfo.FullName, "src", "test", "resources", "fixtures" });

		}

	}

}
