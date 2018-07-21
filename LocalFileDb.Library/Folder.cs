using System.Data;

namespace LocalFileDb.Library
{
	public abstract class Folder
	{
		public Folder(IDbConnection connection)
		{
			if (!DatabaseExists(connection)) CreateDb(connection);
			if (!TablesExist(connection)) CreateTables(connection);
		}

		protected abstract string DatabaseName { get; }

		protected abstract bool DatabaseExists(IDbConnection connection);

		protected abstract void CreateDb(IDbConnection connection);

		protected abstract bool TablesExist(IDbConnection connection);

		protected abstract void CreateTables(IDbConnection connection);

		/// <summary>
		/// Id of containing Folder
		/// </summary>
		public int ParentId { get; set; }

		/// <summary>
		/// Folder's full path
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Folder's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Folder's internal Id
		/// </summary>
		public int Id { get; set; }
	}
}