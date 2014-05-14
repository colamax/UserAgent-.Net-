using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;

namespace UserAgent.Control
{
    class AdrMIUIParser:Parser
    {
        private int lastInt = 1;// 简单的控制
        private Regex reg = new Regex(@"^([A-Za-z0-9]+)_[A-Za-z0-9\-]+; MIUI/\d{1,2}.\d{1,2}.\d{1,2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex reg2 = new Regex(@"^([A-Za-z0-9]+) ([A-Za-z0-9\-]+); MIUI/\d{1,2}.\d{1,2}.\d{1,2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex reg3 = new Regex(@"^([A-Za-z0-9]+) ([A-Za-z0-9\-]+); MIUI/[A-Za-z0-9\.]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex reg4 = new Regex(@"^([0-9]+); MIUI/[A-Za-z0-9\.]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex reg5 = new Regex(@"^([A-Za-z0-9\-]+); MIUI/[A-Za-z0-9\.]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        private Regex lastReg = null;
        public AdrMIUIParser()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (reg.IsMatch (userAgent)) {
                lastInt = 1;
                lastReg = reg;
				return true;
            }else if(reg2.IsMatch(userAgent))
            {
                lastInt = 2;
                lastReg = reg2;
                return true;
            }
            else if (reg3.IsMatch(userAgent))
            {
                lastInt = 3;
                lastReg = reg3;
                return true;
            }
            else if (reg4.IsMatch(userAgent))
            {
                lastInt = 4;
                lastReg = reg4;
                return true;
            }
            else if (reg5.IsMatch(userAgent))
            {
                lastInt = 1;
                lastReg = reg5;
                return true;
            }
            else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Platform = "Android";
            var result = lastReg.Match(userAgent).Groups;
			if (result.Count >= 2) {
                switch (lastInt) { 
                    case 1:
                        tm.Model = result[1].Value.Trim();
                        break;
                    case 2:
                        tm.Brand = result[1].Value.Trim();
                        tm.Model = result[2].Value.Trim();
                        break;
                    case 3:
                        tm.Model =result[1].Value.Trim()+" "+result[2].Value.Trim();
                        break;
                }
				
			}
			return tm;
		}
    }
}
