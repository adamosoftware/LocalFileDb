using Mp3Player.Models.Queries;
using Mp3Player.WinForm.Classes;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Models
{
	public class ArtistListViewItem : ListViewItem
	{
		public ArtistListViewItem(AllArtistsResult artist) : base(artist.Artist)
		{
			ArtistInfo = artist;
			SubItems.AddRange(new string[] { $"{artist.AlbumCount} albums", $"{artist.SongCount} songs" });
		}

		public AllArtistsResult ArtistInfo { get; }
	}

	public class AllArtistsListViewBuilder : ListViewItemBuilder<AllArtistsResult>
	{
		public override ListViewItem ToListViewItem(AllArtistsResult item, ListViewGroup group = null)
		{
			return new ArtistListViewItem(item);
		}
	}
}