using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class BlackBerryParser : Parser
	{
		private Regex reg3 = new Regex(@"BlackBerry", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public BlackBerryParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg3.IsMatch (userAgent)) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "BlackBerry";
			return tm;
		}
	}
}

