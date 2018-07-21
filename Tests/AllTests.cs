using Dapper;
using LocalFileDb.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Postulate.Lite.SqlServer.IntKey;
using System.Data.SqlClient;
using Tests.Classes;

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

		public void Fill()
		{			
			using (var cn = GetConnection())
			{
				var db = new Mp3Db(cn);
				db.SyncAsync(cn, @"C:\Users\Adam\SkyDrive\Music").Wait();
			}
		}

		private void InitDbInner()
		{
			using (var cn = GetConnection())
			{
				cn.Execute("DROP TABLE [Mp3File]");
				cn.Execute("DROP TABLE [Folder]");
				cn.CreateTable<Folder>();
				cn.CreateTable<Mp3File>();
			}
		}
	}
}