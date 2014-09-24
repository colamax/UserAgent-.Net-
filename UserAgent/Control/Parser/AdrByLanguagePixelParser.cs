using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
	public class AdrByLanguagePixelParser : Parser
	{
		private Regex reg1 = new Regex (@"U;\d{1}.\d{1}.\d{1};.*Zh[_|\-]cn;([\w|\s|\-]+);[0-9]{1,4}[0-9]*[1-9]{1,4}[0-9]",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"U;\d{1}.\d{1};.*Zh[_|\-]cn;([\w|\s|\-]+);[0-9]{1,4}[0-9]*[1-9]{1,4}[0-9]",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg3 = new Regex (@"U;\d{1}.[\w|\-|\s]+;.*Zh[_|\-]cn;([\w|\s|\-]+);[0-9]{1,4}[0-9]*[1-9]{1,4}[0-9]",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex lastReg = null;
		public AdrByLanguagePixelParser ()
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
			if (reg3.IsMatch (userAgent)) {
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

