using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class CurrencyDlyExcSearchForm : SearchForm{
	string sdb="";

public 
CurrencyDlyExcSearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getCurrencyDlyExcByDesc(searchText,sdb);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[11][];

	string[] column = new string[2];
	column[0] = "Db";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "Company";
	column[1] = "80";
	columns[1] = column;

	column = new string[2];
	column[0] = "Start Date";
	column[1] = "80";
	columns[2] = column;

    column = new string[2];
	column[0] = "End Date";
	column[1] = "80";
	columns[3] = column;
	
	column = new string[2];
	column[0] = "Currency Base";
	column[1] = "80";
	columns[4] = column;

	column = new string[2];
	column[0] = "Exchange Rate";
	column[1] = "80";
	columns[5] = column;
	
	column = new string[2];
	column[0] = "Currency Code";
	column[1] = "80";
	columns[6] = column;
	
	column = new string[2];
	column[0] = "Date Created";
	column[1] = "0";
	columns[7] = column;

	column = new string[2];
	column[0] = "User Created";
	column[1] = "0";
	columns[8] = column;

	column = new string[2];
	column[0] = "Date Updated";
	column[1] = "0";
	columns[9] = column;
	
	column = new string[2];
	column[0] = "User Updated";
	column[1] = "0";
	columns[10] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.sdb = db;
}

} // class

} // namespace
