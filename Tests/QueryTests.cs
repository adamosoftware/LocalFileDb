using Microsoft.VisualStudio.TestTools.UnitTesting;
using Postulate.Lite.Core;
using System;
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
		public void TestQueries()
		{
			var modelAssembly = FindReferencedAssembly("Mp3Player.Models");
			var allTypes = modelAssembly.GetExportedTypes();
			var queryTypes = allTypes.Where(t => IsSubclassOfRawGeneric(typeof(Query<>), t));

			using (var cn = GetConnection())
			{
				foreach (var qryType in queryTypes)
				{
					var getTestCasesMethod = qryType.GetMethod("GetTestCases");
					if (getTestCasesMethod?.IsStatic ?? false)
					{
						//getTestCasesMethod.Invoke()
					}
				}
			}
		}

		private Assembly FindReferencedAssembly(string assemblyName)
		{
			var name = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Single(a => a.Name.Equals(assemblyName));
			return Assembly.Load(name);
		}

		/// <summary>
		/// From https://stackoverflow.com/a/457708/2023653
		/// </summary>
		private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
		{
			while (toCheck != null && toCheck != typeof(object))
			{
				var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
				if (generic == cur)
				{
					return true;
				}
				toCheck = toCheck.BaseType;
			}
			return false;
		}
	}
}