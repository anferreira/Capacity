using System;
using System.Text.RegularExpressions;

namespace Nujit.NujitERP.ClassLib.Common
{
	
	public enum RegexType
	{
		Price           = 1,               
		NotZeroNumber   = 2,               
		Email           = 3,
		ZeroNumber      = 4,
		NatureNumer     = 5,
		CurrencyRate    = 6,
	}
	
	public class RegexBuilder
	{
		private RegexBuilder(){}

		public static string GetRegex(RegexType regexType )
		{
			string ret = "";
	
			switch (regexType)
			{
				case  RegexType.Price:
				{
					ret = @"^[0-9]{1,15}\.[0-9]{1,2}$|^[0-9]{1,15}$";  //00000.00-99999.99 or 0-99999
					break;			
				}
				case  RegexType.CurrencyRate:
				{
					ret = @"^[0-9]{1,10}\.[0-9]{1,4}$|^[0-9]{1,15}$";  //00000.00-99999.99 or 0-99999
					break;			
				}
							
				case RegexType.NotZeroNumber:
				{
					ret = @"^[0-9]*[1-9][0-9]*$";                      //1---, should ckeck length
					break;		
				}
				case RegexType.NatureNumer:
				{
					ret = @"^[0-9]*[1-9][0-9]*$";                      //1---, should ckeck length
					break;		
				}
				case RegexType.Email:
				{
					ret = @"[\w-]+(\.+[\w-]*)?@([\w-]+\.)+[\w-]+";
					break;
				}
						
			}
			return ret;
		}
	}
}

