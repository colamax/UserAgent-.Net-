using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class IcoolWeatherParser : Parser
	{
//		icoolweather/3.01.001.20140526(17;coolpad 8670;864837021828710-000000000000000;3.01.001.20140526)
		private Regex reg = new Regex(@"^icoolweather/[\d|\.]+\(\d{1,};(.*);", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public IcoolWeatherParser ()
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
			var result = reg.Match(userAgent).Groups;
			if (result.Count >= 2) {
				tm.Model = result[1].Value.Trim();
			}
			return tm;
		}
	}
}

