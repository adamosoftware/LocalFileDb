using System;

namespace LocalFileDb.Library
{
	public class File
	{		
		public int FolderId { get; set; }
		public string Path { get; set; }
		public string Name { get; set; }
		public long Size { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public int Id { get; set; }

		/// <summary>
		/// Use this to capture in any metadata about the file your database requires
		/// </summary>		
		public virtual void GetMetadata(string path)
		{
		}
	}
}