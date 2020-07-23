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
using Nujit.NujitERP.ClassLib.Core.Customer;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using Telerik.Windows.Controls;
using Nujit.NujitWms.WinForms.Util.Controllers;

namespace HotListReports.Windows.Customers{

class CustomerModel : BaseModel2{

private ListView hdrListView;
private ListView customerPartsListView;
private ListView transferListView;
private ListView transferDtlListView;
private ListView transferReleseListView;        
private ListView leadListView;
private ListView shipExportSumListView;

private Person billToPerson;

public CustomerModel(Window window,ListView hdrListView,ListView customerPartsListView,ListView transferListView,ListView transferDtlListView,ListView transferReleseListView, ListView leadListView,ListView shipExportSumListView) : base(window){    

    this.hdrListView            = hdrListView;
    this.customerPartsListView  = customerPartsListView;
    this.transferListView       = transferListView;
    this.transferDtlListView    = transferDtlListView;
    this.leadListView           = leadListView;
    this.transferReleseListView = transferReleseListView;
    this.shipExportSumListView  = shipExportSumListView;

    this.billToPerson= null;
}

public
void loadColumnsOnShipExportSumGrid(ListView listView,bool bcompareDiff){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Order#", "OrderNum", BindingMode.OneWay,60, listView);    
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());            

        textBlockColumnListView = new TextBlockColumnListView("Itm#", "Item", BindingMode.OneWay,15, listView);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ord.Rel", "Release", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plt", "Site", BindingMode.OneWay,15, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());   
                        
        textBlockColumnListView = new TextBlockColumnListView("BillTo", "BillTo", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipTo", "ShipTo", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Shipped", "ShipDate", BindingMode.OneWay,53, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("ShippEx", "ShipDateExcel", BindingMode.OneWay,53, listView);        
            textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());
        }
                
        textBlockColumnListView = new TextBlockColumnListView("ExpShip", "DateRequest", BindingMode.OneWay,45, listView);                                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("ExpShipEx", "ShipDateExcel", BindingMode.OneWay,50, listView);                                
            textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
            gridView.Columns.Add(textBlockColumnListView.process());
        }
    
        textBlockColumnListView = new TextBlockColumnListView("ExpShCum", "DateRequestFromCum", BindingMode.OneWay,45, listView);                                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Changed", "ChangeDate", BindingMode.OneWay,45, listView);                                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Created", "CreateDate", BindingMode.OneWay,45, listView);   //create date                             
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("LT", "LeadTime", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("LTEx", "ActLeadTimeExcel", BindingMode.OneWay,25, listView);           
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
            gridView.Columns.Add(textBlockColumnListView.process());
        }

        textBlockColumnListView = new TextBlockColumnListView("LT2", "LeadTime2", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LT3", "LeadTime3", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());
                                                 
        textBlockColumnListView = new TextBlockColumnListView("Part", "Product", BindingMode.OneWay,90, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                             
        textBlockColumnListView = new TextBlockColumnListView("OT", "OrdType", BindingMode.OneWay,10, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
       
        textBlockColumnListView = new TextBlockColumnListView("QtyOrd", "QtyOrder", BindingMode.OneWay,40, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new QtyShipOrderColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("QtyOrdEx", "QtyOrderedExcel", BindingMode.OneWay,50, listView);  //new      
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());
        }
        
        textBlockColumnListView = new TextBlockColumnListView("QtyShip", "QtyShipped", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new QtyShipOrderColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());       

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("QtyShipEx", "QtyShippedExcel", BindingMode.OneWay,50, listView);  //new      
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());
        }
                
        textBlockColumnListView = new TextBlockColumnListView("QtyBack", "QtyBack", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("QtyBack", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ValueBiggerColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                              
                       
        textBlockColumnListView = new TextBlockColumnListView("CumQty", "CumQty", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyOCum", "QtyOrderedFromCum", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("QtyOnTime", "QtyShippedOnTime", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyLate", "QtyShippedLate", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("MajGrp", "MajGroup", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinGrp", "MinGroup", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MajSales", "MajSales", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinSales", "MinSales", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Cust.PO", "CustPO", BindingMode.OneWay,70, listView);                        
        gridView.Columns.Add(textBlockColumnListView.process());
        

        //textBlockColumnListView = new TextBlockColumnListView("Trad.Partner", "SMTRPT", BindingMode.OneWay,70, listView);                
        //gridView.Columns.Add(textBlockColumnListView.process());

        //textBlockColumnListView = new TextBlockColumnListView("ShipToLoc", "SMSTXL", BindingMode.OneWay,70, listView);                
        //gridView.Columns.Add(textBlockColumnListView.process());
             
        textBlockColumnListView = new TextBlockColumnListView("PPAP", "Ppap", BindingMode.OneWay,30, listView);           
        gridView.Columns.Add(textBlockColumnListView.process());

        if (bcompareDiff) { 
            textBlockColumnListView = new TextBlockColumnListView("PPAPEx", "PPAPExcel", BindingMode.OneWay,40, listView);           
            gridView.Columns.Add(textBlockColumnListView.process());
        }

        textBlockColumnListView = new TextBlockColumnListView("QtyPpm", "QtyPpm", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right); 
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("ActDay", "ActualDays", BindingMode.OneWay,35, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right); 
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Trad.Partner","TradPartner", BindingMode.OneWay,70, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
       
        //textBlockColumnListView = new TextBlockColumnListView("Note", "NoteSub", BindingMode.OneWay,500, listView);           
        //gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Incl","Include", BindingMode.OneWay,30, listView);           
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Approv", "FixManual", BindingMode.OneWay,30, listView);           
        gridView.Columns.Add(textBlockColumnListView.process());
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnTransferGrid Exception: " + ex.Message);        
    }
}

                
public
void loadOrderDocTypeComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Blanket", "B"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Standard","S"));

        setDataContextCombo(comboBox,list);                        

    } catch (Exception ex) {
        MessageBox.Show("loadOrderDocTypeComboBox Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnLeadsGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("MajSales", "MajSalesCode", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinSales", "MinSalesCode", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LeadTime", "LeadTime", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnLeadsGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnShipExportRelGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                            
        textBlockColumnListView = new TextBlockColumnListView("Dtl#","Detail", BindingMode.OneWay,30,listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Release", "Release", BindingMode.OneWay,150, listView);               
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);   
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                  
        gridView.Columns.Add(textBlockColumnListView.process());

                /*
        textBlockColumnListView = new TextBlockColumnListView("ReqShipDate", "RelDate", BindingMode.OneWay,70, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold); 
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                  
        gridView.Columns.Add(textBlockColumnListView.process());*/

        textBlockColumnListView = new TextBlockColumnListView("ReqShipDate", "RelDate", BindingMode.OneWay,70, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");        
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ShipReleaseColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("RelCum", "RelCum", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");        
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ShipReleaseColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());   
        
        
        textBlockColumnListView = new TextBlockColumnListView("RelQty", "RelQty", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ShipReleaseColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());       

        textBlockColumnListView = new TextBlockColumnListView("OurShipCum", "OurShipCum", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OemYtdReq", "OemYtdReq", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OemYtdShip", "OemYtdShip", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());             

        textBlockColumnListView = new TextBlockColumnListView("StCreated", "StDateCreated", BindingMode.OneWay,130, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "DateTime");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ShipReleaseColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());    


        textBlockColumnListView = new TextBlockColumnListView("Trans", "StTranslated", BindingMode.OneWay,30, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TrDate", "StTranslatedDate", BindingMode.OneWay,55, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold); 
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                  
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ran", "Ran", BindingMode.OneWay,80, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("UserId", "UserId", BindingMode.OneWay,80, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnShipExportRelGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnShipExportDtlGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                            
        textBlockColumnListView = new TextBlockColumnListView("Dtl#","Detail", BindingMode.OneWay,30,listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Order#", "OrderNum", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Itm#", "Item", BindingMode.OneWay,15, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ord.Rel", "Release", BindingMode.OneWay,80, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TimeStamp", "TimeStamp", BindingMode.OneWay,180, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Act", "Action", BindingMode.OneWay,20, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ActDesc", "ActionDesc", BindingMode.OneWay,50, listView);                
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("ReqShipDate", "RelDate", BindingMode.OneWay,70, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");        
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("RelQty", "RelQtyInvUnit", BindingMode.OneWay,40, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);   
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                          
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyShip", "QtyShippedInv", BindingMode.OneWay,40, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);   
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                          
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyBack", "QtyBackInv", BindingMode.OneWay,40, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                        
        gridView.Columns.Add(textBlockColumnListView.process());
                /*
        textBlockColumnListView = new TextBlockColumnListView("QtyChang", "QtyChange", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);   
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
       
        textBlockColumnListView = new TextBlockColumnListView("DateChang", "DateChange", BindingMode.OneWay,55, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold); 
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                  
        gridView.Columns.Add(textBlockColumnListView.process());*/

        textBlockColumnListView = new TextBlockColumnListView("ShipDate", "ShipDate", BindingMode.OneWay,55, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold); 
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                  
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ExpShip", "DateRequest", BindingMode.OneWay,55, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);                   
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DaysChang","DaysShipChanged", BindingMode.OneWay,60, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                        
        gridView.Columns.Add(textBlockColumnListView.process());
   
        textBlockColumnListView = new TextBlockColumnListView("Ran", "Ran", BindingMode.OneWay,90, listView);                        
        gridView.Columns.Add(textBlockColumnListView.process());
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnShipExportDtlGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay,70,hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Name", "Name", BindingMode.OneWay,250, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Typ", "CustomerType", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Sts", "Status", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Address 1", "Address1", BindingMode.OneWay,200, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Address 2", "Address2", BindingMode.OneWay,150, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StProv", "State_Prov", BindingMode.OneWay, 30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Terr", "Territory", BindingMode.OneWay,30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ZipCode", "ZipCode", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Curr", "Currency", BindingMode.OneWay, 30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Phone", "Phone", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("BillToCust", "BillToCust", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Class", "PersonClass", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnTransferGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                             
        textBlockColumnListView = new TextBlockColumnListView("BOL#", "FGBOL", BindingMode.OneWay,60,listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lin#", "FGENT", BindingMode.OneWay,15, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plt", "FEPLTC", BindingMode.OneWay,15, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());        
        
        textBlockColumnListView = new TextBlockColumnListView("BillTo", "FEBCS", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipTo", "FESCS", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shipped", "FESDAT", BindingMode.OneWay,53, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("ExpShip", "UPEXSD", BindingMode.OneWay,45, listView);                                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CustDate", "CustDate", BindingMode.OneWay,45, listView);                                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Created", "FirstDate", BindingMode.OneWay,45, listView);   //create date                             
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OrderDate", "FirstDate", BindingMode.OneWay,45, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Posted", "FEFUTRShow", BindingMode.OneWay,45, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Late", "DayLate", BindingMode.OneWay,15, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("DayLate", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new DayLateColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Bold);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LT", "LeadTime", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LT2", "LeadTime2", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LT3", "LeadTime3", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CLT", "BVSLT", BindingMode.OneWay,15, listView);           
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                                     
        gridView.Columns.Add(textBlockColumnListView.process());
                                                 
        textBlockColumnListView = new TextBlockColumnListView("Part", "FGPART", BindingMode.OneWay,90, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.ExtraBold);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                       
        textBlockColumnListView = new TextBlockColumnListView("Order#", "FGORD", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Itm#", "FGITEM", BindingMode.OneWay,15, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ord.Rel", "FGRLNO", BindingMode.OneWay,60, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OT", "DCOTYP", BindingMode.OneWay,10, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
       
        textBlockColumnListView = new TextBlockColumnListView("QtyOrd", "QtyOrder", BindingMode.OneWay,40, listView);  //new      
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new QtyShipOrderColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                /*
        textBlockColumnListView = new TextBlockColumnListView("DFQTOO", "DFQTOO", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());     */           

        textBlockColumnListView = new TextBlockColumnListView("QtyShip", "FGQSHP", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("Object", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new QtyShipOrderColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());       
                
        textBlockColumnListView = new TextBlockColumnListView("QtyBack", "QtyBack", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("QtyBack", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ValueBiggerColorConverter(), "");
        textBlockColumnListView.process();        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                              
       
        checkColumnListView = new CheckColumnListView("Incl", "Included", BindingMode.TwoWay,20, listView);        
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");        
        checkColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(checkColumnListView.process());        

        checkColumnListView = new CheckColumnListView("Exp", "ExportShow", BindingMode.TwoWay,15, listView);        
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");        
        checkColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(checkColumnListView.process());             

        textBlockColumnListView = new TextBlockColumnListView("LTBkDate", "LTBookDate", BindingMode.OneWay,45, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LTBkQty", "LTBookQty", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
                /*
        textBlockColumnListView = new TextBlockColumnListView("ExpecQty", "DDQTBI", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  */     

        textBlockColumnListView = new TextBlockColumnListView("Ran", "FGRAN", BindingMode.OneWay,70, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EdiRelease", "FGCREL", BindingMode.OneWay,80, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("CumQty", "FGCCUM", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PreCumQty", "FGPCUM", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MajGrp", "AVMAJG", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinGrp", "AVMING", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MajSales", "AVMAJS", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinSales", "AVMINS", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("GLSales", "AVGLCD", BindingMode.OneWay,40, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("GLExp", "AVGLED", BindingMode.OneWay,40, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Cust.PO", "FGCPO", BindingMode.OneWay,70, listView);                        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Cust Part", "FGCPT", BindingMode.OneWay,100, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("CClass", "BVCLAS", BindingMode.OneWay,40, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("Trad.Partner", "SMTRPT", BindingMode.OneWay,70, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipToLoc", "SMSTXL", BindingMode.OneWay,70, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
    
                /*
        textBlockColumnListView = new TextBlockColumnListView("TRLPKey", "SMCKEY", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "SMRDAT", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TPartner", "SPTRPT", BindingMode.OneWay,70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumReq", "SPOEMC", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumShip", "SPOEMS", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumDisc", "SPOEMD", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        textBlockColumnListView = new TextBlockColumnListView("PyDate", "PYDATE", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("CumQty", "JITCUM", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumReq", "OZOEMC", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumShip", "OZOEMS", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CumDisc", "OZCUMD", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "PLRDAT", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());
             
        textBlockColumnListView = new TextBlockColumnListView("CumQty", "RRLCUM", BindingMode.OneWay,40, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        
        textBlockColumnListView = new TextBlockColumnListView("OTSt", "UPOTST", BindingMode.OneWay,40, listView);                        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QSt", "UPQTST", BindingMode.OneWay,40, listView);                        
        gridView.Columns.Add(textBlockColumnListView.process());            

        textBlockColumnListView = new TextBlockColumnListView("CustGrp", "CustGroup", BindingMode.OneWay,50, listView);   
        gridView.Columns.Add(textBlockColumnListView.process());
        */                       

        textBlockColumnListView = new TextBlockColumnListView("FirstQty", "FirstQty", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right); 
        gridView.Columns.Add(textBlockColumnListView.process());
       
        textBlockColumnListView = new TextBlockColumnListView("ExpDate", "ExportDateShow", BindingMode.OneWay,45, listView);   
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "Date2");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PPAP", "Ppap", BindingMode.OneWay,30, listView);           
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelBase", "ReleaseBase", BindingMode.OneWay,60, listView);           
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyOrdBase", "QtyOrdBase", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right); 
        gridView.Columns.Add(textBlockColumnListView.process());
                                                  
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnTransferGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnCustomerPartsGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Part", "ProdID", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("BillTo", "BillToCust", BindingMode.OneWay,70, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipTo", "ShipToCust", BindingMode.OneWay,70, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Customer Part", "CustPart", BindingMode.OneWay,120, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LeadTime", "LeadTime", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("WklyQtyComm", "WeeklyQtyCommit", BindingMode.OneWay,70, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());	

        textBlockColumnListView = new TextBlockColumnListView("Customer Part Desc 1", "CustPartDes1", BindingMode.OneWay,180, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StdPckQty", "StdPackQty", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
    
        textBlockColumnListView = new TextBlockColumnListView("StdPckUnit", "StdPackUnit", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StdPckCont", "StdPackCont", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PckSkidCode", "StdPackSkidCode", BindingMode.OneWay,70, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PckSkidQty", "StdPackSkidQty", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PckSkidUom", "StdPackSkidUom", BindingMode.OneWay,70, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                  
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnCustomerPartsGrid Exception: " + ex.Message);        
    }
}


/*
public
Employee loadEmployee(ListView listView, ListView shiftlistView,TabControl mainTabControl){
    employee = null;
    try{ 
        Employee                employeeAux = (Employee)getSelected(listView);       
        TabItem                 viewTabItem= (TabItem)mainTabControl.Items[0];
        TabItem                 dtlTabItem = (TabItem)mainTabControl.Items[1];

        if (employeeAux!= null)
            employee = getCoreFactory().readEmployee(employeeAux.Id,true);  //read employee and full childs

        if (employee != null){       
            dtlTabItem.DataContext = null;                    
            dtlTabItem.DataContext = employee;

            loadEmployeeShift();            
            loadLabours();            

            int imachId= employee.DftMachId;
            loadMachinesFromDept(employee.DftDept);
            employee.DftMachId = imachId;

        }else{
            mainTabControl.SelectedItem = viewTabItem;
            MessageBox.Show("Please, Select Employee First.");
        }            

    } catch (Exception ex) {
        MessageBox.Show("loadEmployee Exception: " + ex.Message);        
    }
    return employee;
}*/

            /*
public
bool save(){
    bool bresult=false;
    try { 
        if (employee!= null){
            reloadLabours(); //check labours selected

            if (getCoreFactory().existsEmployee(employee.Id))
                getCoreFactory().updateEmployee(employee);
            else
                getCoreFactory().writeEmployee(employee);

            bresult=true;
        }
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }    
    return bresult;
}
*/

public
bool loadCustomerParts(TabItem tabItem){
    bool bresult= false;

    try { 
        Person              person              = (Person)getSelected(hdrListView);
        CustPartsContainer  custPartsContainer  = getCoreFactory().createCustPartsContainer();

        tabItem.DataContext = null;
        tabItem.DataContext = person;

        if (person!= null) { 
            string sbillTo = person.CustomerType.Equals(Person.CUSTOMER_TYPE_BILLTO) ? person.Id : "";
            string shipTo  = person.CustomerType.Equals(Person.CUSTOMER_TYPE_SHIPTO) ? person.Id : "";

            custPartsContainer = getCoreFactory().readCustPartByFilters("",sbillTo,shipTo,"",0);
            bresult= true;
        }else
            MessageBox.Show("Please, Select Customer First.");

        setDataContextListView(customerPartsListView,custPartsContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadCustomerParts Exception: " + ex.Message);        
    }    
    return bresult;
}
    
    
public
ShipExportContainer exportAll(){    
    ShipExportContainer shipExportContainer = getCoreFactory().createShipExportContainer();

    try { 
        UpCum01PViewContainer upCum01PViewContainer = (UpCum01PViewContainer)transferListView.DataContext;
        shipExportContainer = export(upCum01PViewContainer);       

    } catch (Exception ex) {
        MessageBox.Show("exportAll Exception: " + ex.Message);        
    }    
    return shipExportContainer;
}

public
ShipExportContainer reprocessSumAll(){    
    ShipExportSumContainer  shipExportSumContainer  = getCoreFactory().createShipExportSumContainer();
    ShipExportContainer     shipExportContainer     = getCoreFactory().createShipExportContainer();

    try { 
        shipExportSumContainer = (ShipExportSumContainer)shipExportSumListView.DataContext;
        if (shipExportSumContainer!= null)
            shipExportContainer = reprocessSum(shipExportSumContainer);
        
    } catch (Exception ex) {
        MessageBox.Show("reprocessSumAll Exception: " + ex.Message);        
    }    
    return shipExportContainer;
}

public
ShipExportContainer exportSel(){    
    ShipExportContainer shipExportContainer = getCoreFactory().createShipExportContainer();

    try { 
        UpCum01PViewContainer   upCum01PViewContainer       = (UpCum01PViewContainer)transferListView.DataContext;
        UpCum01PViewContainer   upCum01PViewContainerInclude= upCum01PViewContainer != null? getTransferInclude(upCum01PViewContainer) : 
                                                                                getCoreFactory().createUpCum01PViewContainer();
                
        shipExportContainer = export(upCum01PViewContainerInclude);
        
    } catch (Exception ex) {
        MessageBox.Show("exportSel Exception: " + ex.Message);        
    }    
    return shipExportContainer;
}

public
ShipExportContainer reprocessSumSel(){    
    ShipExportSumContainer  shipExportSumContainer  = getCoreFactory().createShipExportSumContainer();
    ShipExportContainer     shipExportContainer     = getCoreFactory().createShipExportContainer();

    try { 
        ArrayList   arraySels = getSelecteds(shipExportSumListView);

        foreach(ShipExportSum shipExportSum in arraySels)
            shipExportSumContainer.Add(shipExportSum);

        shipExportContainer = reprocessSum(shipExportSumContainer);
        
    } catch (Exception ex) {
        MessageBox.Show("reprocessSumSel Exception: " + ex.Message);        
    }    
    return shipExportContainer;
}

public
UpCum01PViewContainer getTransferInclude(UpCum01PViewContainer   upCum01PViewContainer){
    UpCum01PViewContainer upCum01PViewContainerInclude = getCoreFactory().createUpCum01PViewContainer(); 
    try {         

        foreach(UpCum01PView upCum01PView in upCum01PViewContainer) {
            if (upCum01PView.Included.Equals(Constants.STRING_YES))
                upCum01PViewContainerInclude.Add(upCum01PView);
        }        

    } catch (Exception ex) {
        MessageBox.Show("getTransferInclude Exception: " + ex.Message);        
    }    
    return upCum01PViewContainerInclude;
}

public
ShipExportContainer export(UpCum01PViewContainer upCum01PViewContainer){    
    ShipExportContainer shipExportContainer = getCoreFactory().createShipExportContainer();

    try { 
        
        if (upCum01PViewContainer!= null && upCum01PViewContainer.Count > 0) { 
            cursorWait();
            freeMemory();
            shipExportContainer = getCoreFactory().bolsShipExport(upCum01PViewContainer);

            cursorNormal();
            MessageBox.Show("Total Records Exported :" + shipExportContainer.Count);
        }else{
            MessageBox.Show("No Items To Export,Plese Select Items.");
        }
        

    } catch (Exception ex) {
        MessageBox.Show("export Exception: " + ex.Message);        
    } finally{
        cursorNormal();
    }
    return shipExportContainer;
}

public
ShipExportContainer reprocessSum(ShipExportSumContainer shipExportSumContainer){    
    ShipExportContainer shipExportContainer = getCoreFactory().createShipExportContainer();

    try { 
        
        if (shipExportSumContainer != null && shipExportSumContainer.Count > 0) { 
            cursorWait();
            freeMemory();
            shipExportContainer = getCoreFactory().reprocessShipExportSum(shipExportSumContainer);

            cursorNormal();
            MessageBox.Show("Total Records Exported :" + shipExportContainer.Count);
        }else{
            MessageBox.Show("No Items To Export,Plese Select Items.");
        }
        

    } catch (Exception ex) {
        MessageBox.Show("export Exception: " + ex.Message);        
    } finally{
        cursorNormal();
    }
    return shipExportContainer;
}


public
void loadCustPartValues(UpCum01PViewContainer upCum01PViewContainer){        
    try { 
        CustParts           custParts = null;        
        CustPartsContainer  custPartsContainer = getCoreFactory().createCustPartsContainer(); 
        CustPartsContainer  custPartsContainerAux = getCoreFactory().createCustPartsContainer();                         
        UpCum01PView        upCum01PView = null;
        
        for (int i=0; i < upCum01PViewContainer.Count; i++) {
            upCum01PView = upCum01PViewContainer[i];
                     
            custParts = custPartsContainer.getByKeyOneOfCustomer(upCum01PView.FGPART,upCum01PView.FEBCS,upCum01PView.FESCS);        
            if (custParts == null){
                custPartsContainerAux = getCoreFactory().readCustPartByFilters(upCum01PView.FGPART,"","", upCum01PView.FGCPT,0);

                custParts = custPartsContainerAux.getByKeyOneOfCustomer(upCum01PView.FGPART,upCum01PView.FEBCS,upCum01PView.FESCS);        
                if (custParts!= null)
                    custPartsContainer.Add(custParts);
            }

            if (custParts!=null)
                upCum01PView.LeadTime = custParts.LeadTime;
        }

    } catch (Exception ex) {
        MessageBox.Show("loadCustPartValues Exception: " + ex.Message);        
    } finally{
        cursorNormal();
    }    
}

public
void loadLeadsForCustomTransfer(UpCum01PViewContainer upCum01PViewContainer){        
    try { 
        CustLead            custLead            = null;        
        CustLeadContainer   custLeadContainer   = getCoreFactory().createCustLeadContainer();         
        UpCum01PView        upCum01PView        = null;
        Hashtable           hashLeads           = new Hashtable();
        string              skey                = "";
        
        for (int i=0; i < upCum01PViewContainer.Count; i++) {
            upCum01PView = upCum01PViewContainer[i];
            //upCum01PView.AVMAJS = "TIN";

            custLead=null;
            skey = upCum01PView.FEBCS.ToUpper() + Constants.DEFAULT_SEP + upCum01PView.AVMAJS.ToUpper() + Constants.DEFAULT_SEP + upCum01PView.AVMINS.ToUpper();
            if (hashLeads.Contains(skey))       //check if lead already loaded
                custLead =  (CustLead)hashLeads[skey];
                        
            if (custLead==null){ //search on table
                custLeadContainer = getCoreFactory().readCustLeadByCustomerFilters(upCum01PView.FEBCS,upCum01PView.AVMAJS);
                custLead = custLeadContainer.getByKey(upCum01PView.FEBCS,upCum01PView.AVMAJS, upCum01PView.AVMINS);//search for exactly
                
                if (custLead == null && custLeadContainer.Count > 0)
                    custLead = custLeadContainer[0];
                
                if (custLead!= null)//add to list already found
                    hashLeads.Add(skey,custLead);
            }

            upCum01PView.LTBookDate = upCum01PView.UPEXSD;
            if (custLead!= null) { 
                upCum01PView.LeadTime   = custLead.LeadTime;                            
                upCum01PView.LTBookDate = upCum01PView.UPEXSD.AddDays(upCum01PView.LeadTime*-1);
                upCum01PView.LTBookQty  = upCum01PView.QtyOrder;
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("loadLeadsForCustomTransfer Exception: " + ex.Message);        
    } finally{
        cursorNormal();
    }    
}

public
void loadLeads(Person person,CustLead custLeadToBeSelected=null){
    try { 
        cursorWait();
        this.billToPerson = null;

        CustLeadContainer   custLeadContainer = getCoreFactory().createCustLeadContainer();        
        Person              personBill = person; 
        
        if (person!= null) { 
            bool isBillTo = personBill.RecType.Equals(Person.TYPE_CUSTOMER) && personBill.CustomerType.Equals(Person.CUSTOMER_TYPE_BILLTO);            
            if (!isBillTo){
                personBill = getCoreFactory().readPerson(person.getPlt(),person.BillToCust);                
            }

            if (personBill!= null) {
                this.billToPerson = personBill;
                custLeadContainer =  getCoreFactory().readCustLeadByFilters(personBill.Id,Constants.STRING_YES,"","",0);//exact Id because could be geenic and we might search for CustId=''
            }else{
                MessageBox.Show("Sorry, Can Not Find BillTo Customer.");                
            }
        }
        setDataContextListView(leadListView,custLeadContainer);       
        setSelected(leadListView,custLeadToBeSelected);

    } catch (Exception ex) {
        MessageBox.Show("loadLeads Exception: " + ex.Message);        
    } finally{
        cursorNormal();
    }                
}

public 
void addLead() {
    try{ 
        if (billToPerson != null) { 
            CustLead custLead = getCoreFactory().createCustLead();
            custLead.CustId = billToPerson.Id;

            CustLeadWindow custLeadWindow = new CustLeadWindow(billToPerson, custLead);
            custLeadWindow.ShowDialog();

            loadLeads(billToPerson,custLead);
        }           

    } catch (Exception ex) {
        MessageBox.Show("addLead Exception: " + ex.Message);        
    }           
}

public 
void modifyLead() {
    try{         
        CustLead custLead =(CustLead)getSelected(leadListView);            
        if (custLead!= null) { 
            CustLeadWindow custLeadWindow = new CustLeadWindow(billToPerson, custLead);
            custLeadWindow.ShowDialog();

            loadLeads(billToPerson,custLead);
        }
                   
    } catch (Exception ex) {
        MessageBox.Show("modifyLead Exception: " + ex.Message);        
    }           
}

public 
bool loadGenericCustomerLeads(){   
    bool bresult=false;
    try{
        Person person       = getCoreFactory().createPerson();
        person.RecType      = Person.TYPE_CUSTOMER;
        person.CustomerType = Person.CUSTOMER_TYPE_BILLTO;
        person.Name         = "Generic Lead Time";

        PersonContainer personContainer = (PersonContainer)hdrListView.DataContext;
        personContainer.Add(person);
        setSelected(hdrListView,person);        
        bresult=true;

    } catch (Exception ex) {
        MessageBox.Show("loadGenericCustomerLeads Exception: " + ex.Message);        
    } 
    return bresult;
}

public 
void delLead() {
    try{         
        CustLead custLead =(CustLead)deleltedSelected(leadListView);            
        if (custLead != null) { 
            getCoreFactory().deleteCustLead(custLead.CustId, custLead.MajSalesCode, custLead.MinSalesCode);                    
            loadLeads(billToPerson);
        }
                   
    } catch (Exception ex) {
        MessageBox.Show("delLead Exception: " + ex.Message);        
    }           
}



public 
void transferIncludeSel(string sincludeFlag) {
    try{         
        ArrayList       arraySelecteds  = getSelecteds(transferListView);
        UpCum01PView    upCum01PView    = null;

        for (int i=0; i < arraySelecteds.Count; i++) { 
            upCum01PView            = (UpCum01PView)arraySelecteds[i];
            upCum01PView.Included   = sincludeFlag;
        }

    } catch (Exception ex) {
        MessageBox.Show("transferIncludeSel Exception: " + ex.Message);        
    }           
}  

public 
void loadShipExportDtl() {
    try{                 
        UpCum01PView            upCum01PView            = (UpCum01PView)getSelected(transferListView);
        UpCum01PViewContainer   upCum01PViewContainer   = getCoreFactory().createUpCum01PViewContainer();
        ShipExportDtlContainer  shipExportDtlContainer  = getCoreFactory().createShipExportDtlContainer();

        if (upCum01PView!= null) { 
            upCum01PViewContainer.Add(upCum01PView);
            if (upCum01PView.ShipExportDtlContainer.Count <= 0)
                getCoreFactory().loadShipExportDtlsFromAS400(upCum01PViewContainer);//load OCRIT/OCRRT from AS400 side
            
            foreach(ShipExportDtl shipExportDtl in upCum01PView.ShipExportDtlContainer) //loading same inf , so then we can change order decreased by timestamp
                shipExportDtlContainer.Add(shipExportDtl);
            shipExportDtlContainer.sortByOrderItemTimeStamp(false);
        }
        setDataContextListView(transferDtlListView,shipExportDtlContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadShipExportDtl Exception: " + ex.Message);        
    }           
}  

public 
void loadShipExportRel() {
    try{                 
        cursorWait();
        UpCum01PView                upCum01PView                = (UpCum01PView)getSelected(transferListView);        
        UpCum01PViewContainer       upCum01PViewContainer       = getCoreFactory().createUpCum01PViewContainer();
        ShipExportReleaseContainer  shipExportReleaseContainer  = getCoreFactory().createShipExportReleaseContainer();
        ShipExportDtlContainer      shipExportDtlContainer      = getCoreFactory().createShipExportDtlContainer();

        if (upCum01PView != null) { 
            upCum01PViewContainer.Add(upCum01PView);
            if (upCum01PView.ShipExportReleaseContainer.Count <=0)               
               getCoreFactory().loadShipExportDtlsFromAS400(upCum01PViewContainer);
            
            foreach(ShipExportRelease shipExportRelease in upCum01PView.ShipExportReleaseContainer) //loading same inf , so then we can change order decreased by timestamp
                shipExportReleaseContainer.Add(shipExportRelease);    
            
            foreach(ShipExportDtl shipExportDtl in upCum01PView.ShipExportDtlContainer) //loading same inf , so then we can change order decreased by timestamp
                shipExportDtlContainer.Add(shipExportDtl); 
            shipExportDtlContainer.sortByOrderItemTimeStamp(false);                   
        }
        setDataContextListView(transferReleseListView,shipExportReleaseContainer);
        setDataContextListView(transferDtlListView, shipExportDtlContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadShipExportRel Exception: " + ex.Message);        
    }finally{
        cursorNormal();
    }                           
} 

public
string getShipExportMode(UpCum01PView upCum01PView){
    string sflagShipExportMode = ShipExport.EXPORT_ORDER;
    try{            
        string              stpartner = "";
        TradingPartner      tradingPartner = null;

        if (upCum01PView != null) { 
            stpartner = upCum01PView.SMTRPT;

            if (string.IsNullOrEmpty(stpartner)){
                //try to get trading partner from customer
                Person person = getCoreFactory().readPerson(upCum01PView.FEPLTC,upCum01PView.FEBCS);
                if (person!= null) 
                    stpartner = person.TPartner;
                else{
                    person = getCoreFactory().readPerson("",upCum01PView.FEBCS);
                    stpartner = person != null ? person.TPartner : "";
                }

                if (string.IsNullOrEmpty(stpartner)){
                    person = getCoreFactory().readPerson(upCum01PView.FEPLTC, upCum01PView.FESCS);
                    if (person!= null)
                        stpartner = person.TPartner;
                    else{
                        person = getCoreFactory().readPerson("",upCum01PView.FEBCS);
                        stpartner = person != null ? person.TPartner : "";
                    }
                }               
            }    
            
            if (!string.IsNullOrEmpty(stpartner)){
                tradingPartner = getCoreFactory().readTradingPartner(stpartner);
                if (tradingPartner!= null)
                    sflagShipExportMode = tradingPartner.ExportMode;
            }                
        }
        
    } catch (Exception ex) {
        MessageBox.Show("getShipExportMode Exception: " + ex.Message);        
    }   
    return sflagShipExportMode;
} 

public 
void adjustLeadTime2( Person  person){
    try {         
        string  sbillTo = person!= null && person.CustomerType.Equals(Person.CUSTOMER_TYPE_BILLTO) ? person.Id : "";
        
        adjustLeadTime(sbillTo);

    } catch (Exception ex) {
        MessageBox.Show("adjustLeadTime2 Exception: " + ex.Message);        
    }
}

public 
void adjustLeadTime(bool bshipExport){
    try { 
        UpCum01PView    upCum01PView= !bshipExport ? (UpCum01PView) getSelected(transferListView) : null;        
        ShipExportSum   shipExportSum= bshipExport ? (ShipExportSum)getSelected(shipExportSumListView) : null; 
        string          sbillTo     =  "";
        string          smajSales   =  "";
        string          sminSales   = "";

        if (upCum01PView!= null) { 
            sbillTo   = upCum01PView.FEBCS;
            smajSales = upCum01PView.AVMAJS;
            sminSales = upCum01PView.AVMINS;                    
        }
        if (shipExportSum != null) { 
            sbillTo   = shipExportSum.BillTo;
            smajSales = shipExportSum.MajSales;
            sminSales = shipExportSum.MinSales;
        }

        adjustLeadTime(sbillTo,smajSales,sminSales);

    } catch (Exception ex) {
        MessageBox.Show("adjustLeadTime Exception: " + ex.Message);        
    }
}

public 
void adjustLeadTime(string sbillTo,string smajSales="",string sminSales=""){
    try { 
        CustLeadAdjustWindow window = new CustLeadAdjustWindow(sbillTo, smajSales,sminSales);
        window.ShowDialog();
    } catch (Exception ex) {
        MessageBox.Show("adjustLeadTime Exception: " + ex.Message);        
    }
}

public 
void editSum(){
    try { 
        ShipExportSum   shipExportSum = (ShipExportSum)getSelected(shipExportSumListView);

        if (shipExportSum!= null) { 
            editSumGeneric(shipExportSum);
        }

    } catch (Exception ex) {
        MessageBox.Show("editSum Exception: " + ex.Message);        
    }
}

public 
void editSumGeneric(ShipExportSum   shipExportSum){
    try {         
        if (shipExportSum!= null) { 
            CustomerShipNoteWindow window = new CustomerShipNoteWindow(shipExportSum);
            window.ShowDialog();

            shipExportSum = getCoreFactory().readShipExportSum(shipExportSum.OrderNum, shipExportSum.Item, shipExportSum.Release);
        }else
            MessageBox.Show("Sorry, Can Not Found Ship Export Sum.");

    } catch (Exception ex) {
        MessageBox.Show("editSumGeneric Exception: " + ex.Message);        
    }
}

public 
void editSumUpCum01P(){
    try { 
        UpCum01PView    upCum01PView = (UpCum01PView)getSelected(transferListView);   
        ShipExportSum   shipExportSum= null;

        if (upCum01PView != null) { 
            shipExportSum = getCoreFactory().readShipExportSum(upCum01PView.FGORD, upCum01PView.FGITEM, upCum01PView.ReleaseBase);
            editSumGeneric(shipExportSum);            
        }

    } catch (Exception ex) {
        MessageBox.Show("editSumUpCum01P Exception: " + ex.Message);        
    }
}



}
}
