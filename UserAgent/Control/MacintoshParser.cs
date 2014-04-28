using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class MacintoshParser : Parser
	{
		private Regex reg1 = new Regex (@"Intel Mac OS X",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public MacintoshParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg1.IsMatch (userAgent)) {
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "MacOX";
			tm.Brand = "Apple";
			return tm;
		}
	}
}

