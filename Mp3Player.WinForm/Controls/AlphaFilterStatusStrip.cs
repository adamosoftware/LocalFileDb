using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Controls
{	
	public class AlphaFilterStatusStrip : StatusStrip
	{
		public event EventHandler LetterClicked;
		public event EventHandler ShowAllClicked;

		public AlphaFilterStatusStrip()
		{
			SizingGrip = false;
		}

		public bool IsFiltered { get; set; }

		public void Load(string[] letterGroups, string selected = null)
		{
			Items.Clear();

			for (int i = 0; i < letterGroups.Length; i++)
			{
				ToolStripStatusLabel label = new ToolStripStatusLabel(letterGroups[i]);
				if (selected?.Equals(letterGroups[i]) ?? false) label.Font = new Font(this.Font, FontStyle.Bold);
				label.Spring = (i == 0 || i == letterGroups.Length - 1);
				label.IsLink = true;
				label.TextAlign =
					(i == 0) ? ContentAlignment.MiddleRight :
					(i == letterGroups.Length - 1) ? ContentAlignment.MiddleLeft :
					ContentAlignment.MiddleCenter;

				label.Click += delegate (object sender, EventArgs e) 
				{
					label.Font = new Font(this.Font, FontStyle.Bold);
					LetterClicked?.Invoke(label, new EventArgs());
					IsFiltered = true;					
				};

				Items.Add(label);
			}

			if (IsFiltered)
			{
				var showAllLabel = new ToolStripStatusLabel("show all");
				showAllLabel.Spring = true;
				showAllLabel.TextAlign = ContentAlignment.MiddleLeft;
				showAllLabel.IsLink = true;
				showAllLabel.Click += delegate (object sender, EventArgs e)
				{
					IsFiltered = false;
					ShowAllClicked?.Invoke(showAllLabel, e);
				};

				var lastLetter = Items[letterGroups.Length - 1] as ToolStripStatusLabel;
				lastLetter.Spring = false;
				lastLetter.TextAlign = ContentAlignment.MiddleCenter;

				Items.Add(showAllLabel);
			}
		}
	}
}