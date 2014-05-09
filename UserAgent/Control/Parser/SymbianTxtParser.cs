using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
    class SymbianTxtParser : Parser
    {
        private Regex reg = new Regex(@"Symbian|Series\d{2}|S60/3.0", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public override bool isMatch(string userAgent)
        {
            if (reg.IsMatch(userAgent)) {
                return true;
            }
            return false;
        }

        public override TerminalModel getTM(string userAgent)
        {
            TerminalModel tm = new TerminalModel();
            tm.Platform = "Symbian";
            return tm;
        }
    }
}
