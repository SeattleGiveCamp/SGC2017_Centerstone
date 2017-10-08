using System;

namespace Centerstone.Models
{
	public class HifImage
	{
		public Guid Id { get; set; }
		public string Path { get; set; }

		public void Delete ()
		{
			try {
				System.IO.File.Delete (Path);
			}
			catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}
	}
}
