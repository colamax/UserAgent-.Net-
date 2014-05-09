using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class BaiduBoxAppParser : Parser
	{
		// Mozilla/5.0 (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM; Touch; NOKIA; Nokia 720) baiduboxapp/042_0.0.5.4_enohpw_008_084/AIKON_0.8_0.82301.0.8_052-crp-capa-588-MR/1399g/CD74CE228142F582886709ADEB014C2C3FD2046E/1
		private Regex reg1 = new Regex (@"\(([\w]+);",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"\((([\w]+);([\w|\.|\s]+);([\w|\.|\s]+);([\w|\.|\s|\/]+);([\w|\.|\s|\/]+);\s([\w]+);\s([\w]+);\s([\w|\.|\s|\/]+);\s([\w|\.|\s|\/|\-]+)).*\) baiduboxapp",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public BaiduBoxAppParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("baiduboxapp") >= 0) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel();
			tm.Browser = "baiduboxapp";

			var result = reg1.Match (userAgent).Groups;
			if (result.Count > 1) {
				if (result [1].Value != null) {
					if (result [1].Value.Trim().Equals ("compatible")) {
						result = reg2.Match (userAgent).Groups;
						if(result [1].Value!=null){
							if (result [1].Value.IndexOf ("Windows Phone") >= 0) {
								tm.Platform = "Windows Phone";
							}
						}
						if(result [9].Value!=null){
							tm.Brand = result [9].Value.Trim ();
						}
						if(result [10].Value!=null){
							tm.Model = result [10].Value.Trim ();
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

