using Dapper;
using LocalFileDb.Library;
using Mp3Player.Models.Extensions;
using Postulate.Lite.SqlServer.IntKey;
using System.Collections.Generic;
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
			//if (!cn.TableExists("dbo", "Playlist")) cn.CreateTable<Playlist>();
			//if (!cn.TableExists("dbo", "PlaylistFile")) cn.CreateTable<PlaylistFile>();
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
			return connection.QuerySingle<string>("SELECT [Path] FROM [dbo].[Folder] WHERE [ParentId]=0 AND [Name]='\\'");
		}

		protected override async Task<IEnumerable<Mp3File>> GetAllFilesAsync(IDbConnection connection)
		{
			return await connection.QueryAsync<Mp3File>("SELECT * FROM [dbo].[Mp3File]");
		}

		protected override async Task RemoveFileAsync(IDbConnection connection, Mp3File file)
		{
			await connection.ExecuteAsync("DELETE [dbo].[Mp3File] WHERE [Id]=@id", new { id = file.Id });
		}
	}
}