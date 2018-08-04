using System;
using System.IO;
using System.Linq;

namespace Mp3Player.Models
{
	public class Mp3File : LocalFileDb.Library.File
	{
		public int? TrackNumber { get; set; }
		public TimeSpan Duration { get; set; }
		public string Title { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public int? Year { get; set; }

		public override void GetMetadata(string path)
		{
			base.GetMetadata(path);

			Title = System.IO.Path.GetFileName(path);

			using (var stream = new FileStream(path, FileMode.Open))
			{
				var mp3file = new Id3.Mp3Stream(stream, Id3.Mp3Permissions.Read);
				if (mp3file.HasTags)
				{
					var tags = mp3file.GetAllTags();
					if (tags.Any())
					{
						if (!string.IsNullOrEmpty(tags[0].Title)) Title = tags[0].Title;
						Artist = tags[0].Artists;
						Album = tags[0].Album;
						TrackNumber = tags[0].Track.AsInt;
						Year = tags[0].Year.AsDateTime?.Year;
					}
				}
			}
		}
	}
}