using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class CompanySearchForm : SearchForm{

	string sdb="";

public 
CompanySearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getCompanyByDesc(searchText,sdb);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[4][];

	string[] column = new string[2];
	column[0] = "Db";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "Code";
	column[1] = "80";
	columns[1] = column;

	column = new string[2];
	column[0] = "Name";
	column[1] = "250";
	columns[2] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "300";
	columns[3] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.sdb = db;	
}

} // class

} // namespace
