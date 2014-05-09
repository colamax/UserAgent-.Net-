using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class TouchPalv5Parser : Parser
	{
		private Regex reg = new Regex (@"\((([\w|\.|\s|\/]+)\s([\w|\.|\s|\/]+))\)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public TouchPalv5Parser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("TouchPalv5") >= 0) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();

			var result = reg.Match (userAgent).Groups;
			tm.Platform = "Android";
			if (result.Count >= 4) {
				if (result [2].Value != null) {
					tm.Model = result [2].Value;
				}
			}
			return tm;
		}
	}
}

