namespace Mp3Player.WinForm.Models
{
	public class Search
	{
		/// <summary>
		/// From the search box
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// From the alpha filter bar
		/// </summary>
		public string ArtistStartsWith { get; set; }
	}
}