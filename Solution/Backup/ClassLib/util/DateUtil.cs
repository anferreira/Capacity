using System;

using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Util{

public
class DateUtil{

public const int HOUR_ITEM = 0;
public const int MIN_ITEM = 1;
public const int DDMMYYYY = 0;
public const int MMDDYYYY = 1;
public const int YYYYMMDD_AS = 2;
public const int YYYYMMDD = 3;
public static DateTime MinValue = new DateTime(1901, 01, 01, 0, 0, 0);
public static DateTime MaxValue = DateTime.MaxValue;


public static
bool isValidDate(string date, int format){
	char[] vec = date.ToCharArray();

	string[] items = new string[3];
	items[0] = "";
	items[1] = "";
	items[2] = "";

	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] != '/')
			items[index] += vec[i];
		else
			index++;
	}

	if (index != 2)
		return false;

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return false;
	}

	try{
		DateTime auxDate = DateTime.Now;
		switch(format){
		case DDMMYYYY:
			auxDate = new DateTime(int.Parse(items[2]),
				int.Parse(items[1]), int.Parse(items[0]));
			return true;
		case MMDDYYYY:
			auxDate = new DateTime(int.Parse(items[2]),
				int.Parse(items[0]), int.Parse(items[1]));
			return true;
		}
		return false;
	}catch(System.Exception){
		return false;
	}
}

public static
DateTime parseDate(string date, int format){
	char[] vec = date.ToCharArray();

	string[] items = new string[3];
	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if ((vec[i] != '/') && (vec[i] != '-'))
			items[index] += vec[i];
		else
			index++;
	}

	if (index != 2)
		return new DateTime(1901, 01, 01);

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return new DateTime(1901, 01, 01);
	}

	switch(format){
	case DDMMYYYY:
		return new DateTime(int.Parse(items[2]),
			int.Parse(items[1]), int.Parse(items[0]));
	case MMDDYYYY:
		return new DateTime(int.Parse(items[2]),
			int.Parse(items[0]), int.Parse(items[1]));
	case YYYYMMDD:
		if (date.Equals("0001/01/01"))
			return new DateTime(1901, 01, 01);
		return new DateTime(int.Parse(items[0]),
			int.Parse(items[1]), int.Parse(items[2]));
	case YYYYMMDD_AS:
		if (date.Equals("0001-01-01"))
			return new DateTime(1901, 01, 01);
		return new DateTime(int.Parse(items[0]),
			int.Parse(items[1]), int.Parse(items[2]));
	default:
		return new DateTime(0);
	}
}

public static
DateTime parseCompleteDate(string date, int format){
	char[] vec = date.ToCharArray();

	string[] items = new string[6]; // yyyy/mm/dd hh:mm:ss
	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if ((vec[i] != '/') && (vec[i] != ':') && (vec[i] != ' '))
			items[index] += vec[i];
		else
			index++;
	}
	
	if (index != 5)
		return new DateTime(0);

	for(int i = 0; i < items.Length; i++){
		if ((items[i] == null) || (items[i].Equals("")))
			return new DateTime(0);
	}

	switch(format){
	case DDMMYYYY:
		int year = int.Parse(items[2]);
		int month = int.Parse(items[1]);
		int day = int.Parse(items[0]);
		int hour = int.Parse(items[3]);
		int min = int.Parse(items[4]);
		int sec = int.Parse(items[5]);
		return new DateTime(year, month, day, hour, min, sec, 0);
	case MMDDYYYY:
		DateTime tempDate = new DateTime(int.Parse(items[2]),
			int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[3]),
			int.Parse(items[4]), int.Parse(items[5]));
		return tempDate;
	default:
		return new DateTime(0);
	}
}

//Claudia
//Return a date sparated by '-'
public static
string formatCompleteDate(DateTime date, int format){
	string dayStr = date.Day.ToString();
	string monthStr = date.Month.ToString();
	string yearStr = date.Year.ToString();
	string hourStr = date.Hour.ToString();
	string minStr = date.Minute.ToString();
	string secStr = date.Second.ToString();

	if (dayStr.Length == 1)
		dayStr = "0" + dayStr;
	if (monthStr.Length == 1)
		monthStr = "0" + monthStr;
	if (hourStr.Length == 1)
		hourStr = "0" + hourStr;
	if (minStr.Length == 1)
		minStr = "0" + minStr;
	if (secStr.Length == 1)
		secStr = "0" + secStr;
	
	switch(format){
	case DateUtil.DDMMYYYY:
		return dayStr + "-" + monthStr + "-" + yearStr + "-" + hourStr + "-" + 
			minStr + ":" + secStr;
	case DateUtil.MMDDYYYY:
		return monthStr + "-" + dayStr + "-" + yearStr + "-" + hourStr + "-" + 
			minStr + "-" + secStr;
	}
	return "";
}

//

public static
string getDateRepresentation(DateTime date, int format){
	string dayStr = date.Day.ToString();
	string monthStr = date.Month.ToString();
	string yearStr = date.Year.ToString();
	
	if (dayStr.Length == 1)
		dayStr = "0" + dayStr;
	if (monthStr.Length == 1)
		monthStr = "0" + monthStr;

	switch(format){
	case DateUtil.DDMMYYYY:
		return dayStr + "/" + monthStr + "/" + yearStr;
	case DateUtil.MMDDYYYY:
		return monthStr + "/" + dayStr + "/" + yearStr;
	case DateUtil.YYYYMMDD:
		return yearStr + "/" + monthStr + "/" + dayStr;
	}
	return "";
}

public static
string getCompleteDateRepresentation(DateTime date, int format){
	string dayStr = date.Day.ToString();
	string monthStr = date.Month.ToString();
	string yearStr = date.Year.ToString();
	string hourStr = date.Hour.ToString();
	string minStr = date.Minute.ToString();
	string secStr = date.Second.ToString();

	if (dayStr.Length == 1)
		dayStr = "0" + dayStr;
	if (monthStr.Length == 1)
		monthStr = "0" + monthStr;
	if (hourStr.Length == 1)
		hourStr = "0" + hourStr;
	if (minStr.Length == 1)
		minStr = "0" + minStr;
	if (secStr.Length == 1)
		secStr = "0" + secStr;
	
	if ((date.Year == 1) || (date.Year == 1900))
		return "";

	switch(format){
	case DateUtil.DDMMYYYY:
		return dayStr + "/" + monthStr + "/" + yearStr + " " + hourStr + ":" + 
			minStr + ":" + secStr;
	case DateUtil.MMDDYYYY:
		return monthStr + "/" + dayStr + "/" + yearStr + " " + hourStr + ":" + 
			minStr + ":" + secStr;
	}
	return "";
}

public static
string getDateRepresentation(int format){
	return DateUtil.getDateRepresentation(DateTime.Today, format);
}

public static
bool isValidTime(string time){ // HH:MM format
	char[] vec = time.ToCharArray();

	string[] items = new string[3];
	items[0] = "";
	items[1] = "";
	items[2] = "00";

	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] != ':')
			items[index] += vec[i];
		else
			index++;
	}

	if ((index != 1) && (index != 2))
		return false;

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return false;
	}

	try{
		DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
			DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
		return true;
	}catch(System.Exception){
		return false;
	}
}

public static 
bool isValidTimeHMS(string time){ // HH:MM format
	char[] vec = time.ToCharArray();

	string[] items = new string[3];
	items[0] = "";
	items[1] = "";
	items[2] = "";

	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] != ':')
			items[index] += vec[i];
		else
			index++;
	}

	if (index != 2)
		return false;

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return false;
	}

	try{
		DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
			DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
		return true;
	}catch(System.Exception){
		return false;
	}
}

public static 
bool isValidDB2Time(string time){ // HH.MM.SS format

	/*char[] vec = time.ToCharArray();

	string[] items = new string[3];
	items[0] = "";
	items[1] = "";
	items[2] = "";

	int index = 0;

	for(int i = 0; i < vec.Length; i++)
	{
		if (vec[i] != '.')
			items[index] += vec[i];
		else
			index++;
	}

	if (index != 2)
		return false;*/

	string[] items = time.Trim().Split('.');
	
	if (items.GetLength(0)!=3)
		return false;

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return false;
	}

	try{
		DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
			DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
		return true;
	}catch(System.Exception){
		return false;
	}
}

public static
string getTimeRepresentation(DateTime date){
	string strHour = date.Hour.ToString();
	if (strHour.Length == 1)
		strHour = "0" + strHour;
	string strMin = date.Minute.ToString();
	if (strMin.Length == 1)
		strMin = "0" + strMin;
	string strSec = date.Second.ToString();
	if (strSec.Length == 1)
		strSec = "0" + strSec;
	return strHour + ":" + strMin +  ":" + strSec;
}

public static 
string getDB2TimeRepresentation(DateTime date){
	string strHour = date.Hour.ToString();
	if (strHour.Length == 1)
		strHour = "0" + strHour;
	string strMin = date.Minute.ToString();
	if (strMin.Length == 1)
		strMin = "0" + strMin;
	string strSec = date.Second.ToString();
	if (strSec.Length == 1)
		strSec = "0" + strSec;
	return strHour + "." + strMin +  "." + strSec;
}

public static
DateTime parseTime(string time){ // HH:MM format
	if (!DateUtil.isValidTime(time))
		throw new NujitException("Invalid Format");
	
	
	char[] vec = time.ToCharArray();

	string[] items = new string[2];
	items[0] = "";
	items[1] = "";

	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] != ':')
			items[index] += vec[i];
		else
			index++;
	}

	DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
		DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), 0, 0);
	return auxDate;
}

public static 
DateTime parseDB2Time(string time) { // HH.MM.SS format
	if (!DateUtil.isValidDB2Time(time))
		throw new NujitException("Invalid Format");

	string[] items = time.Trim().Split('.');

	DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
		DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
	return auxDate;
}

public static
int compareTime(string time1, string time2){
	if ((!DateUtil.isValidTime(time1)) || (!DateUtil.isValidTime(time2)))
		throw new NujitException("There are invalid formats");

	DateTime t1 = DateUtil.parseTime(time1);
	DateTime t2 = DateUtil.parseTime(time2);

	return t1.CompareTo(t2);
}

public static
int getDayOfWeek(DateTime dateTime){
	switch(dateTime.DayOfWeek){
	case DayOfWeek.Sunday:
		return 1;
	case DayOfWeek.Monday:
		return 2;
	case DayOfWeek.Tuesday:
		return 3;
	case DayOfWeek.Wednesday:
		return 4;
	case DayOfWeek.Thursday:
		return 5;
	case DayOfWeek.Friday:
		return 6;
	case DayOfWeek.Saturday:
		return 7;
	}

	throw new NujitException("Error in day of week");
}

/// <summary>
/// Gets the hour of a time
/// </summary>
/// <param name="time"></param>
/// <returns></returns>
public static
int getItemFromTime(string time, int item){ // HH:MM format
	if (!DateUtil.isValidTime(time))
		throw new NujitException("Invalid Format Time");
	
	
	char[] vec = time.ToCharArray();

	string[] items = new string[3];
	items[0] = "";
	items[1] = "";
	items[2] = "00";

	int index = 0;
	
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] != ':')
			items[index] += vec[i];
		else
			index++;
	}

	if (item == HOUR_ITEM)
		return int.Parse(items[0]);
	if (item == MIN_ITEM)
		return int.Parse(items[1]);
	
	throw new NujitException("Invalid item number");
}


public static
string getMonthName(int month){
	switch(month){
	case 1:
		return "Jan";
	case 2:
		return "Feb";
	case 3:
		return "March";
	case 4:
		return "April";
	case 5:
		return "May";
	case 6:
		return "Jun";
	case 7:
		return "Jul";
	case 8:
		return "Aug";
	case 9:
		return "Sep";
	case 10:
		return "Oct";
	case 11:
		return "Nov";
	case 12:
		return "Dec";
	}
	return "";
}

public static
string getNameDayOfWeek(DateTime dateTime){
	switch(getDayOfWeek(dateTime)){
	case 1:
		return "Sun";
	case 2:
		return "Mon";
	case 3:
		return "Tue";
	case 4:
		return "Wed";
	case 5:
		return "Thu";
	case 6:
		return "Fri";
	case 7:
		return "Sat";
	}
	throw new NujitException("Error in day of week");
}

public static
string getNextDayOfWeek(string day){
	switch(day){
	case "Sun":
		return "Mon";
	case "Mon":
		return "Tue";
	case "Tue":
		return "Wed";
	case "Wed":
		return "Thu";
	case "Thu":
		return "Fri";
	case "Fri":
		return "Sat";
	case "Sat":
		return "Sun";
	}
	throw new NujitException("Error in day of week");
}

public static
TimeSpan getTimeSpanFromDays (decimal days){
	return DateUtil.getTimeSpanFromHours (days * 24);
}

public static
TimeSpan getTimeSpanFromHours(decimal hours){
	int seconds = (int)Math.Floor((double)(hours * 60 * 60));
	return new TimeSpan (0, 0, seconds);
}

public static
DateTime subtractDaysExcludeSatandSun(DateTime baseDate, double days, bool excludeSat, bool excludeSun){
	int sats = 0;
	int suns = 0;

	for(int i = 1; i < days + 1; i++){
		DateTime aux = baseDate.AddDays(i * (-1));
		if ((excludeSat) && (aux.DayOfWeek == DayOfWeek.Saturday)){
			sats++;
			days++;
		}
		if ((excludeSun) && (aux.DayOfWeek == DayOfWeek.Sunday)){
			suns++;
			days++;
		}
	}

	return baseDate.AddDays(days * (-1));
}


} // class

} // namespace
