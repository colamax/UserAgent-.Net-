using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class WPOSTxtParser : Parser
	{
		public WPOSTxtParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
            if (userAgent.IndexOf("WindowsPhoneOS") >= 0 || userAgent.IndexOf("Windows Phone") >= 0 || userAgent.IndexOf("WindowsPhone") >= 0 || userAgent.IndexOf("Windows Mobile") >= 0)
            {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "Windows Phone";
			return tm;
		}
	}
}

