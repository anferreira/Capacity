using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class PersonSearchForm : SearchForm{

private string filterType="";
private string filterPlant="";
private string _billToCust="";
private CoreFactory coreFactory = null;

public 
PersonSearchForm(string title) : base(title)
{
	coreFactory = UtilCoreFactory.createCoreFactory();
}

public void setBillToCust (string billToCust)
{
	_billToCust = billToCust;
}

public void setFilter (string type)
{
	type = type.ToUpper();
	if (type.Equals("CUSTOMER"))
		type="C";
	if (type.Equals("VENDOR"))
		type="V";
	filterType = type;
}

public void setFilters (string type, string plant)
{
	type = type.ToUpper();
	if (type.Equals("CUSTOMER"))
		type="C";
	if (type.Equals("VENDOR"))
		type="V";
	filterType = type;
	filterPlant = plant;
}


public void setSchText(string schText){
    this.tBoxSearch.Text = schText;

}

protected override
string[][] search(string searchText){
	string[][] founded = coreFactory.getPersonsByDesc(searchText, filterType, filterPlant, _billToCust);
	return founded;
}



protected override
string[][] getColumns(){
	string[][] columns = new string[9][];

	string[] column = new string[2];
	column[0] = "Plant";
	column[1] = "60";
	columns[0] = column;

	column = new string[2];
	column[0] = "Id";
	column[1] = "60";
	columns[1] = column;

	column = new string[2];
	column[0] = "Name";
	column[1] = "160";
	columns[2] = column;

	column = new string[2];
	column[0] = "Address1";
	column[1] = "160";
	columns[3] = column;

	column = new string[2];
	column[0] = "Address2";
	column[1] = "0";
	columns[4] = column;
	
	column = new string[2];
	column[0] = "Address3";
	column[1] = "0";
	columns[5] = column;
	
	column = new string[2];
	column[0] = "Phone";
	column[1] = "75";
	columns[6] = column;
	
	column = new string[2];
	column[0] = "Fax";
	column[1] = "75";
	columns[7] = column;
	
	column = new string[2];
	column[0] = "Web Page";
	column[1] = "110";
	columns[8] = column;
	
	return columns;
}

} // class

} // namespace
