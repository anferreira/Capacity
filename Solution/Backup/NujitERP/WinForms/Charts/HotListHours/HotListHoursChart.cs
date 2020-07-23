using System;
using System.Drawing;
using Nujit.NujitERP.WinForms.Charts;

namespace Nujit.NujitERP.WinForms.Charts.HotListHoursChart{

public 
class HotListHoursChart : GenericChart{


public 
HotListHoursChart(double[][] data, string[] labels, string[] labelsOfBars, int type, string title) :
	base(type, title,"", data, labels,0, labelsOfBars){

	this.Text = "Machine Hours HotList";
}

public override
Color[] getColors(){
	Color[] colors = new Color[2];
	colors[0] = Color.Blue;
	colors[1] = Color.Red;
	return colors;
}

} // class

} // namespace
