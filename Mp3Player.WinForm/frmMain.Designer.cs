namespace Mp3Player.WinForm
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tbSearch = new System.Windows.Forms.ToolStripTextBox();
			this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
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
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.cmStatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcArtistsPlaylists)).BeginInit();
			this.splcArtistsPlaylists.Panel1.SuspendLayout();
			this.splcArtistsPlaylists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splcArtistAlbums)).BeginInit();
			this.splcArtistAlbums.Panel1.SuspendLayout();
			this.splcArtistAlbums.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSearch,
            this.btnPlayPause,
            this.btnSearch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(607, 25);
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
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(46, 22);
			this.btnSearch.Text = "Search";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRootPath,
            this.tslStatus,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 258);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(607, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslRootPath
			// 
			this.tslRootPath.IsLink = true;
			this.tslRootPath.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this.tslRootPath.Name = "tslRootPath";
			this.tslRootPath.Size = new System.Drawing.Size(535, 17);
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
			this.lvLibrary.Location = new System.Drawing.Point(0, 0);
			this.lvLibrary.Name = "lvLibrary";
			this.lvLibrary.Size = new System.Drawing.Size(366, 119);
			this.lvLibrary.TabIndex = 0;
			this.lvLibrary.TileSize = new System.Drawing.Size(228, 45);
			this.lvLibrary.UseCompatibleStateImageBehavior = false;
			this.lvLibrary.View = System.Windows.Forms.View.Tile;
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
			this.splcArtistsPlaylists.Size = new System.Drawing.Size(607, 233);
			this.splcArtistsPlaylists.SplitterDistance = 366;
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
			this.splcArtistAlbums.Size = new System.Drawing.Size(366, 233);
			this.splcArtistAlbums.SplitterDistance = 141;
			this.splcArtistAlbums.TabIndex = 1;
			// 
			// alphaFilterStatusStrip1
			// 
			this.alphaFilterStatusStrip1.IsFiltered = false;
			this.alphaFilterStatusStrip1.Location = new System.Drawing.Point(0, 119);
			this.alphaFilterStatusStrip1.Name = "alphaFilterStatusStrip1";
			this.alphaFilterStatusStrip1.Size = new System.Drawing.Size(366, 22);
			this.alphaFilterStatusStrip1.SizingGrip = false;
			this.alphaFilterStatusStrip1.TabIndex = 1;
			this.alphaFilterStatusStrip1.Text = "alphaFilterStatusStrip1";
			this.alphaFilterStatusStrip1.LetterClicked += new System.EventHandler(this.alphaFilterStatusStrip1_LetterClicked);
			this.alphaFilterStatusStrip1.ShowAllClicked += new System.EventHandler(this.alphaFilterStatusStrip1_ShowAllClicked);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(607, 280);
			this.Controls.Add(this.splcArtistsPlaylists);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ao Mp3 Player";
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
			((System.ComponentModel.ISupportInitialize)(this.splcArtistAlbums)).EndInit();
			this.splcArtistAlbums.ResumeLayout(false);
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
	}
}

