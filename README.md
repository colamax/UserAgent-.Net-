添加数据库配置　<br/>
UaOperateSystem 表,保存未能解释的UA用来二次分析<br/>
<connectionStrings>
	<add name="BasicConfigDataBase" connectionString="server=192.168.3.67;User Id=root;password=123456;database=CMMM;Allow Zero Datetime=True;charset=utf8" providerName="Light.Data.Mysql,Light.Data" />
</connectionStrings>
<br/>
使用到的命名空间<br/>
using UserAgent;<br/>
using UserAgent.Model;<br/>
<br/>
<br/>
新建 UserAgentParser　对象<br/>
UserAgentParser uap = new UserAgentParser();<br/>
<br/>
解释不到ua时的事件
uap.OnProcessUnknowUa += new ProcessUnknowUaEventHandler(uap_OnProcessUnknowUa);<br/>
<pre>
static void uap_OnProcessUnknowUa(string uaStr)
{
	//code
}
</pre>

ParseUserAgent 方法 <br/>
提收 string 参数，UA的字符串<br/>
返回 TerminalModel　对象<br/>
TerminalModel tm = uap.ParseUserAgent("GN180; 4.0.4; SV1.6; zh-cn");<br/>
<br/>
TerminalModel　对象<br/>
string Browser:浏览器名称 (默认值为空字符串)<br/>
string Brand:客户端厂商名称 (默认值为空字符串)<br/>
string Model:客户端机器类号 (默认值为空字符串)<br/>
string Platform:客户端平台 (默认值为空字符串)<br/>
<br/>
Platform 目前主要有以下返回值<br/>
<pre>
Android
IOS
Windows Phone
BlackBerry
MacOX
KJAVA
MTK
</pre>