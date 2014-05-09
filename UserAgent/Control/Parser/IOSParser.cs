using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class IOSParser : Parser
	{
        private Regex reg = new Regex(@"iPhone|U;iOS\s*(\d)(\.\d){0,2}|\biPhone.*Mobile|\biPod", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"CFNetwork.+Darwin",RegexOptions.Compiled|RegexOptions.IgnoreCase);
        private Regex reg3 = new Regex(@"iPhone|App Store|iPad|iTouch|iPod", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public IOSParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{

			if (reg.IsMatch (userAgent)) {
				return true;
			}
			if (reg2.IsMatch (userAgent)) {
				return true;
			}
            if (reg3.IsMatch(userAgent))
            {
                return true;
            }
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "IOS";
			tm.Brand = "Apple";
			return tm;
		}
	}
}

