using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using UserAgent;
using UserAgent.Model;
namespace UserAgent.WebApi
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ua = Request.QueryString["ua"];
            TerminalModel tm = new TerminalModel();
            if (ua != null && ua.Length > 0)
            {
                UserAgentParser uap = new UserAgentParser();
                //uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);
                tm = uap.ParseUserAgent(ua);
                //Response.Write("tm.Browser=" + tm.Browser);
                //Response.Write("tm.Brand=" + tm.Brand);
                //Response.Write("tm.Model=" + tm.Model);
                //Response.Write("tm.Platform=" + tm.Platform);
            }
            else {
            }
            JavaScriptSerializer ser = new JavaScriptSerializer();
            String jsonStr = ser.Serialize(tm);
            Response.Write(jsonStr);
            
        }
    }
}
