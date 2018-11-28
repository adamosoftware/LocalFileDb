using Postulate.Lite.Core;
using Postulate.Lite.Core.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Mp3Player.Models.Queries
{
	public class SearchMp3Files : Query<Mp3File>, ITestableQuery
	{
		public SearchMp3Files() : base(
			@"SELECT
				[f].*
			FROM 
				[dbo].[Mp3File] [f]
			WHERE
				[Artist] LIKE '%'+@search+'%' OR
				[Album] LIKE '%'+@search+'%' OR
				[Title] LIKE '%'+@search+'%' OR
				[Path] LIKE '%'+@search+'%' OR
				EXISTS(SELECT 1 FROM [dbo].[PlaylistFile] [pf] INNER JOIN [dbo].[Playlist] [p] ON [pf].[PlaylistId]=[p].[Id] WHERE [pf].[FileId]=[f].[Id] AND [p].[Name] LIKE '%'+@search+'%')
			ORDER BY 
				[SortArtist], 
				[Album], 
				[TrackNumber]")
		{
		}

		public string Search { get; set; }

		public static IEnumerable<ITestableQuery> GetTestCases()
		{
			yield return new SearchMp3Files() { Search = "Shallow" };
		}

		public IEnumerable<dynamic> TestExecute(IDbConnection connection)
		{
			return TestExecuteHelper(connection);
		}
	}
}