using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class FamilyPartSearchForm : SearchForm{
 
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

public 
FamilyPartSearchForm(string title) : base(title){
}

public 
FamilyPartSearchForm(string title, string searchPattern) : base(title, searchPattern){
}


protected override 
string[][] search(string searchText){
	string[][] founded = coreFactory.getFamilyPartsByDesc(searchText);

	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[10][];

	string[] column = new string[2];
	column[0] = "Family";
	column[1] = "100";
	columns[0] = column;
	
	column = new string[2];
	column[0] = "Family Seq";
	column[1] = "80";
	columns[1] = column;
	
	column = new string[2];
	column[0] = "Part";
	column[1] = "100";
	columns[2] = column;
	
	column = new string[2];
	column[0] = "Part Seq";
	column[1] = "80";
	columns[3] = column;
	
	column = new string[2];
	column[0] = "Qty";
	column[1] = "80";
	columns[4] = column;
	
	column = new string[2];
	column[0] = "Inv Uom";
	column[1] = "70";
	columns[5] = column;
	
	column = new string[2];
	column[0] = "Qty Available";
	column[1] = "100";
	columns[6] = column;
	
	column = new string[2];
	column[0] = "Shut";
	column[1] = "80";
	columns[7] = column;
			
	column = new string[2];
	column[0] = "Min Qty";
	column[1] = "80";
	columns[8] = column;
	
	column = new string[2];
	column[0] = "Max Qty";
	column[1] = "80";
	columns[9] = column;
	
	return columns;
}

} // class
} // namespace
