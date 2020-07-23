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
class ProductView : Product {

private decimal qoh;
private int     schMaterialAvailId;
private string  matPlannedShow;

public
ProductView(): base(){        
    this.qoh =0;
    this.schMaterialAvailId = 0;
    this.matPlannedShow = Constants.STRING_NO;
}

public
ProductView(int id,
            string prodID,string db, string des1, string des2,
		    string des3, string varFam, int seqLast,
		    string actIDLast, string famProd, string partType,
		    string invStatus, string aBCCode, string majorGroup,
		    string minorGroup, string gLExp, string gLDistr,
		    string majorSales, string minorSales, DateTime lastRevision,
		    string retailProductType, decimal stdPackSize, string stdPackUnit, string prodCode,
            string plant,decimal optimRunPurchSize,decimal prodMultiplier,decimal minRunPurchQty,int matlPrepLdTime,
            decimal pallPackSize,string palletPackUnit,decimal minQty,decimal maxQty,string virtKanDemProf,
            decimal virtKanManDem,decimal daysOnHand,string obectivesAutomaticCalc,decimal demandLowQtySplit,decimal level,
            decimal qoh,int schMaterialAvailId,string matPlannedShow) : 
            base(id,
             prodID, db, des1, des2,
             des3, varFam, seqLast,
             actIDLast, famProd, partType,
             invStatus, aBCCode, majorGroup,
             minorGroup, gLExp, gLDistr,
             majorSales, minorSales, lastRevision,
             retailProductType, stdPackSize, stdPackUnit, prodCode,
             plant, optimRunPurchSize, prodMultiplier, minRunPurchQty, matlPrepLdTime,
             pallPackSize, palletPackUnit, minQty, maxQty, virtKanDemProf,
             virtKanManDem, daysOnHand, obectivesAutomaticCalc, demandLowQtySplit,level){
    this.qoh= qoh;
    this.schMaterialAvailId = schMaterialAvailId;
    this.matPlannedShow = matPlannedShow;
}

public
decimal Qoh{
	get { return qoh; }
	set { if (this.qoh != value){
			this.qoh = value;
		}
	}
}

public
int SchMaterialAvailId{
	get { return schMaterialAvailId; }
	set { if (this.schMaterialAvailId != value){
			this.schMaterialAvailId = value;
		}
	}
}

public
string MatPlannedShow {
	get { return matPlannedShow; }
	set { if (this.matPlannedShow != value){
			this.matPlannedShow = value;
		}
	}
}



} // class
} // package