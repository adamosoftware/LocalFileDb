using JsonSettings;
using LocalFileDb.Library;
using Mp3Player.Models;
using Mp3Player.Models.Queries;
using Mp3Player.WinForm.Classes;
using Mp3Player.WinForm.Controls;
using Mp3Player.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mp3Player.WinForm
{
	public partial class frmMain : Form
	{
		private Settings _settings;
		private string[] _letterGroups = null;

		public frmMain()
		{
			InitializeComponent();
			dgvSearchResults.AutoGenerateColumns = false;
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

				FillSortOptions();

				await LoadLibraryAsync();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void FillSortOptions()
		{
			cbSort.Items.Clear();
			var names = Enum.GetNames(typeof(AllArtistsSortOptions)).OfType<string>().ToArray();
			var values = Enum.GetValues(typeof(AllArtistsSortOptions)).OfType<AllArtistsSortOptions>().ToArray();
			int index = 0;
			foreach (string name in names)
			{
				var item = new ComboBoxItem<AllArtistsSortOptions>(values[index], names[index]);
				cbSort.Items.Add(item);
				if (values[index] == _settings.Sort) cbSort.SelectedItem = item;
				index++;
			}			
		}

		private async Task LoadLibraryAsync(Search search = null)
		{
			lvLibrary.Items.Clear();

			await RunQuery(async (cn) =>
			{
				var sort = ((cbSort.SelectedItem as ComboBoxItem<AllArtistsSortOptions>)?.Value ?? AllArtistsSortOptions.ArtistName);
				var allArtistsQry = new AllArtists(sort);
				if (!string.IsNullOrEmpty(search?.ArtistStartsWith)) allArtistsQry.ArtistStartsWith = search.ArtistStartsWith;
				var allArtists = await allArtistsQry.ExecuteAsync(cn);
				var items = new AllArtistsListViewBuilder();
				lvLibrary.Items.AddRange(items.GetListViewItems(allArtists));

				if (_letterGroups == null)
				{
					_letterGroups = allArtists.GroupBy(row => row.GetLetterGroup()).Select(grp => grp.Key).OrderBy(item => item).ToArray();
				}
				alphaFilterStatusStrip1.Load(_letterGroups, search?.ArtistStartsWith);
			});
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
			ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
			psi.Arguments = _settings.RootFolder;
			Process.Start(psi);
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

		private async void alphaFilterStatusStrip1_LetterClicked(object sender, EventArgs e)
		{
			var label = sender as ToolStripStatusLabel;
			await LoadLibraryAsync(new Search() { ArtistStartsWith = label.Text });
		}

		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3)
			{
				tbSearch.Focus();
				e.Handled = true;
			}
		}

		private async void alphaFilterStatusStrip1_ShowAllClicked(object sender, EventArgs e)
		{
			await LoadLibraryAsync();
		}

		private async void cbSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbSort.SelectedItem != null)
			{
				_settings.Sort = (cbSort.SelectedItem as ComboBoxItem<AllArtistsSortOptions>).Value;
				await LoadLibraryAsync();
			}			
		}

		private async void lvLibrary_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			try
			{
				tbSearch.Text = null;
				if (e.IsSelected)
				{
					var artistInfo = (e.Item as ArtistListViewItem)?.ArtistInfo;
					if (artistInfo != null)
					{
						await RunQuery(async (cn) =>
						{
							var data = await new ArtistMp3Files() { Artist = artistInfo.Artist }.ExecuteAsync(cn);
							FillPlayDropdowns(data);
							dgvSearchResults.DataSource = data;							
							FillAlbumListView(data);
						});
					}
				}				
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void FillAlbumListView(IEnumerable<Mp3File> mp3Files)
		{
			lvAlbums.Items.Clear();

			var albums = mp3Files.Where(row => !string.IsNullOrEmpty(row.Album))
				.GroupBy(row => new { row.Artist, row.Album })
				.OrderBy(item => item.Key.Album).ToArray();			

			if (albums.Count() == 1)
			{
				splitContainer1.Panel1Collapsed = true;
				return;
			}				
			else
			{
				splitContainer1.Panel1Collapsed = false;
			}

			foreach (var albumGrp in albums)
			{
				var item = new AlbumListViewItem(albumGrp.Key.Artist, albumGrp.Key.Album, albumGrp);
				lvAlbums.Items.Add(item);
			}

			var artists = mp3Files
				.Where(row => !string.IsNullOrEmpty(row.Artist))
				.GroupBy(row => row.Artist.ToLower())
				.Select(grp => grp.Key).ToArray();
			if (artists.Length == 1)
			{
				var showAll = new AlbumListViewItem(artists[0], "[ show all ]", mp3Files);
				lvAlbums.Items.Add(showAll);
			}
		}

		private void FillPlayDropdowns(IEnumerable<Mp3File> data)
		{
			var artists = data.GroupBy(row => row.Artist);
			if (artists.Count() > 1)
			{
				btnPlayArtist.Visible = true;
				btnPlayArtist.DropDownItems.Clear();
				foreach (var artistGrp in artists) btnPlayArtist.DropDownItems.Add(new PlayToolStripButton(artistGrp.Key, artistGrp));
			}
			else
			{
				btnPlayArtist.Visible = false;
			}

			var albums = data.GroupBy(row => new { row.Artist, row.Album });
			btnPlayAlbum.Visible = albums.Any();
			btnPlayAlbum.DropDownItems.Clear();
			foreach (var albumGrp in albums) btnPlayAlbum.DropDownItems.Add(new PlayToolStripButton($"{albumGrp.Key.Artist} - {albumGrp.Key.Album}", albumGrp));
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				await RunQuery(async (cn) =>
				{
					var results = await new SearchMp3Files() { Search = tbSearch.Text }.ExecuteAsync(cn);
					FillPlayDropdowns(results);
					if (results.Any())
					{						
						dgvSearchResults.DataSource = results;
						FillAlbumListView(results);
					}
					else
					{						
						MessageBox.Show("No results found.");
					}
				});
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private async Task RunQuery(Func<IDbConnection, Task> queryAction)
		{
			using (var cn = GetConnection())
			{
				tslStatus.Text = "Querying...";
				await queryAction.Invoke(cn);
				tslStatus.Text = "Ready";
			}
		}

		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbSearch.Text.Length >= 3)
			{
				btnSearch_Click(sender, e);
				e.Handled = true;
			}
		}

		private void lvAlbums_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			var files = (e.Item as AlbumListViewItem)?.Files.ToArray();
			if (files != null) dgvSearchResults.DataSource = files;
		}
	}
}