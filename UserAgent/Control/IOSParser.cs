using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class IOSParser : Parser
	{
		private Regex reg = new Regex (@"iPhone|U;iOS\s*(\d)(\.\d){0,2}",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public IOSParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{

			if (reg.IsMatch (userAgent)) {
				return true;
			}else{
				return false;
			}
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

