using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class AdrByPixelParser : Parser
	{
//		4.0.3 GT-I9100 800x480 mobile 15

		private Regex reg = new Regex (@"[\d\.]{1,}\d{1}[,|\s]{1}([\w|\s|\-|\%]+)[,|\s]{1}[0-9]{1,4}[0-9][*|X|x]{1}[1-9]{1,4}[0-9]",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public AdrByPixelParser ()
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
				tm.Model = result [1].Value.Trim ();
			}
			return tm;
		}
	}
}

