﻿namespace Mp3Player.WinForm
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tbSearch = new System.Windows.Forms.ToolStripTextBox();
			this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
			this.cbSort = new System.Windows.Forms.ToolStripComboBox();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslRootPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.lvLibrary = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmStatusBar = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splcArtistsPlaylists = new System.Windows.Forms.SplitContainer();
			this.splcArtistAlbums = new System.Windows.Forms.SplitContainer();
			this.alphaFilterStatusStrip1 = new Mp3Player.WinForm.Controls.AlphaFilterStatusStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.dgvSearchResults = new System.Windows.Forms.DataGridView();
			this.colTrackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.cmStatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcArtistsPlaylists)).BeginInit();
			this.splcArtistsPlaylists.Panel1.SuspendLayout();
			this.splcArtistsPlaylists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcArtistAlbums)).BeginInit();
			this.splcArtistAlbums.Panel1.SuspendLayout();
			this.splcArtistAlbums.Panel2.SuspendLayout();
			this.splcArtistAlbums.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbSort,
            this.tbSearch,
            this.btnPlayPause,
            this.btnSearch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(702, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tbSearch
			// 
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(150, 25);
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.Image")));
			this.btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(49, 22);
			this.btnPlayPause.Text = "Play";
			// 
			// cbSort
			// 
			this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSort.Name = "cbSort";
			this.cbSort.Size = new System.Drawing.Size(121, 25);
			this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(46, 22);
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRootPath,
            this.tslStatus,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 381);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(702, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslRootPath
			// 
			this.tslRootPath.IsLink = true;
			this.tslRootPath.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this.tslRootPath.Name = "tslRootPath";
			this.tslRootPath.Size = new System.Drawing.Size(630, 17);
			this.tslRootPath.Spring = true;
			this.tslRootPath.Text = "(root path)";
			this.tslRootPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tslRootPath.Click += new System.EventHandler(this.tslRootPath_Click);
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(55, 17);
			this.tslStatus.Text = "{0} songs";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// lvLibrary
			// 
			this.lvLibrary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvLibrary.HideSelection = false;
			this.lvLibrary.Location = new System.Drawing.Point(0, 0);
			this.lvLibrary.MultiSelect = false;
			this.lvLibrary.Name = "lvLibrary";
			this.lvLibrary.Size = new System.Drawing.Size(461, 173);
			this.lvLibrary.TabIndex = 0;
			this.lvLibrary.TileSize = new System.Drawing.Size(228, 45);
			this.lvLibrary.UseCompatibleStateImageBehavior = false;
			this.lvLibrary.View = System.Windows.Forms.View.Tile;
			this.lvLibrary.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvLibrary_ItemSelectionChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Albums";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Songs";
			// 
			// cmStatusBar
			// 
			this.cmStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem});
			this.cmStatusBar.Name = "cmStatusBar";
			this.cmStatusBar.Size = new System.Drawing.Size(151, 70);
			// 
			// selectToolStripMenuItem
			// 
			this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
			this.selectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.selectToolStripMenuItem.Text = "Select Folder...";
			this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.viewToolStripMenuItem.Text = "View Folder";
			this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.refreshToolStripMenuItem.Text = "Update Music";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// splcArtistsPlaylists
			// 
			this.splcArtistsPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splcArtistsPlaylists.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splcArtistsPlaylists.Location = new System.Drawing.Point(0, 25);
			this.splcArtistsPlaylists.Name = "splcArtistsPlaylists";
			// 
			// splcArtistsPlaylists.Panel1
			// 
			this.splcArtistsPlaylists.Panel1.Controls.Add(this.splcArtistAlbums);
			this.splcArtistsPlaylists.Size = new System.Drawing.Size(702, 356);
			this.splcArtistsPlaylists.SplitterDistance = 461;
			this.splcArtistsPlaylists.TabIndex = 2;
			// 
			// splcArtistAlbums
			// 
			this.splcArtistAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splcArtistAlbums.Location = new System.Drawing.Point(0, 0);
			this.splcArtistAlbums.Name = "splcArtistAlbums";
			this.splcArtistAlbums.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splcArtistAlbums.Panel1
			// 
			this.splcArtistAlbums.Panel1.Controls.Add(this.lvLibrary);
			this.splcArtistAlbums.Panel1.Controls.Add(this.alphaFilterStatusStrip1);
			// 
			// splcArtistAlbums.Panel2
			// 
			this.splcArtistAlbums.Panel2.Controls.Add(this.dgvSearchResults);
			this.splcArtistAlbums.Size = new System.Drawing.Size(461, 356);
			this.splcArtistAlbums.SplitterDistance = 195;
			this.splcArtistAlbums.TabIndex = 1;
			// 
			// alphaFilterStatusStrip1
			// 
			this.alphaFilterStatusStrip1.IsFiltered = false;
			this.alphaFilterStatusStrip1.Location = new System.Drawing.Point(0, 173);
			this.alphaFilterStatusStrip1.Name = "alphaFilterStatusStrip1";
			this.alphaFilterStatusStrip1.Size = new System.Drawing.Size(461, 22);
			this.alphaFilterStatusStrip1.SizingGrip = false;
			this.alphaFilterStatusStrip1.TabIndex = 1;
			this.alphaFilterStatusStrip1.Text = "alphaFilterStatusStrip1";
			this.alphaFilterStatusStrip1.LetterClicked += new System.EventHandler(this.alphaFilterStatusStrip1_LetterClicked);
			this.alphaFilterStatusStrip1.ShowAllClicked += new System.EventHandler(this.alphaFilterStatusStrip1_ShowAllClicked);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
			this.toolStripLabel1.Text = "Sort artists:";
			// 
			// dgvSearchResults
			// 
			this.dgvSearchResults.AllowUserToAddRows = false;
			this.dgvSearchResults.AllowUserToDeleteRows = false;
			this.dgvSearchResults.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.dgvSearchResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrackNumber,
            this.colTitle,
            this.colArtist,
            this.colAlbum,
            this.colPath,
            this.colYear});
			this.dgvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSearchResults.Location = new System.Drawing.Point(0, 0);
			this.dgvSearchResults.Name = "dgvSearchResults";
			this.dgvSearchResults.ReadOnly = true;
			this.dgvSearchResults.RowHeadersVisible = false;
			this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSearchResults.Size = new System.Drawing.Size(461, 157);
			this.dgvSearchResults.TabIndex = 0;
			// 
			// colTrackNumber
			// 
			this.colTrackNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.colTrackNumber.DataPropertyName = "TrackNumber";
			this.colTrackNumber.HeaderText = "#";
			this.colTrackNumber.Name = "colTrackNumber";
			this.colTrackNumber.ReadOnly = true;
			this.colTrackNumber.Width = 41;
			// 
			// colTitle
			// 
			this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colTitle.DataPropertyName = "Title";
			this.colTitle.HeaderText = "Title";
			this.colTitle.Name = "colTitle";
			this.colTitle.ReadOnly = true;
			// 
			// colArtist
			// 
			this.colArtist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colArtist.DataPropertyName = "Artist";
			this.colArtist.HeaderText = "Artist";
			this.colArtist.Name = "colArtist";
			this.colArtist.ReadOnly = true;
			// 
			// colAlbum
			// 
			this.colAlbum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colAlbum.DataPropertyName = "Album";
			this.colAlbum.HeaderText = "Album";
			this.colAlbum.Name = "colAlbum";
			this.colAlbum.ReadOnly = true;
			// 
			// colPath
			// 
			this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colPath.DataPropertyName = "Path";
			this.colPath.HeaderText = "Path";
			this.colPath.Name = "colPath";
			this.colPath.ReadOnly = true;
			// 
			// colYear
			// 
			this.colYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colYear.DataPropertyName = "Year";
			this.colYear.HeaderText = "Year";
			this.colYear.Name = "colYear";
			this.colYear.ReadOnly = true;
			this.colYear.Width = 57;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 403);
			this.Controls.Add(this.splcArtistsPlaylists);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AOMP3";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.cmStatusBar.ResumeLayout(false);
			this.splcArtistsPlaylists.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splcArtistsPlaylists)).EndInit();
			this.splcArtistsPlaylists.ResumeLayout(false);
			this.splcArtistAlbums.Panel1.ResumeLayout(false);
			this.splcArtistAlbums.Panel1.PerformLayout();
			this.splcArtistAlbums.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splcArtistAlbums)).EndInit();
			this.splcArtistAlbums.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tslRootPath;
		private System.Windows.Forms.ToolStripTextBox tbSearch;
		private System.Windows.Forms.ToolStripStatusLabel tslStatus;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripButton btnPlayPause;
		private System.Windows.Forms.ListView lvLibrary;
		private System.Windows.Forms.ContextMenuStrip cmStatusBar;
		private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStripButton btnSearch;
		private System.Windows.Forms.SplitContainer splcArtistsPlaylists;
		private System.Windows.Forms.SplitContainer splcArtistAlbums;
		private Controls.AlphaFilterStatusStrip alphaFilterStatusStrip1;
		private System.Windows.Forms.ToolStripComboBox cbSort;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.DataGridView dgvSearchResults;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTrackNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAlbum;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
	}
}

