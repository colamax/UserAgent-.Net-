using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UserAgent.Control;

namespace UserAgent.Control
{
    class DefultAB :Abandon
    {
        private List<Regex> defultReg = new List<Regex>();

        public DefultAB() {
            defultReg.Add(new Regex(@"^b.a.a.a.a.b@[A-Za-z0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"Version:meishij", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^agent[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^agent-[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^[A-Za-z]+.[A-Za-z]+.[A-Za-z]+.[A-Za-z]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^dzm-client[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^null/null/[0-9]+", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^pkg:com.[A-Za-z0-9]+.[A-Za-z0-9]+,udid:[\w]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^qiushibalke_[0-9].[0-9].[0-9]_[\w]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            defultReg.Add(new Regex(@"^tbtui_2.4.0_p\+[\w|\+|\/]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			defultReg.Add(new Regex(@"^User-Agent:", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			defultReg.Add(new Regex(@"^apache-httpclient/suishen", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			defultReg.Add(new Regex(@"^avgmobilation", RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }
        //private Regex reg1 = new Regex(@"^b.a.a.a.a.b@[A-Za-z0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private Regex reg2 = new Regex(@"Version:meishij", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private Regex reg3 = new Regex(@"^agent[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private Regex reg4 = new Regex(@"^agent-[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private Regex reg5 = new Regex(@"^[A-Za-z0-9]+.[A-Za-z0-9]+.[A-Za-z0-9]+.[A-Za-z0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private Regex reg6 = new Regex(@"^dzm-client[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        public override bool isMatch(string userAgent)
        {
            //if (reg1.IsMatch(userAgent))
            //{
            //    return true;
            //}
            //if (reg2.IsMatch(userAgent))
            //{
            //    return true;
            //}
            //if (reg3.IsMatch(userAgent))
            //{
            //    return true;
            //}
            //if (reg4.IsMatch(userAgent))
            //{
            //    return true;
            //}
            //if (reg5.IsMatch(userAgent))
            //{
            //    return true;
            //}
            foreach (Regex item in defultReg) {
                if (item.IsMatch(userAgent)) {
                    return true;
                }
            }
            return false;
        }
    }
}
