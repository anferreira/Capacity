using System;

using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB{

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
string toString(double number){
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ',' || vec[i] == '.'){
			vec[i] = '.';
			founded = true;
			decimalCount = vec.Length - i - 1;
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

public static
string toString(int number){
    if (!isNull(number)){
	    string nStr = number.ToString();
	    char[] vec = nStr.ToCharArray();
	    for(int i = 0; i < vec.Length; i++){
		    if (vec[i] == ',')
			    vec[i] = '.';
	    }
	    return new string(vec);
	}return "NULL";
}

public static
bool isNull(int ivalue){
	if (ivalue == int.MinValue)
		return true;
	return false;

}

public static 
int boolToint(bool bvalue){
	int iresult = 0;
	if (bvalue)
		iresult = 1;
	return iresult;
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
public static 
bool withPoint(string number){
	char[] vec = number.ToCharArray();
	for (int i = 0; i< vec.Length; i++){
		if (vec[i] == ',')
			return false;
	}
	return true;
}

public static
decimal absolute(decimal num){
	if (num < 0)
		return num * (-1);
	return num;
}

public static
string toString(decimal dvalue, int imaxDigits, int idecPlaces){
    string  sret = "";
    long    lmaxValue = long.MaxValue;
    string  smaxValue = "";
    string  sdecPlaces = "";
    int     i = 0;

    if (imaxDigits > 0){
        for (i = 0; i < imaxDigits; i++)
            smaxValue += 9;
        lmaxValue = Convert.ToInt64(smaxValue);
    }
    for (i = 0; i < idecPlaces; i++)
        sdecPlaces += "#";

    if (dvalue > lmaxValue)
        dvalue = lmaxValue;

    sret = dvalue.ToString("0." + sdecPlaces);

    return sret.Replace(",","."); //just in case , involved
}
} // class

} // namespace
