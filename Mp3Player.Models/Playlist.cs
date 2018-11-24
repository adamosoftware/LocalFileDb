using Postulate.Lite.Core.Attributes;
using Postulate.Lite.SqlServer.IntKey;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Mp3Player.Models
{
	public class Playlist
	{
		[MaxLength(50)]
		[PrimaryKey]
		public string Name { get; set; }

		public static Playlist GetNowPlaying(IDbConnection connection)
		{
			var nowPlaying = new Playlist() { Name = "Now Playing" };
			int id = connection.Merge(nowPlaying);
			return connection.Find<Playlist>(id);
		}
	}
}