using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LocalFileDb.Library
{
	public class Folder
	{
		/// <summary>
		/// Id of containing Folder
		/// </summary>
		public int ParentId { get; set; }

		/// <summary>
		/// Folder's full path
		/// </summary>
		[MaxLength(255)]
		public string Path { get; set; }

		/// <summary>
		/// Folder's name
		/// </summary>
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// Folder's internal Id
		/// </summary>
		public int Id { get; set; }
	}
}