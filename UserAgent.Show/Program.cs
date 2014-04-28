using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserAgent;
using UserAgent.Model;

namespace UserAgent.Show
{
    class Program
    {
        static void Main(string[] args)
        {
            UserAgentParser uap = new UserAgentParser("Baase");
            TerminalModel tm = uap.ParseUserAgent("Geeeee1.6; zh-cn");
            Console.WriteLine("tm.Browser=" + tm.Browser);
            Console.WriteLine("tm.Brand=" + tm.Brand);
            Console.WriteLine("tm.Model=" + tm.Model);
            Console.WriteLine("tm.Platform=" + tm.Platform);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.ReadKey();
        }
    }
}
