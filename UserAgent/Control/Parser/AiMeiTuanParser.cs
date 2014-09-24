using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class AiMeiTuanParser:Parser
	{
		private Regex reg = new Regex (@"^Ai[MeiTuan|Movie]{1,} /(.*)-[\d\.]{1,}\d-(.*)-[0-9]{1,3}[0-9]x[1-9]{1,3}[0-9]",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public AiMeiTuanParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg.IsMatch (userAgent)) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "Android";
			var result = reg.Match (userAgent).Groups;
			if (result.Count >= 2) {
				tm.Brand = result [1].Value.Trim ();
				tm.Model = result [2].Value.Trim ();
			}
			return tm;
		}
	}
}

