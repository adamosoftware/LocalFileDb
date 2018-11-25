using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LocalFileDb.Library
{
	public abstract class FileDb<TFolder, TFile> 
		where TFolder : Folder, new()
		where TFile : File, new()
	{
		private string _path;

		public FileDb(IDbConnection connection)
		{
			Initialize(connection);
			Added = new List<TFile>();
			Removed = new List<TFile>();
		}

		public List<TFile> Added { get; private set; }
		public List<TFile> Removed { get; private set; }
		public TimeSpan Elapsed { get; private set; }

		protected abstract string[] IncludeFileMasks { get; }

		/// <summary>
		/// Use this to validate and create database objects needed to save the file system data
		/// </summary>		
		protected abstract void Initialize(IDbConnection connection);

		/// <summary>
		/// Finds or creates a Folder record
		/// </summary>
		protected abstract Task<int> SyncFolderAsync(IDbConnection connection, TFolder folder);

		/// <summary>
		/// Finds or creates a File record
		/// </summary>
		protected abstract Task SyncFileAsync(IDbConnection connection, TFile file);

		protected abstract Task<IEnumerable<TFile>> GetAllFilesAsync(IDbConnection connection);

		protected abstract Task RemoveFileAsync(IDbConnection connection, TFile file);

		/// <summary>
		/// Adds newly discovered files to the database, and removes those that have been deleted, while logging changes
		/// </summary>
		public async Task SyncAsync(IDbConnection connection, string path, IProgress<SyncProgress> progress = null)
		{
			var sw = Stopwatch.StartNew();

			_path = path;
			var folder = new TFolder() { Name = ToLocal(path), Path = path };
			int folderId = await SyncFolderAsync(connection, folder);
			
			await SyncFilesAsync(connection, folder, sw, progress);
			await SyncDirectoriesAsync(connection, folder, sw, progress);
			await RemoveMissingFilesAsync(connection, sw, progress);

			sw.Stop();
			Elapsed = sw.Elapsed;
		}

		private async Task RemoveMissingFilesAsync(IDbConnection connection, Stopwatch stopwatch, IProgress<SyncProgress> progress)
		{
			progress?.Report(new SyncProgress() { Message = "Removing deleted files...", Elapsed = stopwatch.Elapsed });

			var allFiles = await GetAllFilesAsync(connection);

			string rootPath = GetRootPath(connection);

			foreach (var file in allFiles)
			{
				if (!System.IO.File.Exists(Path.Combine(rootPath, file.Path)))
				{
					Removed.Add(file);
					progress?.Report(new SyncProgress() { Message = $"Removing {file.Path}", Elapsed = stopwatch.Elapsed });
					await RemoveFileAsync(connection, file);
				}
			}
		}

		public abstract string GetRootPath(IDbConnection connection);		

		public string GetFullPath(IDbConnection connection, TFile file)
		{
			return Path.Combine(GetRootPath(connection), file.Path);
		}

		private async Task SyncDirectoriesAsync(IDbConnection connection, TFolder folder, Stopwatch stopwatch, IProgress<SyncProgress> progress)
		{
			progress?.Report(new SyncProgress() { Message = $"Scanning directories in {folder.Path}", Elapsed = stopwatch.Elapsed });

			string[] folders = Directory.GetDirectories(folder.Path);

			foreach (string subDir in folders)
			{
				var subfolder = new TFolder() { ParentId = folder.Id, Name = Path.GetFileName(subDir), Path = subDir };
				await SyncFolderAsync(connection, subfolder);
				await SyncFilesAsync(connection, subfolder, stopwatch, progress);
				await SyncDirectoriesAsync(connection, subfolder, stopwatch, progress);
			}
		}

		private async Task SyncFilesAsync(IDbConnection connection, TFolder folder, Stopwatch stopwatch, IProgress<SyncProgress> progress = null)
		{
			progress?.Report(new SyncProgress() { Message = $"Getting files in {folder.Path}", Elapsed = stopwatch.Elapsed });

			foreach (string mask in IncludeFileMasks)
			{
				string[] files = Directory.GetFiles(folder.Path, mask, SearchOption.TopDirectoryOnly);

				foreach (var fileName in files)
				{
					FileInfo fi = new FileInfo(fileName);

					var file = new TFile()
					{
						FolderId = folder.Id,
						Name = Path.GetFileName(fileName),
						Path = ToLocal(fileName),
						DateCreated = fi.CreationTimeUtc,
						DateModified = fi.LastWriteTimeUtc,
						Size = fi.Length
					};
					Added.Add(file);

					file.GetMetadata(fileName);
					await SyncFileAsync(connection, file);
				}
			}
		}

		private string ToLocal(string path)
		{
			return (path.Length > _path.Length) ? path.Substring(_path.Length + 1) : "\\";
		}
	}
}