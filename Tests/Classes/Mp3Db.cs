using LocalFileDb.Library;
using Postulate.Lite.SqlServer.IntKey;
using System;
using System.Data;
using System.Data.SqlClient;
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

		protected override Task SyncFileAsync(IDbConnection connection, Mp3File file)
		{
			var criteria = new Mp3File() { FolderId = file.FolderId, Name = file.Name };
			// need to implement async crud methods
			//return connection.FindWhere(criteria);
			throw new NotImplementedException();
		}

		protected override Task<int> SyncFolderAsync(IDbConnection connection, Folder folder)
		{
			throw new NotImplementedException();
		}
	}
}