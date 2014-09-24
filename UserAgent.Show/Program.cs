using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UserAgent;
using UserAgent.Model;
using Light.Data;
namespace UserAgent.Show
{
    class Program
    {
        static void Main(string[] args)
        {
//			Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            UserAgentParser uap = new UserAgentParser();
            uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);
//			TerminalModel tm = uap.ParseUserAgent("blackberry8700/4.2.1 profile/midp-2.0 configuration/cldc-1.1 vendorid/114");
//            Console.WriteLine("tm.Browser=" + tm.Browser);
//            Console.WriteLine("tm.Brand=" + tm.Brand);
//            Console.WriteLine("tm.Model=" + tm.Model);
//            Console.WriteLine("tm.Platform=" + tm.Platform);
//            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
//            uap.Clear();
//            Console.ReadKey();

			string strReadFilePath = @"aa.txt";
            StreamReader srReadFile = new StreamReader(strReadFilePath);
			while (!srReadFile.EndOfStream)
			{
				string strReadLine = srReadFile.ReadLine(); //读取每行数据
				if (strReadLine != null) 
				{
					TerminalModel tm = uap.ParseUserAgent(strReadLine);
					if (tm.Platform != null && tm.Platform.Length > 1) {
						Console.WriteLine(strReadLine); //屏幕打印每行数据
			            Console.WriteLine ("tm.Browser=" + tm.Browser);
			            Console.WriteLine ("tm.Brand=" + tm.Brand);
			            Console.WriteLine ("tm.Model=" + tm.Model);
			            Console.WriteLine ("tm.Platform=" + tm.Platform);
					} else {
//						Console.WriteLine(strReadLine); //屏幕打印每行数据
					}
				}
			}
			srReadFile.Close();


			//string strReadFilePath = @"../../uaa.txt";
//			StreamReader srReadFile = new StreamReader(strReadFilePath);
            //float total = 0;
            //float haveNum = 0;
            //float ucUser = 0;
            //int ucnum = 0;
            //int allnum = 0;
            //while (!srReadFile.EndOfStream)
            //{
            //    string strReadLine = srReadFile.ReadLine(); //读取每行数据
            //    if (strReadLine != null)
            //    {
            //        total++;
            //        Stopwatch sw = new Stopwatch();
            //        sw.Start();
            //        TerminalModel tm = uap.ParseUserAgent(strReadLine);
            //        sw.Stop();
            //        if (tm.Platform != null && tm.Platform.Length > 1)
            //        {
            //            haveNum++;

            //            Console.WriteLine(strReadLine); //屏幕打印每行数据
            //            string[] sArray = strReadLine.Split('\t');
            //            if (sArray[1].Length > 0)
            //            {
            //                int result = int.Parse(sArray[1].ToString());
            //                Console.WriteLine("ALL+" + result);
            //                allnum += result;
            //            }

            //            if (tm.Browser.Equals("UCBrowser"))
            //            {
            //                ucUser++;
            //                Console.WriteLine(strReadLine); //屏幕打印每行数据
            //                sArray = strReadLine.Split('\t');
            //                if (sArray[1].Length > 0)
            //                {
            //                    int result = int.Parse(sArray[1].ToString());
            //                    Console.WriteLine("UC+" + result);
            //                    ucnum += result;
            //                }
            //            }
            //            Console.WriteLine (strReadLine); //屏幕打印每行数据
            //            Console.WriteLine ("tm.Browser=" + tm.Browser);
            //            Console.WriteLine ("tm.Brand=" + tm.Brand);
            //            Console.WriteLine ("tm.Model=" + tm.Model);
            //            Console.WriteLine ("tm.Platform=" + tm.Platform);
            //            Console.WriteLine ("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            //            Console.WriteLine("++++>" + sw.ElapsedMilliseconds);
            //        }
            //        else
            //        {
            //            Console.WriteLine (strReadLine); //屏幕打印每行数据
            //            Console.WriteLine("---->" + sw.ElapsedMilliseconds);
            //        }
            //    }

            //}
            //关闭读取流文件
            //srReadFile.Close();
            //Console.WriteLine("total:" + total);
            //Console.WriteLine("haveNum:" + haveNum);
            //Console.WriteLine("PER:" + haveNum / total * 100 + "%");
            //Console.WriteLine("ucUser:" + ucUser);
            //Console.WriteLine("UC:" + ucnum);
            //Console.WriteLine("总:" + allnum);
        }

        static void uap_OnProcessUnknowUa(string uaStr)
        {
			Console.WriteLine ("-------------------");
			Console.WriteLine("uap_OnProcessUnknowUa");
            Console.WriteLine(uaStr);
			Console.WriteLine ("-------------------");
        }

    }
}
