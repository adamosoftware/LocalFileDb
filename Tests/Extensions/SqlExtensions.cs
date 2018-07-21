using Dapper;
using Postulate.Lite.Core.Extensions;
using System.Data.SqlClient;

namespace Tests.Extensions
{
	public static class SqlExtensions
	{
		public static bool DbExists(this SqlConnection connection, string databaseName)
		{
			return connection.Exists("[sys].[databases] WHERE [name]=@name", new { name = databaseName });
		}

		public static void CreateDb(this SqlConnection connection, string databaseName)
		{
			connection.Execute($"CREATE TABLE [{databaseName}]");
		}

		public static bool TableExists(this SqlConnection connection, string schema, string tableName)
		{
			return connection.Exists("[sys].[tables] WHERE SCHEMA_NAME([schema_id])=@schema AND [name]=@tableName", new { schema, tableName });
		}
	}
}