using Postulate.Lite.Core;

namespace Mp3Player.Models.Queries
{
	public class ArtistMp3Files : Query<Mp3File>
	{
		public ArtistMp3Files() : base("SELECT * FROM [dbo].[Mp3File] WHERE [Artist]=@artist ORDER BY [Album], [TrackNumber]")
		{
		}

		public string Artist { get; set; }
	}
}