using System;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class BomObjectivesView : Bom {

private decimal qtyBase;
private decimal qtyTotal;
private decimal qoh;
private decimal qtyHotList;
private DateTime dateObjective;

public
BomObjectivesView(Bom bom) : base ( bom.getBomContainer(),bom.Level,bom.Purchased,bom.Prod,bom.Act,
                                    bom.Seq,bom.Qty,bom.Dept,bom.Cfg,bom.ProdRate){
    this.qtyBase = 0;
    this.qtyTotal= 0;
    this.qoh = 0;
    this.qtyHotList = 0;
    this.dateObjective = DateTime.Now;
}

public
void reconvert(){
    ArrayList arrayList = new ArrayList();
    foreach(Bom bomAux in this.getBomContainer())
       arrayList.Add(bomAux);
    this.getBomContainer().Clear();
    
   foreach(Bom bomAux in arrayList){
        BomObjectivesView bomViewAux = new BomObjectivesView(bomAux);

        bomViewAux.QtyBase = this.QtyBase;
        bomViewAux.QtyTotal= this.QtyBase * bomViewAux.Qty;
        this.addToBomContainer(bomViewAux);
        bomViewAux.reconvert();
   }
}

public
decimal QtyBase {
	get { return qtyBase; }
	set { if (this.qtyBase != value){
			this.qtyBase = value;		
		}
	}
}

public
decimal QtyTotal {
	get { return qtyTotal; }
	set { if (this.qtyTotal != value){
			this.qtyTotal = value;		
		}
	}
}

public
decimal Qoh {
	get { return qoh; }
	set { if (this.qoh != value){
			this.qoh = value;		
		}
	}
}

public
decimal QtyHotList {
	get { return qtyHotList; }
	set { if (this.qtyHotList != value){
			this.qtyHotList = value;		
		}
	}
}

public
DateTime DateObjective {
	get { return dateObjective; }
	set { if (this.dateObjective != value){
			this.dateObjective = value;		
		}
	}
}


} // class

} // namespace
