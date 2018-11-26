using Mp3Player.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Classes
{
	public class AlbumListViewItem : ListViewItem
	{
		public AlbumListViewItem(string artist, string album, IEnumerable<Mp3File> files) : base(album)
		{
			Artist = artist;
			Album = album;
			SongCount = files.Count();
			Files = files;
			SubItems.Add(artist);
			SubItems.Add($"{files.Count()} songs");
		}

		public string Artist { get; set; }
		public string Album { get; set; }
		public int SongCount { get; set; }
		public IEnumerable<Mp3File> Files { get; }
	}
}