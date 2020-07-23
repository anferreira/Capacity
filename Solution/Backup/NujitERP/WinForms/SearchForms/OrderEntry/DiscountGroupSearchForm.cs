using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class DiscountGroupSearchForm : SearchForm{

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
DiscountGroupSearchForm(string title) : base(title){
}

public 
DiscountGroupSearchForm(string title, CoreFactory coreFactory) : base(title){
	_coreFactory = coreFactory;
}

protected override
string[][] search(string searchText) {
	string[][] founded = coreFactory.getGroupDiscByCode(searchText);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[6][];

	string[] column = new string[2];
	column[0] = "Code";
	column[1] = "55";
	columns[0] = column;

	column = new string[2];
	column[0] = "Discount No 1";
	column[1] = "125";
	columns[1] = column;

	column = new string[2];
	column[0] = "Discount No 2";
	column[1] = "125";
	columns[2] = column;

	column = new string[2];
	column[0] = "Discount No 3";
	column[1] = "125";
	columns[3] = column;

	column = new string[2];
	column[0] = "Discount No 4";
	column[1] = "125";
	columns[4] = column;

	column = new string[2];
	column[0] = "Discount No 5";
	column[1] = "125";
	columns[5] = column;

	return columns;
}

} // class

} // namespace
