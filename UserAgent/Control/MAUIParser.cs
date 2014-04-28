using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class MAUIParser : Parser
	{
		public MAUIParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("Browser/MAUI") >= 0) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "MTK";
			return tm;
		}
	}
}

