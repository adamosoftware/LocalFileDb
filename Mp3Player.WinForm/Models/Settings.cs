using JsonSettings;
using System;

namespace Mp3Player.WinForm.Models
{
	public class Settings : JsonSettingsBase
	{
		public override Scope Scope => Scope.User;

		public override string CompanyName => "Adam O'Neil Software";

		public override string ProductName => "AoMp3Player";

		public override string Filename => "settings.json";

		public string RootFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

		public FormPosition FormPosition { get; set; }
	}
}