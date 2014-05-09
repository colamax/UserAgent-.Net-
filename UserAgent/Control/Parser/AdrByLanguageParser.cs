using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class AdrByLanguageParser : Parser
	{
		// ZTE-T U812; 2.3.7; meteorad; zh-cn
        private Regex reg1 = new Regex(@"([\w|\s|\-|\+]+); \d{1}.\d{1}.\d{1}.*zh-[cn|hk|tw]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		// SM-N900; 4.3; JSS15J.N900ZSUCML1; zh-cn
        private Regex reg2 = new Regex(@"([\w|\s|\-|\+]+);\s\d{1}.\d{1};.*zh-[cn|hk|tw]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		private Regex lastReg = null;
		public AdrByLanguageParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg1.IsMatch (userAgent)) {
				lastReg = reg1;
				return true;
			}
			if (reg2.IsMatch (userAgent)) {
				lastReg = reg2;
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "Android";
			var result = lastReg.Match (userAgent).Groups;
			if (result.Count >= 2) {
				tm.Model = result [1].Value.Trim ();
				string[] sArray=Regex.Split(result[1].Value," ",RegexOptions.IgnoreCase);
				if (sArray.Length >= 2) {
					tm.Brand = sArray [0].Trim ();
					tm.Model = sArray [1].Trim ();
				}
			}
			return tm;
		}
	}
}

