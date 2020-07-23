using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{
	
public 
class Inventory : MarshalByRefObject{

private string prodID;
private string plant;
private string[][] invPltLocContainer;

//private InvPltLocDataBase[] invPltLocDataBaseContainer;

public 
Inventory(){
}

public 
Inventory(string prodID,string plant,string[][] invPltLocContainer){
	this.prodID = prodID;
    this.plant  = plant;
	
	this.invPltLocContainer = invPltLocContainer;
}

public 
void addValueInventory(string prodID,string seq, string lotID, string masPrOrd,
								string prOrd,string stkLoc,string qoh,string qohAvail,
								string uom, string qoh2, string qohAvail2,string uom2,
								string prod2){

	string[][] aux = new string[invPltLocContainer.Length + 1][];
	for(int i = 0; i < invPltLocContainer.Length; i++){
		string[] line = (string[])invPltLocContainer[i].Clone();
		aux[i] = line;
	}
	
	string[] line2 = new string[13];
	line2[0] = prodID;
	line2[1] = seq;
	line2[2] = lotID;
	line2[3] = masPrOrd;
	line2[4] = prOrd;
	line2[5] = stkLoc;
	line2[6] = qoh;
	line2[7] = qohAvail;
	line2[8] = uom;
	line2[9] = qoh2;
	line2[10] = qohAvail2;
	line2[11] = uom2;
	line2[12] = prod2;
	aux[aux.Length - 1] = line2;
	invPltLocContainer = aux;
}//end getInvPltLocAsString


public 
string[][] getInvPltLocAsString(){
	return invPltLocContainer;
}//end getInvPltLocAsString

public 
void removeAllInventary(){
	invPltLocContainer = new string[0][];
}

public 
string getProdID(){
	return prodID;
}

//Seters

public 
void setInvPltLocContainer(string[][] invPltLocContainer){
	this.invPltLocContainer = invPltLocContainer;
}

public 
void setProdID(string prodID){
	this.prodID =prodID;
}

public 
decimal getTotalInventory(int seq){
	decimal inv = 0;

	for(int i = 0; i < invPltLocContainer.Length; i++){
		if (int.Parse(invPltLocContainer[i][1]) == seq)
			inv += decimal.Parse(invPltLocContainer[i][6]);
	}
	return inv;
}

public 
decimal getTotalInventory(){
	decimal inv = 0;

	for(int i = 0; i < invPltLocContainer.Length; i++)
		inv += decimal.Parse(invPltLocContainer[i][6]);

	return inv;
}

public 
decimal getTotalInventoryForMaterials(string[] stkLocs){
	Hashtable hash = new Hashtable();

	/*string stkLocsTxt = Nujit.NujitERP.ClassLib.Common.Configuration.StkLocsMaterials;
	string[] stklocs = stkLocsTxt.Split(',');*/

	for(int i = 0; i < stkLocs.Length; i++){
		string[] stkLocsAux = stkLocs[i].Split(',');
		hash.Add(stkLocsAux[0].Trim(), stkLocsAux[0].Trim());
	}
	
	decimal inv = 0;

	for(int i = 0; i < invPltLocContainer.Length; i++){
		if (hash.ContainsKey(invPltLocContainer[i][5]))
			inv += decimal.Parse(invPltLocContainer[i][6]);
	}

	return inv;
}

public
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;			
		}
	}
}

}//end class

}//end namespace
