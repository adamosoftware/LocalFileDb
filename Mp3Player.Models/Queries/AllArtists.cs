using Postulate.Lite.Core;
using Postulate.Lite.Core.Attributes;

namespace Mp3Player.Models.Queries
{
	public class AllArtistsResult
	{
		public string Artist { get; set; }
		public string SortArtist { get; set; }
		public int? SongCount { get; set; }
		public int? AlbumCount { get; set; }

		/// <summary>
		/// Required for bands like 'Til Tuesday that start with a non-letter character.
		/// The letter group for 'Till Tuesday would be 'T
		/// </summary>
		public string GetLetterGroup()
		{
			int index = 0;
			while (!char.IsLetterOrDigit(SortArtist[index]))
			{
				index++;				
			}
			return SortArtist.Substring(0, index + 1).ToUpper();
		}
	}

	public class AllArtists : Query<AllArtistsResult>
	{
		public AllArtists() : base(
			@"WITH [albums] AS (
				SELECT
					[SortArtist],
					[Album]
				FROM
					[dbo].[Mp3File]
				WHERE
					LEN([SortArtist])>0 AND LEN([Album])>0
				GROUP BY
					[SortArtist], [Album]
			), [albumCounts] AS (
				SELECT [SortArtist], COUNT(1) AS [AlbumCount]
				FROM [albums]
				GROUP BY [SortArtist]
			) SELECT
				[f].[Artist],
				[f].[SortArtist],
				COUNT(1) AS [SongCount],
				[c].[AlbumCount]
			FROM
				[dbo].[Mp3File] [f]
				LEFT JOIN [albumCounts] [c] ON [f].[SortArtist]=[c].[SortArtist]
			WHERE
				LEN([f].[SortArtist])>0 {andWhere}
			GROUP BY
				[Artist],
				[f].[SortArtist],
				[c].[AlbumCount]
			ORDER BY
				[f].[SortArtist]")
		{
		}

		[Where("[f].[SortArtist] LIKE @artistStartsWith + '%'")]
		public string ArtistStartsWith { get; set; }
	}
}