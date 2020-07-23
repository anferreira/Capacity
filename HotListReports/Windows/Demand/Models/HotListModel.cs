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

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;



namespace HotListReports.Windows.Demand{
class  HotListModel : BaseModelDatesReport{

private HotListViewHdrContainer hotListViewHdrContainer;
private TextBox                 textBoxLast;
private ArrayList               arrayBoxSelected;


public HotListModel(Window window) : base(window){    
    this.hotListViewHdrContainer = coreFactory.createHotListViewHdrContainer();
    this.textBoxLast = null;
    this.arrayBoxSelected = new ArrayList();
}

public
void searchHotList(ListView listView,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,string sglExp,string sreportedPoint,string sprodFamily,int idaysWithQty,bool bqtyCumulative,bool bqohAffects, bool baddReceipParts, bool baddMaterialConsumPart,int rows){
    try {
        string[][] items = getCoreFactory().getHotListAsStringNew(0, splantHotList, splant, sdept, smachine, imachineId, spart,-1, sglExp,sreportedPoint, sprodFamily, idaysWithQty,false, bqtyCumulative, bqohAffects, baddReceipParts, baddMaterialConsumPart, rows);
        
        DateTime runDate = DateUtil.MinValue;
        int i =getPastDueIndex(out runDate, splantHotList);
        summarizePastDue(items, i, bqtyCumulative);
        loadColumnsOnHotListDateOnTopGrid(listView,i,splantHotList,idaysWithQty);        

        setDataContextListView(listView,items);        
       
    } catch (Exception ex) {
        MessageBox.Show("search Exception: " + ex.Message);        
    }
}
               
public
void searchHotListLabourType(ListView listView,string splantHotlist,string splant,string sdept,string smachine,int imachineId,string spart,string sglExp,string srepPoint,bool bqtyCumulative, bool baddReceipParts, bool baddMaterialConsumPart,int rows){
    try {
        string[][] items = getCoreFactory().getHotListLabourType(0, splantHotlist, splant, sdept, smachine, imachineId, spart, -1, sglExp, srepPoint, false, false, baddReceipParts, baddMaterialConsumPart, rows);

        DateTime runDate = DateUtil.MinValue;
        int i =getPastDueIndex(out runDate, splantHotlist);
        summarizePastDue(items, i, false);
        loadColumnsOnLabourTypeGrid(listView,i,splantHotlist);        

        setDataContextListView(listView,items);        
                
    } catch (Exception ex) {
        MessageBox.Show("searchHotListLabourType Exception: " + ex.Message);        
    }
}

public
void searchInventory(ListView listView,string splantOriginal,string spart, int seq,string stockLoc,string smachine,int imachineId,string sglExp,string srepPoint,string sprodFamily, DateTime startDate, DateTime endDate,bool bqtyCumulative, bool baddReceipParts,int rows){
    try {
        string[][] items = getCoreFactory().getInventoryForSchedule(splantOriginal,spart, seq, stockLoc, smachine, imachineId, sglExp,"", "", startDate, endDate, baddReceipParts, bqtyCumulative, rows);
        
        setDataContextListView(listView,items);
                
    } catch (Exception ex) {
        MessageBox.Show("search Exception: " + ex.Message);        
    }
}

public
void summarizePastDue(string[][] items,int indexPastDue,bool bqtyCumulative){
    try {        
        int     itotalIndex= Constants.INDEX_HOTLIST_START_PASTUE + indexPastDue;
        decimal dsumQty=0;
        decimal dpriorQty=0;
        decimal doriginalPastDue=0;
        // 1 2 3 4 5 6 7 8
        for (int i=0;i < items.Length;i++){
            string[]  line = items[i];
            
            dsumQty=0;
            doriginalPastDue= bqtyCumulative ? Convert.ToDecimal(line[Constants.INDEX_HOTLIST_START_PASTUE]) : 0;
            dpriorQty=0;
            for (int j= Constants.INDEX_HOTLIST_START_PASTUE; j < (line.Length-2) && j <= itotalIndex; j++){                
                        
                if (bqtyCumulative){
                    if (j > Constants.INDEX_HOTLIST_START_PASTUE)
                        dsumQty+= Convert.ToDecimal(line[j]) - dpriorQty;
                    else
                        dsumQty+= Convert.ToDecimal(line[j]);
                }else
                    dsumQty+= Convert.ToDecimal(line[j]);

                dpriorQty  = Convert.ToDecimal(line[j]);
                if (j == itotalIndex)
                    line[j] = decimal.Floor(dsumQty).ToString();
                else
                    line[j] = decimal.Floor(0).ToString();                
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("search Exception: " + ex.Message);        
    }
}

public
int getPastDueIndex(out DateTime runDate,string splant){
    int index = 0;
    runDate = DateUtil.MinValue;       
    try {
        bool        bfound=false;
        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);        
        runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
        DateTime    currentWeek=DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out priorMonday, out nextSunday);

        currentWeek = priorMonday; //all day minor than currentweek will be past due        
        for (int i = 0; i< 90 && !bfound; i++){
            DateTime dateTimeAux = runDate.AddDays(i);            
            if (dateTimeAux < currentWeek)
                index=(i+1);
            else
                bfound=true;
        }
    } catch (Exception ex) {
        MessageBox.Show("getPastDueIndex Exception: " + ex.Message);        
    }
    return index;
}

public
void loadColumnsOnHotListDateOnTopGrid(ListView listView,int indexPastDue,string splant,int idaysWithQty){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("Dept", "[0]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "[7]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "[4]", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;           
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));                     
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());        
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "[5]", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());                
                
        textBlockColumnListView = new TextBlockColumnListView("L", "[108]", BindingMode.OneWay,10,listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Qoh", "[9]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                  

        textBlockColumnListView = new TextBlockColumnListView("Optimum" + "\n" + "RunQty", "[107]", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                                   
                 
        textBlockColumnListView = new TextBlockColumnListView("PastDue", "[" + (indexPastDue+ Constants.INDEX_HOTLIST_START_PASTUE) +"]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);
        DateTime    runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
		
        int idaysAux= idaysWithQty == 0 ? int.MaxValue : (idaysWithQty * 3);        
        if (idaysAux >0 && idaysAux < 14)        
            idaysAux= 14;

        for (int i= indexPastDue; i < 90 && idaysAux >= 0; i++,idaysAux--){
            DateTime dateTimeAux = runDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);
     
            textColumnListView = new TextColumnListView(sweekTitle + "\n" + sdate, "["  +  (i+ Constants.INDEX_HOTLIST_START_PASTUE + 1) +  "]", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);            
            loadTextColumnListView(textColumnListView,cell);            
            gridView.Columns.Add(textColumnListView.process()); 
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListDateOnTopGrid Exception: " + ex.Message);        
    }
}

private
void loadTextColumnListView(TextColumnListView textColumnListView, Style  cell){
    textColumnListView.setProperty(TextBox.FontWeightProperty, FontWeights.UltraBold);            
    textColumnListView.setProperty(TextBox.MinHeightProperty, (double)10);
    textColumnListView.setProperty(TextBox.HeightProperty, (double)17);
    textColumnListView.setProperty(TextBox.FontSizeProperty, (double)11.5);
    textColumnListView.setProperty(TextBox.PaddingProperty, new Thickness(0));
    textColumnListView.setConverter(new DecimalToStringConverterNew(), "int");            
    textColumnListView.setProperty(TextBox.IsReadOnlyProperty,true);
    textColumnListView.getColumn().HeaderContainerStyle = cell;                   
    textColumnListView.setEvent(TextBox.GotFocusEvent, new RoutedEventHandler(textBoxGotFocus));                                 
    textColumnListView.setProperty(TextBox.TextAlignmentProperty, TextAlignment.Right);
    textColumnListView.setProperty(TextBox.FontFamilyProperty,new FontFamily(Constants.FONT_FAMILY_ARIALBLACK));    
}
        /*
private
void loadTextBlockColumnListView(TextBlockColumnListView textColumnListView, Style  cell){
    textColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.UltraBold);            
    textColumnListView.setProperty(TextBlock.MinHeightProperty, (double)10);
    textColumnListView.setProperty(TextBlock.HeightProperty, (double)17);
    textColumnListView.setProperty(TextBlock.FontSizeProperty, (double)11.5);
    textColumnListView.setProperty(TextBlock.PaddingProperty, new Thickness(0));
    textColumnListView.setConverter(new DecimalToStringConverterNew(), "int");                
    textColumnListView.getColumn().HeaderContainerStyle = cell;                   
    textColumnListView.setEvent(TextBlock.GotFocusEvent, new RoutedEventHandler(textBoxGotFocus));                             
    textColumnListView.setProperty(TextBlock.ForegroundProperty,new SolidColorBrush(Colors.DarkBlue));                    
    textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textColumnListView.setProperty(TextBlock.FontFamilyProperty,new FontFamily(Constants.FONT_FAMILY_ARIALBLACK));    
}*/

private 
void textBoxGotFocus(object sender, RoutedEventArgs e){            
    textBoxGotFocus((TextBox)sender);
}

private 
void textBoxGotFocus(TextBox textBoxEvent){
    try { 
        bool bcontrolPressed = (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl));

        if (!bcontrolPressed)
            startCellSelect();

        if (true){ 
            textBoxLast = textBoxEvent;   
     
            HotListCellSel  hotListCellSel      = new HotListCellSel();
            HotListCellSel  hotListCellSelOld   = arrayBoxSelected.Count > 0 ? (HotListCellSel)arrayBoxSelected[0]  : null;
            var             binding = BindingOperations.GetBinding(textBoxLast, TextBox.TextProperty); // get binding
            string          sbind   = binding!= null ? binding.Path.Path : "";        
            int             index   = 0;        
        
            sbind = sbind.Replace("]", "").Replace("[","");
            if (NumberUtil.isIntegerNumber(sbind))
                index = Convert.ToInt32(sbind);

            hotListCellSel.TextBox  = textBoxLast;
            hotListCellSel.Items    = (string[])textBoxLast.DataContext;
            hotListCellSel.XIndex   = index;
        
            textBoxLast.Background = new SolidColorBrush(Colors.Green);

            if (hotListCellSel!= null && hotListCellSelOld!= null && hotListCellSel.Yindex!= hotListCellSelOld.Yindex)
                startCellSelect();

            arrayBoxSelected.Add(hotListCellSel);
        }

    } catch (Exception ex) {
        MessageBox.Show("textBoxGotFocus Exception: " + ex.Message);        
    }
}  

public
void loadColumnsOnInventoryGrid(ListView listView,DateTime startDate){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                             
        textBlockColumnListView = new TextBlockColumnListView("Part", "[0]", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());        
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "[1]", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  
                
        textBlockColumnListView = new TextBlockColumnListView("Desc", "[3]", BindingMode.OneWay,190, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                        
        gridView.Columns.Add(textBlockColumnListView.process());                        
                                                
        textBlockColumnListView = new TextBlockColumnListView("Qoh", "[" + Constants.INDEX_INVENTORY_START_QOH.ToString()  +  "]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                                       
                                
        for (int i= 0; i < 90;i++){
            DateTime dateTimeAux = startDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0", CapacityView.TITLE_WEEK0); 
         
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate, "[" + (i + Constants.INDEX_INVENTORY_START_QOH + 1) + "]", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());    
        
            //textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate, "[" + (i + Constants.INDEX_INVENTORY_START_QOH + 1) + "]", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            //this.loadTextBlockColumnListView(textBlockColumnListView, cell);
            //gridView.Columns.Add(textBlockColumnListView.process()); 
            
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnInventoryGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnLabourTypeGrid(ListView listView,int indexPastDue,string splant){
      try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
            
        textBlockColumnListView = new TextBlockColumnListView("Department", "[3]", BindingMode.OneWay, 120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "[0]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LabourId", "[1]", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Desc", "[2]", BindingMode.OneWay,120, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));                                   
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());                
        
        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);
        DateTime    runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
        
        for (int i= indexPastDue; i < 90;i++){
            DateTime dateTimeAux = runDate.AddDays(i);
            string   sdate      = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0", CapacityView.TITLE_WEEK0); 

            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate, "["  +  (i+ Constants.INDEX_HOTLIST_START_PASTUE + 1) +  "]", BindingMode.OneWay,40, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnLabourTypeGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnLabourTypeGrid2(ListView listView,string splant){
      try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                    
        textBlockColumnListView = new TextBlockColumnListView("Labour", "LabName", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT)); 
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lab.Id", "Id", BindingMode.OneWay,50, listView);   
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                     
        gridView.Columns.Add(textBlockColumnListView.process());
        
        HotListHdr  hotListHdr      = getCoreFactory().readLastHotList(splant);
        DateTime    runDate         = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
        int         ipastDueIndex   = getPastDueIndex(out runDate,splant);
        
        for (int i= ipastDueIndex; i < (90-ipastDueIndex); i++){
            DateTime    dateTimeAux = runDate.AddDays(i);
            string      sdate       = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string      sweekTitle  = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0", CapacityView.TITLE_WEEK0); 
            string      sbind       = "Day" + (i+1).ToString("000");

            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sbind, BindingMode.OneWay,40, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"0.0");
            gridView.Columns.Add(textBlockColumnListView.process());  
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnLabourTypeGrid2 Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnFutureInventoryGrid(ListView listView,DateTime startDate,DateTime endDate){
      try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Part", "[0]", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));                        
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());        
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "[1]", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  
                
        textBlockColumnListView = new TextBlockColumnListView("Desc", "[2]", BindingMode.OneWay,190, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                        
        gridView.Columns.Add(textBlockColumnListView.process());                           
                                                     
        textBlockColumnListView = new TextBlockColumnListView("Qoh", "[" + (Constants.INDEX_INVENTORY_FUTURE-1) + "]", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process()); 

        int istartWeek  = DateUtil.weekNumber(startDate);
        int ibkpStartWeek = istartWeek;
        int iendWeek    = DateUtil.weekNumber(endDate) + (endDate.Year > startDate.Year ? DateUtil.weekNumber(new DateTime(startDate.Year, 12, 31)) : 0); 
        DateTime        priorMonday = startDate;
        DateTime        nextSunday  = startDate;
                       
        for (int i= istartWeek; i < iendWeek && i < (ibkpStartWeek + CapacityView.TITLE_COUNTS); i++){
            DateUtil.getPriorMondayNextSundayFromDate(startDate.AddDays( (i - istartWeek) * 7 ),out priorMonday,out nextSunday);

            string   sdate      = DateUtil.getDateRepresentation(priorMonday,DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(priorMonday).Replace("Week0", CapacityView.TITLE_WEEK0); 
                    
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate, "["  + (i - istartWeek + Constants.INDEX_INVENTORY_FUTURE) +  "]", BindingMode.OneWay,40, listView); 
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
            
             /*
            textColumnListView = new TextColumnListView(sweekTitle + "\n" + sdate, "[" + (i - istartWeek + Constants.INDEX_INVENTORY_FUTURE) + "]",BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);            // +2 because part/seq on first indexs
            loadTextColumnListView(textColumnListView,cell);  
            gridView.Columns.Add(textColumnListView.process()); */
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnLabourTypeGrid Exception: " + ex.Message);        
    }
}
        
public
void loadValuesOnHotListView(ListView listView, HotListViewContainer hotListViewContainer, decimal dcumPercent, CapacityView.SORT_TYPE sortType) {
    
    int                     j = 0;
    string                  sweeK = "";
    string                  splantDeptResource = "";    
    HotListViewContainer    hotListViewContainerForMachineOriginal = coreFactory.createHotListViewContainer();    
    HotListViewContainer    hotListViewContainerForMachine = coreFactory.createHotListViewContainer();    
    ArrayList               arrayColumns = CapacityView.getArrayWeeeksByTitle();
    ArrayList               arrayRes = new ArrayList();    
    HotListView             hotListView = null;    
        
    Hashtable               hashRes = new Hashtable();              //get differents resource/reqname per plant/dept
            
    this.hotListViewHdrContainer = coreFactory.createHotListViewHdrContainer();
    
    listView.Items.Clear(); 
    
    if (sortType == CapacityView.SORT_TYPE.REQUIRMENT)
        hotListViewContainer.sortByMachine();
    else
        hotListViewContainer.sortByLocationMachine();        
                       
    //get differents plant/dept/resource 
    arrayRes = hotListViewContainer.getDifferentsPlantDeptResource(out hashRes);
                                            
    for (j=0; j < arrayRes.Count;j++) { //loop on list of differents resource/requirments
        splantDeptResource= (string)arrayRes[j]; //current plant/dept/resource/requirment
            
        HotListView hotListViewAux = (HotListView)hashRes[splantDeptResource];                                                     
        hotListViewContainerForMachineOriginal = hotListViewContainer.getListByMachine(splantDeptResource);
        hotListViewContainerForMachine = coreFactory.createHotListViewContainer();

        for (int k =0; k < arrayColumns.Count; k++){ 
            sweeK= (string)arrayColumns[k];  //current week/title

            hotListView = hotListViewContainerForMachineOriginal.getForMatrixByDeptMachine(sweeK);
            if (hotListView != null){ //found for shift   
                hotListViewContainerForMachine.Add(hotListView);                                                                                 
            }else{                    //not found for shift 
                HotListView hotListViewero = coreFactory.cloneHotListView(hotListViewAux);                
                hotListViewero.WeekTitle = sweeK;
                hotListViewero.Qty = 0;
                hotListViewContainerForMachine.Add(hotListViewero);
            }
        }
        loadMachineInfo(hotListViewAux, hotListViewContainerForMachine); //load machine info            
    }                                                    
    
    //show info processed on screen
    HotListViewHdrContainer hotListViewHdrAuxContainer = this.hotListViewHdrContainer;    
    loadListViewWithContainer(listView, hotListViewHdrAuxContainer, hotListViewContainer);
}  

private
bool loadMachineInfo(HotListView hotListViewSample, HotListViewContainer hotListViewContainer){
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.TYPE_NORMAL;    

    HotListView     hotListView = null;    
    HotListView     hotListViewPastDue = null;
    HotListViewHdr  hotListViewHdr = coreFactory.createHotListViewHdr();
    bool            bprocess = true;
            
    hotListViewHdr.copy(hotListViewSample); //copy main requirment fields and then add to list
    this.hotListViewHdrContainer.Add(hotListViewHdr);

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
          
        for (int j=0; j < hotListViewContainer.Count;j++){ //loop on every shift
            hotListView= hotListViewContainer[j];            

            if (j==0)
                hotListViewPastDue = hotListView;//load past due

            switch (i){
                case 0:
                    hotListView.ShowType = CapacityView.SHOW_TYPE.TYPE_NORMAL;      
                    hotListViewHdr.addToList(coreFactory.cloneHotListView(hotListView));
                    break;              
             }  
        }                
    }
    return true;
}

private
void loadListViewWithContainer(ListView listView,HotListViewHdrContainer hotListViewHdrauxContainer,
                               HotListViewContainer hotListViewContainer){
    HotListViewHdr      hotListViewHdr = null;        
    //bool                bshowTotals = (genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL);

    listView.Items.Clear(); 
           
    for (int i=0; i < hotListViewHdrauxContainer.Count;i++){
        hotListViewHdr = hotListViewHdrauxContainer[i];

        /*
        //if reqtype showed , changed we show summarize first
        if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport) && !sreqTypeForReport.Equals(capacityViewHdr.ReqType))                    
            loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);
        */
                loadRequirmentCell(listView, hotListViewHdr);
    }  

    /*
    //load last summary
    if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport))
        loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);
    */
}  

private
void loadRequirmentCell(ListView listView,HotListViewHdr hotListViewHdr){
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.TYPE_NORMAL;     
    var             rowList = new List<string>();  
    HotListView     hotListView = null;    
    bool            bprocess = true;        
    int             istartShowIndex=0;

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
        rowList = new List<string>();    

        if (i >= istartShowIndex){ //on list view only will be showed depending if All or Percentages            
            //location
            rowList.Add("");
            rowList.Add(hotListViewHdr.PlantDept);
            //splantDeptForReport= capacityViewHdr.PlantDept;
        
            //reqname
            rowList.Add( i== istartShowIndex ? hotListViewHdr.Mach : "");        

            listView.Items.Add(rowList);
        }

        HotListViewContainer hotListViewContainer = hotListViewHdr.getList((CapacityView.SHOW_TYPE)i);

        for (int j=0; j < hotListViewContainer.Count;j++){ //loop on every week
            hotListView= hotListViewContainer[j];
            rowList.Add(hotListView.getCellValue());
        } 
        
       // bprocess = capacityViewHdr.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE);
    }
}


public
bool getFirstDateWithQty(string splant,string[] item,out decimal dqty,out DateTime scheduleDateTime){
    bool            bresult = false;
    dqty = 0;
    scheduleDateTime = DateUtil.MinValue;

    try{
        DateTime    runDate = DateUtil.MinValue;
        int         ipastDueIndex = getPastDueIndex(out runDate,splant) + Constants.INDEX_HOTLIST_START_PASTUE;
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;                
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out priorMonday, out nextSunday);                
        int         idays=0;

        if (runDate > priorMonday)
            priorMonday = runDate;

        for (int i= ipastDueIndex+1; i < (item.Length-2) && scheduleDateTime == DateUtil.MinValue; i++,idays++){
            decimal daux = Convert.ToDecimal(item[i]);
            if (daux < 0){
                dqty = Math.Abs(daux);
                scheduleDateTime = priorMonday.AddDays(idays);
                bresult = true;
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("getFirsDateWithQty Exception: " + ex.Message);        
    }
    return bresult;
}

public
void loadInventoryObjectivesReport(ListView listView,string splant){
    try{ 
        inventoryObjectiveHdr = getCoreFactory().readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdr, splant);
        InventoryObjectivePart          invObjectivePart = null;
        InventoryObjectivePartDtl       invObjectivePartDtl = null;    
        PartReportWeeksViewContainer    partReportWeeksViewContainer = getCoreFactory().createPartReportWeeksViewContainer();
        InventoryObjectiveReportView    inventoryObjectiveReportView = null;
        DateTime                        dateStart = DateTime.Now;
                    
        realodWeeksRanges();   
        if (inventoryObjectiveHdr!= null){
            for (int i=0; i < inventoryObjectiveHdr.InventoryObjectivePartContainer.Count;i++){

                invObjectivePart = inventoryObjectiveHdr.InventoryObjectivePartContainer[i];

                inventoryObjectiveReportView = getCoreFactory().createInventoryObjectiveReportView();
            
                inventoryObjectiveReportView = (InventoryObjectiveReportView)partReportWeeksViewContainer.getByPartSeq(invObjectivePart.Part,invObjectivePart.Seq);

                for (int j=0; j < invObjectivePart.InventoryObjectivePartDtlContainer.Count;j++){

                    invObjectivePartDtl = invObjectivePart.InventoryObjectivePartDtlContainer[j];

                    if (inventoryObjectiveReportView!= null && 
                        invObjectivePartDtl.DateObjective >= dSweek0 && invObjectivePartDtl.DateObjective <= dEweek13){

                        inventoryObjectiveReportView = getCoreFactory().createInventoryObjectiveReportView();
                        inventoryObjectiveReportView.Part= invObjectivePart.Part;
                        inventoryObjectiveReportView.Seq = invObjectivePart.Seq;
                        partReportWeeksViewContainer.Add(inventoryObjectiveReportView);
                    }
        
                    if (invObjectivePartDtl.DateObjective>= dSweek0 && invObjectivePartDtl.DateObjective <= dEweek0){                  
                        inventoryObjectiveReportView.Week0+= invObjectivePartDtl.Qty;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek1 && invObjectivePartDtl.DateObjective <= dEweek1){                    
                        inventoryObjectiveReportView.Week1+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek2 && invObjectivePartDtl.DateObjective <= dEweek2){                    
                        inventoryObjectiveReportView.Week2+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek3 && invObjectivePartDtl.DateObjective <= dEweek3){                    
                        inventoryObjectiveReportView.Week3+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek4 && invObjectivePartDtl.DateObjective <= dEweek4){                    
                        inventoryObjectiveReportView.Week4+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek5 && invObjectivePartDtl.DateObjective <= dEweek5){                    
                        inventoryObjectiveReportView.Week5+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek6 && invObjectivePartDtl.DateObjective <= dEweek6){                    
                        inventoryObjectiveReportView.Week6+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek7 && invObjectivePartDtl.DateObjective <= dEweek7){                    
                        inventoryObjectiveReportView.Week7+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek8 && invObjectivePartDtl.DateObjective <= dEweek8){                    
                        inventoryObjectiveReportView.Week8+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek9 && invObjectivePartDtl.DateObjective <= dEweek9){                    
                        inventoryObjectiveReportView.Week9+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek10 && invObjectivePartDtl.DateObjective <= dEweek10){                    
                        inventoryObjectiveReportView.Week10+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek11 && invObjectivePartDtl.DateObjective <= dEweek11){                    
                        inventoryObjectiveReportView.Week11+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek12 && invObjectivePartDtl.DateObjective <= dEweek12){                    
                        inventoryObjectiveReportView.Week12+= invObjectivePartDtl.Qty;;
                    }else if (invObjectivePartDtl.DateObjective>= dSweek13 && invObjectivePartDtl.DateObjective <= dEweek13){                    
                        inventoryObjectiveReportView.Week13+= invObjectivePartDtl.Qty;;                    
                    }
                }
            }

        }
        setDataContextListView(listView,partReportWeeksViewContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadInventoryObjectivesReport Exception: " + ex.Message);        
    }
}

public 
void startCellSelect(){   
    for (int i=0; i < arrayBoxSelected.Count; i++) {
        HotListCellSel hotListCellSel = (HotListCellSel)arrayBoxSelected[i];
        hotListCellSel.TextBox.Background = new SolidColorBrush(Colors.White);
    }         
    arrayBoxSelected.Clear();                      
}

public
bool addIfCurrCellFocused(){
    bool bresult=false;

    if (this.textBoxLast!= null && textBoxLast.IsFocused){ 
        textBoxGotFocus(textBoxLast);
        bresult=true;
    }        
    return bresult;        
} 

public
HotListCellSel getHotListCellSels(ScheduleHdr scheduleHdr){    
    try {        
        string              spart       = "";
        string              splant      = scheduleHdr!= null ? scheduleHdr.Plant:"";                
        HotListHdr          hotListHdr  = getCoreFactory().readLastHotList(splant);        
        DateTime            runDate     = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
        string              sdept       = "";
        string              smach       = "";
        int                 iseq        = 0;
        decimal             dqty        = 0;        
        HotListCellSel      hotListCellSel = null;
        HotListCellSel      hotListCellSelOriginal = null;
        
        if (arrayBoxSelected.Count > 0){
                                                           
            for (int i=0; i < arrayBoxSelected.Count; i++) {
                hotListCellSel = (HotListCellSel)arrayBoxSelected[i];
                
                if (hotListCellSel.Items != null && hotListCellSel.XIndex < hotListCellSel.Items.Length){                   

                    sdept = hotListCellSel.Items[0];
                    smach = hotListCellSel.Items[2];
                    spart = hotListCellSel.Items[4];
                    iseq  = NumberUtil.isIntegerNumber(hotListCellSel.Items[5]) ? Convert.ToInt32(hotListCellSel.Items[5]) : -1;
                    dqty  = NumberUtil.isDecimalNumber(hotListCellSel.Items[hotListCellSel.XIndex]) ? Convert.ToDecimal(hotListCellSel.Items[hotListCellSel.XIndex]) : 0;

                    if (hotListCellSelOriginal == null){                      
                        hotListCellSelOriginal = new HotListCellSel();
                        hotListCellSelOriginal.Part = spart;
                        hotListCellSelOriginal.Seq  = iseq;
                        hotListCellSelOriginal.Dept = sdept;
                        hotListCellSelOriginal.Mach = smach;
                        hotListCellSelOriginal.XIndex = hotListCellSel.XIndex;
                    }

                    if (hotListCellSel.XIndex < hotListCellSelOriginal.XIndex)
                        hotListCellSelOriginal.XIndex = hotListCellSel.XIndex;

                    if (hotListCellSelOriginal.Part.ToUpper().Equals(spart.ToUpper()) && iseq == hotListCellSelOriginal.Seq &&
                        hotListCellSelOriginal.Dept.ToUpper().Equals(sdept.ToUpper()) && hotListCellSelOriginal.Dept.ToUpper().Equals(sdept.ToUpper())){                          
                        hotListCellSelOriginal.Qty = hotListCellSelOriginal.Qty + System.Math.Abs(dqty);
                    }
                }                                                
            }

            if (hotListCellSelOriginal!= null && hotListHdr!= null) { 
                int days = (hotListCellSelOriginal.XIndex - Constants.INDEX_HOTLIST_START_PASTUE - 1);
                hotListCellSelOriginal.DateTime = runDate.AddDays(days);
            }

            return hotListCellSelOriginal;
                        
        }else
            MessageBox.Show("Please, Select HotList Cell To Schedule.");
                    
    } catch (Exception ex) {
        MessageBox.Show("scheduleHotListNew Exception: " + ex.Message);
    }finally{
        startCellSelect();
    }
    return null;
}  

public
HotListCellSel getHotListCellSelsInventory(ScheduleHdr scheduleHdr,bool bfutureInventoryMode){    
    try {        
        string              spart       = "";
        string              splant      = scheduleHdr!= null ? scheduleHdr.Plant:"";                
        HotListHdr          hotListHdr  = getCoreFactory().readLastHotList(splant);        
        DateTime            runDate     = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
        string              sdept       = "";
        string              smach       = "";
        int                 iseq        = 0;
        decimal             dqty        = 0;        
        HotListCellSel      hotListCellSel = null;
        HotListCellSel      hotListCellSelOriginal = null;
        DateTime            monCurrWeek = DateUtil.getPriorMondayCurrWeek();                        
        
        if (arrayBoxSelected.Count > 0){
                                                           
            for (int i=0; i < arrayBoxSelected.Count; i++) {
                hotListCellSel = (HotListCellSel)arrayBoxSelected[i];
                
                if (hotListCellSel.Items != null && hotListCellSel.XIndex < hotListCellSel.Items.Length){                   

                    spart = hotListCellSel.Items[0];
                    iseq  = NumberUtil.isIntegerNumber(hotListCellSel.Items[1]) ? Convert.ToInt32(hotListCellSel.Items[1]) : -1;                    
                    dqty  = NumberUtil.isDecimalNumber(hotListCellSel.Items[hotListCellSel.XIndex]) ? Convert.ToDecimal(hotListCellSel.Items[hotListCellSel.XIndex]) : 0;

                    if (hotListCellSelOriginal == null){                      
                        hotListCellSelOriginal = new HotListCellSel();
                        hotListCellSelOriginal.Part = spart;
                        hotListCellSelOriginal.Seq  = iseq;                        
                        hotListCellSelOriginal.XIndex = hotListCellSel.XIndex;
                    }

                    if (hotListCellSel.XIndex < hotListCellSelOriginal.XIndex)
                        hotListCellSelOriginal.XIndex = hotListCellSel.XIndex;

                    if (hotListCellSelOriginal.Part.ToUpper().Equals(spart.ToUpper()) && iseq == hotListCellSelOriginal.Seq &&
                        hotListCellSelOriginal.Dept.ToUpper().Equals(sdept.ToUpper()) && hotListCellSelOriginal.Dept.ToUpper().Equals(sdept.ToUpper())){                          
                        hotListCellSelOriginal.Qty = hotListCellSelOriginal.Qty + System.Math.Abs(dqty);
                    }
                }                                                 
            }

            if (hotListCellSelOriginal!= null && hotListHdr!= null) { 
                int days =0;
                if (bfutureInventoryMode) { 
                    days = (hotListCellSelOriginal.XIndex - Constants.INDEX_INVENTORY_FUTURE) * 7;
                    hotListCellSelOriginal.DateTime = monCurrWeek.AddDays(days);
                }else{
                    days = (hotListCellSelOriginal.XIndex - Constants.INDEX_INVENTORY_START_QOH-2); //-2 because start from DateTime.Now -1 Day
                    hotListCellSelOriginal.DateTime = DateTime.Now.AddDays(days);
                }                
            }

            return hotListCellSelOriginal;
                        
        }else
            MessageBox.Show("Please, Select HotList Cell To Schedule.");
                    
    } catch (Exception ex) {
        MessageBox.Show("getHotListCellSelsInventory Exception: " + ex.Message);
    }finally{
        startCellSelect();
    }
    return null;
} 

}
}
