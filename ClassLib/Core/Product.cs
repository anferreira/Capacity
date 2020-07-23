using System;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

[Serializable]
public 
class Product : MarshalByRefObject{

private int id;
private string prodID;
private string db;
private string des1;
private string des2;
private string des3;
private string varFam;
private int seqLast;
private string actIDLast;
private string famProd;
private string partType;
private string invStatus;
private string aBCCode;
private string majorGroup;
private string minorGroup;
private string gLExp;
private string gLDistr;
private string majorSales;
private string minorSales;
private DateTime lastRevision;
private string retailProductType;
private decimal stdPackSize;
private string stdPackUnit;
private string prodCode;

private string plant;
private decimal optimRunPurchSize;
private decimal prodMultiplier;
private decimal minRunPurchQty;
private int matlPrepLdTime;
private decimal pallPackSize;
private string palletPackUnit;
private decimal minQty;
private decimal maxQty;
private string virtKanDemProf;
private decimal virtKanManDem;
private decimal daysOnHand;
private string obectivesAutomaticCalc;
private decimal demandLowQtySplit;
private decimal level;


private bool    selectedShow;

public 
Product(){
    this.id = 0;
	this.plant = "";
	this.optimRunPurchSize = 0;
	this.prodMultiplier = 0;
	this.minRunPurchQty = 0;
	this.matlPrepLdTime = 0;
	this.pallPackSize = 0;
	this.palletPackUnit = "";
	this.minQty = 0;
	this.maxQty = 0;
	this.virtKanDemProf = "";
	this.virtKanManDem = 0;
    this.daysOnHand = 0;
    this.obectivesAutomaticCalc = Constants.STRING_NO;
    this.demandLowQtySplit = 1;
    this.level =1;
}

public 
Product(int id,
        string prodID,string db, string des1, string des2,
		string des3, string varFam, int seqLast,
		string actIDLast, string famProd, string partType,
		string invStatus, string aBCCode, string majorGroup,
		string minorGroup, string gLExp, string gLDistr,
		string majorSales, string minorSales, DateTime lastRevision,
		string retailProductType, decimal stdPackSize, string stdPackUnit, string prodCode,
        string plant,decimal optimRunPurchSize,decimal prodMultiplier,decimal minRunPurchQty,int matlPrepLdTime,
        decimal pallPackSize,string palletPackUnit,decimal minQty,decimal maxQty,string virtKanDemProf,
        decimal virtKanManDem,decimal daysOnHand,string obectivesAutomaticCalc,decimal demandLowQtySplit,decimal level){	
    this.id = id;
	this.prodID = prodID;
	this.db = db;
	this.des1 = des1;
	this.des2 = des2;
	this.des3 = des3;
	this.varFam = varFam; 
	this.seqLast = seqLast;
	this.actIDLast = actIDLast;
	this.famProd = famProd;
	this.partType = partType;
	this.invStatus = invStatus;
	this.aBCCode = aBCCode;
	this.majorGroup = majorGroup;
	this.minorGroup = minorGroup;
	this.gLExp = gLExp;
	this.gLDistr = gLDistr;
	this.majorSales = majorSales;
	this.minorSales = minorSales;
	this.lastRevision = lastRevision;
	this.retailProductType = retailProductType;
	this.stdPackSize = stdPackSize;
	this.stdPackUnit = stdPackUnit;
	this.prodCode = prodCode;

    this.plant = plant;
	this.optimRunPurchSize = optimRunPurchSize;
	this.prodMultiplier = prodMultiplier;
	this.minRunPurchQty = minRunPurchQty;
	this.matlPrepLdTime = matlPrepLdTime;
	this.pallPackSize = pallPackSize;
	this.palletPackUnit = palletPackUnit;
	this.minQty = minQty;
	this.maxQty = maxQty;
	this.virtKanDemProf = virtKanDemProf;
	this.virtKanManDem = virtKanManDem;
    this.daysOnHand = daysOnHand;
    this.obectivesAutomaticCalc = obectivesAutomaticCalc;
    this.demandLowQtySplit = demandLowQtySplit;
    this.level = level;

    this.selectedShow = false;    
}

public
void setProdID(string prodID){
	this.prodID = prodID;
}

public
void setDb(string Db){
	this.db = db;
}

public
void setDes1(string des1){
	this.des1 = des1;
}

public
void setDes2(string des2){
	this.des2 = des2;
}

public
void setDes3(string des3){
	this.des3 = des3;
}

public
void setVarFam(string varFam){
	this.varFam = varFam;
}

public
void setSeqLast(int seqLast){
	this.seqLast = seqLast;
}

public
void setActIDLast(string actIDLast){
	this.actIDLast = actIDLast;
}

public
void setFamProd(string famProd){
	this.famProd = famProd;
}

public
void setPartType(string partType){
	this.partType = partType;
}

public
void setInvStatus(string invStatus){
	this.invStatus = invStatus;
}

public
void setABCCode(string aBCCode){
	this.aBCCode = aBCCode;
}

public
void setMajorGroup(string majorGroup){
	this.majorGroup = majorGroup;
}

public
void setMinorGroup(string minorGroup){
	this.minorGroup = minorGroup;
}

public
void setGLExp(string gLExp){
	this.gLExp = gLExp;
}

public
void setGLDistr(string gLDistr){
	this.gLDistr = gLDistr;
}

public
void setMajorSales(string majorSales){
	this.majorSales = majorSales;
}

public
void setMinorSales(string minorSales){
	this.minorSales = minorSales;
}

public
void setLastRevision(DateTime lastRevision){
	this.lastRevision = lastRevision;
}

public
void setRetailProductType(string retailProductType){
	this.retailProductType = retailProductType;
}

public
void setStdPackSize(decimal stdPackSize){
	this.stdPackSize = stdPackSize;
}

public
void setStdPackUnit(string stdPackUnit){
	this.stdPackUnit = stdPackUnit;
}

public
void setProdCode(string prodCode){
	this.prodCode = prodCode;
}

public
string getProdID(){
	return prodID;
}

public
string getDb(){
	return db;
}

public
string getDes1(){
	return des1;
}

public
string getDes2(){
	return des2;
}

public
string getDes3(){
	return des3;
}

public
string getVarFam(){
	return varFam;
}

public
int getSeqLast(){
	return seqLast;
}

public
string getActIDLast(){
	return actIDLast;
}

public
string getFamProd(){
	return famProd;
}

public
string getPartType(){
	return partType;
}

public
string getInvStatus(){
	return invStatus;
}

public
string getABCCode(){
	return aBCCode;
}

public
string getMajorGroup(){
	return majorGroup;
}

public
string getMinorGroup(){
	return minorGroup;
}

public
string getGLExp(){
	return gLExp;
}

public
string getGLDistr(){
	return gLDistr;
}

public
string getMajorSales(){
	return majorSales;
}

public
string getMinorSales(){
	return minorSales;
}

public
DateTime getLastRevision(){
	return lastRevision;
}

public
string getRetailProductType(){
	return retailProductType;
}

public
decimal getStdPackSize(){
	return stdPackSize;
}

public
string getStdPackUnit(){
	return stdPackUnit;
}

public
string getProdCode(){
	return prodCode;
}


/****************************** Set/get *****************************************/
[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id; }
	set { if (this.id != value){
			this.id = value;
			//Notify("Id");
		}
	}
}
                
[System.Runtime.Serialization.DataMember]
public
string ProdID {
	get { return prodID; }
	set { if (this.prodID != value){
			this.prodID = value;
			//Notify("ProdID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Db {
	get { return db; }
	set { if (this.db != value){
			this.db = value;
			//Notify("ProdID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Des1 {
	get { return des1; }
	set { if (this.des1 != value){
			this.des1 = value;
			//Notify("Des1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Des2 {
	get { return des2; }
	set { if (this.des2 != value){
			this.des2 = value;
			//Notify("Des2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Des3 {
	get { return des3; }
	set { if (this.des3 != value){
			this.des3 = value;
			//Notify("Des3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string VarFam {
	get { return varFam; }
	set { if (this.varFam != value){
			this.varFam = value;
			//Notify("VarFam");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SeqLast {
	get { return seqLast; }
	set { if (this.seqLast != value){
			this.seqLast = value;
			//Notify("seqLast");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ActIDLast {
	get { return actIDLast; }
	set { if (this.actIDLast != value){
			this.actIDLast = value;
			//Notify("ActIDLast");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FamProd {
	get { return famProd; }
	set { if (this.famProd != value){
			this.famProd = value;
			//Notify("FamProd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PartType {
	get { return partType; }
	set { if (this.partType != value){
			this.partType = value;
			//Notify("PartType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string InvStatus {
	get { return invStatus; }
	set { if (this.invStatus != value){
			this.invStatus = value;
			//Notify("InvStatus");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ABCCode {
	get { return aBCCode; }
	set { if (this.aBCCode != value){
			this.aBCCode = value;
			//Notify("ABCCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MajorGroup {
	get { return majorGroup; }
	set { if (this.majorGroup != value){
			this.majorGroup = value;
			//Notify("MajorGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinorGroup {
	get { return minorGroup; }
	set { if (this.minorGroup != value){
			this.minorGroup = value;
			//Notify("MinorGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string GLExp {
	get { return gLExp; }
	set { if (this.gLExp != value){
			this.gLExp = value;
			//Notify("GLExp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string GLDistr {
	get { return gLDistr; }
	set { if (this.gLDistr != value){
			this.gLDistr = value;
			//Notify("GLDistr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MajorSales {
	get { return majorSales; }
	set { if (this.majorSales != value){
			this.majorSales = value;
			//Notify("MajorSales");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinorSales {
	get { return minorSales; }
	set { if (this.minorSales != value){
			this.minorSales = value;
			//Notify("MinorSales");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LastRevision {
	get { return lastRevision; }
	set { if (this.lastRevision != value){
			this.lastRevision = value;
			//Notify("LastRevision");
		}
	}
}

public
string RetailProductType {
	get { return retailProductType; }
	set { if (this.retailProductType != value){
			this.retailProductType = value;
			//Notify("RetailProductType");
		}
	}
}

public
decimal StdPackSize {
	get { return stdPackSize; }
	set { if (this.stdPackSize != value){
			this.stdPackSize = value;
			//Notify("StdPackSize");
		}
	}
}

public
string StdPackUnit {
	get { return stdPackUnit; }
	set { if (this.stdPackUnit != value){
			this.stdPackUnit = value;
			//Notify("StdPackUnit");
		}
	}
}

public
string ProdCode {
	get { return prodCode; }
	set { if (this.prodCode != value){
			this.prodCode = value;
			//Notify("ProdCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			//Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OptimRunPurchSize {
	get { return optimRunPurchSize;}
	set { if (this.optimRunPurchSize != value){
			this.optimRunPurchSize = value;
			//Notify("OptimRunPurchSize");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ProdMultiplier {
	get { return prodMultiplier;}
	set { if (this.prodMultiplier != value){
			this.prodMultiplier = value;
			//Notify("ProdMultiplier");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MinRunPurchQty {
	get { return minRunPurchQty;}
	set { if (this.minRunPurchQty != value){
			this.minRunPurchQty = value;
			//Notify("MinRunPurchQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MatlPrepLdTime {
	get { return matlPrepLdTime;}
	set { if (this.matlPrepLdTime != value){
			this.matlPrepLdTime = value;
			//Notify("MatlPrepLdTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PallPackSize {
	get { return pallPackSize;}
	set { if (this.pallPackSize != value){
			this.pallPackSize = value;
			//Notify("PallPackSize");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PalletPackUnit {
	get { return palletPackUnit;}
	set { if (this.palletPackUnit != value){
			this.palletPackUnit = value;
			//Notify("PalletPackUnit");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MinQty {
	get { return minQty;}
	set { if (this.minQty != value){
			this.minQty = value;
			//Notify("MinQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaxQty {
	get { return maxQty;}
	set { if (this.maxQty != value){
			this.maxQty = value;
			//Notify("MaxQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string VirtKanDemProf {
	get { return virtKanDemProf;}
	set { if (this.virtKanDemProf != value){
			this.virtKanDemProf = value;
			//Notify("VirtKanDemProf");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal VirtKanManDem {
	get { return virtKanManDem;}
	set { if (this.virtKanManDem != value){
			this.virtKanManDem = value;
			//Notify("VirtKanManDem");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysOnHand {
	get { return daysOnHand; }
	set { if (this.daysOnHand != value){
			this.daysOnHand = value;
			//Notify("VirtKanManDem");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ObectivesAutomaticCalc {
	get { return obectivesAutomaticCalc; }
	set { if (this.obectivesAutomaticCalc != value){
			this.obectivesAutomaticCalc = value;
			//Notify("VirtKanManDem");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DemandLowQtySplit {
	get { return demandLowQtySplit; }
	set { if (this.demandLowQtySplit != value){
			this.demandLowQtySplit = value;			
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Level {
	get { return level; }
	set { if (this.level != value){
			this.level = value;			
		}
	}
}

public
bool SelectedShow {
	get { return selectedShow; }
	set { if (this.selectedShow != value){
			this.selectedShow = value;
		}
	}
}



} // class

} // namespace
