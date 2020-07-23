/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class Routing : BusinessObject {

public const string ROUTING_TYPE_MAIN= "M";
public const string ROUTING_TYPE_ALTERNATIVE= "A";

private int id;
private string prodID;
private string plt;
private string dept;
private string actID;
private int seq;
private string subID;
private int subIDRank;
private int subOrdNum;
private int methodRank;
private string cfg;
private string varFam;
private decimal cycleTm;
private string cycleUom;
private decimal runStd;
private decimal cavityNum;
private decimal cavUnavail;
private decimal cavAvail;
private decimal cycleHr;
private string batchProc;
private decimal batchTm;
private decimal batchQty;
private string batchUom;
private string repPoint;
private string eCNCurr;
private decimal yieldPer;
private decimal reworkPer;
private string schSort1;
private string schSort2;
private int prodLev;
private string subIDDes;
private string actType;
private string oneTm;
private decimal tm;
private string useMach;
private decimal machCyc;
private string indDept;
private string labOnly;
private string famOnly;
private int qtyMen;
private int qtyMachines;
private string routingType;
private decimal scrapPercent;
private decimal efficiency;   
private decimal optRunQty;

private int machIdShow;

private RoutingLabToolContainer routingLabToolContainer;

#if !WEB
internal
#else
public
#endif
Routing(){
	this.id = 0;
	this.prodID = "";
	this.plt = "";
	this.dept = "";
	this.actID = "";
	this.seq = 0;
	this.subID = "";
	this.subIDRank = 0;
	this.subOrdNum = 0;
	this.methodRank = 0;
	this.cfg = "";
	this.varFam = "";
	this.cycleTm = 0;
	this.cycleUom = "";
	this.runStd = 0;
	this.cavityNum = 0;
	this.cavUnavail = 0;
	this.cavAvail = 0;
	this.cycleHr = 0;
	this.batchProc = "";
	this.batchTm = 0;
	this.batchQty = 0;
	this.batchUom = "";
	this.repPoint = "";
	this.eCNCurr = "";
	this.yieldPer = 0;
	this.reworkPer = 0;
	this.schSort1 = "";
	this.schSort2 = "";
	this.prodLev = 0;
	this.subIDDes = "";
	this.actType = "";
	this.oneTm = "";
	this.tm = 0;
	this.useMach = "";
	this.machCyc = 0;
	this.indDept = "";
	this.labOnly = "";
	this.famOnly = "";
	this.qtyMen = 0;
	this.qtyMachines = 0;
    this.routingType = ROUTING_TYPE_MAIN;
    this.scrapPercent = 1;
    this.efficiency = 1;
    this.optRunQty = 0;
    this.machIdShow = 0;
    this.routingLabToolContainer = new RoutingLabToolContainer();
}

internal
Routing(
	int id,
	string prodID,
	string plt,
	string dept,
	string actID,
	int seq,
	string subID,
	int subIDRank,
	int subOrdNum,
	int methodRank,
	string cfg,
	string varFam,
	decimal cycleTm,
	string cycleUom,
	decimal runStd,
	decimal cavityNum,
	decimal cavUnavail,
	decimal cavAvail,
	decimal cycleHr,
	string batchProc,
	decimal batchTm,
	decimal batchQty,
	string batchUom,
	string repPoint,
	string eCNCurr,
	decimal yieldPer,
	decimal reworkPer,
	string schSort1,
	string schSort2,
	int prodLev,
	string subIDDes,
	string actType,
	string oneTm,
	decimal tm,
	string useMach,
	decimal machCyc,
	string indDept,
	string labOnly,
	string famOnly,
	int qtyMen,
	int qtyMachines,
    string routingType,
    decimal scrapPercent,
    decimal efficiency,
    decimal optRunQty,
    int machIdShow){
	this.id = id;
	this.prodID = prodID;
	this.plt = plt;
	this.dept = dept;
	this.actID = actID;
	this.seq = seq;
	this.subID = subID;
	this.subIDRank = subIDRank;
	this.subOrdNum = subOrdNum;
	this.methodRank = methodRank;
	this.cfg = cfg;
	this.varFam = varFam;
	this.cycleTm = cycleTm;
	this.cycleUom = cycleUom;
	this.runStd = runStd;
	this.cavityNum = cavityNum;
	this.cavUnavail = cavUnavail;
	this.cavAvail = cavAvail;
	this.cycleHr = cycleHr;
	this.batchProc = batchProc;
	this.batchTm = batchTm;
	this.batchQty = batchQty;
	this.batchUom = batchUom;
	this.repPoint = repPoint;
	this.eCNCurr = eCNCurr;
	this.yieldPer = yieldPer;
	this.reworkPer = reworkPer;
	this.schSort1 = schSort1;
	this.schSort2 = schSort2;
	this.prodLev = prodLev;
	this.subIDDes = subIDDes;
	this.actType = actType;
	this.oneTm = oneTm;
	this.tm = tm;
	this.useMach = useMach;
	this.machCyc = machCyc;
	this.indDept = indDept;
	this.labOnly = labOnly;
	this.famOnly = famOnly;
	this.qtyMen = qtyMen;
	this.qtyMachines = qtyMachines;
    this.routingType = routingType;
    this.scrapPercent= scrapPercent;
    this.efficiency = efficiency;    
    this.optRunQty = optRunQty;
    this.machIdShow = machIdShow;
    this.routingLabToolContainer = new RoutingLabToolContainer();
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ProdID {
	get { return prodID;}
	set { if (this.prodID != value){
			this.prodID = value;
			Notify("ProdID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plt {
	get { return plt;}
	set { if (this.plt != value){
			this.plt = value;
			Notify("Plt");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept {
	get { return dept;}
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ActID {
	get { return actID;}
	set { if (this.actID != value){
			this.actID = value;
			Notify("ActID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SubID {
	get { return subID;}
	set { if (this.subID != value){
			this.subID = value;
			Notify("SubID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubIDRank {
	get { return subIDRank;}
	set { if (this.subIDRank != value){
			this.subIDRank = value;
			Notify("SubIDRank");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubOrdNum {
	get { return subOrdNum;}
	set { if (this.subOrdNum != value){
			this.subOrdNum = value;
			Notify("SubOrdNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MethodRank {
	get { return methodRank;}
	set { if (this.methodRank != value){
			this.methodRank = value;
			Notify("MethodRank");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Cfg {
	get { return cfg;}
	set { if (this.cfg != value){
			this.cfg = value;
			Notify("Cfg");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string VarFam {
	get { return varFam;}
	set { if (this.varFam != value){
			this.varFam = value;
			Notify("VarFam");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CycleTm {
	get { return cycleTm;}
	set { if (this.cycleTm != value){
			this.cycleTm = value;
			Notify("CycleTm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CycleUom {
	get { return cycleUom;}
	set { if (this.cycleUom != value){
			this.cycleUom = value;
			Notify("CycleUom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RunStd {
	get { return runStd;}
	set { if (this.runStd != value){
			this.runStd = value;
			Notify("RunStd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CavityNum {
	get { return cavityNum;}
	set { if (this.cavityNum != value){
			this.cavityNum = value;
			Notify("CavityNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CavUnavail {
	get { return cavUnavail;}
	set { if (this.cavUnavail != value){
			this.cavUnavail = value;
			Notify("CavUnavail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CavAvail {
	get { return cavAvail;}
	set { if (this.cavAvail != value){
			this.cavAvail = value;
			Notify("CavAvail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CycleHr {
	get { return cycleHr;}
	set { if (this.cycleHr != value){
			this.cycleHr = value;
			Notify("CycleHr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BatchProc {
	get { return batchProc;}
	set { if (this.batchProc != value){
			this.batchProc = value;
			Notify("BatchProc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BatchTm {
	get { return batchTm;}
	set { if (this.batchTm != value){
			this.batchTm = value;
			Notify("BatchTm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BatchQty {
	get { return batchQty;}
	set { if (this.batchQty != value){
			this.batchQty = value;
			Notify("BatchQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BatchUom {
	get { return batchUom;}
	set { if (this.batchUom != value){
			this.batchUom = value;
			Notify("BatchUom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RepPoint {
	get { return repPoint;}
	set { if (this.repPoint != value){
			this.repPoint = value;
			Notify("RepPoint");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ECNCurr {
	get { return eCNCurr;}
	set { if (this.eCNCurr != value){
			this.eCNCurr = value;
			Notify("ECNCurr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal YieldPer {
	get { return yieldPer;}
	set { if (this.yieldPer != value){
			this.yieldPer = value;
			Notify("YieldPer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ReworkPer {
	get { return reworkPer;}
	set { if (this.reworkPer != value){
			this.reworkPer = value;
			Notify("ReworkPer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SchSort1 {
	get { return schSort1;}
	set { if (this.schSort1 != value){
			this.schSort1 = value;
			Notify("SchSort1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SchSort2 {
	get { return schSort2;}
	set { if (this.schSort2 != value){
			this.schSort2 = value;
			Notify("SchSort2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ProdLev {
	get { return prodLev;}
	set { if (this.prodLev != value){
			this.prodLev = value;
			Notify("ProdLev");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SubIDDes {
	get { return subIDDes;}
	set { if (this.subIDDes != value){
			this.subIDDes = value;
			Notify("SubIDDes");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ActType {
	get { return actType;}
	set { if (this.actType != value){
			this.actType = value;
			Notify("ActType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OneTm {
	get { return oneTm;}
	set { if (this.oneTm != value){
			this.oneTm = value;
			Notify("OneTm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Tm {
	get { return tm;}
	set { if (this.tm != value){
			this.tm = value;
			Notify("Tm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string UseMach {
	get { return useMach;}
	set { if (this.useMach != value){
			this.useMach = value;
			Notify("UseMach");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MachCyc {
	get { return machCyc;}
	set { if (this.machCyc != value){
			this.machCyc = value;
			Notify("MachCyc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string IndDept {
	get { return indDept;}
	set { if (this.indDept != value){
			this.indDept = value;
			Notify("IndDept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LabOnly {
	get { return labOnly;}
	set { if (this.labOnly != value){
			this.labOnly = value;
			Notify("LabOnly");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FamOnly {
	get { return famOnly;}
	set { if (this.famOnly != value){
			this.famOnly = value;
			Notify("FamOnly");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int QtyMen {
	get { return qtyMen;}
	set { if (this.qtyMen != value){
			this.qtyMen = value;
			Notify("QtyMen");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int QtyMachines {
	get { return qtyMachines;}
	set { if (this.qtyMachines != value){
			this.qtyMachines = value;
			Notify("QtyMachines");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RoutingType {
	get { return routingType; }
	set { if (this.routingType != value){
			this.routingType = value;
			Notify("RoutingType");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
decimal ScrapPercent {
	get { return scrapPercent; }
	set { if (this.scrapPercent != value){
			this.scrapPercent = value;
			Notify("ScrapPercent");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Efficiency {
	get { return efficiency; }
	set { if (this.efficiency != value){
			this.efficiency = value;
			Notify("Efficiency");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OptRunQty {
	get { return optRunQty; }
	set { if (this.optRunQty != value){
			this.optRunQty = value;
			Notify("optRunQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachIdShow {
	get { return machIdShow; }
	set { if (this.machIdShow != value){
			this.machIdShow = value;
			Notify("MachIdShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
RoutingLabToolContainer RoutingLabToolContainer {
	get { return routingLabToolContainer;}
	set { if (this.routingLabToolContainer != value){
			this.routingLabToolContainer = value;
			Notify("RoutingLabToolContainer");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Routing)
		return	this.prodID.Equals(((Routing)obj).ProdID) &&
				this.plt.Equals(((Routing)obj).Plt) &&
				this.dept.Equals(((Routing)obj).Dept) &&
				this.actID.Equals(((Routing)obj).ActID) &&
				this.seq.Equals(((Routing)obj).Seq) &&
				this.cfg.Equals(((Routing)obj).Cfg);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){    
    for (int i=0;i < routingLabToolContainer.Count;i++){
        RoutingLabTool routingLabTool = routingLabToolContainer[i];
                        
        routingLabTool.HdrId = this.Id;
        routingLabTool.Detail = i+1;              
    }
}

public
int TotLabourTypes{
	get { return routingLabToolContainer.getTotalByType(RoutingLabTool.LABOUR_TYPE);}
	set {
            Notify("TotLabourTypes");
	}
}

public
int TotTools{
	get { return routingLabToolContainer.getTotalByType(RoutingLabTool.TOOL_TYPE);}
	set {
        Notify("TotTools");		
	}
}

} // class
} // package