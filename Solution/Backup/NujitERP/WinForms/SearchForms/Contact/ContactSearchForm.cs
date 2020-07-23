using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{
	
public 
class ContactSearchForm : SearchForm{

public 
ContactSearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getContactsByDesc(searchText);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[4][];

	string[] column = new string[2];
	column = new string[2];
	column[0] = "ID";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "First Name";
	column[1] = "180";
	columns[1] = column;

	column = new string[2];
	column[0] = "Second Name";
	column[1] = "180";
	columns[2] = column;

	column = new string[2];
	column[0] = "Last Name";
	column[1] = "180";
	columns[3] = column;

	return columns;
}

} // class

} // namespace
