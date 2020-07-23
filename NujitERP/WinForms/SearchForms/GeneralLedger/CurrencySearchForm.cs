using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class CurrencySearchForm : SearchForm{
	string sdb="";

public 
CurrencySearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getCurrencyByDesc(searchText,sdb);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[3][];

	string[] column = new string[2];
	column[0] = "Db";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "Currency";
	column[1] = "80";
	columns[1] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "200";
	columns[2] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.sdb = db;
}

} // class

} // namespace
