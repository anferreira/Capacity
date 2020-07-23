using System;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB{

public
class DateUtil{


public static
string getDateRepresentation(DateTime date){
	string dayStr = date.Day.ToString();
	string monthStr = date.Month.ToString();
	string yearStr = date.Year.ToString();
	
	if (dayStr.Length == 1)
		dayStr = "0" + dayStr;
	if (monthStr.Length == 1)
		monthStr = "0" + monthStr;

	if (Configuration.SqlRepositoryType.Equals("SQLServer"))
		return monthStr + "/" + dayStr + "/" + yearStr; // month, day, year, separated by /
	else
		return yearStr + "-" + monthStr + "-" + dayStr; // year, month, day separated by -
}

public static
string getCompleteDateRepresentation(DateTime date){
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

	if (Configuration.SqlRepositoryType.Equals("SQLServer"))
		return monthStr + "/" + dayStr + "/" + yearStr + " " + hourStr + ":" + 
			minStr + ":" + secStr;
	else
		return yearStr + "-" + monthStr + "-" + dayStr + " " + hourStr + ":" + minStr + ":" + secStr;
}


private static
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
		return new DateTime(int.Parse(items[2]),
			int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[3]),
			int.Parse(items[4]), int.Parse(items[5]));
	default:
		return new DateTime(0);
	}
}

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
	case YYYYMMDD_AS:
		return yearStr + "-" + monthStr + "-" + dayStr;

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
	case YYYYMMDD_AS:
		return yearStr + "-" + monthStr + "-" + dayStr + " " + hourStr + ":" + 
			minStr + ":" + secStr;
	}
	return "";
}

public static
string getDateRepresentation(int format){
	return DateUtil.getDateRepresentation(DateTime.Today, format);
}

private static
bool isValidTime(string time){ // HH:MM format
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

	if (index != 1)
		return false;

	for(int i = 0; i < items.Length; i++){
		if (items[i].Equals(""))
			return false;
	}

	try{
		DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
			DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), 0, 0);
		return true;
	}catch(System.Exception){
		return false;
	}
}

private static 
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

private static 
bool isValidDB2Time(string time){ 
	string[] items = time.Trim().Split('.');
	
	if (items.GetLength(0)!=3)
		return false;

	for(int i = 0; i < items.Length; i++)
	{
		if (items[i].Equals(""))
			return false;
	}

	try
	{
		DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
			DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
		return true;
	}
	catch(System.Exception)
	{
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

private static 
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

private static
DateTime parseTime(string time){ // HH:MM format
	if (!DateUtil.isValidTime(time))
		throw new PersistenceException("Invalid Format of Date");
	
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

private static 
DateTime parseDB2Time(string time){ // HH.MM.SS format
	if (!DateUtil.isValidDB2Time(time))
		throw new PersistenceException("Invalid Format Of Date");

	string[] items = time.Trim().Split('.');

	DateTime auxDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
		DateTime.Today.Day, int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), 0);
	return auxDate;
}

public const int HOUR_ITEM = 0;
public const int MIN_ITEM = 1;
public const int DDMMYYYY = 0;
public const int MMDDYYYY = 1;
public const int YYYYMMDD_AS = 2;
public const int YYYYMMDD = 3;
public static DateTime MinValue = new DateTime(1901, 01, 01, 0, 0, 0);

} // class

} // namespace
