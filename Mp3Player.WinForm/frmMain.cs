using JsonSettings;
using LocalFileDb.Library;
using Mp3Player.Models;
using Mp3Player.Models.Queries;
using Mp3Player.WinForm.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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

		private IDbConnection GetConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			return new SqlConnection(connectionString);
		}

		private void tslRootPath_Click(object sender, EventArgs e)
		{
			cmStatusBar.Show(statusStrip1, new Point() { X = 0, Y = statusStrip1.Height });
		}

		private async void frmMain_Load(object sender, EventArgs e)
		{
			try
			{
				_settings = JsonSettingsBase.Load<Settings>();
				_settings.FormPosition?.ApplyToForm(this);				

				tslRootPath.Text = _settings.RootFolder;
				tslStatus.Text = "Ready";

				await LoadLibraryAsync();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private async Task LoadLibraryAsync()
		{
			using (var cn = GetConnection())
			{
				var allArtistsGrp = new ListViewGroup("All Artists") { Name = "AllArtists" };
				lvLibrary.Groups.Add(allArtistsGrp);				
				
				var allArtists = await new AllArtists().ExecuteAsync(cn);
				var items = new AllArtistsListViewBuilder();
				lvLibrary.Items.AddRange(items.GetListViewItems(allArtists, allArtistsGrp));

				alphaFilterStatusStrip1.Load(allArtists.GroupBy(row => row.GetLetterGroup()).Select(grp => grp.Key).ToArray());
				//foreach (var item in allArtists) allArtistsGrp.Items.AddRange()
				
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

		private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStripProgressBar1.Visible = true;
			toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
			tslRootPath.Visible = false;

			try
			{
				using (var cn = GetConnection())
				{
					var db = new Mp3Db(cn);					
					var progress = new Progress<SyncProgress>(UpdateProgress);
					await db.SyncAsync(cn, _settings.RootFolder, progress);
					MessageBox.Show($"Songs added: {db.Added.Count}, removed: {db.Removed.Count}, time elapsed: {db.Elapsed.TotalSeconds:n0} seconds");
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

			tslRootPath.Visible = true;
			toolStripProgressBar1.Visible = false;
			tslStatus.Text = "Ready";
		}

		private void UpdateProgress(SyncProgress obj)
		{
			tslStatus.Text = obj.Message;
		}
	}
}