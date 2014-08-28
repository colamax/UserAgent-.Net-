using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using Light.Data;
using UserAgent;
using UserAgent.Model;
namespace UserAgent.WebApi
{
    public partial class _Default : System.Web.UI.Page
    {
        private static DataContext logDataBase = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                logDataBase = DataContextConfiguration.ContextCollection["Baase"];
            }
            catch (Exception)
            {
            }

            string ua = Request.QueryString["ua"];
            TerminalModel tm = new TerminalModel();
            if (ua != null && ua.Length > 0)
            {
                String SaveUnloadUAStr = ConfigurationManager.AppSettings["SaveUnloadUA"].Trim().ToString();

                UserAgentParser uap = new UserAgentParser();
                if (SaveUnloadUAStr != null) {
                    if (Convert.ToBoolean(SaveUnloadUAStr))
                    {
                        uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);
                    }
                }
                
                
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
        static void uap_OnProcessUnknowUa(string uaStr)
        {
            UaNotClearUserAgent uncu = new UaNotClearUserAgent();
            uncu.UserAgent = uaStr;
            try
            {
                logDataBase.Insert(uncu);
            }
            catch (Exception)
            {
            }
        }
    }
}
