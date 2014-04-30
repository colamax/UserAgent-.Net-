using System;
using System.Collections.Generic;
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
        ReaderWriterLock _locker = new ReaderWriterLock();
        Dictionary<string, TerminalModel> _uaDict = new Dictionary<string, TerminalModel>();
        UaNotClearUserAgent uncua = new UaNotClearUserAgent();

        
        public UserAgentParser()
        {
            LoadData();
        }

        TerminalModel GetCache(string userAgent)
        {
            TerminalModel tm = null;
            _locker.AcquireReaderLock(1000);
            _uaDict.TryGetValue(userAgent, out tm);
            _locker.ReleaseReaderLock();
            return tm;
        }

        void SetCache(string userAgent, TerminalModel tm)
        {
            _locker.AcquireWriterLock(1000);
            _uaDict[userAgent] = tm;
            _locker.ReleaseWriterLock();
        }

        private void LoadData()
        {
            _parserList.Add(new IOSParser());
            _parserList.Add(new UCBrowserParser());
            _parserList.Add(new MQQBrowserParser());
            _parserList.Add(new KJAVAParser());
            _parserList.Add(new MAUIParser());
            _parserList.Add(new MicroMessengerParser());
            _parserList.Add(new BaiduBrowserParser());
            _parserList.Add(new BaiduBoxAppParser());
            _parserList.Add(new BlackBerryParser());
            _parserList.Add(new TouchPalv5Parser());
            _parserList.Add(new AdrByLanguageParser());
            _parserList.Add(new AdrByPixelParser());
            _parserList.Add(new AdrByLanguagePixelParser());
            _parserList.Add(new WPOSTxtParser());
            _parserList.Add(new MacintoshParser());
			_parserList.Add (new AdrTxtParser ());
        }
        public TerminalModel ParseUserAgent(String userAgent)
        {
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
                    if (tm.Platform != null)
                    {
                        SetCache(userAgent, tm);
                        return tm;
                    }
                }
            }
            //uncua.UserAgent = userAgent;
            //try
            //{
            //    dataBase.Insert(uncua);
            //}
            //catch (Exception e)
            //{
            //    e.ToString();
            //}
            if (OnProcessUnknowUa != null)
            {
                //OnProcessUnknowUa.BeginInvoke(userAgent, new AsyncCallback(Callback), OnProcessUnknowUa);
                OnProcessUnknowUa(userAgent);
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
        
        internal void Clear()
        {
            _parserList.Clear();
            _uaDict.Clear();
        }
    }
}
