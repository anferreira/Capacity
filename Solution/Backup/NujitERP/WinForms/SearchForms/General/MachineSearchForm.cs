using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

public 
class MachineSearchForm : SearchForm{

private System.ComponentModel.Container components = null;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private string plant;
private string department;

public MachineSearchForm(string title, string plant, string department, string searchPattern) : base(title, searchPattern){
	this.plant = plant;
	this.department = department;
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

	founded = coreFactory.getMachinesByPltDeptAndDesc(plant, department, searchText);
	return founded;
}

protected override
string[][] getColumns(){
	string[][] columns = new string[6][];

	string[] column = new string[2];
	column[0] = "Plant";
	column[1] = "100";
	columns[0] = column;

	column = new string[2];
	column[0] = "Department";
	column[1] = "100";
	columns[1] = column;

	column = new string[2];
	column[0] = "Machine";
	column[1] = "100";
	columns[2] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "200";
	columns[3] = column;

	column = new string[2];
	column[0] = "Mach Type";
	column[1] = "100";
	columns[4] = column;
	
	column = new string[2];
	column[0] = "Sch Type";
	column[1] = "100";
	columns[5] = column;

	return columns;
}

}
}
