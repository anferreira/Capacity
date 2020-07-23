using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using System.Windows.Media;

namespace HotListReports.Windows.HotLists{

public
class HotListInvAnalysisViewSel : HotListInvAnalysisView{
        
private int         machId;
private TextBox     textBox;

public 
HotListInvAnalysisViewSel() : base(){
    this.textBox= null;
    this.machId = 0;
} 

public
TextBox TextBox{
	get { return textBox; }
	set { 
        this.textBox = value;					
	}
}

public
int MachId{
	get { return machId; }
	set { if (this.machId != value){
			this.machId = value;			
		}
	}
}

public
void setSelected() {
    if (textBox!= null)
        textBox.Background = new SolidColorBrush(Colors.Green);
}

public
void setFree() {
    if (textBox!= null)
        textBox.Background = new SolidColorBrush(Colors.White);
}    

}
}
