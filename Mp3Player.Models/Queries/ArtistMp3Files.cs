using Postulate.Lite.Core;
using Postulate.Lite.Core.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Mp3Player.Models.Queries
{
	public class ArtistMp3Files : Query<Mp3File>, ITestableQuery
	{
		public ArtistMp3Files() : base("SELECT * FROM [dbo].[Mp3File] WHERE [Artist]=@artist ORDER BY [Album], [TrackNumber]")
		{
		}

		public string Artist { get; set; }

		public static IEnumerable<ITestableQuery> GetTestCases()
		{
			yield return new ArtistMp3Files() { Artist = "Sting" };
		}

		public IEnumerable<dynamic> TestExecute(IDbConnection connection)
		{
			return TestExecuteHelper(connection);
		}
	}
}