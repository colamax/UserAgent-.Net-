using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class BaiduBrowserParser : Parser
	{
		// Mozilla/5.0 (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM; Touch; NOKIA; RM-913_apac_prc_213) baidubrowser/2.5.0.12 (Baidu; P3 8.0.10521)
		private Regex reg1 = new Regex (@"\(([\w]+);",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"\((([\w]+);([\w|\.|\s]+);([\w|\.|\s]+);([\w|\.|\s|\/]+);([\w|\.|\s|\/]+);\s([\w]+);\s([\w]+);\s([\w|\.|\s|\/]+);\s([\w|\.|\s|\/|\-]+))\) baidubrowser",RegexOptions.Compiled|RegexOptions.IgnoreCase);

		public BaiduBrowserParser ()
		{
		}

		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("baidubrowser") >= 0) {
				return true;
			} else {
				return false;
			}
		}

		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel();
			tm.Browser = "baidubrowser";
			var result = reg1.Match (userAgent).Groups;
			if (reg1.IsMatch(userAgent)) {
				if (result [1].Value != null) {
					if (result [1].Value.Trim().Equals ("compatible")) {
						if (reg2.IsMatch (userAgent)) {
							result = reg2.Match (userAgent).Groups;
							if(result [1].Value!=null){
								if (result [1].Value.IndexOf ("Windows Phone") >= 0) {
									tm.Platform = "WindowsPhone";
								}
							}
							if(result [9].Value!=null){
								tm.Brand = result [9].Value.Trim ();
							}
							if(result [10].Value!=null){
								tm.Model = result [10].Value.Trim ();
							}
						}
						return tm;
					}else if(result [1].Value.Trim().Equals ("Linux")){
						tm.Platform = "Android";
						return tm;
					}
				}
			}
			return tm;
		}
	}
}

