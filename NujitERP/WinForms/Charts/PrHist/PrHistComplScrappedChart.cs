using System;
using System.Drawing;
using Nujit.NujitERP.WinForms.Charts;
using ChartDirector;

namespace Nujit.NujitERP.WinForms.Charts.HotListHoursChart{

public 
class PrHistComplScrappedChart : GenericChart{


public 
PrHistComplScrappedChart(double[][] data, string[] labels, string[] labelsOfBars, int type,string stittle) :
	base(type, stittle,"Quantity",data, labels,90,labelsOfBars){

	this.Text = stittle;	
}

public 
PrHistComplScrappedChart(double[] data, string[] labels, string[] labelsOfBars, int type,string stittle) :
	base(stittle, type, data, labels, 0, labelsOfBars){


	this.Text = stittle;
}

//public override 
//int[] getBackgroundGradientColor(){ 
//	return Chart.greenMetalGradient;
//}

public override
Color[] getColors(){
	Color[] colors = new Color[2];
	colors[0] = Color.LightGray;
	colors[1] = Color.Red;
	return colors;
}

public override
Color getTitleFontColor(){
	return Color.Blue;
}


} // class

} // namespace
