using System;
using System.Collections.Generic;
using System.Text;

using Light.Data;

namespace UserAgent.Model
{
	[DataTable("UaNotClearUserAgent")]
	public partial class UaNotClearUserAgent : DataTableEntity
	{
		#region "Static Field"
		static DataFieldInfo _idField = DataFieldInfo<UaNotClearUserAgent>.Create("id");
		static DataFieldInfo _userAgentField = DataFieldInfo<UaNotClearUserAgent>.Create("UserAgent");
		#endregion

		#region "Static DataFieldInfo"
		public static DataFieldInfo IdField
		{
			get
			{
				return _idField;
			}
		}
		public static DataFieldInfo UserAgentField
		{
			get
			{
				return _userAgentField;
			}
		}
		#endregion

		#region "Data Property"
		private	int _id;

		[DataField("id", IsIdentity = true, IsPrimaryKey = true, DBType = "int")]
		public int Id
		{
			get
			{
				return 	_id;
			}
			set
			{
				_id = value;
			}
		}
		private	string _userAgent;

		[DataField("UserAgent", DBType = "varchar")]
		public string UserAgent
		{
			get
			{
				return 	_userAgent;
			}
			set
			{
				_userAgent = value;
			}
		}
		#endregion
	}
}


