using Mp3Player.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Controls
{
	/// <summary>
	/// Provides a way to bundle a set of songs into a play command
	/// </summary>
	public class PlayToolStripButton : ToolStripButton
	{
		public PlayToolStripButton(string text, IEnumerable<Mp3File> files) : base(text)
		{
			Files = files;
		}

		public IEnumerable<Mp3File> Files { get; }
	}
}