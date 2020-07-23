using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

public 
class ToolSearchForm : SearchForm{

private System.ComponentModel.Container components = null;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

public 
ToolSearchForm(string title) : base(title){
}

protected 
override void Dispose( bool disposing ){
	if( disposing ){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

protected override 
string[][] search(string searchText){
	string[][] founded = null;

	founded = coreFactory.getPdToolByDesc(searchText, 0);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[14][];

	string[] column = new string[2];
	column[0] = "Entry#";
	column[1] = "80";
	columns[0] = column;
	
	column = new string[2];
	column[0] = "Db";
	column[1] = "0";
	columns[1] = column;
	
	column = new string[2];
	column[0] = "Company";
	column[1] = "100";
	columns[2] = column;
	
	column = new string[2];
	column[0] = "Plant";
	column[1] = "100";
	columns[3] = column;
	
	column = new string[2];
	column[0] = "Tool#";
	column[1] = "80";
	columns[4] = column;
	
	column = new string[2];
	column[0] = "Desc1";
	column[1] = "100";
	columns[5] = column;
	
	column = new string[2];
	column[0] = "Desc2";
	column[1] = "100";
	columns[6] = column;
	
	column = new string[2];
	column[0] = "Desc3";
	column[1] = "100";
	columns[7] = column;
	
	column = new string[2];
	column[0] = "Class";
	column[1] = "80";
	columns[8] = column;
	
	column = new string[2];
	column[0] = "Asset Id";
	column[1] = "80";
	columns[9] = column;
	
	column = new string[2];
	column[0] = "Status";
	column[1] = "60";
	columns[10] = column;
	
	column = new string[2];
	column[0] = "SchStatus";
	column[1] = "60";
	columns[11] = column;
	
	column = new string[2];
	column[0] = "Prod UOM";
	column[1] = "80";
	columns[12] = column;
	
	column = new string[2];
	column[0] = "Curr WO";
	column[1] = "80";
	columns[13] = column;
		
	return columns;
}

}
}
