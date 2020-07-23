using System;

using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Util{

public
class NumberUtil{ 

public static
bool isIntegerNumber(string number){
	if ((number == null) || (number.Equals("")))
		return false;
	
	try{
		int trash = int.Parse(number);
		return true;
	}catch(System.Exception){
		return false;
	}
}

public static
bool isDoubleNumber(string number)
{
	if ((number == null) || (number.Equals("")))
		return false;

	try
	{
		double trash = double.Parse(number);
		return true;
	}
	catch(System.Exception)
	{
		return false;
	}
}

public static
bool isDecimalNumber(string number)
{
	if ((number == null) || (number.Equals("")))
		return false;

	try
	{
		decimal trash = decimal.Parse(number);
		return true;
	}
	catch(System.Exception)
	{
		return false;
	}
}

public static
string toString(double number)
{
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++)
	{
		if (vec[i] == ',' || vec[i] == '.')
		{
			vec[i] = '.';
			founded = true;
			decimalCount = vec.Length - i - 1;
		}
	}

	string returnNumber = new string(vec);
	if (!founded)
	{
		returnNumber += ".00";
	}
	else
	{
		if (decimalCount == 1)
			returnNumber += "0";
	}
	return returnNumber;
}

public static
string toString(double number, int precision)
{
	string format = "";
	for (int i=0; i<precision; i++)
		format += "";
	string nStr = "";
	if (precision > 0)
		nStr = number.ToString("#,###,###,###,###." + format);
	else if (precision == 0)
		nStr = number.ToString("#,###,###,###,###");
	else
		nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	for(int i = 0; i < vec.Length; i++)
	{
		if (vec[i] == ',')
		{
			vec[i] = '.';
			decimalCount = vec.Length - i - 1;
		}
	}

	return new string(vec);
}

public static
string toString(decimal number, int precision){
	string format = "";
	for (int i=0; i<precision; i++)
		format += "";
	string nStr = "";
	if (precision > 0)
		nStr = number.ToString("#,###,###,###,###." + format);
	else if (precision == 0)
		nStr = number.ToString("#,###,###,###,###");
	else
		nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ','){
			vec[i] = '.';
			decimalCount = vec.Length - i - 1;
		}
	}
	
	string returnNumber = new string(vec);
	return returnNumber;
}

public static
string toString(decimal number){
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ','){
			vec[i] = '.';
			decimalCount = vec.Length - i - 1;
		}
	}
	
	string returnNumber = new string(vec);
	return returnNumber;
}

public static int boolToint(bool bvalue)
{
	int iresult=0;
	if (bvalue)
		iresult=1;
		return iresult;
}

public static bool intToBool(int ivalue)
{
	bool bresult=false;
	if (ivalue != 0)
		bresult=true;
	return bresult;
}

public static
string toString(int number){
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ',')
			vec[i] = '.';
	}
	return new string(vec);
}

public static
string toStringForReport(decimal number){
	number = decimal.Round(number, 2);
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ','){
			vec[i] = '.';
			founded = true;
			decimalCount = vec.Length - i - 1;
		}else{
			if (vec[i] == '.'){
				vec[i] = ',';
				founded = true;
				decimalCount = vec.Length - i - 1;
			}
		}
	}
	
	string returnNumber = new string(vec);
	if (!founded){
		returnNumber += ".00";
	}else{
		if (decimalCount == 1)
			returnNumber += "0";
	}
	return returnNumber;
}

public static
string toStringForReportMaterials(decimal number){
	number = decimal.Round(number, 2);
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ','){
			vec[i] = '.';
			founded = true;
			decimalCount = vec.Length - i - 1;
		}else{
			if (vec[i] == '.'){
				vec[i] = '.';
				founded = true;
				decimalCount = vec.Length - i - 1;
			}
		}
	}
	
	string returnNumber = new string(vec);
	if (!founded){
		returnNumber += ".00";
	}else{
		if (decimalCount == 1)
			returnNumber += "0";
	}
	return returnNumber;
}

//Function that check if the string that is suppose to be a decimal number is with '.' or with ','
public static bool withPoint(string number){
	char[] vec = number.ToCharArray();
	for (int i = 0; i< vec.Length; i++){
		if (vec[i] == ',')
			return false;
	}
	return true;
}

} // class

} // namespace
