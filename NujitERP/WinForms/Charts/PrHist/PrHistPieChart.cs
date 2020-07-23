using System;
using System.Drawing;
using Nujit.NujitERP.WinForms.Charts;
using ChartDirector;

namespace Nujit.NujitERP.WinForms.Charts.HotListHoursChart{

public 
class PrHistPieChart : GenericChart{


public 
PrHistPieChart(double[] data, string[] labels):
	base(GenericChart.PIE_CHART,"Prueba Pie Chart",data,labels)
{		
	//this.Text = stittle;	
}

public override int[] getBackgroundGradientColor(){ return Chart.greenMetalGradient;}
public override
Color[] getColors(){
	Color[] colors = new Color[2];
	colors[0] = Color.Blue;
	colors[1] = Color.Red;
	return colors;
}


} // class

} // namespace
