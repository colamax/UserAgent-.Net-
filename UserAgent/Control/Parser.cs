using System;
using UserAgent.Model;
namespace UserAgent.Control
{
	public abstract class Parser
	{
		public abstract Boolean isMatch(String userAgent);

		public abstract TerminalModel getTM (String userAgent); 
	}
}

