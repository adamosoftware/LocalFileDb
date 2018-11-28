using Postulate.Lite.Core;
using Postulate.Lite.Core.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Mp3Player.Models.Queries
{
	public class ArtistAlbumsResult
	{
		public string Artist { get; set; }
		public string Album { get; set; }
		public int? SongCount { get; set; }
		public int? Year { get; set; }
	}

	public class ArtistAlbums : Query<ArtistAlbumsResult>, ITestableQuery
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

		public static IEnumerable<ITestableQuery> GetTestCases()
		{
			yield return new ArtistAlbums() { Artist = "Sting" };
		}

		public IEnumerable<dynamic> TestExecute(IDbConnection connection)
		{
			return TestExecuteHelper(connection);
		}
	}
}