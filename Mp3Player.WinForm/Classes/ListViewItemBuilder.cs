using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Classes
{
	public abstract class ListViewItemBuilder<T>
	{
		public abstract ListViewItem ToListViewItem(T @object, ListViewGroup group = null);

		public ListViewItem[] GetListViewItems(IEnumerable<T> rows, ListViewGroup group = null)
		{
			return rows.Select(r => ToListViewItem(r, group)).ToArray();
		}
	}
}