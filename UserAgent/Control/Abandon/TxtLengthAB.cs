using System;
using System.Text.RegularExpressions;
using UserAgent.Control;
namespace UserAgent.Control
{
    class TxtLengthAB :Abandon
    {
        private Regex reg1 = new Regex(@"^[A-Za-z0-9=]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public override bool isMatch(string userAgent)
        {
            if(userAgent.Length >=250){
                if (reg1.IsMatch(userAgent))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
