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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class MainMat : BusinessObject {

private string pART;
private int dTL;
private string mAINPART;

private MainMatContainer mainMatContainer;

#if !WEB
internal
#else
public
#endif
MainMat(){
	this.pART = "";
	this.dTL = 0;
	this.mAINPART = "";
    this.mainMatContainer = new MainMatContainer();
}

internal
MainMat(
	string pART,
	int dTL,
	string mAINPART)
{
	this.pART = pART;
	this.dTL = dTL;
	this.mAINPART = mAINPART;
    this.mainMatContainer = new MainMatContainer();
}

[System.Runtime.Serialization.DataMember]
public
string PART {
	get { return pART;}
	set { if (this.pART != value){
			this.pART = value;
			Notify("PART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DTL {
	get { return dTL;}
	set { if (this.dTL != value){
			this.dTL = value;
			Notify("DTL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MAINPART {
	get { return mAINPART;}
	set { if (this.mAINPART != value){
			this.mAINPART = value;
			Notify("MAINPART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
MainMatContainer MainMatContainer {
	get { return mainMatContainer;}
	set { if (this.mainMatContainer != value){
			this.mainMatContainer = value;
			Notify("MainMatContainer");
		}
	}
}

public
void fillRedundances(){
    for (int i=0; i < this.mainMatContainer.Count;i++){
        this.mainMatContainer[i].PART= this.PART;
        this.mainMatContainer[i].DTL=i+1;        
    }       
} 

public override
bool Equals(object obj){
	if (obj is MainMat)
		return	this.pART.Equals(((MainMat)obj).PART) &&
				this.dTL.Equals(((MainMat)obj).DTL);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package