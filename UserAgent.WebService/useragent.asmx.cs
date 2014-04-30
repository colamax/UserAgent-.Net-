using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UserAgent;
using UserAgent.Model;
namespace UserAgent.WebService
{
    /// <summary>
    /// useragent 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class useragent : System.Web.Services.WebService
    {
        private UserAgentParser uap = new UserAgentParser();
        [WebMethod]
        public TerminalModel ParseUserAgent(string useragent)
        {
            if (useragent.Length <= 0)
            {
                return new TerminalModel();
            }else{
                TerminalModel tm = uap.ParseUserAgent(useragent.Trim());
                return tm;
            }
            
        }
    }
}
