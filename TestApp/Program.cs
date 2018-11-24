using LocalFileDb.Library;
using Mp3Player.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TestApp
{
	public class Program
	{
		private static SqlConnection GetConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			return new SqlConnection(connectionString);
		}

		public static void Main(string[] args)
		{			
			var progress = new Progress<SyncProgress>(ReportProgress);

			using (var cn = GetConnection())
			{
				var db = new Mp3Db(cn);
				db.SyncAsync(cn, @"C:\Users\Adam\OneDrive\Music", progress).Wait();
			}
		}

		private static void ReportProgress(SyncProgress progress)
		{
			Console.WriteLine($"{progress.Message} {progress.Elapsed.TotalSeconds.ToString()}");
		}
	}
}