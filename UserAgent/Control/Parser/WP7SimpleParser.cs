using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class WP7SimpleParser:Parser
	{
		private Regex reg = new Regex(@"^wp7 ([\w|\s|\-|\+]+); ([\w|\s|\-|\+]+);", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public WP7SimpleParser ()
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
			tm.Platform = "WindowsPhone";
			var result = reg.Match(userAgent).Groups;
			if (result.Count >= 2) {
				tm.Model = result[2].Value.Trim();
				tm.Brand = result[3].Value.Trim();
			}
			return tm;
		}
	}
}

