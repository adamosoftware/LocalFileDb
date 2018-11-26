using Postulate.Lite.Core;

namespace Mp3Player.Models.Queries
{
	public class SearchMp3Files : Query<Mp3File>
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
	}
}