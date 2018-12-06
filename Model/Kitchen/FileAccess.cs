using System;
namespace Kitchen {
	public class FileAccess {
		private static FileAccess instance;

		private FileAccess() {
			throw new System.Exception("Not implemented");
		}
		public FileAccess GetInstance() {
			return this.instance;
		}
		public void WriteToFile(ref string fileName, ref string[] lines) {
			throw new System.Exception("Not implemented");
		}
		public string[] ReadFile(ref string fileName) {
			throw new System.Exception("Not implemented");
		}

		private FileAccess fileAccess;


	}

}
