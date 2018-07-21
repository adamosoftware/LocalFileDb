using LocalFileDb.Library;
using System;

namespace Tests.Classes
{
	public class Mp3File : File
	{
		public int TrackNumber { get; set; }
		public TimeSpan Duration { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public int Year { get; set; }
	}
}