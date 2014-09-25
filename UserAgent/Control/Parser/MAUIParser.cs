using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class MAUIParser : Parser
	{
		private Regex reg = new Regex (@"MAUI_WAP_Browser",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public MAUIParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg.IsMatch (userAgent)) {
				return true;
			}
			if (userAgent.IndexOf ("Browser/MAUI") >= 0) {
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "MTK";
			return tm;
		}
	}
}

