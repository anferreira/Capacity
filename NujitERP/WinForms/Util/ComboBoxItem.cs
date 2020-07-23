using System;

namespace Nujit.NujitERP.WinForms.Util
{
	public class ComboBoxItem
	{
		private object _content;
		private string _display;

		public ComboBoxItem(string display, object content)
		{
			_content = content;
			_display = display;
		}

		public ComboBoxItem ()
		{
			_content = null;
			_display = "Empty";
		}

		public string Display
		{
			get {return _display;}
			set {_display = value;}
		}

		public object Content
		{
			get {return _content;}
			set {_content = value;}
		}

		public override string ToString()
		{
			return _display;
		}

	}
}
