using LocalFileDb.Library;
using Postulate.Lite.Core;
using Postulate.Lite.SqlServer.IntKey;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Tests.Extensions;

namespace Tests.Classes
{
	public class Mp3Db : FileDb<Folder, Mp3File>
	{
		public Mp3Db(IDbConnection connection) : base(connection)
		{
		}

		protected override string[] IncludeFileMasks => new string[] { "*.mp3", "*.wma" };

		protected override void Initialize(IDbConnection connection)
		{
			var cn = connection as SqlConnection;
			if (!cn.TableExists("dbo", "Folder")) cn.CreateTable<Folder>();
			if (!cn.TableExists("dbo", "Mp3File")) cn.CreateTable<Mp3File>();
		}

		protected override async Task SyncFileAsync(IDbConnection connection, Mp3File file)
		{			
			await connection.MergeAsync(file);			
		}

		protected override async Task<int> SyncFolderAsync(IDbConnection connection, Folder folder)
		{
			return await connection.MergeAsync(folder);
		}
	}
}