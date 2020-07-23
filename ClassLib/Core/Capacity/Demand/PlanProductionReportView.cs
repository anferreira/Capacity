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
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PlanProductionReportView : MachineReportView {

private string part;
private int    seq; 
private string custPart;
private string billTo;
private string shipTo;
private decimal maAutCum;
private decimal faAutCum;
        
private ArrayList arrayDays;

private CellTitles cellTitles;

public
PlanProductionReportView(): base(){        
    this.part = "";
    this.seq = 0;
    this.custPart = "";
    this.billTo = "";
    this.shipTo = "";
    this.maAutCum = 0;
    this.faAutCum = 0;

    arrayDays = new ArrayList(); //generate for 90 days
    for (int i=0; i < 90; i++){
        CellPlanProduction cellPlanProduction = new CellPlanProduction();
        arrayDays.Add(cellPlanProduction);
        cellPlanProduction.XIndex = i;
    }
    
    this.cellTitles = new CellTitles();    
    this.cellTitles.Title1 = "Planned";
    this.cellTitles.Title2 = "Production";
    this.cellTitles.Title3 = "862 Daily";    
    this.cellTitles.Title4 = "830 Weekly";    
    this.cellTitles.Title5 = "Shipments";
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part; }
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPart {
	get { return custPart; }
	set { if (this.custPart != value){
			this.custPart = value;
			Notify("CustPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BillTo {
	get { return billTo; }
	set { if (this.billTo != value){
			this.billTo = value;
			Notify("BillTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipTo {
	get { return shipTo; }
	set { if (this.shipTo != value){
			this.shipTo = value;
			Notify("ShipTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaAutCum {
	get { return maAutCum; }
	set { if (this.maAutCum != value){
			this.maAutCum = value;
			Notify("MaAutCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FaAutCum {
	get { return faAutCum; }
	set { if (this.faAutCum != value){
			this.faAutCum = value;
			Notify("FaAutCum");
		}
	}
}

public
CellPlanProduction getCellByIndex(int i){
    CellPlanProduction cell = null;
    if (i >= 0 && i < arrayDays.Count)
        cell = (CellPlanProduction)arrayDays[i];
    return cell;
}

public
void setCellByIndex(int i,CellPlanProduction cell){    
    if (i >= 0 && i < arrayDays.Count)
        arrayDays[i]= cell;    
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day001 {
	get { return getCellByIndex(0);}
	set {
        setCell(0,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day002 {
	get { return getCellByIndex(1);}
	set {
        setCell(1,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day003 {
	get { return getCellByIndex(2);}
	set {
        setCell(2,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day004 {
	get { return getCellByIndex(3);}
	set {
        setCell(3,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day005 {
	get { return getCellByIndex(4);}
	set {
        setCell(4,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day006 {
	get { return getCellByIndex(5);}
	set {
        setCell(5,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day007 {
	get { return getCellByIndex(6);}
	set {
        setCell(6,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day008 {
	get { return getCellByIndex(7);}
	set {
        setCell(7,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day009 {
	get { return getCellByIndex(8);}
	set {
        setCell(8,value);
	}
}


[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day010 {
	get { return getCellByIndex(9);}
	set {
        setCell(9,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day011 {
	get { return getCellByIndex(10);}
	set {
        setCell(10,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day012 {
	get { return getCellByIndex(11);}
	set {
        setCell(11,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day013 {
	get { return getCellByIndex(12);}
	set {
        setCell(12,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day014 {
	get { return getCellByIndex(13);}
	set {
        setCell(13,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day015 {
	get { return getCellByIndex(14);}
	set {
        setCell(14,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day016 {
	get { return getCellByIndex(15);}
	set {
        setCell(15,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day017 {
	get { return getCellByIndex(16);}
	set {
        setCell(16,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day018 {
	get { return getCellByIndex(17);}
	set {
        setCell(17,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day019 {
	get { return getCellByIndex(18);}
	set {
        setCell(18,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day020 {
	get { return getCellByIndex(19);}
	set {
        setCell(19,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day021 {
	get { return getCellByIndex(20);}
	set {
        setCell(20,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day022 {
	get { return getCellByIndex(21);}
	set {
        setCell(21,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day023 {
	get { return getCellByIndex(22);}
	set {
        setCell(22,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day024 {
	get { return getCellByIndex(23);}
	set {
        setCell(23,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day025 {
	get { return getCellByIndex(24);}
	set {
        setCell(24,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day026 {
	get { return getCellByIndex(25);}
	set {
        setCell(25,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day027 {
	get { return getCellByIndex(26);}
	set {
        setCell(26,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day028 {
	get { return getCellByIndex(27);}
	set {
        setCell(27,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day029 {
	get { return getCellByIndex(28);}
	set {
        setCell(28,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day030 {
	get { return getCellByIndex(29);}
	set {
        setCell(29,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day031 {
	get { return getCellByIndex(30);}
	set {
        setCell(30,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day032 {
	get { return getCellByIndex(31);}
	set {
        setCell(31,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day033 {
	get { return getCellByIndex(32);}
	set {
        setCell(32,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day034 {
	get { return getCellByIndex(33);}
	set {
        setCell(33,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day035 {
	get { return getCellByIndex(34);}
	set {
        setCell(34,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day036 {
	get { return getCellByIndex(35);}
	set {
        setCell(35,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day037 {
	get { return getCellByIndex(36);}
	set {
        setCell(36,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day038 {
	get { return getCellByIndex(37);}
	set {
        setCell(37,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day039 {
	get { return getCellByIndex(38);}
	set {
        setCell(38,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day040 {
	get { return getCellByIndex(39);}
	set {
        setCell(39,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day041 {
	get { return getCellByIndex(40);}
	set {
        setCell(40,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day042 {
	get { return getCellByIndex(41);}
	set {
        setCell(41,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day043 {
	get { return getCellByIndex(42);}
	set {
        setCell(42,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day044 {
	get { return getCellByIndex(43);}
	set {
        setCell(43,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day045 {
	get { return getCellByIndex(44);}
	set {
        setCell(44,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day046 {
	get { return getCellByIndex(45);}
	set {
        setCell(45,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day047 {
	get { return getCellByIndex(46);}
	set {
        setCell(46,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day048 {
	get { return getCellByIndex(47);}
	set {
        setCell(47,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day049 {
	get { return getCellByIndex(48);}
	set {
        setCell(48,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day050 {
	get { return getCellByIndex(49);}
	set {
        setCell(49,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day051 {
	get { return getCellByIndex(50);}
	set {
        setCell(50,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day052 {
	get { return getCellByIndex(51);}
	set {
        setCell(51,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day053 {
	get { return getCellByIndex(52);}
	set {
        setCell(52,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day054 {
	get { return getCellByIndex(53);}
	set {
        setCell(53,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day055 {
	get { return getCellByIndex(54);}
	set {
        setCell(54,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day056 {
	get { return getCellByIndex(55);}
	set {
        setCell(55,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day057 {
	get { return getCellByIndex(56);}
	set {
        setCell(56,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day058 {
	get { return getCellByIndex(57);}
	set {
        setCell(57,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day059 {
	get { return getCellByIndex(58);}
	set {
        setCell(58,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day060 {
	get { return getCellByIndex(59);}
	set {
        setCell(59,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day061 {
	get { return getCellByIndex(60);}
	set {
        setCell(60,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day062 {
	get { return getCellByIndex(61);}
	set {
        setCell(61,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day063 {
	get { return getCellByIndex(62);}
	set {
        setCell(62,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day064 {
	get { return getCellByIndex(63);}
	set {
        setCell(63,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day065 {
	get { return getCellByIndex(64);}
	set {
        setCell(64,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day066 {
	get { return getCellByIndex(65);}
	set {
        setCell(65,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day067 {
	get { return getCellByIndex(66);}
	set {
        setCell(66,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day068 {
	get { return getCellByIndex(67);}
	set {
        setCell(67,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day069 {
	get { return getCellByIndex(68);}
	set {
        setCell(68,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day070 {
	get { return getCellByIndex(69);}
	set {
        setCell(69,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day071 {
	get { return getCellByIndex(70);}
	set {
        setCell(70,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day072 {
	get { return getCellByIndex(71);}
	set {
        setCell(71,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day073 {
	get { return getCellByIndex(72);}
	set {
        setCell(72,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day074 {
	get { return getCellByIndex(73);}
	set {
        setCell(73,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day075 {
	get { return getCellByIndex(74);}
	set {
        setCell(74,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day076 {
	get { return getCellByIndex(75);}
	set {
        setCell(75,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day077 {
	get { return getCellByIndex(76);}
	set {
        setCell(76,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day078 {
	get { return getCellByIndex(77);}
	set {
        setCell(77,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day079 {
	get { return getCellByIndex(78);}
	set {
        setCell(78,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day080 {
	get { return getCellByIndex(79);}
	set {
        setCell(79,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day081 {
	get { return getCellByIndex(80);}
	set {
        setCell(80,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day082 {
	get { return getCellByIndex(81);}
	set {
        setCell(81,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day083 {
	get { return getCellByIndex(82);}
	set {
        setCell(82,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day084 {
	get { return getCellByIndex(83);}
	set {
        setCell(83,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day085 {
	get { return getCellByIndex(84);}
	set {
        setCell(84,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day086 {
	get { return getCellByIndex(85);}
	set {
        setCell(85,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day087 {
	get { return getCellByIndex(86);}
	set {
        setCell(86,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day088 {
	get { return getCellByIndex(87);}
	set {
        setCell(87,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day089 {
	get { return getCellByIndex(88);}
	set {
        setCell(88,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanProduction Day090 {
	get { return getCellByIndex(89);}
	set {
        setCell(89,value);
	}
}


public
void setCell(int index,CellPlanProduction cellNew){
    CellPlanProduction cell = getCellByIndex(22);
    if (cell != cellNew){
        setCellByIndex(index, cell);
		Notify("Day" + (index+1).ToString("000"));
	}
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles {
	get { return cellTitles; }
	set { if (this.cellTitles != value){
			this.cellTitles = value;
			Notify("CellTitles");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is PlanProductionReportView)
		return	this.Part.Equals(((PlanProductionReportView)obj).Part) &&
				this.Seq.Equals(((PlanProductionReportView)obj).Seq) &&
                this.CustPart.Equals(((PlanProductionReportView)obj).CustPart) &&
                this.ShipTo.Equals(((PlanProductionReportView)obj).ShipTo) &&
                this.MaAutCum.Equals(((PlanProductionReportView)obj).MaAutCum) &&
                this.FaAutCum.Equals(((PlanProductionReportView)obj).FaAutCum);
	else
		return false;
}


} // class
} // package