/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.ClassLib.Core.Reports{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class RP1268D : BusinessObject {

private int hdrId;
private int detail;
private string part;
private decimal rTPart;
private decimal part10;
private decimal part20;
private decimal part30;
private decimal part40;
private decimal part50;
private decimal part60;
private decimal part70;
private decimal part80;
private decimal part90;
private decimal part100;
private decimal part110;
private decimal part120;
private decimal part130;
private decimal part140;
private decimal part150;
private decimal part160;
private decimal qtyHold;
private decimal finGood;
private decimal netQoh;
private decimal cDPast;
private decimal cDWeek1;
private decimal cDWeek2;
private decimal cDWeek3;
private decimal cDWeek4;
private decimal cDWeek5;
private decimal cDWeek6;
private decimal cDWeek7;
private decimal cDWeek8;

private decimal cDWeek9;
private decimal cDWeek10;
private decimal cDWeek11;
private decimal cDWeek12;
private decimal cDWeek13;
private decimal cDWeek14;

private string aVMAJG;
private string aVMING;
private string eNGCHANGE;
private decimal qTYG12;

private RP1268SContainer rP1268SContainer;

#if !WEB
internal
#else
public
#endif
RP1268D(){
	this.hdrId = 0;
	this.detail = 0;
	this.part = "";
	this.rTPart = 0;
	this.part10 = 0;
	this.part20 = 0;
	this.part30 = 0;
	this.part40 = 0;
	this.part50 = 0;
	this.part60 = 0;
	this.part70 = 0;
	this.part80 = 0;
	this.part90 = 0;
	this.part100 = 0;
	this.part110 = 0;
	this.part120 = 0;
	this.part130 = 0;
	this.part140 = 0;
	this.part150 = 0;
	this.part160 = 0;
	this.qtyHold = 0;
	this.finGood = 0;
	this.netQoh = 0;
	this.cDPast = 0;
	this.cDWeek1 = 0;
	this.cDWeek2 = 0;
	this.cDWeek3 = 0;
	this.cDWeek4 = 0;
	this.cDWeek5 = 0;
	this.cDWeek6 = 0;
	this.cDWeek7 = 0;
	this.cDWeek8 = 0;

    this.cDWeek9= 0;
    this.cDWeek10= 0;
    this.cDWeek11= 0;
    this.cDWeek12= 0;
    this.cDWeek13= 0;
    this.cDWeek14= 0;
    this.aVMAJG = "";
    this.aVMING= "";

    this.eNGCHANGE = "";    
    this.qTYG12 = 0;
    this.rP1268SContainer = new RP1268SContainer();
}

internal
RP1268D(
	int hdrId,
	int detail,
	string part,
	decimal rTPart,
	decimal part10,
	decimal part20,
	decimal part30,
	decimal part40,
	decimal part50,
	decimal part60,
	decimal part70,
	decimal part80,
	decimal part90,
	decimal part100,
	decimal part110,
	decimal part120,
	decimal part130,
	decimal part140,
	decimal part150,
	decimal part160,
	decimal qtyHold,
	decimal finGood,
	decimal netQoh,
	decimal cDPast,
	decimal cDWeek1,
	decimal cDWeek2,
	decimal cDWeek3,
	decimal cDWeek4,
	decimal cDWeek5,
	decimal cDWeek6,
	decimal cDWeek7,
	decimal cDWeek8,
    decimal cDWeek9,
	decimal cDWeek10,
	decimal cDWeek11,
	decimal cDWeek12,
	decimal cDWeek13,
	decimal cDWeek14,
    string  aVMAJG,
    string  aVMING,
    string  eNGCHANGE,    
    decimal qTYG12){
	this.hdrId = hdrId;
	this.detail = detail;
	this.part = part;
	this.rTPart = rTPart;
	this.part10 = part10;
	this.part20 = part20;
	this.part30 = part30;
	this.part40 = part40;
	this.part50 = part50;
	this.part60 = part60;
	this.part70 = part70;
	this.part80 = part80;
	this.part90 = part90;
	this.part100 = part100;
	this.part110 = part110;
	this.part120 = part120;
	this.part130 = part130;
	this.part140 = part140;
	this.part150 = part150;
	this.part160 = part160;
	this.qtyHold = qtyHold;
	this.finGood = finGood;
	this.netQoh = netQoh;
	this.cDPast = cDPast;
	this.cDWeek1 = cDWeek1;
	this.cDWeek2 = cDWeek2;
	this.cDWeek3 = cDWeek3;
	this.cDWeek4 = cDWeek4;
	this.cDWeek5 = cDWeek5;
	this.cDWeek6 = cDWeek6;
	this.cDWeek7 = cDWeek7;
	this.cDWeek8 = cDWeek8;

    this.cDWeek9=  cDWeek9;
    this.cDWeek10= cDWeek10;
    this.cDWeek11= cDWeek11;
    this.cDWeek12= cDWeek12;
    this.cDWeek13= cDWeek13;
    this.cDWeek14= cDWeek14;
    this.aVMAJG = aVMAJG;
    this.aVMING = aVMING;

    this.eNGCHANGE = eNGCHANGE;    
    this.qTYG12 = qTYG12;
    this.rP1268SContainer = new RP1268SContainer();
}

[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId;}
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail {
	get { return detail;}
	set { if (this.detail != value){
			this.detail = value;
			Notify("Detail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part;}
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RTPart {
	get { return rTPart;}
	set { if (this.rTPart != value){
			this.rTPart = value;
			Notify("RTPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part10 {
	get { return part10;}
	set { if (this.part10 != value){
			this.part10 = value;
			Notify("Part10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part20 {
	get { return part20;}
	set { if (this.part20 != value){
			this.part20 = value;
			Notify("Part20");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part30 {
	get { return part30;}
	set { if (this.part30 != value){
			this.part30 = value;
			Notify("Part30");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part40 {
	get { return part40;}
	set { if (this.part40 != value){
			this.part40 = value;
			Notify("Part40");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part50 {
	get { return part50;}
	set { if (this.part50 != value){
			this.part50 = value;
			Notify("Part50");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part60 {
	get { return part60;}
	set { if (this.part60 != value){
			this.part60 = value;
			Notify("Part60");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part70 {
	get { return part70;}
	set { if (this.part70 != value){
			this.part70 = value;
			Notify("Part70");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part80 {
	get { return part80;}
	set { if (this.part80 != value){
			this.part80 = value;
			Notify("Part80");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part90 {
	get { return part90;}
	set { if (this.part90 != value){
			this.part90 = value;
			Notify("Part90");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part100 {
	get { return part100;}
	set { if (this.part100 != value){
			this.part100 = value;
			Notify("Part100");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part110 {
	get { return part110;}
	set { if (this.part110 != value){
			this.part110 = value;
			Notify("Part110");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part120 {
	get { return part120;}
	set { if (this.part120 != value){
			this.part120 = value;
			Notify("Part120");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part130 {
	get { return part130;}
	set { if (this.part130 != value){
			this.part130 = value;
			Notify("Part130");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part140 {
	get { return part140;}
	set { if (this.part140 != value){
			this.part140 = value;
			Notify("Part140");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part150 {
	get { return part150;}
	set { if (this.part150 != value){
			this.part150 = value;
			Notify("Part150");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Part160 {
	get { return part160;}
	set { if (this.part160 != value){
			this.part160 = value;
			Notify("Part160");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyHold {
	get { return qtyHold;}
	set { if (this.qtyHold != value){
			this.qtyHold = value;
			Notify("QtyHold");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FinGood {
	get { return finGood;}
	set { if (this.finGood != value){
			this.finGood = value;
			Notify("FinGood");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NetQoh {
	get { return netQoh;}
	set { if (this.netQoh != value){
			this.netQoh = value;
			Notify("NetQoh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDPast {
	get { return cDPast;}
	set { if (this.cDPast != value){
			this.cDPast = value;
			Notify("CDPast");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek1 {
	get { return cDWeek1;}
	set { if (this.cDWeek1 != value){
			this.cDWeek1 = value;
			Notify("CDWeek1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek2 {
	get { return cDWeek2;}
	set { if (this.cDWeek2 != value){
			this.cDWeek2 = value;
			Notify("CDWeek2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek3 {
	get { return cDWeek3;}
	set { if (this.cDWeek3 != value){
			this.cDWeek3 = value;
			Notify("CDWeek3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek4 {
	get { return cDWeek4;}
	set { if (this.cDWeek4 != value){
			this.cDWeek4 = value;
			Notify("CDWeek4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek5 {
	get { return cDWeek5;}
	set { if (this.cDWeek5 != value){
			this.cDWeek5 = value;
			Notify("CDWeek5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek6 {
	get { return cDWeek6;}
	set { if (this.cDWeek6 != value){
			this.cDWeek6 = value;
			Notify("CDWeek6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek7 {
	get { return cDWeek7;}
	set { if (this.cDWeek7 != value){
			this.cDWeek7 = value;
			Notify("CDWeek7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek8 {
	get { return cDWeek8;}
	set { if (this.cDWeek8 != value){
			this.cDWeek8 = value;
			Notify("CDWeek8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek9 {
	get { return cDWeek9;}
	set { if (this.cDWeek9 != value){
			this.cDWeek9 = value;
			Notify("CDWeek9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek10 {
	get { return cDWeek10;}
	set { if (this.cDWeek10 != value){
			this.cDWeek10 = value;
			Notify("CDWeek10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek11 {
	get { return cDWeek11;}
	set { if (this.cDWeek11 != value){
			this.cDWeek11 = value;
			Notify("CDWeek11");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek12 {
	get { return cDWeek12;}
	set { if (this.cDWeek12 != value){
			this.cDWeek12 = value;
			Notify("CDWeek12");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek13 {
	get { return cDWeek13;}
	set { if (this.cDWeek13 != value){
			this.cDWeek13 = value;
			Notify("CDWeek13");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CDWeek14 {
	get { return cDWeek14;}
	set { if (this.cDWeek14 != value){
			this.cDWeek14 = value;
			Notify("CDWeek14");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVMAJG {
	get { return aVMAJG; }
	set { if (this.aVMAJG != value){
			this.aVMAJG = value;
			Notify("AVMAJG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVMING {
	get { return aVMING; }
	set { if (this.aVMING != value){
			this.aVMING = value;
			Notify("AVMING");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ENGCHANGE {
	get { return eNGCHANGE; }
	set { if (this.eNGCHANGE != value){
			this.eNGCHANGE = value;
			Notify("ENGCHANGE");
		}
	}
}
  
[System.Runtime.Serialization.DataMember]
public
RP1268SContainer RP1268SContainer {
	get { return rP1268SContainer; }
	set { if (this.rP1268SContainer != value){
			this.rP1268SContainer = value;
			Notify("RP1268SContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QTYG12 {
	get { return qTYG12; }
	set { if (this.qTYG12 != value){
			this.qTYG12 = value;
			Notify("QTYG12");
		}
	}
}
        
public override
bool Equals(object obj){
	if (obj is RP1268D)
		return	this.hdrId.Equals(((RP1268D)obj).HdrId) &&
				this.detail.Equals(((RP1268D)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){
    for (int i=0; i < this.rP1268SContainer.Count;i++){
        this.rP1268SContainer[i].HdrId = this.hdrId;
        this.rP1268SContainer[i].Detail=this.detail;
        this.rP1268SContainer[i].SubDtl=i+1;
    }   
}

} // class
} // package