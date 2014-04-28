using System;

namespace UserAgent.Model
{
	public class TerminalModel
	{
		string _browser = "";

		public string Browser{
			get{ 
				return _browser;
			}
			set{ 
				_browser = value;
			}
		}

		string _brand = "";

		public string Brand {
			get {
				return _brand;
			}
			set {
				_brand = value;
			}
		}

		string _model = "";

		public string Model {
			get {
				return _model;
			}
			set {
				_model = value;
			}
		}

        //string _operateSystem = "";

        //public string OperateSystem
        //{
        //    get
        //    {
        //        return _operateSystem;
        //    }
        //    set
        //    {
        //        _operateSystem = value;
        //    }
        //}

		string _platform = "";

		public string Platform {
			get {
				return _platform;
			}
			set {
				_platform = value;
			}
		}

		public TerminalModel ()
		{

		}
	}
}

