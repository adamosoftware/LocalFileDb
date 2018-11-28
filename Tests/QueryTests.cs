using Microsoft.VisualStudio.TestTools.UnitTesting;
using Postulate.Lite.Core;
using Postulate.Lite.Core.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Tests
{
	[TestClass]
	public class QueryTests
	{
		private static SqlConnection GetConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			return new SqlConnection(connectionString);
		}

		[TestMethod]
		public void TestMp3PlayerModelQueries()
		{
			// gets all the query test cases from the model assembly, where queries in this solution are defined
			IEnumerable<ITestableQuery> queries = QueryTesting.GetTestCases(Assembly.GetExecutingAssembly(), "Mp3Player.Models");

			using (var cn = GetConnection())
			{
				foreach (var qry in queries) qry.TestExecute(cn);
			}
		}
	}
}