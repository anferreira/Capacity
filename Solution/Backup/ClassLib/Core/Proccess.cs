using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;


namespace Nujit.NujitERP.ClassLib.Core{

public
class Proccess{

private string prodFamId;
private BomSumDataBaseContainer bomSumDataBaseContainer;
private ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer;
private SchPrFmHrDataBase schPrFmHrDataBase;

public
Proccess(){
}

public
Proccess(string familyCode, string productCode, BomSumDataBaseContainer bomSumDataBaseContainer,
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		SchPrFmHrDataBase schPrFmHrDataBase){
	
	this.prodFamId = prodFamId;
	this.bomSumDataBaseContainer = bomSumDataBaseContainer;
	this.prodFmActSubDataBaseContainer = prodFmActSubDataBaseContainer;
	this.schPrFmHrDataBase = schPrFmHrDataBase;
}

public
string[] getProductsCodesFromFamily(){
	string[] returnVector = new string[prodFmActSubDataBaseContainer.Count];
	int index = 0;

	IEnumerator enumerator = prodFmActSubDataBaseContainer.GetEnumerator();
	while(enumerator.MoveNext()){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase)enumerator.Current;
		returnVector[index] = prodFmActSubDataBase.getPC_ProdID();
		index++;
	}

	return returnVector;
}

public
decimal getTotalMaterialReq(int quantity){
	decimal total = 0;
	
	IEnumerator enumerator = bomSumDataBaseContainer.GetEnumerator();
	while(enumerator.MoveNext()){
		BomSumDataBase bomSumDataBase = (BomSumDataBase)enumerator.Current;
		total += quantity * bomSumDataBase.getBMS_MatQty();
	}
	return total;
}

public
string getMainMaterial(){
	/*
	IEnumerator enumerator = bomSumDataBaseContainer.GetEnumerator();
	while(enumerator.MoveNext()){
		DictionaryEntry dict = (DictionaryEntry)enumerator.Current;
		
		BomSumDataBase bomSumDataBase = (BomSumDataBase)dict.Value;
		return bomSumDataBase.getBMS_MainMaterial();
	}*/
	return "";
}

public
decimal getQtyPer(){
/*	IEnumerator enumerator = bomSumDataBaseContainer.GetEnumerator();
	while(enumerator.MoveNext()){
		DictionaryEntry dict = (DictionaryEntry)enumerator.Current;
		
		BomSumDataBase bomSumDataBase = (BomSumDataBase)dict.Value;
		return bomSumDataBase.getBMS_MainMaterialQty();
	}*/
	return 0;
}

} // class

} // namespace
