using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;


namespace UserAgent.Control
{
    class AdrTxtParser : Parser
    {
		private Regex reg = new Regex (@"Android[/\s]?((\d{1})(\.\d+)*)?",RegexOptions.Compiled|RegexOptions.IgnoreCase);
        private Regex reg2 = new Regex(@"Linux; U;\s?((\d{1})(\.\d+)*){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private Regex reg3 = new Regex(@"Android", RegexOptions.Compiled);
        public AdrTxtParser()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg.IsMatch (userAgent)) {
				return true;
			}
            if (reg2.IsMatch(userAgent))
            {
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
			tm.Platform = "Android";
			return tm;
		}
    }
}
