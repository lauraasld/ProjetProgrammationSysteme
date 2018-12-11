using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class FileAccess {
		private static FileAccess instance;

		private FileAccess() {
		}
		public static FileAccess GetInstance() {
			return instance;
		}
		public void WriteToFile(string fileName, string[] lines) {
			throw new System.Exception("Not implemented");
		}
		public string[] ReadFile(string fileName) {
			throw new System.Exception("Not implemented");
		}

	}

}
