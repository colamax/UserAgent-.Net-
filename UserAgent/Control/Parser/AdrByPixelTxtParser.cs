using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
    class AdrByPixelTxtParser : Parser
    {
        private Regex reg = new Regex(@"adr \(([\w|\s|\-|\+]+),.*[0-9]{1,3}[0-9]*[1-9]{1,3}[0-9]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

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
            if (result.Count >= 2)
            {
                tm.Model = result[1].Value.Trim();
                string[] sArray = Regex.Split(result[1].Value, " ", RegexOptions.IgnoreCase);
                if (sArray.Length >= 2)
                {
                    tm.Brand = sArray[0].Trim();
                    tm.Model = sArray[1].Trim();
                }
            }
			return tm;
		}
    }
}
