using Postulate.Lite.Core;
using Postulate.Lite.Core.Attributes;
using System;
using System.Collections.Generic;

namespace Mp3Player.Models.Queries
{
	public enum AllArtistsSortOptions
	{
		ArtistName,
		SongCount,
		LastPlayed
	}

	public class AllArtistsResult
	{
		public string Artist { get; set; }
		public string SortArtist { get; set; }
		public int? SongCount { get; set; }
		public int? AlbumCount { get; set; }
		public DateTime? LastPlayed { get; set; }

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
		public AllArtists(AllArtistsSortOptions sort = AllArtistsSortOptions.ArtistName) : base(
			$@"WITH [albums] AS (
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
				MAX([f].[LastStarted]) AS [LastPlay],
				[c].[AlbumCount]
			FROM
				[dbo].[Mp3File] [f]
				LEFT JOIN [albumCounts] [c] ON [f].[SortArtist]=[c].[SortArtist]
			WHERE
				LEN([f].[SortArtist])>0 {{andWhere}}
			GROUP BY
				[Artist],
				[f].[SortArtist],
				[c].[AlbumCount]
			ORDER BY
				{SortOptions[sort]}")
		{
		}

		[Where("[f].[SortArtist] LIKE @artistStartsWith + '%'")]
		public string ArtistStartsWith { get; set; }

		public static Dictionary<AllArtistsSortOptions, string> SortOptions
		{
			get
			{
				return new Dictionary<AllArtistsSortOptions, string>()
				{
					{ AllArtistsSortOptions.ArtistName, "[f].[SortArtist] ASC" },
					{ AllArtistsSortOptions.SongCount, "COUNT(1) DESC" },
					{ AllArtistsSortOptions.LastPlayed, "MAX([f].[LastStarted]) DESC" }
				};
			}
		}

		public static IEnumerable<AllArtists> GetTestCases()
		{
			yield return new AllArtists() { ArtistStartsWith = "a" };
			yield return new AllArtists(AllArtistsSortOptions.LastPlayed) { ArtistStartsWith = "b" };
			yield return new AllArtists(AllArtistsSortOptions.SongCount) { ArtistStartsWith = "c" };
		}
	}
}