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
class HotList : HotListDays {

private int idAut;
private int id;
private string prodID;
private string actID;
private int seq;
private string uom;
private string dept;
private string mach;
private decimal machCyc;
private decimal qoh;
private decimal qohCml;
private string majorGroup;
private string minorGroup;
private string finalized;
private string type;
private string mainMaterial;
private int mainMaterialSeq;
private decimal mainMaterialQoh;
private string plt;

private int levelShow=0;

#if !WEB
internal
#else
public
#endif
HotList() : base(){
	this.idAut = 0;
	this.id = 0;
	this.prodID = "";
	this.actID = "";
	this.seq = 0;
	this.uom = "";
	this.dept = "";
	this.mach = "";
	this.machCyc = 0;
	this.qoh = 0;
	this.qohCml = 0;
	
	this.majorGroup = "";
	this.minorGroup = "";
	this.finalized = "";
	this.type = "";
	this.mainMaterial = "";
	this.mainMaterialSeq = 0;
	this.mainMaterialQoh = 0;
	this.plt = "";
}

internal
HotList(
	int idAut,
	int id,
	string prodID,
	string actID,
	int seq,
	string uom,
	string dept,
	string mach,
	decimal machCyc,
	decimal qoh,
	decimal qohCml,
	decimal pastDue,
	decimal day001,
	decimal day002,
	decimal day003,
	decimal day004,
	decimal day005,
	decimal day006,
	decimal day007,
	decimal day008,
	decimal day009,
	decimal day010,
	decimal day011,
	decimal day012,
	decimal day013,
	decimal day014,
	decimal day015,
	decimal day016,
	decimal day017,
	decimal day018,
	decimal day019,
	decimal day020,
	decimal day021,
	decimal day022,
	decimal day023,
	decimal day024,
	decimal day025,
	decimal day026,
	decimal day027,
	decimal day028,
	decimal day029,
	decimal day030,
	decimal day031,
	decimal day032,
	decimal day033,
	decimal day034,
	decimal day035,
	decimal day036,
	decimal day037,
	decimal day038,
	decimal day039,
	decimal day040,
	decimal day041,
	decimal day042,
	decimal day043,
	decimal day044,
	decimal day045,
	decimal day046,
	decimal day047,
	decimal day048,
	decimal day049,
	decimal day050,
	decimal day051,
	decimal day052,
	decimal day053,
	decimal day054,
	decimal day055,
	decimal day056,
	decimal day057,
	decimal day058,
	decimal day059,
	decimal day060,
	decimal day061,
	decimal day062,
	decimal day063,
	decimal day064,
	decimal day065,
	decimal day066,
	decimal day067,
	decimal day068,
	decimal day069,
	decimal day070,
	decimal day071,
	decimal day072,
	decimal day073,
	decimal day074,
	decimal day075,
	decimal day076,
	decimal day077,
	decimal day078,
	decimal day079,
	decimal day080,
	decimal day081,
	decimal day082,
	decimal day083,
	decimal day084,
	decimal day085,
	decimal day086,
	decimal day087,
	decimal day088,
	decimal day089,
	decimal day090,
	string majorGroup,
	string minorGroup,
	string finalized,
	string type,
	string mainMaterial,
	int mainMaterialSeq,
	decimal mainMaterialQoh,
	string plt) : base(pastDue,day001,day002,day003,day004,day005,day006,day007,day008,day009,day010,
                        day011,day012,day013,day014,day015,day016,day017,day018,day019,day020,
                        day021,day022,day023,day024,day025,day026,day027,day028,day029,day030,
                        day031,day032,day033,day034,day035,day036,day037,day038,day039,day040,
                        day041,day042,day043,day044,day045,day046,day047,day048,day049,day050,
                        day051,day052,day053,day054,day055,day056,day057,day058,day059,day060,
                        day061,day062,day063,day064,day065,day066,day067,day068,day069,day070,
                        day071,day072,day073,day074,day075,day076,day077,day078,day079,day080,
                        day081,day082,day083,day084,day085,day086,day087,day088,day089,day090){
	this.idAut = idAut;
	this.id = id;
	this.prodID = prodID;
	this.actID = actID;
	this.seq = seq;
	this.uom = uom;
	this.dept = dept;
	this.mach = mach;
	this.machCyc = machCyc;
	this.qoh = qoh;
	this.qohCml = qohCml;
	
	this.majorGroup = majorGroup;
	this.minorGroup = minorGroup;
	this.finalized = finalized;
	this.type = type;
	this.mainMaterial = mainMaterial;
	this.mainMaterialSeq = mainMaterialSeq;
	this.mainMaterialQoh = mainMaterialQoh;
	this.plt = plt;
}

[System.Runtime.Serialization.DataMember]
public
int IdAut {
	get { return idAut;}
	set { if (this.idAut != value){
			this.idAut = value;
			Notify("IdAut");
		}
	}
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
string Uom {
	get { return uom;}
	set { if (this.uom != value){
			this.uom = value;
			Notify("Uom");
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
string Mach {
	get { return mach;}
	set { if (this.mach != value){
			this.mach = value;
			Notify("Mach");
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
decimal Qoh {
	get { return qoh;}
	set { if (this.qoh != value){
			this.qoh = value;
			Notify("Qoh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QohCml {
	get { return qohCml;}
	set { if (this.qohCml != value){
			this.qohCml = value;
			Notify("QohCml");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MajorGroup {
	get { return majorGroup;}
	set { if (this.majorGroup != value){
			this.majorGroup = value;
			Notify("MajorGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinorGroup {
	get { return minorGroup;}
	set { if (this.minorGroup != value){
			this.minorGroup = value;
			Notify("MinorGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Finalized {
	get { return finalized;}
	set { if (this.finalized != value){
			this.finalized = value;
			Notify("Finalized");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Type {
	get { return type;}
	set { if (this.type != value){
			this.type = value;
			Notify("Type");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MainMaterial {
	get { return mainMaterial;}
	set { if (this.mainMaterial != value){
			this.mainMaterial = value;
			Notify("MainMaterial");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MainMaterialSeq {
	get { return mainMaterialSeq;}
	set { if (this.mainMaterialSeq != value){
			this.mainMaterialSeq = value;
			Notify("MainMaterialSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MainMaterialQoh {
	get { return mainMaterialQoh;}
	set { if (this.mainMaterialQoh != value){
			this.mainMaterialQoh = value;
			Notify("MainMaterialQoh");
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
int LevelShow {
	get { return levelShow; }
	set { if (this.levelShow != value){
			this.levelShow = value;
			Notify("LevelShow");
		}
	}
}


public override
bool Equals(object obj){
	if (obj is HotList)
		return	this.idAut.Equals(((HotList)obj).IdAut);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
DateTime calculatePastDueDate(DateTime runDate){
    DateTime pastDue = runDate.AddDays(-1);
    pastDue =  new DateTime(pastDue.Year, pastDue.Month, pastDue.Day,23,59,59);
    return pastDue;
}

public
void copy(HotList hotList){	
	this.IdAut=hotList.IdAut;
	this.Id=hotList.Id;
	this.ProdID=hotList.ProdID;
	this.ActID=hotList.ActID;
	this.Seq=hotList.Seq;
	this.Uom=hotList.Uom;
	this.Dept=hotList.Dept;
	this.Mach=hotList.Mach;
	this.MachCyc=hotList.MachCyc;
	this.Qoh=hotList.Qoh;
	this.QohCml=hotList.QohCml;

	this.MajorGroup=hotList.MajorGroup;
	this.MinorGroup=hotList.MinorGroup;
	this.Finalized=hotList.Finalized;
	this.Type=hotList.Type;
	this.MainMaterial=hotList.MainMaterial;
	this.MainMaterialSeq=hotList.MainMaterialSeq;
	this.MainMaterialQoh=hotList.MainMaterialQoh;
	this.Plt=hotList.Plt;
            
    base.copy(hotList);            	
}

public
void setQohAffectsNets(bool bcumulativeQty){
    decimal     dpastDue= 0;
    decimal     dnet    = 0;
    string      sfield  = "";        
    
    if (bcumulativeQty)
        this.calculateNonCumulative();

    dpastDue = this.PastDue; // this.PastDue = -57 Qoh=92
    dpastDue+= this.Qoh;
    if (this.Qoh > Math.Abs(this.PastDue))
        this.PastDue = 0;   
    else        
        this.PastDue = dpastDue;
           
    for (int j=0; j < Constants.MAX_HOTLIST_DAYS; j++){
        sfield  = "Day" + (j+1).ToString("000");
        dnet    = this.getQtyByFieldName(sfield);

        if (dpastDue > Math.Abs(dnet)) { 
            //this.setQtyByDate(runDate,runDate.AddDays(j),0);
            this.setQtyByFieldName(sfield,0);
            dpastDue+=dnet;
        }else{
            dpastDue+=dnet;
            //this.setQtyByDate(runDate,runDate.AddDays(j),dpastDue);            
            this.setQtyByFieldName(sfield,dpastDue);
        }                        
    }
    if (!bcumulativeQty)
        this.calculateNonCumulative();    
}


} // class
} // package