using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class ApplewebkitTxtParser:Parser
	{
		private Regex reg = new Regex (@"applewebkit.*safari",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public ApplewebkitTxtParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg.IsMatch (userAgent)) {
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "IOS";
			tm.Brand = "Apple";
			return tm;
		}
	}
}

