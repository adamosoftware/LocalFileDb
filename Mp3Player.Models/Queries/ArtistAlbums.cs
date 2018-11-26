using Postulate.Lite.Core;

namespace Mp3Player.Models.Queries
{
	public class ArtistAlbumsResult
	{
		public string Artist { get; set; }
		public string Album { get; set; }
		public int? SongCount { get; set; }
		public int? Year { get; set; }
	}

	public class ArtistAlbums : Query<ArtistAlbumsResult>
	{
		public ArtistAlbums() : base(
			@"SELECT
				[Artist],
				[Album],
				COUNT(1) AS [SongCount],
				MAX([Year]) AS [Year]
			FROM
				[dbo].[Mp3File]
			WHERE
				[Artist]=@artist AND
				LEN([Album]) > 0
			GROUP BY
				[Artist],				
				[Album]
			ORDER BY
				[Album]")
		{
		}

		public string Artist { get; set; }
	}
}