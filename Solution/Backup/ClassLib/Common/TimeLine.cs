using System;

namespace Nujit.NujitERP.ClassLib.Common
{

	public class TimeLine
	{
		#region Vars
		private int[] _MinuteLine;
		
		
		#endregion Vars

  		public TimeLine()
		{
			InitializeMinuteline();
		}

		public void InitializeMinuteline()
		{
		
			this._MinuteLine = new int[1440];
			
			for (int i = 0; i<1440;i++)
			{
					_MinuteLine[i] =0; 
			}
		}

		public bool FillInTimeSlot(int intStartTimeInMinute, int intEndTimeInMinute)
		{
		
			bool result = true;
			
			int count = 0 ;

			for (int i = intStartTimeInMinute; i <=intEndTimeInMinute; i++ )
			{
				if (this._MinuteLine[i] == 1 && i != intStartTimeInMinute && i != intEndTimeInMinute)
				{
				   result = false; break;
       			}
				count++;
				this._MinuteLine[i] = 1;

//				if (this._MinuteLine[i] == 1)
//				{
//				   result = false; break;
//       			}
//				count++;
//				this._MinuteLine[i] = 1;
			}

			return ( result && (count !=0));//; && (count == intEndTimeInMinute - intStartTimeInMinute));
		}

		public bool FillInTimeSlot(string strStartHourMin, string strEndHourMin)   //hh:mm
		{
			 int intStartTimeInMinute = HourMinuteToMinute( strStartHourMin) ;
			 int intEndTimeInMinute   = HourMinuteToMinute( strEndHourMin) ;
 			 return FillInTimeSlot( intStartTimeInMinute, intEndTimeInMinute);
		}

		
		public void ClearTimeSlot(int intStartTimeInMinute, int intEndTimeInMinute)
		{
			for (int i = intStartTimeInMinute; i <=intEndTimeInMinute; i++ )
			{
			
				this._MinuteLine[i] = 0;

			}
		}

		public void ClearTimeSlot(string strStartHourMin, string strEndHourMin)   //hh:mm
		{
			int intStartTimeInMinute = HourMinuteToMinute( strStartHourMin) ;
			int intEndTimeInMinute   = HourMinuteToMinute( strEndHourMin) ;
			ClearTimeSlot(intStartTimeInMinute, intEndTimeInMinute);
		}

  
		#region TimeLine and TimeSlot

		static int HourMinuteToMinute(string strHourMinute)// hh:mm
		{
			 int intHour = TimeLine.GetTime(strHourMinute,"h");
			 
			 int intMinute =   TimeLine.GetTime(strHourMinute,"m");
			 
			return	intMinute +  intHour * 60 ; 
		
		}



		#endregion	 TimeLine and TimeSlot

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
			return Math.Round((decimal)MinuteSpan(intStartHour, intStartMinute, intEndHour, intEndMinute) / 60 , 2);
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

		public static int  LastDayInDayOfWeek(int intDay)
		{
			if	(intDay == 0)
				return 6;

			return --intDay;
		
		}

		#endregion

	}
}
