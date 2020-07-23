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
using HotListReports.Windows.Inventories;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Products{

class ProductModel : BaseModel2{

public ProductModel(Window window) : base(window){    
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    searchByComboBox.Items.Add("Code");
    searchByComboBox.Items.Add("Des1");
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Code", "ProdID", BindingMode.OneWay,150, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1", "Des1", BindingMode.OneWay,200, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 2", "Des2", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("F/P", "FamProd", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PTyp", "PartType", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("InvSts", "InvStatus", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("AvgPull", "VirtKanManDem", BindingMode.OneWay,30, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MinQty", "MinQty", BindingMode.OneWay,35, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("MinQty", "MinQty", BindingMode.OneWay,35, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MaGrp", "MajorGroup", BindingMode.OneWay,30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MiGrp", "MinorGroup", BindingMode.OneWay,30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("LastRevision", "LastRevision", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());
                    
        textBlockColumnListView = new TextBlockColumnListView("StdPck", "StdPackSize", BindingMode.OneWay,30, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Uom", "StdPackUnit", BindingMode.OneWay, 30, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("GLExp", "GLExp", BindingMode.OneWay, 30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MaSale", "MajorSales", BindingMode.OneWay, 30, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MiSale", "MinorSales", BindingMode.OneWay, 30, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RtlPr", "RetailProductType", BindingMode.OneWay, 30, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ProdCod", "ProdCode", BindingMode.OneWay, 35, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qoh","Qoh", BindingMode.OneWay,40,hdrListView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MatPlan", "MatPlannedShow", BindingMode.OneWay,30, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DayOHand", "DaysOnHand", BindingMode.OneWay,45, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ObjAutCalc", "ObectivesAutomaticCalc", BindingMode.OneWay,50, hdrListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DemLowQty", "DemandLowQtySplit", BindingMode.OneWay,55, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
      
                
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnDetailsGrid(ListView dtlListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,40, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay, 80, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("IsFam", "IsFamily", BindingMode.OneWay,50, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,40, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay, 65, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay, 65, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

                                                
        dtlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailsGrid Exception: " + ex.Message);        
    }
}

public 
void add(out ScheduleHdr scheduleHdr){    
    scheduleHdr = coreFactory.createScheduleHdr();        
    try{            
       
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

public
Product loadPart(ListView listView,TabControl mainTabControl,TextBox textBox){
    Product product = null;
    try{ 
        Product productSel = (Product)getSelected(listView);       
        TabItem viewTabItem= (TabItem)mainTabControl.Items[0];
        TabItem dtlTabItem = (TabItem)mainTabControl.Items[1];
                        
        if (productSel != null){
            product = getCoreFactory().readProduct(productSel.ProdID);
        
            if (product != null){
                dtlTabItem.DataContext = null;                    
                dtlTabItem.DataContext = product;
                textBox.Focus();
            }else{
                mainTabControl.SelectedItem = viewTabItem;
                MessageBox.Show("Sorry, Can Not Find Part :" + productSel.ProdID + ".");
            }
        }else{
            mainTabControl.SelectedItem = viewTabItem;
            MessageBox.Show("Please, Select Item Part First.");
        }            

    } catch (Exception ex) {
        MessageBox.Show("loadPart Exception: " + ex.Message);        
    }
    return product;
}

public
void routings(Product product){
    try{
        if (product != null){
            RoutingWindow routingWindow = new RoutingWindow(false,Configuration.DftPlant,null,product);
            routingWindow.ShowDialog();                            
        }else
            MessageBox.Show("Please, Select Item First.");                     
    }catch (Exception ex){
        MessageBox.Show("routings Exception: " + ex.Message);
    } 
}

public
bool processShMaterial(ListView listView){
    bool bresult=false;
    try{
        ProductContainer    productContainer= (ProductContainer)listView.DataContext;
        Product             product         = (Product)getSelected(listView);
        bool                bprocessAgain   = false;

        if (product != null){            
            HotListHdr          hotListHdr          = getCoreFactory().readLastHotList(Configuration.DftPlant);        
            HotListContainer    hotListContainer    = null;
            HotList             hotList             = null;
            Machine             machine             = null;
            int                 index               = productContainer.IndexOf(product);

            do { 
                bprocessAgain   = false;
                if (hotListHdr!= null && product!=null) { 
                    //Bom  bom    =  getCoreFactory().makeBom(hotListSelected.ProdID,hotListSelected.Seq, hotListHdr.Plant);if (bom!=null && bom.getBomContainer().Count > 0) { 
                    BomSumContainer matBomSumContainer = getCoreFactory().getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(product.ProdID, product.SeqLast, hotListHdr.Plant,Constants.STRING_YES,1);

                    if (matBomSumContainer.Count > 0) { 

                        hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr.Id,"","","","",0, product.ProdID, product.SeqLast,"","",false,false,0);

                        if (hotListContainer.Count > 0) { 
                            hotList = hotListContainer[0];
                            HotListDayContainer hotDayContainer = hotList.getQtyDatesNonZero(hotListHdr.HotlistRunDate);

                            if (hotDayContainer.Count > 0) { 
                                HotListDay hotListDay = hotDayContainer.getByDate(DateTime.Now);
                                        /*
                                if (hotListDay == null)
                                    hotListDay = hotDayContainer.getBiggerThanDate(DateTime.Now);
                                */  

                                if (hotListDay == null) { 
                                    hotListDay = getCoreFactory().createHotListDay();
                                    hotListDay.DateTime = DateTime.Now;
                                    hotListDay.Qty      =0;
                                }
                                machine  = getCoreFactory().readMachine(hotListHdr.Plant,hotList.Dept,hotList.Mach);

                                SchMaterialAvailWindow schMaterialAvailWindow = new SchMaterialAvailWindow(hotListHdr, hotList.IdAut, hotList.ProdID, hotList.Seq, hotListDay.DateTime, hotListDay.Qty, machine!= null? machine.Id:0);
                                schMaterialAvailWindow.setMaterials(matBomSumContainer);
                                if ((bool)schMaterialAvailWindow.ShowDialog()) { 
                                    bresult=true;      
                                    bprocessAgain = schMaterialAvailWindow.getNextPart();                                                                  
                                }    
                                                                
                                if (bprocessAgain){
                                    index++;
                                    if (index < productContainer.Count)
                                        product = productContainer[index];
                                }
                            }
                        }else
                            MessageBox.Show("Can Not Find HotList Record For Part :" + product.ProdID + " Seq :" + Convert.ToInt32(product.SeqLast));

                    }else
                        MessageBox.Show("Sorry, Part :" + product.ProdID + " Seq :" + Convert.ToInt32(product.SeqLast) + " Has Not Bom Associated.");
                }

            } while (bprocessAgain && index < productContainer.Count);

         
        }else
            MessageBox.Show("Please, Select Item First.");                     
    }catch (Exception ex){
        MessageBox.Show("processShMaterial Exception: " + ex.Message);
    } 
    return bresult;
}
        
}
}
