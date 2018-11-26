namespace Mp3Player.WinForm.Models
{
	public class ComboBoxItem<T>
	{
		public ComboBoxItem(T value, string text)
		{
			Value = value;
			Text = text;
		}

		public T Value { get; }
		public string Text { get; }

		public override string ToString()
		{
			return Text;
		}
	}
}