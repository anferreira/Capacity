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
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;


namespace HotListReports.Windows.Demand{

/// <summary>
/// Interaction logic for DemandWindow.xaml
/// </summary>
public partial 
class DemandWindow : Window{

private DemandModel model;
private int         itabIndex;
private int         itabDtlIndex;
private DemTransformH demTransformH;
private string          stimeCodeFilterSelected;
private string          sdiscardFilterSelected;
private bool            brunFirstTime;
private TrlpKeyFilter   trlpKeyFilter;

public class TrlpKeyFilter {
    public int TrlpKey { get; set; }    
}

public DemandWindow(){
    InitializeComponent();

    model = new DemandModel(this,dtlListView,dtlDaysListView,dtlDaysAuhorizListView,dtlPlanVsProductionListView);

    this.itabIndex = 0;
    this.itabDtlIndex = 0;
    this.demTransformH = null;    
    this.stimeCodeFilterSelected = "";
    this.sdiscardFilterSelected = "";
    this.brunFirstTime = true;
    this.trlpKeyFilter = new TrlpKeyFilter();
    trlpKeyFilter.TrlpKey=0;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){    
}

private
DemandH getCurrDemandH(){ 
    return (DemandH)dtlTopCanvas.DataContext;
}

private 
void initialize(){
    try {
        model.addButtonsListViewFunctions(this.hdrListView, firstButton, prevButton, nextButton, lastButton);
        model.addButtonsListViewFunctions(this.dtlListView, firstDButton, prevDButton, nextDButton, lastDButton);
        model.addButtonsListViewFunctions(this.dtlDaysListView, firstD2Button, prevD2Button, nextD2Button, lastD2Button);
        model.addButtonsListViewFunctions(this.dtlDaysAuhorizListView, firstD3Button, prevD3Button, nextD3Button, lastD3Button);
        model.addButtonsListViewFunctions(this.dtlPlanVsProductionListView, firstD4Button, prevD4Button, nextD4Button, lastD4Button);
            
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        model.Cursor = this.Cursor;
        model.loadSearchByCombo(searchByComboBox,false);//not use TrlpKey filter
        model.loadStatusCombo(stsComboBox);        
        model.loadPlantCombo(plantComboBox,true);model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
        model.loadSourceCombo(sourceComboBox);
        model.loadTimeCodeCombo(timeCodeComboBox);
        model.loadYesNoComboBox(discardFilterComboBox,true);
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnDetailsGrid(dtlListView);
        model.loadColumnsOnTransformGrid(transformListView);        

        model.screenFullArea();

        this.transformTabItem.Visibility = Visibility.Collapsed;
        showHideScrollDetailButtons();
        this.searchTrlpKeyTextBox.DataContext = trlpKeyFilter;
        searchTrlpKeyLabel.Visibility = searchTrlpKeyTextBox.Visibility = Visibility.Hidden;//for now not use TrlpKey filters 

        search();

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    moveToTransformTab();    
}

private 
void dtlDaysListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    moveToTransformTab();
}

private 
void dtlDaysAuhorizListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    moveToTransformTab();
}

private 
void dtlPlanVsProductionListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    moveToTransformTab();
}

private
void moveToTransformTab(){
    if (this.demTransformH != null)
        mainTabControl.SelectedItem = this.transformTabItem;
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    mainTabControlSelectionChanged();
}

private 
void dtlTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    dtlTabControlSelectionChanged();
}
       
private 
void mainTabControlSelectionChanged(){
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;
                       
            if (indexSel == 0){
                this.demTransformH=null;
                this.transformTabItem.Visibility = Visibility.Collapsed;
                search();
            }else if (indexSel == 1){
                                
                if (ipriorIndex == 0){
                    DemandH demandH = (DemandH)model.getSelected(hdrListView);                                             
                    if (demandH!=null)
                        loadDemandH(demandH);
                    else
                        mainTabControl.SelectedItem = this.hdrTabItem;
                }

            }else if (indexSel == 2 && this.demTransformH!=null){
                DemandD demandD = model.getDtlSelectedForTransform(getCurrDemandH(),itabDtlIndex,stimeCodeFilterSelected, sdiscardFilterSelected);
                if (demandD != null)
                    loadTransform(demandD);
                else
                    mainTabControl.SelectedItem = this.dtlTabItem;
            }
        }
         
    } catch (Exception ex) {
       MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);     
    }
}

private 
void dtlTabControlSelectionChanged(){
    try {
        int indexSel    = dtlTabControl.SelectedIndex;
        int ipriorIndex = itabDtlIndex;
                
        if (indexSel != itabDtlIndex){
            this.itabDtlIndex = indexSel;
                       
            showHideScrollDetailButtons();
            loadDtlColumnsGrid();
            searchDtls();
        }
         
    } catch (Exception ex) {
       MessageBox.Show("dtlTabControlSelectionChanged Exception: " + ex.Message);     
    }

}

private
void loadDtlColumnsGrid(){
    try{
        switch(itabDtlIndex){
            case  1: model.loadColumnsOnDetailsDatesGridView(dtlDaysListView, false);               break;
            case  2: model.loadColumnsOnDetailsDatesGridView(dtlDaysAuhorizListView, true);         break;
            case  3: model.rewritePlannedVsProductionListViewColumns(dtlPlanVsProductionListView);  break;
        }

    }catch (Exception ex){
        MessageBox.Show("loadDtlColumnsGrid Exception: " + ex.Message);
    }                                        
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){    
    search();
}

private 
void search(){
    try{
        int         irows       = brunFirstTime ? 1 : model.getRecords(recordsTextBox);                    
        string      sid         = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,0);
        decimal     dtrlpKey    = model.getSearchFromComboBoxInt(searchByComboBox,searchForTextBox,1);                        
        string      splant      = model.getSelectedComboBoxItemString(plantComboBox);
        string      status      = model.getSelectedComboBoxItemString(stsComboBox);
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);
        DemandH     demandHSel  = (DemandH)model.getSelected(hdrListView);
                
        DemandHContainer demandHContainer = model.getCoreFactory().readDemandHByFilters(sid,splant,status,dtrlpKey,fromDate, toDate, irows);
        model.setDataContextListView(hdrListView,demandHContainer);        
        model.setSelected(hdrListView,demandHSel); //try sel prior sel
        this.searchForTextBox.Focus();

        if (brunFirstTime && hdrListView.Items.Count > 0)
            mainTabControl.SelectedItem = dtlTabItem;
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
      brunFirstTime=false;
    }                                       
}  

private 
void loadDemandH(DemandH demandHAux){
    try{        
        this.demTransformH = null;
        DemandDContainer demandDContainer = null;
        model.DemandDViewContainer = model.getCoreFactory().createDemandDViewContainer();    

        DemandH demandH = model.getCoreFactory().readDemandH(demandHAux.Id);
        dtlTopCanvas.DataContext = null;
        dtlTopCanvas.DataContext = demandH;
        model.DemandH = demandH;

        if (demandH!=null){                    
            demandDContainer = demandH.DemandDContainer;

            this.demTransformH = model.getCoreFactory().getDemTransformHdrByMaxID((int)demandH.Id);
            this.transformTabItem.Visibility = demTransformH!=null ? Visibility.Visible : Visibility.Collapsed;

            model.loadBillTo(billToComboBox,demandH);
            model.loadShipTo(shipToComboBox,demandH);
        }  
        searchDtls();
                                                          
    }catch (Exception ex){
        MessageBox.Show("loadDemandH Exception: " + ex.Message);
    }finally{       
    }
}
        
private 
void loadTransform(DemandD demandD){
    try{
        //show demandD info
        transformTopCanvas.DataContext = null;
        transformTopCanvas.DataContext = demandD;
                           
        //show DemTransformD info related
        DemTransformDContainer demTransformDContainer = model.getCoreFactory().createDemTransformDContainer();

        if (this.demTransformH!=null){
            foreach (DemTransformD demTransformD in demTransformH.DemTransformDContainer){
                if (demandD.HdrId == demTransformD.DemandHdr && demandD.Detail == demTransformD.DemandDetail) { 
                    demTransformDContainer.Add(demTransformD);
                    demTransformD.DemandD = demandD;
                }
            }
        }             

        this.transformListView.DataContext= demTransformDContainer;
        this.transformListView.ItemsSource= demTransformDContainer;

    }catch (Exception ex){
        MessageBox.Show("loadTransform Exception: " + ex.Message);
    }                       
}
        
private 
void demDumpButton_Click(object sender, RoutedEventArgs e){
    demandDump();
}

private 
void demandDump(){    
    try {        
        if (model.demandDump())        
            search();        

    }catch (Exception ex){
       MessageBox.Show("demandDump Exception: " + ex.Message);  
    }
}

private 
void transformButton_Click(object sender, RoutedEventArgs e){
    transform();    
}

private 
void transform(){    
    if (model.transform(hdrListView))        
        search();                 
}

private 
void detailButton_Click(object sender, RoutedEventArgs e){
    editDtl();
}

private 
void editDtl(){    
    model.editDtl(getCurrDemandH(), (DemandD)model.getSelected(dtlListView));            
}

private 
void merge830862Button_Click(object sender, RoutedEventArgs e){
    merge830862();
}

private 
void merge830862(){
    model.merge830862(hdrListView);
}
 
private 
void saveButton_Click(object sender, RoutedEventArgs e){
    saveDemand();
}

private 
void saveDemand(){
    model.saveDemand(getCurrDemandH());
}

private 
void dumpInventory(){
    model.demandDump();    
}

private 
void createHotListButton_Click(object sender, RoutedEventArgs e){
    createHotList();    
}

private 
void createHotList(){
    if (model.createHotList(hdrListView))        
        search(); 
}

private 
void dumpTransCreateHotListButton_Click(object sender, RoutedEventArgs e){
    dumpTransCreateHotList();
}

private 
void dumpTransCreateHotList(){
    if (model.dumpTransCreateHotList())        
        search();
}

private 
void searchDtlButton_Click(object sender, RoutedEventArgs e){
    searchDtls();
}

private
void showHideScrollDetailButtons(){
    firstDButton.Visibility = prevDButton.Visibility = nextDButton.Visibility = lastDButton.Visibility = itabDtlIndex == 0 ? Visibility.Visible : Visibility.Hidden;
    firstD2Button.Visibility= prevD2Button.Visibility= nextD2Button.Visibility= lastD2Button.Visibility= itabDtlIndex == 1 ? Visibility.Visible : Visibility.Hidden;
    firstD3Button.Visibility= prevD3Button.Visibility= nextD3Button.Visibility= lastD3Button.Visibility= itabDtlIndex == 2 ? Visibility.Visible : Visibility.Hidden;
    firstD4Button.Visibility= prevD4Button.Visibility= nextD4Button.Visibility= lastD4Button.Visibility= itabDtlIndex == 3 ? Visibility.Visible : Visibility.Hidden;
    detailButton.Visibility = itabDtlIndex == 0 ? Visibility.Visible : Visibility.Hidden;

    exportButton.Visibility = dtlTabControl.SelectedItem!= null && dtlTabControl.SelectedItem.Equals(dtlView2Item) ? Visibility.Visible : Visibility.Hidden;
}

private 
void searchDtls(){
    try{         
  
        switch(itabDtlIndex){
            case  0: searchDtl();           break;
            case  1: searchDtlDates(false); break;
            case  2: searchDtlDates(true);  break;
            case  3: searchDtlDates(true);  break;
        }                

        searchTrlpKeyTextBox.IsEnabled = itabDtlIndex==0;

    } catch (Exception ex) {
       MessageBox.Show("searchDtls Exception: " + ex.Message); 
    }
}

private 
void searchDtl(){
    try{                
        model.ProcessStart();
        DemandH             demandH = getCurrDemandH();
        DemandDContainer    demandDContainer = model.getCoreFactory().createDemandDContainer();
        string              source  = model.getSelectedComboBoxItemString(sourceComboBox);
        string              sbillTo = model.getSelectedComboBoxItemString(billToComboBox);
        string              shipTo  = model.getSelectedComboBoxItemString(shipToComboBox);
        string              stimeCod= model.getSelectedComboBoxItemString(timeCodeComboBox);
        string              sdiscard= model.getSelectedComboBoxItemString(discardFilterComboBox);
        string              spart   = this.searchForPartTextBox.Text;
        decimal             dtrlpKey= NumberUtil.isIntegerNumber(searchTrlpKeyTextBox.Text) ? Convert.ToInt32(searchTrlpKeyTextBox.Text):0;
        bool                bincludeZerotQty = (bool)includeZeroQtyCheckBox.IsChecked;
        Object              objSelected1 = model.ObjSelected1;

        if (demandH!= null){
            if (!string.IsNullOrEmpty(spart))        
                spart = spart + "%";
            demandDContainer = demandH.DemandDContainer.getByFilters(source,stimeCod,sdiscard,sbillTo, shipTo,spart,dtrlpKey,"", bincludeZerotQty);
        }
        model.setDataContextListView(dtlListView,demandDContainer);        
        model.setSelected(dtlListView,objSelected1);
        timeLabel.Content = model.ProcessEndAndTex(dtlListView.Items.Count);    
                                    
    }catch (Exception ex){
        MessageBox.Show("searchDtl Exception: " + ex.Message);
    }                       
}  

private 
void searchDtlDates(bool baddAuhotization){
    try{                
        model.ProcessStart();
        DemandH                 demandH = getCurrDemandH();     
        DemandDViewContainer    demandDViewContainerResult = model.getCoreFactory().createDemandDViewContainer();
        string                  source  = model.getSelectedComboBoxItemString(sourceComboBox);
        string                  sbillTo = model.getSelectedComboBoxItemString(billToComboBox);
        string                  shipTo  = model.getSelectedComboBoxItemString(shipToComboBox);
        string                  stimeCod= model.getSelectedComboBoxItemString(timeCodeComboBox);
        string                  sdiscard= model.getSelectedComboBoxItemString(discardFilterComboBox);
        string                  spart   = this.searchForPartTextBox.Text;
        decimal                 dtrlpKey= NumberUtil.isIntegerNumber(searchTrlpKeyTextBox.Text) ? Convert.ToInt32(searchTrlpKeyTextBox.Text):0;
        ListView                listView= dtlDaysListView;
        bool                    baddTimeCode = itabDtlIndex == 3;
        Object                  objectSelected = null;

        switch(itabDtlIndex){
            case  1: listView=dtlDaysListView;              objectSelected = model.ObjSelected2;break;
            case  2: listView=dtlDaysAuhorizListView;       objectSelected = model.ObjSelected3;break;
            case  3: listView=dtlPlanVsProductionListView;  objectSelected = model.ObjSelected4;break;
        }

        if (demandH!= null){
            if (!string.IsNullOrEmpty(spart))        
                spart = spart + "%";

            stimeCodeFilterSelected = stimeCod;

            if (!string.IsNullOrEmpty(stimeCod) || baddTimeCode) //we are not loading time code on original container, so if timecode, so we run query
                demandDViewContainerResult = model.getCoreFactory().getDemandDViewReportByFilters(demandH.Id,source,stimeCod,sbillTo,shipTo,spart, baddAuhotization, baddTimeCode, 0);            
            else { 
                if (model.DemandDViewContainer.Count < 1)
                    model.DemandDViewContainer = model.getCoreFactory().getDemandDViewReportByFilters(demandH.Id,"","","","","", baddAuhotization, baddTimeCode,0);            

                if (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(stimeCod) && string.IsNullOrEmpty(sbillTo) && string.IsNullOrEmpty(shipTo) && string.IsNullOrEmpty(spart))
                    demandDViewContainerResult = model.DemandDViewContainer;//just to not waste tiem, if all filter empty
                else 
                    demandDViewContainerResult = model.DemandDViewContainer.getByFilters(source,stimeCod,sbillTo,shipTo,spart);
            }
        }

        if (itabDtlIndex == 3)
            model.loadPlanVsProduction(demandH,demandDViewContainerResult,(bool)includeProductionCheckBox.IsChecked);
        else
            model.setDataContextListView(listView, demandDViewContainerResult);    
        
        model.setSelected(listView,objectSelected);
        timeLabel.Content = model.ProcessEndAndTex(listView.Items.Count);            
                                                   
    }catch (Exception ex){
        MessageBox.Show("searchDtlDates Exception: " + ex.Message);
    }                       
}  

private 
void cancelTransformButton_Click(object sender, RoutedEventArgs e){
    cancelTransform();
}

private 
void cancelTransform(){
    mainTabControl.SelectedItem = dtlTabItem;    
}

private 
void dtlListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    model.ObjSelected1 = model.getSelected(dtlListView);    
}

private 
void dtlDaysListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    model.ObjSelected2 = model.getSelected(dtlDaysListView);    
}

private 
void dtlDaysAuhorizListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    model.ObjSelected3 = model.getSelected(dtlDaysAuhorizListView);    
}

private 
void dtlPlanVsProductionListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    model.ObjSelected4 = model.getSelected(dtlPlanVsProductionListView);    
}

private 
void includeProductionCheckBox_Click(object sender, RoutedEventArgs e){
    if (itabDtlIndex == 3 && (bool)includeProductionCheckBox.IsChecked)
        searchDtls();
}

private 
void includeZeroQtyCheckBox_Click(object sender, RoutedEventArgs e){    
    searchDtls();
}

private 
void exportButton_Click(object sender, RoutedEventArgs e){
    model.exportByDates(dtlDaysListView);
}



}
}
