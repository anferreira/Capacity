using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class ShiftHdrSearchForm : SearchForm{

	string db = "";
	int company = -1;
	string plt = "";
	string dept = "";

public 
ShiftHdrSearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getShiftHdrByDesc(searchText,db,company,plt,dept);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[6][];

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
	column[0] = "Dept Code";
	column[1] = "80";
	columns[3] = column;

	column = new string[2];
	column[0] = "Code";
	column[1] = "80";
	columns[4] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "250";
	columns[5] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.db = db;	
}

public 
void setCompanyFilter (int company){
	this.company = company;	
}

public 
void setPlantFilter (string plt){
	this.plt = plt;	
}

public 
void setDeptFilter (string dept){
	this.dept = dept;	
}

} // class

} // namespace
