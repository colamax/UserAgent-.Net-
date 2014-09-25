using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class WPOSTxtParser : Parser
	{
//		private Regex reg = new Regex(@"[WindowsPhone|Windows Phone|Windows Mobile]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public WPOSTxtParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf("windowsphone") >= 0 ||userAgent.IndexOf("WindowsPhoneOS") >= 0 || userAgent.IndexOf("Windows Phone") >= 0 || userAgent.IndexOf("WindowsPhone") >= 0 || userAgent.IndexOf("Windows Mobile") >= 0||userAgent.IndexOf("windows Phone") >= 0)
            {
				return true;
			} else {
				return false;
			}
//			if (reg.IsMatch (userAgent)) {
//				return true;
//			} else {
//				return false;
//			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "WindowsPhone";
			return tm;
		}
	}
}

