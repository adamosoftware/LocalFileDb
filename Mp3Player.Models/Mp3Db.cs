using Dapper;
using LocalFileDb.Library;
using Mp3Player.Models.Extensions;
using Postulate.Lite.SqlServer.IntKey;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Mp3Player.Models
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

		public override string GetRootPath(IDbConnection connection)
		{
			return connection.QuerySingle<string>("SELECT [Path] FROM [dbo].[Folder] WHERE [ParentId]=0 AND [Name]='\'");
		}
	}
}