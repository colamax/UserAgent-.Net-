using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using UserAgent.Control;
using UserAgent.Model;
namespace UserAgent
{
    public delegate void ProcessUnknowUaEventHandler(string uaStr);
    public class UserAgentParser
    {
        public event ProcessUnknowUaEventHandler OnProcessUnknowUa;
        List<Parser> _parserList = new List<Parser>();
        List<Abandon> _abandon_list = new List<Abandon>();
        ReaderWriterLock _locker = new ReaderWriterLock();
        //Dictionary<string, TerminalModel> _uaDict = new Dictionary<string, TerminalModel>();
        ConcurrentDictionary<string, TerminalModel> _uaDict = new ConcurrentDictionary<string, TerminalModel>();
        UaNotClearUserAgent uncua = new UaNotClearUserAgent();

        
        public UserAgentParser()
        {
            LoadData();
        }

        TerminalModel GetCache(string userAgent)
        {
            TerminalModel tm = null;
            if (string.IsNullOrEmpty(userAgent))
            {
                return tm;
            }
            //_locker.acquirereaderlock(1000);
            //_uadict.trygetvalue(useragent, out tm);
            //_locker.releasereaderlock();
            _uaDict.TryGetValue(userAgent, out tm);
            //_locker.ReleaseReaderLock();
            return tm;
        }

        void SetCache(string userAgent, TerminalModel tm)
        {
            //_locker.AcquireWriterLock(1000);
            //_uaDict[userAgent] = tm;
            //_locker.ReleaseWriterLock();
            if (string.IsNullOrEmpty(userAgent))
            {
                return;
            }
            _uaDict.TryAdd(userAgent, tm);
        }

        private void LoadData()
        {
			_parserList.Add (new IcoolWeatherParser ());
			_parserList.Add (new UCWebSimpleParser ());
			_parserList.Add (new WPSearchParser ());
			_parserList.Add (new WP7SimpleParser());
			_parserList.Add(new AiMeiTuanParser ());
            _parserList.Add(new AdrMIUIParser());
            _parserList.Add(new UCBrowserParser());
            _parserList.Add(new MQQBrowserParser());
            _parserList.Add(new MAUIParser());
            _parserList.Add(new MicroMessengerParser());
            _parserList.Add(new BaiduBrowserParser());
            _parserList.Add(new BaiduBoxAppParser());
            _parserList.Add(new BlackBerryParser());
            _parserList.Add(new TouchPalv5Parser());
            _parserList.Add(new AdrByLanguageParser());
            _parserList.Add(new AdrByPixelParser());
            _parserList.Add(new AdrByLanguagePixelParser());
            _parserList.Add(new AdrByPixelTxtParser());
            _parserList.Add(new AdrBySamsungPixel());
            _parserList.Add(new WPOSTxtParser());
            _parserList.Add(new IOSParser());
            _parserList.Add(new MacintoshParser());
            _parserList.Add(new SymbianTxtParser());
            _parserList.Add(new KJAVAParser());
			_parserList.Add (new AdrTxtParser ());
//			_parserList.Add (new ApplewebkitTxtParser ());

            //不加UA的标识
            _abandon_list.Add(new TxtLengthAB());
            _abandon_list.Add(new DefultAB());
        }
        public TerminalModel ParseUserAgent(String userAgent)
        {
            if (string.IsNullOrEmpty(userAgent)) {
                return new TerminalModel();
            }
            TerminalModel tm = GetCache(userAgent);

            if (tm != null)
            {
                return tm;
            }
            tm = new TerminalModel();
            foreach (Parser parser in _parserList)
            {
                if (parser.isMatch(userAgent))
                {
                    tm = parser.getTM(userAgent);
                    if (tm.Platform != null && tm.Platform != "")
                    {
                        SetCache(userAgent, tm);
                        return tm;
                    }
                }
            }

            Boolean callFun = false;
            foreach (Abandon ab in _abandon_list)
            {
                if (ab.isMatch(userAgent))
                {
                    callFun = true;
                    break;
                }
            }
            if(callFun){

            }else{
                if (OnProcessUnknowUa != null)
                {
                    //OnProcessUnknowUa.BeginInvoke(userAgent, new AsyncCallback(Callback), OnProcessUnknowUa);
                    OnProcessUnknowUa(userAgent);
                }
            }
            

            SetCache(userAgent, tm);
            return tm;
        }

        //void Callback(IAsyncResult result)
        //{
        //    ProcessUnknowUaEventHandler handler = result.AsyncState as ProcessUnknowUaEventHandler;
        //    if (handler != null)
        //    {

        //        handler.EndInvoke(result);
        //    }
        //}
        
        //internal void Clear()
        //{
        //    _parserList.Clear();
        //    _uaDict.Clear();
        //}

        //清空缓存
        public void Clear() {
            _uaDict.Clear();
        }
    }
}
