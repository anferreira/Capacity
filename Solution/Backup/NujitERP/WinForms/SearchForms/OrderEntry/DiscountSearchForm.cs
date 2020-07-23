using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class DiscountSearchForm : SearchForm{

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
DiscountSearchForm(string title) : base(title){
}

public 
DiscountSearchForm(string title, CoreFactory coreFactory) : base(title){
	_coreFactory = coreFactory;
}

protected override
string[][] search(string searchText){
	string[][] founded = coreFactory.getDiscountsByDesc(searchText,0);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[3][];

	string[] column = new string[2];
	column[0] = "Code";
	column[1] = "100";
	columns[0] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "460";
	columns[1] = column;

	column = new string[2];
	column[0] = "Percent / Amount";
	column[1] = "120";
	columns[2] = column;

	return columns;
}

} // class

} // namespace
