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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class SchProductAvail : Product {

private decimal     qoh;
private decimal     qty;
private decimal     qtyAdjust;
private decimal     optRunQty;
private int         seq;
private DateTime    dateTime;
private string      familyPart;
private string      familyPartDesc;

public
SchProductAvail(): base(){        
    init();
}

private
void init(){
    this.qoh =0;
    this.qty =0;
    this.qtyAdjust=0;
    this.optRunQty = 0;
    this.seq=0;
    this.dateTime=DateUtil.MinValue;
    this.familyPart="";
    this.familyPartDesc="";
}

public
SchProductAvail(Product product): base( product.Id, product.ProdID, product.Db,
                                        product.Des1,product.Des2, product.Des3,
                                        product.VarFam, product.SeqLast,
                                        product.ActIDLast, product.FamProd,
                                        product.PartType, product.InvStatus,
                                        product.ABCCode, product.MajorGroup,
                                        product.MinorGroup, product.GLExp,
                                        product.GLDistr, product.MajorSales,
                                        product.MinorSales, product.LastRevision,
                                        product.RetailProductType, product.StdPackSize,
                                        product.StdPackUnit, product.ProdCode,

                                        product.Plant,
                                        product.OptimRunPurchSize,
                                        product.ProdMultiplier,
                                        product.MinRunPurchQty,
                                        product.MatlPrepLdTime,
                                        product.PallPackSize,
                                        product.PalletPackUnit,
                                        product.MinQty,
                                        product.MaxQty,
                                        product.VirtKanDemProf,
                                        product.VirtKanManDem,
                                        product.DaysOnHand,
                                        product.ObectivesAutomaticCalc,
                                        product.DemandLowQtySplit,
                                        product.Level){  
    init();                  
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
decimal Qty {
	get { return qty; }
	set { if (this.qty != value){
			this.qty = value;			
		}
	}
}

public
decimal QtyAdjust {
	get { return qtyAdjust; }
	set { if (this.qtyAdjust != value){
			this.qtyAdjust = value;			
		}
	}
}

public
decimal OptRunQty {
	get { return optRunQty; }
	set { if (this.optRunQty != value){
			this.optRunQty = value;			
		}
	}
}

public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;			
		}
	}
}

public
DateTime DateTime{
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;			
		}
	}
}
  
public
string FamilyPart{
	get { return familyPart; }
	set { if (this.familyPart != value){
			this.familyPart = value;			
		}
	}
}

public
string FamilyPartDesc{
	get { return familyPartDesc; }
	set { if (this.familyPartDesc != value){
			this.familyPartDesc = value;			
		}
	}
}


} // class
} // package