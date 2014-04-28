添加数据库配置
UaOperateSystem 表,保存未能解释的UA用来二次分析
<connectionStrings>
	<add name="BasicConfigDataBase" connectionString="server=192.168.3.67;User Id=root;password=123456;database=CMMM;Allow Zero Datetime=True;charset=utf8" providerName="Light.Data.Mysql,Light.Data" />
</connectionStrings>

使用到的命名空间
using UserAgent;
using UserAgent.Model;


新建 UserAgentParser　对象
UserAgentParser uap = new UserAgentParser("BasicConfigDataBase");

ParseUserAgent 方法 
提收 string 参数，UA的字符串
返回 TerminalModel　对象
TerminalModel tm = uap.ParseUserAgent("GN180; 4.0.4; SV1.6; zh-cn");

TerminalModel　对象
string Browser:浏览器名称 (默认值为空字符串)
string Brand:客户端厂商名称 (默认值为空字符串)
string Model:客户端机器类号 (默认值为空字符串)
string Platform:客户端平台 (默认值为空字符串)

Platform 目前主要有以下返回值
Android
IOS
Windows Phone
BlackBerry
MacOX
KJAVA
MTK