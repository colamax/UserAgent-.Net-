using System;
using System.Collections.Generic;
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
            uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);
			TerminalModel tm = uap.ParseUserAgent("DOOjjjjjjjjj-cn");
            Console.WriteLine("tm.Browser=" + tm.Browser);
            Console.WriteLine("tm.Brand=" + tm.Brand);
            Console.WriteLine("tm.Model=" + tm.Model);
            Console.WriteLine("tm.Platform=" + tm.Platform);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.ReadKey();
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
