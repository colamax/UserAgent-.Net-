using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
    class AdrBySamsungPixel : Parser
    {
        private Regex reg = new Regex(@"samsung-([\w|\-|\s]+),[0-9]{1,3}[0-9]*[1-9]{1,3}[0-9]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public override bool isMatch(string userAgent)
        {
            if (reg.IsMatch(userAgent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override TerminalModel getTM(string userAgent)
        {
            TerminalModel tm = new TerminalModel();
            tm.Platform = "Android";
            var result = reg.Match(userAgent).Groups;
            if (result.Count >= 2)
            {
                tm.Brand = "samsung";
                tm.Model = result[1].Value.Trim();
            }
            return tm;
        }
    }
}
