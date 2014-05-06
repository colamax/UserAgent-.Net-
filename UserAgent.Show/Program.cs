﻿using System;
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
            UserAgentParser uap = new UserAgentParser();
//            uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);
			TerminalModel tm = uap.ParseUserAgent("UCWEB/2.0 (Linux; U; Adr 2.3.4; zh-CN; HTC Sensation XE with Beats Audio Z715e) U2/1.0.0 UCBrowser/9.7.5.418 U2/1.0.0 Mobile");
            Console.WriteLine("tm.Browser=" + tm.Browser);
            Console.WriteLine("tm.Brand=" + tm.Brand);
            Console.WriteLine("tm.Model=" + tm.Model);
            Console.WriteLine("tm.Platform=" + tm.Platform);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.ReadKey();
//            string strReadFilePath = @"../../part-r-00000(6).txt";
//            StreamReader srReadFile = new StreamReader(strReadFilePath);
//            float total = 0;
//            float haveNum = 0;
//            while (!srReadFile.EndOfStream)
//            {
//                string strReadLine = srReadFile.ReadLine(); //读取每行数据
//                if (strReadLine != null) 
//                {
//                    total++;
//                    Stopwatch sw = new Stopwatch();
//                    sw.Start();
//                    TerminalModel tm = uap.ParseUserAgent (strReadLine);
//                    sw.Stop();
//                    if (tm.Platform != null && tm.Platform.Length>1) {
//                        haveNum++;
////						Console.WriteLine (strReadLine); //屏幕打印每行数据
////						Console.WriteLine ("tm.Browser=" + tm.Browser);
////						Console.WriteLine ("tm.Brand=" + tm.Brand);
////						Console.WriteLine ("tm.Model=" + tm.Model);
////						Console.WriteLine ("tm.Platform=" + tm.Platform);
////						Console.WriteLine ("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
////						Console.WriteLine("++++>" + sw.ElapsedMilliseconds);
//                    } else {
//                        Console.WriteLine (strReadLine); //屏幕打印每行数据
////						Console.WriteLine("---->" + sw.ElapsedMilliseconds);
//                    }
//                }

//            }
//            //关闭读取流文件
//            srReadFile.Close();
//            Console.WriteLine("total:" + total);
//            Console.WriteLine("haveNum:" + haveNum);
//            Console.WriteLine("PER:" + haveNum/total*100+"%");
        }

        static void uap_OnProcessUnknowUa(string uaStr)
        {
            DataContext dataBase = DataContextConfiguration.ContextCollection["Baase"];
            UaNotClearUserAgent uncua = new UaNotClearUserAgent();
            uncua.UserAgent = uaStr;
            try
            {
                dataBase.Insert(uncua);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

    }
}
