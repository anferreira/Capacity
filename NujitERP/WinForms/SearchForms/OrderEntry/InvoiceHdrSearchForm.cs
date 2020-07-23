using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class InvoiceHdrSearchForm : SearchForm{
	string sdb="";

public 
InvoiceHdrSearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded =UtilCoreFactory.createCoreFactory().getInvoiceByNum();
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
	column[0] = "Company";
	column[1] = "60";
	columns[1] = column;

	column = new string[2];
	column[0] = "Plant";
	column[1] = "60";
	columns[2] = column;

	column = new string[2];
	column[0] = "Ivnoice  #";
	column[1] = "60";
	columns[2] = column;

	return columns;
}

public 
void setBaseFilter (string db){
	this.sdb = db;
}

} // class
} // namespace
