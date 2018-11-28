using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp3Player.Models.Queries;
using Postulate.Lite.Core;
using Postulate.Lite.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
			IEnumerable<ITestableQuery> queries = QueryTesting.GetTestCases(Assembly.GetExecutingAssembly(), "Mp3Player.Models");

			using (var cn = GetConnection())
			{				
				foreach (var qry in queries) qry.TestExecute(cn);
			}				
		}
	}
}