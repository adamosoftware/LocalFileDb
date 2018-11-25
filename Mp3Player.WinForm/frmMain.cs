using JsonSettings;
using Mp3Player.WinForm.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mp3Player.WinForm
{
	public partial class frmMain : Form
	{
		private Settings _settings;

		public frmMain()
		{
			InitializeComponent();
		}

		private void tslRootPath_Click(object sender, EventArgs e)
		{
			cmStatusBar.Show(statusStrip1, new Point() { X = 0, Y = statusStrip1.Height });
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			try
			{
				_settings = JsonSettingsBase.Load<Settings>();
				_settings.FormPosition?.ApplyToForm(this);

				tslRootPath.Text = _settings.RootFolder;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				_settings.FormPosition = FormPosition.FromForm(this);
				_settings.Save();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void selectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				_settings.RootFolder = dlg.SelectedPath;
			}
		}

		private void viewToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}