using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

public 
class PlantSearchForm : SearchForm{

public 
PlantSearchForm(string title) : base(title){
}

protected override
string[][] search(string searchText){
	string[][] founded = UtilCoreFactory.createCoreFactory().getPlantsByDesc(searchText);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[6][];			

	string[] column = new string[2];
	column[0] = "Plant";
	column[1] = "80";
	columns[0] = column;

	column = new string[2];
	column[0] = "Name";
	column[1] = "120";
	columns[1] = column;

	column = new string[2];
	column[0] = "Ads1";
	column[1] = "120";
	columns[2] = column;

	column = new string[2];
	column[0] = "Ads2";
	column[1] = "120";
	columns[3] = column;

	column = new string[2];
	column[0] = "Ads3";
	column[1] = "120";
	columns[4] = column;

	column = new string[2];
	column[0] = "Ads4";
	column[1] = "120";
	columns[5] = column;

	return columns;
}

} // class
} // namespace
