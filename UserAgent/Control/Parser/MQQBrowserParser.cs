using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class MQQBrowserParser : Parser
	{ 
		private Regex reg1 = new Regex (@"\(([\w]+);",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"\(((.*);(.*);(.*);(.*);(.*);(.*);(.*))\)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public MQQBrowserParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (userAgent.IndexOf ("MQQBrowser") == 0) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (string userAgent)
		{	
			TerminalModel tm = new TerminalModel();
			tm.Browser = "MQQBrowser";

			if (reg1.IsMatch (userAgent)) {
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
							if(result [7].Value!=null){
								tm.Brand = result [7].Value.Trim ();
							}
							if(result [8].Value!=null){
								tm.Model = result [8].Value.Trim ();
							}
							return tm;
						}else if(result [1].Value.Trim().Equals ("Linux")){
							tm.Platform = "Android";
							return tm;
						}
					}
				}
			}

			return tm;
		}
	}
}

