using System;

namespace Mp3Player.WinForm.Models
{
	public class Settings
	{
		public string RootFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
	}
}