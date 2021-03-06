﻿using System;
using System.Text.RegularExpressions;
using UserAgent.Model;
using UserAgent.Control;
namespace UserAgent.Control
{
	public class UCWebSimpleParser:Parser
	{
		private int lastInt = 1;// 简单的控制
//		ucweb/2.0(java; u; midp-2.0; zh-cn; samsung-gt-s8500) u2/1.0.0 ucbrowser/8.6.1.237 u2/1.0.0 mobile
		private Regex javareg = new Regex(@"ucweb/2.0.*\(java;[\w|\s|\-]+;[\w|\s|\-|\.]+;[\w|\s|\-]+;([\w|\s|\-|\.]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0 (linux; u; adr 2.3.6; zh-cn; t730) u2/1.0.0 ucbrowser/9.9.0.459 u2/1.0.0 mobile
		private Regex linuxreg = new Regex(@"ucweb/2.0.*\(linux;[u|\s]+;[\w|\s|\-|\.]+;[\w|\s|\-]+;([\w|\s|\-|\.]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0 (windows; u; wds 7.10; zh-cn; dell; venue pro) u2/1.0.0 ucbrowser/3.2.0.340 u2/1.0.0 mobile
		private Regex winreg = new Regex(@"ucweb/2.0.*\(windows;[u|\s]+;[\w|\s|\-|\.]+;[\w|\s|\-]+;([\w|\s|\-|\.]+);([\w|\s|\-|\.]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0 (ios; u; iph os 5_0; zh-cn; iph4,1) u2/1.0.0 ucbrowser/9.2.0.312 u2/1.0.0 mobile
		private Regex iosreg = new Regex(@"ucweb/2.0.*\(ios;[u|\s]+;(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0 (midp-2.0; u; zh-cn; h60-l01) u2/1.0.0 ucbrowser/9.9.2.467  u2/1.0.0 mobile
		private Regex midpreg = new Regex(@"ucweb/2.0.*\(midp-2.0;[u|\s]+;[\w|\s|\-|\.]+;([\w|\s|\-|\.]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0(blackberry; u; 5.1.0.641; en-us; 9900/5.1.0.641) u2/1.0.0 ucbrowser/8.1.0.216
		private Regex bbreg = new Regex(@"ucweb/2.0.*\(blackberry;[u|\s]+;(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		ucweb/2.0 (linux; u; adr
		private Regex sbreg = new Regex(@"ucweb/2.0.*\(linux; u; adr(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		j2me/ucweb7.4.0.57
		private Regex j2mereg = new Regex(@"j2me/ucweb[\d|\.]+(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		JUC (Linux; U; 索-4.0.0; zh-cn; Q101; 480*800) UCWEB7.9.0.94/139/800
//		juc(linux;u;2.1-update1_hiapk_1.1_xxkj;zh_cn;milestone xt720;480*854;)ucweb7.7.0.85/139/800
		private Regex jucreg = new Regex(@"juc[\s]{0,}\(linux;[\s]{0,}u;.*;[\w|\s|\-|\_]+;(.*);[\s]{0,}[0-9]{1,4}[0-9][*|X|x]{1}[1-9]{1,4}[0-9]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		maui_wap_browser/ucweb7.9.0.94/109/33456
		private Regex mtkreg = new Regex(@"maui_wap_browser/ucweb(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private Regex lastReg = null;
		public UCWebSimpleParser ()
		{
		}
		public override bool isMatch (string userAgent)
		{
			if (javareg.IsMatch (userAgent)) {
				lastReg = javareg;
				lastInt = 1;
				return true;
			}
			if (linuxreg.IsMatch (userAgent)) {
				lastReg = linuxreg;
				lastInt = 2;
				return true;
			}
			if (winreg.IsMatch (userAgent)) {
				lastReg = winreg;
				lastInt = 3;
				return true;
			}
			if (iosreg.IsMatch (userAgent)) {
				lastReg = iosreg;
				lastInt = 4;
				return true;
			}
			if (midpreg.IsMatch (userAgent)) {
				lastReg = midpreg;
				lastInt = 5;
				return true;
			}
			if (bbreg.IsMatch (userAgent)) {
				lastReg = bbreg;
				lastInt = 6;
				return true;
			}
			if (sbreg.IsMatch (userAgent)) {
				lastReg = sbreg;
				lastInt = 7;
				return true;
			}
			if (j2mereg.IsMatch (userAgent)) {
				lastReg = j2mereg;
				lastInt = 8;
				return true;
			}
			if (jucreg.IsMatch (userAgent)) {
				lastReg = jucreg;
				lastInt = 9;
				return true;
			}
			if (mtkreg.IsMatch (userAgent)) {
				lastReg = mtkreg;
				lastInt = 10;
				return true;
			}
			return false;
		}
		public override TerminalModel getTM (string userAgent)
		{
			TerminalModel tm = new TerminalModel ();
			tm.Browser = "UCBrowser";

			var result = lastReg.Match (userAgent).Groups;
			if (result.Count >= 2) {
				switch (lastInt) {
				case 1:
					tm.Platform = "KJAVA";
					tm.Model = result [1].Value.Trim ();
					break;
				case 2:
					tm.Platform = "Android";
					tm.Model = result [1].Value.Trim ();
					break;
				case 3:
					tm.Platform = "WindowsPhone";
					tm.Brand = result [1].Value.Trim ();
					tm.Model = result [2].Value.Trim ();
					break;
				case 4:
					tm.Platform = "IOS";
					tm.Brand = "Apple";
					break;
				case 5:
					tm.Platform = "Android";
					tm.Model = result [1].Value.Trim ();
					break;
				case 6:
					tm.Platform = "BlackBerry";
					break;
				case 7:
					tm.Platform = "Android";
					break;
				case 8:
					tm.Platform = "KJAVA";
					break;
				case 9:
					tm.Platform = "Android";
					tm.Model = result [1].Value.Trim ();
					break;
				case 10:
					tm.Platform = "MTK";
					break;
				}

			}
			return tm;
		}
	}
}

