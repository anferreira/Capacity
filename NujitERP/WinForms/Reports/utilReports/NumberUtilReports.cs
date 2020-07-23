using System;
using Nujit.NujitERP.ClassLib.ErpException;


namespace Nujit.NujitERP.ClassLib.Reports.UtilReports{


public 
class NumberUtilReports{
		

public static
string toString(double number){
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == ','){
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
	number = decimal.Round(number, 2);
	string nStr = number.ToString();
	char[] vec = nStr.ToCharArray();
	int decimalCount = 0;

	bool founded = false;
	for(int i = 0; i < vec.Length; i++){
		if (vec[i] == '.'){
			founded = true;
		}else{
			if (vec[i] == ','){
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

	}//end class
}//end namespace
