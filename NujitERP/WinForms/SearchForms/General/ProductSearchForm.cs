using System;
using Nujit.NujitERP.WinForms.Util;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.SearchForms{

	
public 
class ProductSearchForm : SearchForm{

private bool onlyByProdId = false;
private bool familyOrPartSearch = false;
private bool family = false;
private string retailProductType="";
//private CoreFactory coreFactory = null;

public 
ProductSearchForm(string title, bool onlyByProdId) : base(title){
	this.onlyByProdId = onlyByProdId;
}

public 
ProductSearchForm(string title, string searchPattern, bool onlyByProdId) : base(title, searchPattern){
	this.onlyByProdId = onlyByProdId;
}

public 
ProductSearchForm(string title, string searchPattern, bool onlyByProdId, bool family) : base(title, searchPattern){
	this.onlyByProdId = onlyByProdId;
	this.familyOrPartSearch = true;
	this.family = family;
}

protected override 
string[][] search(string searchText){
	string[][] founded = null;

	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	if (familyOrPartSearch){
		founded = coreFactory.getProductsByProdIdAndFamily(searchText, family);
		return founded;
	}
	if (onlyByProdId)
		founded = coreFactory.getProductsByProdId(searchText);
	else
		founded = coreFactory.getProductsByDescOrId(searchText, retailProductType);

	coreFactory = null;
	return founded;
}

public 
string retailProductTypeFilter{
	set{retailProductType = value;}
}

protected override
string[][] getColumns(){
	string[][] columns = new string[9][];

	string[] column = new string[2];
	column[0] = "ID";
	column[1] = "100";
	columns[0] = column;

	column = new string[2];
	column[0] = "Description";
	column[1] = "230";
	columns[1] = column;

	column = new string[2];
	column[0] = "Des2";
	column[1] = "0";
	columns[2] = column;

	column = new string[2];
	column[0] = "Des3";
	column[1] = "0";
	columns[3] = column;

	column = new string[2];
	column[0] = "Seq Last";
	column[1] = "65";
	columns[4] = column;

	column = new string[2];
	column[0] = "Fam/Prod";
	column[1] = "65";
	columns[5] = column;

	column = new string[2];
	column[0] = "Part Type";
	column[1] = "65";
	columns[6] = column;

	column = new string[2];
	column[0] = "Major Group";
	column[1] = "70";
	columns[7] = column;

	column = new string[2];
	column[0] = "Minor Group";
	column[1] = "70";
	columns[8] = column;

	return columns;
}

} // class

} // namespace
