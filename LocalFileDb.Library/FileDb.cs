using System;
using System.Data;
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
		}

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

		/// <summary>
		/// Adds newly discovered files to the database, and removes those that have been deleted, while logging changes
		/// </summary>
		public async Task SyncAsync(IDbConnection connection, string path, IProgress<string> progress = null)
		{
			_path = path;
			var folder = new TFolder() { Name = ToLocal(path), Path = path };
			int folderId = await SyncFolderAsync(connection, folder);

			await SyncFilesAsync(connection, folder, progress);
			await SyncDirectoriesAsync(connection, folder, progress);
		}

		private async Task SyncDirectoriesAsync(IDbConnection connection, TFolder folder, IProgress<string> progress)
		{
			progress?.Report($"Scanning directories in {folder.Path}");

			string[] folders = Directory.GetDirectories(folder.Path);

			foreach (string subDir in folders)
			{
				var subfolder = new TFolder() { ParentId = folder.Id, Name = Path.GetFileName(subDir), Path = ToLocal(subDir) };
				await SyncFolderAsync(connection, subfolder);
				await SyncFilesAsync(connection, subfolder, progress);
				await SyncDirectoriesAsync(connection, subfolder, progress);
			}
		}

		private async Task SyncFilesAsync(IDbConnection connection, TFolder folder, IProgress<string> progress = null)
		{
			progress?.Report($"Getting files in {folder.Path}");

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