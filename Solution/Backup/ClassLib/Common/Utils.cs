using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;  

namespace Nujit.NujitERP.ClassLib.Common
{
	public class Utils
	{
		#region Time 

		public static int MinuteSpan(int intStartHour, int intStartMinute, int intEndHour, int intEndMinute)
		{ 
			if	( intStartHour == 24)	 intStartHour = 0;
			if	( intEndHour == 24)	     intEndHour = 0;

			if	( intStartMinute == 60)	 intStartMinute = 0;
			if	( intEndMinute == 60)	 intEndMinute = 0;

//
//			if (intStart <= intEnd)
//			return   (intEnd - intStart);
			
			int intMinuteSpan = 0;

			while (intStartHour != intEndHour ||intStartMinute !=intEndMinute )
			{	   
				intMinuteSpan ++;

				if ( ++intStartMinute == 60)
				{
					intStartHour = ++intStartHour % 24;
					intStartMinute = 0;
				}
					
			}
			return	intMinuteSpan;
		}

    	public static decimal HourSpan(int intStartHour, int intStartMinute, int intEndHour, int intEndMinute)
		{
			return Math.Round( (decimal)MinuteSpan(intStartHour, intStartMinute, intEndHour, intEndMinute) / 60 , 1);
		}
	
		public static decimal MinuteToHour(int intMinutes)
		{
			return (decimal) intMinutes / 60;	
		}

   		public static int TimeSpan(int intStart, int intEnd, int intBase)
		{ 
			if	( intStart == intBase)	 intStart = 0;

			if (intStart <= intEnd)
				return   (intEnd - intStart);
			
			int intTimeSpan = 0;

			while (intStart != intEnd)
			{	   
				intTimeSpan ++;
				if ( ++intStart == intBase)
					intStart = 0;
			}
			return	intTimeSpan;
		}

		//strTime -- hh:mm 
      	public static int GetTime(string strTime, string strHOrM)
		{
			if ( strHOrM.ToLower().Equals("h"))
			{
				return (int.Parse(strTime.Substring(0,2)));
			}
			else  if ( strHOrM.ToLower().Equals("m"))
			{
				return (int.Parse(strTime.Substring(3,2)));
			}
			return 0;
		}

		public static int DayOfWeekToNumber(string strDayOfweek)
		{	
			int intDay = 0 ;

			switch ( strDayOfweek.ToUpper())
			{
				case "SUNDAY":
					intDay = 0 ;break;
				case "MONDAY":
				  	intDay = 1 ;break;
				case "TUESDAY":
					intDay = 2 ;break;
				case "WEDNESDAY":
					intDay = 3 ;break;
				case "THURSDAY":
					intDay = 4 ;break;
				case "FRIDAY":
					intDay = 5 ;break;
				case "SATURDAY":
					intDay = 6 ;break;
			}
			return	intDay;
		}

		public static string NumberToDayOfWeek(int intDay)
		{	
			string strDayOfweek = string.Empty ;

			switch ( intDay )
			{
				case 0:
					strDayOfweek = "Sunday" ;break;
				case 1:
					strDayOfweek = "Monday" ;break;
				case 2:
					strDayOfweek = "Tuesday" ;break;
				case 3:
					strDayOfweek = "Wednesday" ;break;
				case 4:
					strDayOfweek = "Thursday" ;break;
				case 5:
					strDayOfweek = "Friday" ;break;
				case 6:
					strDayOfweek = "Saturday" ;break;
			}
			return	strDayOfweek;
		
		}

		#endregion

		#region string format builder

		public static string StringFillZero(string s, int n)
		{
			string strReturn = s;
			for(int i=n;i>s.Length;i--)
			{
				strReturn = "0" + strReturn;
			}

			
			return strReturn;
		}
		
		public static string StringPrefixAndMiddleFillZero(string strPrefix,string s, int totalLength)
		{   
			string strReturn = s;

			if ( (strPrefix.Length + s.Length) > totalLength)
			{
				return strReturn;
			}
			else
			{
				strReturn = s.PadLeft((totalLength - strPrefix.Length),'0') ;
    			strReturn = strPrefix + strReturn;
			}
			return strReturn;
		}

		public static int HexToDec(string hex)
		{
			int dec = 0;
			
			while(hex.Length > 0)
			{
				string s = hex.Substring(0,1).ToUpper();
				int n = 0;

				switch(s)
				{	
					case "A": n = 10;break;
					case "B": n = 11;break;
					case "C": n = 12;break;
					case "D": n = 13;break;
					case "E": n = 14;break;
					case "F": n = 15;break;
					default: n = int.Parse(s);break;
				}

				dec = dec*16 + n;

				hex = hex.Substring(1);  
			}

			return dec;
		}


		#endregion

		#region log file
		
		public static string GetLogFileName()
		{
			System.DateTime dt = System.DateTime.Now;
			return(Utils.StringFillZero(dt.Year.ToString(),4) + Utils.StringFillZero(dt.Month.ToString(),2) + Utils.StringFillZero(dt.Day.ToString(),2) + Utils.StringFillZero(dt.Hour.ToString(),2) + Utils.StringFillZero(dt.Minute.ToString(),2) + Utils.StringFillZero(dt.Second.ToString(),2));
		}

		#endregion

		#region image

		public static System.Drawing.Image DownloadOnlineImage(string strImageURL)
		{
			System.Drawing.Image imgOnline;
 
			WebClient objClient = new WebClient();
			//objClient.Headers.Add("Content-Type","image/gif");
			byte[] arrByteResponse = objClient.DownloadData(strImageURL);
			objClient.Dispose();

			MemoryStream stream = new MemoryStream(arrByteResponse);
			imgOnline = System.Drawing.Image.FromStream(stream);
			
			return(imgOnline);
		}
		
		public static System.Drawing.Color GetColorFromHexCode(string strHexCode)
		{
			System.Drawing.Color color = Color.White;

			if(strHexCode != null && strHexCode != string.Empty && strHexCode.Length == 6)
			{
				color = Color.FromArgb(HexToDec(strHexCode.Substring(0,2)),HexToDec(strHexCode.Substring(2,2)),HexToDec(strHexCode.Substring(4,2)));
			}

			return color;
		}

		#endregion

		#region Regular expression check

		public static bool RegexCheck(String strNumber, RegexType regexType)
		{	
			string strPattern = RegexBuilder.GetRegex(regexType );

			Regex objPattern = new Regex(strPattern);
			
			return objPattern.IsMatch(strNumber);
		}

		#endregion

		#region popup message

		public static void PopupError(Exception e)
		{	
			PopupEvent("N/A", e.Message, 0);
			return;
		}

		public static void PopupError(string errorMsg)
		{			
			PopupEvent("N/A", errorMsg, 0);
			return;
		}
		
		public static void PopupError(int errorNumber, Exception e)
		{			
			PopupEvent(errorNumber.ToString(), e.Message, 0);
			return;
		}

		public static void PopupMessage(string message)
		{
			PopupEvent("N/A", message, 1);
			return;
		}
		
		private static void PopupEvent(string errorNumber, string messageBody, int option) 
		{
			string strMessage;
			
			if(option == 0)
			{
				strMessage = "" +
					"Error Number: " + errorNumber + "\n\n" +
					"Error Message: \n------------------------\n" + messageBody;

				MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				strMessage = messageBody;

				MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return;
		}

		#endregion
		
	}
}
