using System.Drawing;
using System.Windows.Forms;

namespace Mp3Player.WinForm.Models
{
	public class FormPosition
	{
		public FormWindowState WindowState { get; set; } = FormWindowState.Minimized;
		public Size Size { get; set; }
		public Point Location { get; set; }

		public static FormPosition FromForm(Form form)
		{
			return new FormPosition()
			{
				WindowState = form.WindowState,
				Size = form.Size,
				Location = form.Location
			};
		}

		public void ApplyToForm(Form form)
		{
			if (WindowState == FormWindowState.Maximized)
			{
				form.WindowState = FormWindowState.Maximized;
			}
			else if (WindowState == FormWindowState.Normal)
			{
				form.Location = Location;
				form.Size = Size;
			}
		}
	}
}