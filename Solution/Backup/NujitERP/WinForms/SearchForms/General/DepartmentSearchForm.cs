using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class DepartmentSearchForm : SearchForm{

	string sdb="";
	string plt="";
	int company=-1;

public 
DepartmentSearchForm(string title) : base(title){
}

public 
DepartmentSearchForm(string title, string searchPattern) : base(title, searchPattern){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getDepartmentByDesc(searchText,sdb,company,plt);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[5][];

	string[] column = new string[2];
	column[0] = "Db";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "Company Code";
	column[1] = "90";
	columns[1] = column;

	column = new string[2];
	column[0] = "Plant Code";
	column[1] = "80";
	columns[2] = column;

	column = new string[2];
	column[0] = "Code";
	column[1] = "80";
	columns[3] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "300";
	columns[4] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.sdb = db;	
}

public 
void setPlantFilter (string plt){
	this.plt = plt;	
}

public 
void setCompanyFilter (int company){
	this.company = company;	
}

} // class

} // namespace
