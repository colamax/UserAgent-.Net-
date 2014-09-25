using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class KJAVAParser : Parser
	{
		public KJAVAParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("rofile/MIDP") >= 0) {
				return true;
			}
			if (userAgent.IndexOf ("Browser/OpenWave") >= 0) {
				return true;
			}
			if (userAgent.IndexOf ("j2me") >= 0) {
				return true;
			}
			if (userAgent.IndexOf ("J2ME") >= 0) {
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "KJAVA";
			return tm;
		}
	}
}

