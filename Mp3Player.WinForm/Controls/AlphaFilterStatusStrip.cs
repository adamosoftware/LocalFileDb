using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Controls
{	
	public class AlphaFilterStatusStrip : StatusStrip
	{
		public event EventHandler LetterClicked;

		public AlphaFilterStatusStrip()
		{
			SizingGrip = false;
		}

		public void Load(string[] letterGroups)
		{
			Items.Clear();

			for (int i = 0; i < letterGroups.Length; i++)
			{
				ToolStripStatusLabel label = new ToolStripStatusLabel(letterGroups[i]);
				label.Spring = (i == 0 || i == letterGroups.Length - 1);
				label.IsLink = true;
				label.TextAlign =
					(i == 0) ? ContentAlignment.MiddleRight :
					(i == letterGroups.Length - 1) ? ContentAlignment.MiddleLeft :
					ContentAlignment.MiddleCenter;
				label.Click += delegate (object sender, EventArgs e) { LetterClicked?.Invoke(label, new EventArgs()); };
				Items.Add(label);
			}
		}
	}
}