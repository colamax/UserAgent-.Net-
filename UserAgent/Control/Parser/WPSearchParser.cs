using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class WPSearchParser:Parser
	{
//		windows phone search (windows phone os 8.10;huawei;w2-u00;8.10;14157)
		private Regex reg = new Regex(@"^windows phone search \((.*);([\w|\s|\-|\+]+);([\w|\s|\-|\+]+);", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public WPSearchParser ()
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
				tm.Model = result[3].Value.Trim();
				tm.Brand = result[2].Value.Trim();
			}
			return tm;
		}
	}
}

