using System;
using System.Runtime.Serialization;


namespace Nujit.NujitERP.ClassLib.Common
{

	public struct PageOptionStruct
	{
		public string Text;
		public string URL;
	}
	
	public struct AdminOptionsStruct
	{
		public string Text;
		public string URL;
		public string QueryStringName;
		public string QueryStringItem;
		
	}
}
