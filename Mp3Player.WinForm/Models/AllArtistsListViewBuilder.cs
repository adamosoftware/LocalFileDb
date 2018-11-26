using Mp3Player.Models.Queries;
using Mp3Player.WinForm.Classes;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Models
{
	public class AllArtistsListViewBuilder : ListViewItemBuilder<AllArtistsResult>
	{
		public override ListViewItem ToListViewItem(AllArtistsResult item, ListViewGroup group = null)
		{
			var result = new ListViewItem() { Text = item.Artist };
			if (group != null) result.Group = group;
			result.SubItems.AddRange(new string[] { $"{item.AlbumCount} albums", $"{item.SongCount} songs" });
			return result;
		}
	}
}