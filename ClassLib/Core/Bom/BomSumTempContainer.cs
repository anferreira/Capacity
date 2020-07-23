using System;
using System.Data;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class BomSumTempContainer : Hashtable{

private 
struct relKey{

public string prodId;
public int prodSeq;
public string matId;
public int matSeq;

public 
relKey(string prodId, int prodSeq, string matId, int matSeq){
	this.prodId = prodId;
	this.matId = matId;
	this.prodSeq = prodSeq;
	this.matSeq = matSeq;
}

public 
relKey(BomSum bomSumElement){
	this.prodId = bomSumElement.getBMS_ProdID();
	this.prodSeq = bomSumElement.getBMS_Seq();
	this.matId = bomSumElement.getBMS_MatID();
	this.matSeq = bomSumElement.getBMS_MatSeq();
}

public override 
string ToString(){
	return("('"+prodId+"',"+prodSeq.ToString()+"):('"+matId+"',"+matSeq.ToString()+")");
}

public override 
int GetHashCode(){
	if (prodId == null)
		prodId="";
	if (matId == null)
		matId="";

	return (prodId.GetHashCode() ^ matId.GetHashCode() ^ prodSeq.GetHashCode() ^ matSeq.GetHashCode());
}

} // struct

public 
BomSumTempContainer() : base(1000){
}

public 
void addBomSum(BomSum bomSumElement){
	relKey key = new relKey(bomSumElement.getBMS_ProdID(), bomSumElement.getBMS_Seq(), bomSumElement.getBMS_MatID(), bomSumElement.getBMS_MatSeq());

	if (!this.ContainsKey(key))
		this.Add(key, bomSumElement);
}

public 
void forceAddBomSum(BomSum bomSumElement){
	relKey key = new relKey(bomSumElement.getBMS_ProdID(), bomSumElement.getBMS_Seq(), bomSumElement.getBMS_MatID(), bomSumElement.getBMS_MatSeq());

	this[key] = bomSumElement;
}

public 
bool existsBomSum(string prodId, int prodSeq, string matId, int matSeq){
	relKey key = new relKey(prodId, prodSeq, matId, matSeq);

	if (this.ContainsKey(key))
		return true;
	else
		return false;
}

public 
void deleteBomSum(string prodId, int prodSeq, string matId, int matSeq){
	relKey key = new relKey(prodId, prodSeq, matId, matSeq);

	if (this.ContainsKey(key)){
		BomSum bomSumObj = (BomSum)this[key];
		bomSumObj.delete();			
	}
}

public 
BomSum getBomSum(string prodId, int prodSeq, string matId, int matSeq){
	relKey key = new relKey(prodId, prodSeq, matId, matSeq);
	
	if (this.ContainsKey(key)){
		BomSum bomSumObj = (BomSum)this[key];
		if (!bomSumObj.isDeleted())
			return bomSumObj;
		else 
			return null;
	}else
		return null;
}

public 
ArrayList getProductChildren(string prodId, int prodSeq){
	ArrayList BMSList = new ArrayList();

	BMSList = getProductChildren(BMSList, prodId, prodSeq);
	return BMSList;
}

private 
ArrayList getProductChildren(ArrayList BMSList, string prodId, int prodSeq){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry bomSumEntry = (DictionaryEntry) en.Current;
		BomSum bomSum = (BomSum) bomSumEntry.Value;

		string cProdId = bomSum.getBMS_ProdID();
		int cProdSeq = bomSum.getBMS_Seq();
		string cMatId = bomSum.getBMS_MatID();
		int cMatSeq = bomSum.getBMS_MatSeq();

		if ((cProdId == prodId) && (cProdSeq == prodSeq)){
			relKey keyBMS = new relKey(cProdId, cProdSeq, cMatId, cMatSeq);
			BomSum bomSumObj = (BomSum)this[keyBMS];
			if (!bomSum.isDeleted()) {
				BMSList.Add(bomSumObj);
			}
		}
	}
	return BMSList;
}

public 
ArrayList getProductSubMaterials(string prodId, int prodSeq){
	ArrayList BMSList = new ArrayList();

	BMSList = getProductSubMaterials(BMSList, prodId, prodSeq);
	return BMSList;
}

private
ArrayList getProductSubMaterials(ArrayList BMSList, string prodId, int prodSeq){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry bomSumEntry = (DictionaryEntry) en.Current;
		BomSum bomSum = (BomSum) bomSumEntry.Value;

		string cProdId = bomSum.getBMS_ProdID();
		int cProdSeq = bomSum.getBMS_Seq();
		string cMatId = bomSum.getBMS_MatID();
		int cMatSeq = bomSum.getBMS_MatSeq();

		if ((cProdId == prodId) && (cProdSeq == prodSeq)){
			relKey keyBMS = new relKey(cProdId, cProdSeq, cMatId, cMatSeq);
			BomSum bomSumObj = (BomSum)this[keyBMS];
			if (!bomSum.isDeleted()) {
				if (!findKeyInArray(keyBMS,BMSList)){
					BMSList.Add(bomSumObj);
					BMSList = getProductSubMaterials(BMSList, cMatId, cMatSeq);
				}
			}
		}
	}

	return BMSList;
}

private 
bool findKeyInArray(relKey keyBMS, ArrayList list){
	for(int x = 0; x < list.Count; x++){
		BomSum bomSumObj = (BomSum)list[x];
		relKey key = new relKey(bomSumObj);
		if (keyBMS.Equals(key))
			return true;
	}
	return false;
}

public 
bool validateMaterial(BomSum bomSumObj){
	return (!findMaterialInParents(bomSumObj, bomSumObj.getBMS_MatID(), bomSumObj.getBMS_MatSeq()));
}

private 
bool findMaterialInParents(BomSum bomSumObj, string matId, int matSeq){
	if (bomSumObj==null)
		return false;
	else if ((bomSumObj.getBMS_ProdID()==matId) && (bomSumObj.getBMS_Seq()==matSeq))
		return true;
	else{
		bool returnValue = false;
		ArrayList bMSList = findParentMaterials(bomSumObj.getBMS_ProdID(), bomSumObj.getBMS_Seq());
		for(int x = 0; x < bMSList.Count; x++){
			BomSum bomSumElement = (BomSum)bMSList[x];
			if ((bomSumElement.getBMS_ProdID() == matId) && (bomSumElement.getBMS_Seq() == matSeq))
				return true;
			returnValue = returnValue || findMaterialInParents(bomSumElement, matId, matSeq);
		}
		return returnValue;
	}
}

private 
ArrayList findParentMaterials(string prodId, int prodSeq){
	ArrayList bMSList = new ArrayList();
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry bomSumEntry = (DictionaryEntry) en.Current;
		BomSum bomSum = (BomSum) bomSumEntry.Value;

		string cMatId = bomSum.getBMS_MatID();
		int cMatSeq = bomSum.getBMS_MatSeq();

		if ((cMatId == prodId) && (cMatSeq == prodSeq)){
			relKey keyBMS = new relKey(bomSum);
			if (!bomSum.isDeleted())
				if (!findKeyInArray(keyBMS,bMSList))
					bMSList.Add(bomSum);
		}
	}
	return bMSList;
}

public 
BomSumTempContainer Copy(){
	BomSumTempContainer newTC = new BomSumTempContainer();

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry bomSumEntry = (DictionaryEntry) en.Current;
		relKey key = (relKey) bomSumEntry.Key;
		BomSum bomSum = (BomSum) bomSumEntry.Value;

		newTC.Add(key, bomSum);
	}
	return newTC;
}

public override 
string ToString(){
	string outStr = "[";
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry bomSumEntry = (DictionaryEntry) en.Current;
		BomSum bomSum = (BomSum) bomSumEntry.Value;

		string subProdId = bomSum.getBMS_ProdID();
		int subProdSeq = bomSum.getBMS_Seq();
		string subMatId = bomSum.getBMS_MatID();
		int subMatSeq = bomSum.getBMS_MatSeq();

		relKey keyBMS = new relKey(subProdId, subProdSeq, subMatId, subMatSeq);
		outStr += keyBMS.ToString();
		if (bomSum.isDeleted())
			outStr += "D ";
		else
			outStr += " ";
	}
	outStr += "]";
	return outStr;
}


} // class

} // namespace