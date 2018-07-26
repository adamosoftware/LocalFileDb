using Postulate.Lite.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace LocalFileDb.Library
{
	public class File
	{				
		[PrimaryKey]
		public int FolderId { get; set; }
		[PrimaryKey]
		[MaxLength(255)]
		public string Name { get; set; }
		[MaxLength(500)]
		public string Path { get; set; }
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