﻿using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class UCBrowserParser :Parser
	{ 
		private Regex reg1 = new Regex (@"\(([-|\w|\.]+);",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg2 = new Regex (@"\((([-|\w|\.]+);(.*);(.*);(.*);(.*))\)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg3 = new Regex (@"\(((.*);(.*);(.*);(.*);(.*))\)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		private Regex reg4 = new Regex (@"\(((.*);(.*);(.*);(.*);(.*);(.*))\)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
		public UCBrowserParser ()
		{

		}
		public override Boolean isMatch(String userAgent)
		{
			if (userAgent.IndexOf ("UCBrowser") >= 0) {
				return true;
			} else {
				return false;
			}
		}
		public override TerminalModel getTM (String userAgent)
		{
			TerminalModel tm = new TerminalModel();
			tm.Browser = "UCBrowser";

			var result = reg1.Match (userAgent).Groups;
			if (result.Count > 1) {
				if (result [1].Value != null) {
					if (result [1].Value.Equals ("compatible")) {
						if (userAgent.IndexOf ("Trident") >= 0) {
							tm.Platform = "Windows Mobile";
						}
					} else if (result [1].Value.Equals ("MIDP-2.0")) {
						tm.Platform = "Android";
						result = reg2.Match (userAgent).Groups;
						if (result.Count >= 7) {
							if (result [6].Value != null) {
								tm.Model = result [6].Value.Trim ();
								int checkBuild = tm.Model.IndexOf ("Build/");
								if (checkBuild > 0) {
									tm.Model = tm.Model.Substring (0, checkBuild).Trim ();
								}
							}
						}
						return tm;
					} else if (result [1].Value.Equals ("Linux")) {
						tm.Platform = "Android";
						result = reg3.Match (userAgent).Groups;
						if (result.Count >= 7) {
							if (result [6].Value != null) {
								tm.Model = result [6].Value.Trim ();
								int checkBuild = tm.Model.IndexOf ("Build/");
								if (checkBuild > 0) {
									tm.Model = tm.Model.Substring (0, checkBuild).Trim ();
								}
							}
						}
						return tm;
					} else if (result [1].Value.Equals ("Macintosh")) {
						tm.Platform = "IOS";
						return tm;
					} else if (result [1].Value.Equals ("Windows")) {
						tm.Platform = "Windows Phone";
						result = reg4.Match (userAgent).Groups;
						if (result.Count >= 8) {
							if (result [6].Value != null) {
								tm.Brand = result [6].Value;
							}
							if (result [7].Value != null) {
								tm.Model = result [7].Value;
							}
						}
						if (userAgent.IndexOf ("Profile/MIDP") >= 0) {
							tm.Platform = "KJAVA";
						}
						return tm;
					} else if (result [1].Value.Equals ("BlackBerry")) {
						tm.Platform = "BlackBerry";
						return tm;
					} else if (result [1].Value.Equals ("iPhone")) {
						tm.Platform = "IOS";
						return tm;
					}
				}
			}
			return tm;
		}
	}
}
