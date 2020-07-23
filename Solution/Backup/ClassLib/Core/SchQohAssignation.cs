using System;
using System.Data;
using System.Collections;

using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;

namespace Nujit.NujitERP.ClassLib.Core{

// Class Scheduling 
// This a core class namespace
// Contains all functionallity for make a plannig girid
//

[Serializable]
public 
class SchQohAssignation : MarshalByRefObject{

private string plant;
private string departament;
private string schVersion;

private SchQohAssignDataBaseContainer schQohAssignDataBaseContainer;

public
SchQohAssignation(string plant, string departament, string schVersion,
		SchQohAssignDataBaseContainer schQohAssignDataBaseContainer){

	this.plant = plant;
	this.departament = departament;
	this.schVersion = schVersion;
	this.schQohAssignDataBaseContainer = schQohAssignDataBaseContainer;
}

public
SchQohAssignation(SchQohAssignDataBaseContainer schQohAssignDataBaseContainer){

	this.plant = "";
	this.departament = "";
	this.schVersion = "";
	this.schQohAssignDataBaseContainer = schQohAssignDataBaseContainer;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public 
void setSchVersion(string schVersion){
	this.schVersion = schVersion;
}

public 
string getSchVersion(){
	return schVersion;
}

public
void setDepartament(string departament){
	this.departament = departament;
}

public
string getPlant(){
	return plant;
}

public
string getDepartament(){
	return departament;
}

public
SchQohAssignDataBaseContainer getSchQohAssignDataBaseContainer()
{
	return schQohAssignDataBaseContainer;
}

public void setQohAssignation (string prodID, int seq, decimal ordID, decimal itemID, string rlID, decimal qoh)
{
	SchQohAssignDataBase schQohAssignDataBase = new SchQohAssignDataBase(schQohAssignDataBaseContainer.getDataBaseAccess());
	
	schQohAssignDataBase.setSQA_Dept(departament);
	schQohAssignDataBase.setSQA_Plt(plant);
	schQohAssignDataBase.setSQA_SchVersion(schVersion);
	schQohAssignDataBase.setSQA_ProdID(prodID);
	schQohAssignDataBase.setSQA_Seq(seq);
	schQohAssignDataBase.setSQA_OrdID(ordID);
	schQohAssignDataBase.setSQA_ItemID(itemID);
	schQohAssignDataBase.setSQA_RLID(rlID);

	SchQohAssignDataBase oldSchQohAssignDataBase = (SchQohAssignDataBase)schQohAssignDataBaseContainer.getFirstObject(schQohAssignDataBase.getHashKey());

	if (oldSchQohAssignDataBase != null)
		oldSchQohAssignDataBase.setSQA_Qty(qoh);
	else
	{
		schQohAssignDataBase.setSQA_Qty(qoh);
		schQohAssignDataBaseContainer.Add (schQohAssignDataBase, schQohAssignDataBase.getHashKey());
	}
}

public decimal getQohAssignation (string prodID, int seq, decimal ordID, decimal itemID, string rlID)
{
	SchQohAssignDataBase schQohAssignDataBase = new SchQohAssignDataBase(schQohAssignDataBaseContainer.getDataBaseAccess());
	
	schQohAssignDataBase.setSQA_Dept(departament);
	schQohAssignDataBase.setSQA_Plt(plant);
	schQohAssignDataBase.setSQA_SchVersion(schVersion);
	schQohAssignDataBase.setSQA_ProdID(prodID);
	schQohAssignDataBase.setSQA_Seq(seq);
	schQohAssignDataBase.setSQA_OrdID(ordID);
	schQohAssignDataBase.setSQA_ItemID(itemID);
	schQohAssignDataBase.setSQA_RLID(rlID);

	schQohAssignDataBase = (SchQohAssignDataBase)schQohAssignDataBaseContainer.getFirstObject(schQohAssignDataBase.getHashKey());

	if (schQohAssignDataBase != null)
		return schQohAssignDataBase.getSQA_Qty();
	else
		return 0;
}

} // Qoh assignation class

} // namespace