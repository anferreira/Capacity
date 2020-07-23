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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CellTitles : BusinessObject {

private string title1;
private string title2;
private string title3;
private string title4;
private string title5;
private string title6;
private string title7;
private string title8;
private string title9;
private string title10;
private string title11;
private string title12;
private string title13;

public
CellTitles(): base(){            
    this.title1 = "";
    this.title2 = "";
    this.title3 = "";  
    this.title4 = "";
    this.title5 = "";  
    this.title6 = "";  
    this.title7 = "";
    this.title8 = "";  
    this.title9 = "";  
    this.title10 = "";
    this.title11 = "";  
    this.title12 = "";  
    this.title13 = "";  
}

[System.Runtime.Serialization.DataMember]
public
string Title1 {
	get { return title1; }
	set { if (this.title1 != value){
			this.title1 = value;
			Notify("Title1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title2 {
	get { return title2; }
	set { if (this.title2 != value){
			this.title2 = value;
			Notify("Title2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title3 {
	get { return title3; }
	set { if (this.title3 != value){
			this.title3 = value;
			Notify("Title3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title4 {
	get { return title4; }
	set { if (this.title4 != value){
			this.title4 = value;
			Notify("Title4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title5 {
	get { return title5; }
	set { if (this.title5 != value){
			this.title5 = value;
			Notify("Title5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title6 {
	get { return title6; }
	set { if (this.title6 != value){
			this.title6 = value;
			Notify("Title6");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string Title7 {
	get { return title7; }
	set { if (this.title7 != value){
			this.title7 = value;
			Notify("Title7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title8 {
	get { return title8; }
	set { if (this.title8 != value){
			this.title8 = value;
			Notify("Title8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title9 {
	get { return title9; }
	set { if (this.title9 != value){
			this.title9 = value;
			Notify("Title9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title10 {
	get { return title10; }
	set { if (this.title10 != value){
			this.title10 = value;
			Notify("Title10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Title11 {
	get { return title11; }
	set { if (this.title11 != value){
			this.title11 = value;
			Notify("Title11");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string Title12 {
	get { return title12; }
	set { if (this.title12 != value){
			this.title12 = value;
			Notify("Title12");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string Title13 {
	get { return title13; }
	set { if (this.title13 != value){
			this.title13 = value;
			Notify("Title13");
		}
	}
}

} // class
} // package