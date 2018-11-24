using Postulate.Lite.Core.Attributes;

namespace Mp3Player.Models
{
	public class PlaylistFile
	{
		[References(typeof(Playlist))]
		[PrimaryKey]
		public int PlaylistId { get; set; }

		[References(typeof(Mp3File))]
		[PrimaryKey]
		public int FileId { get; set; }

		public int Order { get; set; }
	}
}