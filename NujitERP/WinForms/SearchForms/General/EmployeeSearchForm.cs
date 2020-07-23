using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class EmployeeSearchForm : SearchForm{

private CoreFactory _coreFactory = null;

private CoreFactory coreFactory{
	get{
		if (_coreFactory == null)
			_coreFactory = UtilCoreFactory.createCoreFactory();
		return _coreFactory;
	}
	set {_coreFactory = value;}
}

public 
EmployeeSearchForm(string title) : base(title){
}

public 
EmployeeSearchForm(string title, CoreFactory coreFactory) : base(title){
	_coreFactory = coreFactory;
}

protected override 
string[][] search(string searchText){
	string[][] founded = coreFactory.getEmployeeByDesc(searchText,0);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[3][];

	string[] column = new string[2];
	column[0] = "ID";
	column[1] = "150";
	columns[0] = column;

	column = new string[2];
	column[0] = "First Name";
	column[1] = "280";
	columns[1] = column;

	column = new string[2];
	column[0] = "Last Name";
	column[1] = "280";
	columns[2] = column;

	return columns;
}

} // class

} // namespace
