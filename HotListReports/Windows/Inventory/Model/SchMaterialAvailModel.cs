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
using Telerik.Windows.Controls;
using FarsiLibrary.FX.Win.Controls;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Inventories{


class SchMaterialAvailModel : BaseModel2{

private SchMaterialAvailContainer   schMaterialAvailContainer;
private SchMaterialAvailContainer   schMaterialAvailTotUsedContainer;

private HotListHdr                  hotListHdr;
private int                         ihotListIdAut;
private string                      spart;
private int                         seq;
private DateTime                    dateTime;
private decimal                     dqty;
private int                         imachId;

private SchProductAvail             schProductAvail;
private SchMaterialAvail            schMaterialAvailMain;
private ListView                    hdrListView;
private ListView                    detailsListView;
private ListView                    serialsListView;
private BomSumContainer             matBomSumContainer;
private Hashtable                   hashInventory;

public SchMaterialAvailModel(Window     window,ListView hdrListView, ListView detailsListView,ListView serialsListView,
                            HotListHdr  hotListHdr, int ihotListIdAut, string spart, int seq, DateTime dateTime, decimal dqty, int imachId) : base(window){    
    schMaterialAvailContainer = getCoreFactory().createSchMaterialAvailContainer();
    schMaterialAvailTotUsedContainer = getCoreFactory().createSchMaterialAvailContainer();

    schMaterialAvailMain= getCoreFactory().createSchMaterialAvail();     
    this.hotListHdr     = hotListHdr;
    this.ihotListIdAut  = ihotListIdAut;
    this.spart          = spart;
    this.seq            = seq;
    this.dateTime       = dateTime;
    this.dqty           = dqty;
    this.imachId        = imachId;

    this.schProductAvail = getCoreFactory().createSchProductAvail(getCoreFactory().createProduct());
    this.detailsListView = detailsListView;
    this.hdrListView = hdrListView;
    this.serialsListView = serialsListView;
    matBomSumContainer = getCoreFactory().createBomSumContainer();
    this.hashInventory = new Hashtable();
}

public
string Part{
	get { return spart; }
	set { if (this.spart != value){
			this.spart = value;			
		}
	}
}

public
int Seq{
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;			
		}
	}
}

public
decimal Qty{
	get { return dqty; }
	set { if (this.dqty != value){
			this.dqty = value;			
		}
	}
}

public
DateTime DateTime{
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;			
		}
	}
}

public
BomSumContainer MatBomSumContainer {
	get { return matBomSumContainer; }
	set { 
        this.matBomSumContainer = value;				
	}
}

public
void loadColumnsOnHeaderGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Child Part", "ChildPart", BindingMode.OneWay, 140, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));  
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                                      
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ChSeq", "ChildSeq", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Child Desc", "ChildDescShow", BindingMode.OneWay,250,listView);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Max Qty", "MaxQty", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Qty/Per", "ChildQty", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
    
        textBlockColumnListView = new TextBlockColumnListView("Qty.Sel.", "ChildQtyTotal", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("AvailQty.", "ChildAvailQty", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.Short", "ChildCumulativeQOH", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
       
                              
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnDtlGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Parent Part", "ParentPart", BindingMode.OneWay, 140, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PSeq", "ParentSeq", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Max Qty.", "MaxQty", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Child Part", "ChildPart", BindingMode.OneWay, 140, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);       
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ChSeq", "ChildSeq", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Child Desc", "ChildDescShow", BindingMode.OneWay,120,listView);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Qty/Per", "ChildQty", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
    
        textBlockColumnListView = new TextBlockColumnListView("Qty.Sel.", "ChildQtyTotal", BindingMode.OneWay,65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());        
                              
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDtlGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnSerialGrid(ListView listView) {
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                        
        textBlockColumnListView = new TextBlockColumnListView("Serial", "HTSERN", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "HTPART", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "HTSEQ", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Weight", "WEIGHT_SHOW", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;  
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.", "HTQTY", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.Comp.", "HTQTYC", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lot", "HTLOTN", BindingMode.OneWay,90, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Job Num.", "HTJOBN", BindingMode.OneWay,90, listView);
        gridView.Columns.Add(textBlockColumnListView.process());                

        textBlockColumnListView = new TextBlockColumnListView("Sts.", "HTSTS", BindingMode.OneWay,30, listView);
        gridView.Columns.Add(textBlockColumnListView.process());        

        textBlockColumnListView = new TextBlockColumnListView("Uom","HTUNIT", BindingMode.OneWay,40, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Act.Date", "HTADAT", BindingMode.OneWay,70, listView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());


        listView.View = gridView;

    } catch (Exception ex) {
       MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);       
    }
}

private
bool loadProductInfo(string splant,string spart,int iseq,decimal dqty,DateTime dateTime,int imachId){
    bool bresult=false;
    try { 
        Product                 product         = getCoreFactory().readProduct(spart);
        Inventory               inventory       = getCoreFactory().readInventory(spart,splant);
        ProductPlanDtContainer  productPlanDtContainer = getCoreFactory().createProductPlanDtContainer();
        ProductPlanDt           productPlanDt   = null;
        decimal                 doptRunSize     = getOptRunSize(splant,spart,iseq,imachId);
        
        if (product!= null){
            bresult=true;

            schProductAvail = getCoreFactory().createSchProductAvail(product);                              
            schProductAvail.Seq = iseq < 0 ? product.SeqLast : iseq;
            doptRunSize     = doptRunSize != 0 ? doptRunSize : product.OptimRunPurchSize;
        }
        
        schProductAvail.Qoh     = inventory!= null ? inventory.getTotalInventory(iseq):0;
        schProductAvail.Qty     = System.Math.Abs(dqty);
        schProductAvail.OptimRunPurchSize = doptRunSize;
        schProductAvail.DateTime=dateTime;

        //check if part is family part
        productPlanDtContainer = getCoreFactory().readProductPlanDtByFilters(schProductAvail.ProdID,schProductAvail.Seq,"",-1,0);
        if (productPlanDtContainer.Count > 0){
            productPlanDt = productPlanDtContainer[0];
            schProductAvail.FamilyPart      = productPlanDt.FamCfg;
            schProductAvail.FamilyPartDesc  = schProductAvail.Des1;
        }else{
            //check if part is part from family
            productPlanDtContainer = getCoreFactory().readProductPlanDtByFilters("",-1, schProductAvail.ProdID,schProductAvail.Seq, 0);    
            if (productPlanDtContainer.Count < 1 && product!= null && schProductAvail.Seq == product.SeqLast)       //same seq as last seq, so we try with seq=0         
                productPlanDtContainer = getCoreFactory().readProductPlanDtByFilters("",-1, schProductAvail.ProdID,0,0);    

            if (productPlanDtContainer.Count > 0){           
                productPlanDt = productPlanDtContainer[0];                             
                schProductAvail.FamilyPart      = productPlanDt.FamCfg;                

                Product  productFamily  = getCoreFactory().readProduct(schProductAvail.FamilyPart);
                if (productFamily!= null)
                    schProductAvail.FamilyPartDesc  = productFamily.Des1;
            }    
        }
        
    } catch (Exception ex) {
        MessageBox.Show("loadProductInfo Exception: " + ex.Message);        
    }
    return bresult;
}

private
decimal getOptRunSize(string splant,string spart,int iseq,int imachId){
    decimal doptRunSize=0;
    try { 
        Routing                 routing     = null;    
        RoutingContainer        routingContainer= getCoreFactory().createRoutingContainer();
        Machine                 machine     = null;    
        string                  sdept       ="";
        string                  smachine    = "";

        if (imachId > 0){
            machine = getCoreFactory().readMachineById(imachId);
            if (machine!= null){
                sdept       = machine.Dept;
                smachine    = machine.Mach;
            }
        }

        routingContainer = getCoreFactory().readRoutingByFilters(spart,splant,sdept,iseq,smachine,"",false,true,1);
        if (routingContainer.Count > 0)
            routing= routingContainer[0];

        if (routing!= null)
            doptRunSize = routing.OptRunQty;

    
    } catch (Exception ex) {
        MessageBox.Show("getOpRunSize Exception: " + ex.Message);        
    }
    return doptRunSize;
}

private
bool loadChildsProductInfo(){
    bool bresult=false;
    try { 
        Product             product = null;
        SchMaterialAvail    schMaterialAvail = null;
      
        for (int i=0; i < schMaterialAvailContainer.Count;i++){
            schMaterialAvail = schMaterialAvailContainer[i];

            product = getCoreFactory().readProduct(schMaterialAvail.ChildPart);
            if (product!= null)
                schMaterialAvail.ChildDescShow = product.Des1;
        }
        
    } catch (Exception ex) {
        MessageBox.Show("loadChildProductInfo Exception: " + ex.Message);        
    }
    return bresult;
}

public 
void processMatAvailable(TextBox seqTextBox,TextBox qohTextBox){
    try{        
        decimal                     dscheduleQty =0;
        schMaterialAvailTotUsedContainer= getCoreFactory().createSchMaterialAvailContainer();
        schMaterialAvailContainer       = getCoreFactory().readSchMaterialAvailByFilters(hotListHdr.Plant, hotListHdr.Id,ihotListIdAut, 0,"",-1,"",-1,dateTime,false,0);
                        
        loadProductInfo(hotListHdr.Plant,spart, seq,dqty,dateTime,imachId);   //load parent part info        
        schProductAvail.Qty = getScheduledQty(); 
        
        if (schMaterialAvailContainer.Count < 1) 
            schMaterialAvailContainer = getCoreFactory().processSchMaterialAvail(schMaterialAvailTotUsedContainer,this.matBomSumContainer,hotListHdr,schProductAvail.ProdID, schProductAvail.Seq, schProductAvail.DateTime,schProductAvail.Qty);
        else
            schMaterialAvailTotUsedContainer = loadMaterialsFromOthers(schMaterialAvailContainer,ihotListIdAut,dateTime);

        loadChildsProductInfo();                    //load child part indo--> desc1

        schMaterialAvailMain = getCoreFactory().createSchMaterialAvail();
        if (schMaterialAvailContainer.Count > 0)
            schMaterialAvailMain = schMaterialAvailContainer[0];    

        schProductAvail.QtyAdjust = schMaterialAvailMain.ParentQtyAdjust;
        window.DataContext = null;
        window.DataContext = schProductAvail;

        processAdjust();

        schMaterialAvailTotUsedContainer.calculateChildQtyTotal();
        setDataContextListView(hdrListView,schMaterialAvailContainer);
        setDataContextListView(detailsListView,schMaterialAvailTotUsedContainer);
                         
    } catch (Exception ex) {
        MessageBox.Show("processMatAvailable Exception: " + ex.Message);        
    }
}

private
SchMaterialAvailContainer loadMaterialsFromOthers(SchMaterialAvailContainer schMaterialAvailContainer,int ihotListIdAut,DateTime dateTime){
    SchMaterialAvailContainer schMaterialAvailTotalContainer = getCoreFactory().createSchMaterialAvailContainer();
    SchMaterialAvailContainer schMaterialAvailAuxContainer = getCoreFactory().createSchMaterialAvailContainer();

    for (int i=0; i < schMaterialAvailContainer.Count; i++) { 
        SchMaterialAvail schMaterialAvail = schMaterialAvailContainer[i];

        schMaterialAvailAuxContainer = getCoreFactory().readSchMaterialAvailByFilters(hotListHdr.Plant,hotListHdr.Id,0,ihotListIdAut,"",-1, schMaterialAvail.ChildPart, schMaterialAvail.ChildSeq,dateTime,false,0);
        for (int j=0; j < schMaterialAvailAuxContainer.Count; j++) { 
            SchMaterialAvail schMaterialAvailAux  =schMaterialAvailAuxContainer[j];             
            schMaterialAvailTotalContainer.Add(schMaterialAvailAuxContainer[j]);        
        }
    }
    return schMaterialAvailTotalContainer;
}

public 
bool save(){   
    bool    bresult=false;
    try{
        processAdjust();

        if (dataOk()) { 
            schMaterialAvailContainer.fillRedundances();
            for (int i=0; i < schMaterialAvailContainer.Count; i++) {               
                save(schMaterialAvailContainer[i]);                   

                bresult=true;
            }   
        }
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
    return bresult;
}

public 
void save(SchMaterialAvail schMaterialAvail){   
    try{
        if (schMaterialAvail.Id > 0)
            getCoreFactory().updateSchMaterialAvail(schMaterialAvail);
        else
            getCoreFactory().writeSchMaterialAvail(schMaterialAvail);
        
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}

public 
void hdrListViewSelectionChanged(){   
    try{
        SchMaterialAvail schMaterialAvail   = (SchMaterialAvail)getSelected(hdrListView);
        SchMaterialAvail schMaterialAvailAux= null;

        if (schMaterialAvail!= null){
            schMaterialAvailAux = this.schMaterialAvailTotUsedContainer.getByChildPartButNotId(schMaterialAvail.ChildPart, schMaterialAvail.ChildSeq);
            if (schMaterialAvailAux!= null)
                setSelected(detailsListView,schMaterialAvailAux);

        }

    } catch (Exception ex) {
        MessageBox.Show("hdrListViewSelectionChanged Exception: " + ex.Message);        
    }
}

public
void processAdjust(TextBox textBoxAdjust){	                       
    try{
        if (!NumberUtil.isDecimalNumber(textBoxAdjust.Text)) 
            textBoxAdjust.Text="0";

        processAdjust(textBoxAdjust.Text);                    

    }catch (Exception ex) {
        MessageBox.Show("processAdjust Exception: " + ex.Message);        
    }
}

public
void processAdjust(string sadjust){	                       
    try{
        if (NumberUtil.isDecimalNumber(sadjust)) { 
            schMaterialAvailMain.ParentQtyAdjust = Convert.ToDecimal(sadjust);
            processAdjust();
        } 

    }catch (Exception ex) {
        MessageBox.Show("processAdjust Exception: " + ex.Message);        
    }
}

public
void processAdjust(){	                       
    try{
        if (getCoreFactory()!= null && schMaterialAvailMain != null) { 
                                
            decimal             dchildQoh       = 0;
            decimal             dmatUsed        = 0;
            decimal             dchildQtyNeeded = 0;
            DateTime            fromDate        = DateUtil.minorHour(dateTime);
            DateTime            toDate          = DateUtil.highHour(dateTime);
            //we check receipts parts and material consume, which affects qoh
            ScheduleReceiptPartContainer        scheduleReceiptPartContainer        = getCoreFactory().getReceiptPartContainerByFilters(0, hotListHdr.Plant,"",-1,"",0, fromDate,toDate);
            ScheduleMaterialConsumPartContainer scheduleMaterialConsumPartContainer = getCoreFactory().getMaterialConsumPartContainerByFilters(0, hotListHdr.Plant,"",-1,"",0,fromDate,toDate);
    

            for (int i=0; i < schMaterialAvailContainer.Count; i++){                
                SchMaterialAvail schMaterialAvail = schMaterialAvailContainer[i];
                
                dchildQoh  = getQoh(schMaterialAvail.ChildPart,schMaterialAvail.ChildSeq,hotListHdr.Plant);
                dmatUsed   = schMaterialAvailTotUsedContainer.getTotalChildPartButNotId(schMaterialAvail.ChildPart, schMaterialAvail.ChildSeq,0);

                dchildQoh-=dmatUsed;
                dchildQoh+= scheduleReceiptPartContainer.getTotalRemainsQty(schMaterialAvail.ChildPart, schMaterialAvail.ChildSeq);
                dchildQoh-= scheduleMaterialConsumPartContainer.getTotalRemainsQty(schMaterialAvail.ChildPart, schMaterialAvail.ChildSeq);
                if (dchildQoh < 0)
                    dchildQoh =0;

                schMaterialAvail.ParentSrcHotId = schMaterialAvailMain.ParentSrcHotId;
                schMaterialAvail.ParentQtyAdjust= schMaterialAvailMain.ParentQtyAdjust;
                schMaterialAvail.DateTime       = schMaterialAvailMain.DateTime;

                dchildQtyNeeded                 = schMaterialAvail.ChildQty * schMaterialAvail.ParentQtyAdjust;
                dchildQtyNeeded                 = dchildQoh >= dchildQtyNeeded ?  0 : (dchildQtyNeeded-dchildQoh);

                schMaterialAvail.MaxQty         = dchildQoh / (schMaterialAvail.ChildQty != 0 ? schMaterialAvail.ChildQty:1);

                schMaterialAvail.ChildQtyTotal  =  (schMaterialAvail.ParentQtyAdjust * schMaterialAvail.ChildQty);
                schMaterialAvail.ChildCumulativeQOH = dchildQtyNeeded;
            }    		
        }

    }catch (Exception ex) {
        MessageBox.Show("processAdjust Exception: " + ex.Message);        
    }
}

public
decimal getQoh(string spart,int seq,string splant){
    decimal dqoh=0;
    string  skey = spart.ToUpper() + Constants.DEFAULT_SEP + seq.ToString();
    
    if (getFromHashTable(hashInventory, skey)!= null)
        dqoh = (decimal)getFromHashTable(hashInventory,skey);
    else{
        Inventory inventory  = getCoreFactory().readInventory(spart,splant);
        dqoh  = inventory!= null ? inventory.getTotalInventory(seq) : 0;

        addToHashTable(hashInventory, dqoh, skey);
    }
    return dqoh;
}

public
bool dataOk(){	                       
    bool bresult=true;
    try{
        decimal dmaxMinorQty = schMaterialAvailContainer.getMinMaxQty();
       
        if (schMaterialAvailMain != null) {
            if (dmaxMinorQty ==0) {
                System.Windows.MessageBox.Show("Sorry, You Can Not Adjust Qty, Because Minor Qty To Adjust Is Zero");
                bresult=false;

            } else if (schMaterialAvailMain.ParentQtyAdjust > dmaxMinorQty &&
                        System.Windows.MessageBox.Show("Adjusted Qty. Might Not Bigger Than " + Convert.ToInt32(dmaxMinorQty) + ", Continue Anyway ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) {
                bresult =false;
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("dataOk Exception: " + ex.Message);        
    }
    return bresult;
}

public
void searchSeris(){
    try {       
        SchMaterialAvail    schMaterialAvail= (SchMaterialAvail)getSelected(hdrListView);
        SeriContainer       seriContainer   = (SeriContainer)serialsListView.DataContext;

        if (seriContainer==null)
            seriContainer = getCoreFactory().createSeriContainer();

        if (schMaterialAvail!= null) {  
            SeriWindow window = new SeriWindow(schMaterialAvail.ChildPart,schMaterialAvail.ChildSeq, hotListHdr.Plant);
            if ((bool)window.ShowDialog()){
                Seri seri = window.getSelected();
                if (seri!= null && seriContainer.getByKey(seri.HTSERN) == null) { 

                    if (schMaterialAvail.ChildPart.ToUpper().Equals(seri.HTPART.ToUpper()))                            
                        seriContainer.Add(seri);        
                    else
                        MessageBox.Show("Sorry, Different Serial's Part Selected , Might Be Part =" + schMaterialAvail.ChildPart + ".");
                }
            }
        }
        setDataContextListView(serialsListView,seriContainer);

    } catch (Exception ex) {
       MessageBox.Show("searchSeris Exception: " + ex.Message);       
    }
}
  
public 
void moveNextDate(DateTime dateTime){
    try {    

        if (hotListHdr!= null){
            //hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr.Id,"","","","",0,spart,iseq,"","",false,false,0);

        }

    } catch (Exception ex) {
       MessageBox.Show("moveNextDate Exception: " + ex.Message);       
    }
}
  

public 
void loadQtySchMaterialAvail(DateTime dateTime,out decimal dqty,int ihotListIdAut){
    dqty=0;
    try{                
        schMaterialAvailContainer  = getCoreFactory().readSchMaterialAvailByFilters(hotListHdr.Plant, hotListHdr.Id,ihotListIdAut, 0,"",-1,"",-1,dateTime,false,0);

        schMaterialAvailMain = getCoreFactory().createSchMaterialAvail();
        if (schMaterialAvailContainer.Count > 0)
            schMaterialAvailMain = schMaterialAvailContainer[0];    
        
        dqty = schMaterialAvailMain.ParentQtyAdjust;
                          
    } catch (Exception ex) {
       MessageBox.Show("loadSchMaterialAvail Exception: " + ex.Message);       
    }                                     
}

public
decimal getScheduledQty(){                 
    decimal dqty =0;
    try{        
        ScheduleReceiptPartContainer   scheduleReceiptPartContainer = getCoreFactory().getReceiptPartContainerByFilters(0,hotListHdr.Plant, spart, seq, "",0,DateUtil.minorHour(dateTime),DateUtil.highHour(dateTime));
        dqty = scheduleReceiptPartContainer.getTotalRecQty();
    } catch (Exception ex) {
       MessageBox.Show("getScheduledQty Exception: " + ex.Message);       
    }     
    return dqty;
}


}
}
