using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Planned;
using HotListReports.Windows.Inventories;
using HotListReports.Windows.Demand;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.HotLists{


class HotListScheduleModel : BaseModel2{

private HotListContainer    hotListContainerSelsSchedule;
private HotListHdr          hotListHdr;
private ScheduleHdr         scheduleHdr;

public HotListScheduleModel(Window window,HotListContainer hotListContainerSelsSchedule, HotListHdr hotListHdr) : base(window){    
    this.hotListHdr                     = hotListHdr;        
    this.hotListContainerSelsSchedule   = hotListContainerSelsSchedule;
    scheduleHdr                         = null;
}

public
HotListContainer HotListContainerSelsSchedule{
	get { return hotListContainerSelsSchedule; }
	set { if (this.hotListContainerSelsSchedule != value){
			this.hotListContainerSelsSchedule = value;			
		}
	}
}

public
HotListHdr HotListHdr{
	get { return hotListHdr; }
	set { if (this.hotListHdr != value){
			this.hotListHdr = value;			
		}
	}
}

public
void loadColumnsOnHotList(ListView listView){
    try {
         GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "ProdID", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());        
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());        
                
        textBlockColumnListView = new TextBlockColumnListView("MajGrp", "MajorGroup", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                    
        gridView.Columns.Add(textBlockColumnListView.process());                      

        textBlockColumnListView = new TextBlockColumnListView("AvgDay" + "\n" + "Pull", "VirtKanManDem", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());      

        textBlockColumnListView = new TextBlockColumnListView("DayOn" + "\n" + "Hand", "DaysOnHand", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());      
                                                                                    
        textBlockColumnListView = new TextBlockColumnListView("Qoh", "Qoh", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Optimum" + "\n" + "RunQty", "OptRunQty", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
            
        textBlockColumnListView = new TextBlockColumnListView("MatQty", "MatQty", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());           
                
        textBlockColumnListView = new TextBlockColumnListView("RunStd", "MachCyc", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                     

        textBlockColumnListView = new TextBlockColumnListView("Date", "DateTime", BindingMode.OneWay,70,listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);    
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        TextNumericNewColumnListView textNumericNewColumnListView = new TextNumericNewColumnListView("Qty", "Qty", BindingMode.TwoWay,70, listView);
        textNumericNewColumnListView.setProperty(TextBox.IsReadOnlyProperty,false);
        textNumericNewColumnListView.setConverter(new DecimalToStringConverterNew(),"int");    
        textNumericNewColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textNumericNewColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("Hours", "Hours", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());       
                                                                            
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotList Exception: " + ex.Message);        
    }       
}

public 
bool schedule(){
    bool bresult=false;
    try { 
        if (hotListContainerSelsSchedule.Count > 0 && hotListHdr!= null) { 
            scheduleHdr                         = getCoreFactory().readScheduleHdrLast(hotListHdr.Plant);
            SchedulePart    schedulePart        = null;
            string          splant              = hotListHdr.Plant;            
            string          smessError          = "";
            int             icountAdded         =0;
            int             icountDiscarded     =0;

            if (scheduleHdr == null) { 
                scheduleHdr  = getCoreFactory().createScheduleHdr();
                scheduleHdr.Plant = hotListHdr.Plant;
            }
            
            for (int i=0; i < hotListContainerSelsSchedule.Count; i++) {
                HotListInvAnalysisViewSel hotListInvAnalysisViewSel = (HotListInvAnalysisViewSel)hotListContainerSelsSchedule[i];

                hotListInvAnalysisViewSel.DateTime = DateUtil.minorHour(hotListInvAnalysisViewSel.DateTime);
                hotListInvAnalysisViewSel.Qty      = Math.Abs(hotListInvAnalysisViewSel.Qty);

                if (hotListInvAnalysisViewSel.Qty > 0) { 
                    schedulePart = getCoreFactory(). scheduleAddSchedulePart(ref scheduleHdr,splant, hotListInvAnalysisViewSel.MachId,
                    hotListInvAnalysisViewSel.ProdID, hotListInvAnalysisViewSel.Seq,Math.Abs(hotListInvAnalysisViewSel.Qty), hotListInvAnalysisViewSel.DateTime,true,true,out smessError);

                    if (schedulePart!= null && string.IsNullOrEmpty(smessError)){
                        icountAdded++;
                        schedulePart.HdrId      = hotListInvAnalysisViewSel.Id;
                        schedulePart.HotListId  = hotListInvAnalysisViewSel.IdAut;
                    }else              
                        icountDiscarded++;
                }else              
                    icountDiscarded++;
            }

            bresult =true;
            if (icountAdded > 0 && scheduleHdr!= null){                            
                if (scheduleHdr.Id > 0)
                    getCoreFactory().updateScheduleHdr(scheduleHdr);
                else
                    getCoreFactory().writeScheduleHdr(scheduleHdr);                
            }
                    
            MessageBox.Show("Schedule Processed :\n\n" +  " Added     : " + icountAdded.ToString() +  "\n\n" + " Discarded : " + icountDiscarded.ToString());
        }else
            MessageBox.Show("Please, Select Item First.");

    } catch (Exception ex) {
        bresult=false;
        MessageBox.Show("schedule Exception: " + ex.Message);        
    }finally{
     
    }

    return bresult;
}  

public 
bool del(ListView listView){
    bool bresult=false;
    try{            
        HotListInvAnalysisViewSel hotListInvAnalysisViewSel = (HotListInvAnalysisViewSel)getSelected(listView);           

        if (hotListInvAnalysisViewSel != null){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Remove Item ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                hotListInvAnalysisViewSel.setFree();
                hotListContainerSelsSchedule.Remove(hotListInvAnalysisViewSel);
                bresult = true;
            }
        }else
            MessageBox.Show("To Delete Item, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }                       
    return bresult;
}


}
}
