using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class MicroMessengerParser : Parser
	{
		private Regex reg1 = new Regex (@"^Mozilla.*\(([\w]+);.*\).*MicroMessenger",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"^Mozilla.*\(([\w]+);\s([\w]+);\s([\w|\.|\s|\-]+);\s([\w|\-]+);\s([\w|\-|\s]+).*\).*MicroMessenger",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg3 = new Regex (@"^Mozilla.*\(([\w]+);\s([\w|\.|\s]+);\s([\w|\.|\s]+);\s([\w|\.|\s|\/]+);\s([\w|\.|\s|\/]+);\s([\w]+);\s([\w]+);\s([\w|\-|\.|\s]+);\s([\w|\.|\s|\/|\-]+).*\).*MicroMessenger",RegexOptions.Compiled|RegexOptions.IgnoreCase);

		public MicroMessengerParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg1.IsMatch (userAgent)) {
				return true;
			}else{
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			var result = reg1.Match (userAgent).Groups;
			if (result [1].Value.Trim ().Equals ("Linux")) {
				tm.Platform = "Android";
				if (reg2.IsMatch (userAgent)) {
					result = reg2.Match (userAgent).Groups;
					tm.Model = result [5].Value.Trim ();
					int checkBuild = tm.Model.IndexOf ("Build");
					if (checkBuild > 0) {
						tm.Model = tm.Model.Substring (0, checkBuild).Trim ();
					}
				}
			} else if (result [1].Value.Trim ().Equals ("compatible")) {
				if (reg3.IsMatch (userAgent)) {
					result = reg3.Match (userAgent).Groups;
					if (result [0].Value.IndexOf ("Windows Phone") >= 0) {
						tm.Platform = "WindowsPhone";
					}
					if (result [8].Value !=null) {
						tm.Brand = result [8].Value.Trim ();
					}
					if (result [9].Value !=null) {
						tm.Model = result [9].Value.Trim ();
					}
				}

			} else if (result [1].Value.Trim ().Equals ("Macintosh")) {
				tm.Platform = "IOS";
			} else {
			}
			return tm;
		}
	}
}

