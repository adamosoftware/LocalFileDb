using Dapper;
using LocalFileDb.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp3Player.Models;
using Postulate.Lite.SqlServer.IntKey;
using System.Data;
using System.Data.SqlClient;

namespace Tests
{
	[TestClass]
	public class AllTests
	{
		protected SqlConnection GetConnection()
		{
			return new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Database=Mp3Files;Integrated Security=true");
		}

		[TestMethod]
		public void InitDb()
		{
			InitDbInner();
			//var provider = new SqlServerProvider<int>((obj) => Convert.ToInt32(obj), "identity(1,1)");
			//Debug.Write(provider.CreateTableCommand(typeof(Folder)));
		}

		[TestMethod]
		public void Fill()
		{
			InitDbInner();

			using (var cn = GetConnection())
			{
				var db = new Mp3Db(cn);
				db.SyncAsync(cn, @"C:\Users\Adam\OneDrive\Music").Wait();
			}
		}

		private void InitDbInner()
		{
			using (var cn = GetConnection())
			{
				ExecuteIgnoreError(cn, "DROP TABLE [Mp3File]");
				ExecuteIgnoreError(cn, "DROP TABLE [Folder]");
				cn.CreateTable<Folder>();
				cn.CreateTable<Mp3File>();
			}
		}

		private void ExecuteIgnoreError(IDbConnection connection, string query, object parameters = null)
		{
			try
			{
				connection.Execute(query, parameters);
			}
			catch 
			{
				// do nothing
			}
		}
	}
}