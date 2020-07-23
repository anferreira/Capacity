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
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Boms;
using HotListReports.Windows.Demand;
using HotListReports.Windows.Inventories;

namespace HotListReports.Windows.HotLists{
/// <summary>
/// Interaction logic for HotListWindow.xaml
/// </summary>
public partial 
class HotListWindow : Window{

private HotListModel    model;
private DemandModel     demandModel;
private int             itabIndex;
private HotList         hotListSelected;
private DaysWithQoh     daysWithQoh;
private ArrayList       arrayFieldListWeekly;
private bool            bcontrol;

public class DaysWithQoh {
    public int Days { get; set; }    
}

public 
HotListWindow(){
    InitializeComponent();

    this.model = new HotListModel(this);
    this.demandModel = new DemandModel(this,null,null,null,null);
    this.itabIndex = 0;
    this.hotListSelected = null;
    this.daysWithQoh = new DaysWithQoh();
    this.daysWithQoh.Days=7;
    this.arrayFieldListWeekly = new ArrayList();
    this.bcontrol = false;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
  
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
   search();
}

private 
void initialize(){        
    try {         
        model.addFunnelTitle();
        plantComboBox.SelectionChanged-= plantComboBox_SelectionChanged;

        model.addButtonsListViewFunctions(weeklyListView,       firstButton,prevButton,nextButton,lastButton);
        model.addButtonsListViewFunctions(dailyListView,        firstDButton,prevDButton,nextDButton,lastDButton);
        model.addButtonsListViewFunctions(bomHotListListView,   firstBButton,prevBButton,nextBButton,lastBButton);
        showScrollButtons(0);

        model.loadSearchByCombo(searchByComboBox);
        model.loadPlantCombo(plantComboBox,false);
        model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);                
        model.loadDifferentsMajorGroup(majorGroupComboBox);
        model.loadPartGLExps(glExpsComboBox);
        model.loadYesNoComboBox(reportedPointComboBox,true);
        model.setSelectedComboBoxItem(reportedPointComboBox,Constants.STRING_YES);// reported point Y by default
        model.plantComboBoxSelectionChanged(plantComboBox,deptComboBox);
        timeLabel.Content = "";
        exportButton.Visibility = Visibility.Visible;

        daysWithQoTextBox.DataContext=daysWithQoh;

        model.screenFullArea();        
        search();   

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{
        plantComboBox.SelectionChanged+= plantComboBox_SelectionChanged;
    }
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    mainTabControlSelectionChanged();
}

private 
void mainTabControlSelectionChanged(){
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;

            showScrollButtons(indexSel);

            hotListSelected = null;
            if (ipriorIndex == 0)
                hotListSelected = (HotList)model.getSelected(weeklyListView);
            else if (ipriorIndex == 1)                
                hotListSelected = (HotList)model.getSelected(dailyListView);
                       
            if (indexSel == 0){               
               search(hotListSelected);
            }else if (indexSel == 1){
               search(hotListSelected);                                 

            }else if (indexSel == 2){                          
                search(hotListSelected);
            }
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private
void showScrollButtons(int indexSel){
    firstButton.Visibility  = nextButton.Visibility = prevButton.Visibility = lastButton.Visibility = indexSel == 0 ? Visibility.Visible:Visibility.Hidden;
    firstDButton.Visibility = nextDButton.Visibility= prevDButton.Visibility= lastDButton.Visibility= indexSel == 1 ? Visibility.Visible:Visibility.Hidden;
    firstBButton.Visibility = nextBButton.Visibility= prevBButton.Visibility= lastBButton.Visibility= indexSel == 2 ? Visibility.Visible:Visibility.Hidden;
}

private 
void weeklyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    mainTabControl.SelectedItem = dailyTabItem;
}

private 
void dailyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    mainTabControl.SelectedItem = this.bomHotListTabItem;
}

private 
void qtyCumulativeHotListCheckBox_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void qohAffectsCheckBox_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(HotList hotListAlreadySel=null){    
    try{
        model.cursorWait();
        model.ProcessStart();
        model.startCellSelect();

        ListView    listView        = dailyListView;                                    
        string      splant          = model.getSelectedComboBoxItemString(plantComboBox);
        string      sdept           = model.getSelectedComboBoxItemString(deptComboBox);
        string      smajGroup       = model.getSelectedComboBoxItemString(majorGroupComboBox);
        string      sglExp          = model.getSelectedComboBoxItemString(glExpsComboBox);
        string      srepPoint       = model.getSelectedComboBoxItemString(reportedPointComboBox);
        string      spart           = partTextBox.Text;
        string      smachine        = searchByComboBox.SelectedIndex == 0? this.searchForTextBox.Text : "";        
        HotListHdr  hotListHdr      = model.getCoreFactory().readLastHotList(splant);
        DateTime    runDate         = hotListHdr!= null ? hotListHdr.HotlistRunDate :DateTime.Now;
        int         indexPastDue    = model.getPastDueIndex(hotListHdr!= null? hotListHdr.HotlistRunDate:DateTime.Now, splant);
        bool        bincludePlan    = (bool)includePlannedCheckBox.IsChecked;
        bool        bisDaily        = false;
        bool        bgetCumulQty    = (bool)qtyCumulativeHotListCheckBox.IsChecked; 
        bool        bqohAffects     = (bool)qohAffectsCheckBox.IsChecked; 
        HotList     hotListCurrSel  = null;

        model.HotListHdr = hotListHdr;
        model.adjustHotListSelectTitle(hotListHdr);

        if (!string.IsNullOrEmpty(spart))
            spart+="%";
        if (!string.IsNullOrEmpty(smachine))
            smachine+="%";

        daysWithQoh.Days  = daysWithQoh.Days > Constants.MAX_HOTLIST_DAYS ? Constants.MAX_HOTLIST_DAYS : daysWithQoh.Days;

        HotListContainer hotListContainer = model.getCoreFactory().createHotListContainer();
        //model.adjustHotListContainerBasedPastDue(hotListContainer,splant);

        //model.readPlannedPartsHash(splant);
                
        if (mainTabControl.SelectedItem.Equals(dailyTabItem)) {
            bisDaily = true;
            listView = dailyListView;
            model.loadColumnsOnHotList(dailyListView, indexPastDue, splant,daysWithQoh.Days);                                    
            hotListContainer = model.getCoreFactory().getHotListInvAnalysis(hotListHdr!=null ? hotListHdr.Id:0, splant, splant, sdept, smachine,0, spart, -1,smajGroup,sglExp,srepPoint,daysWithQoh.Days,false, bgetCumulQty, bqohAffects,false,false,0);            
            //hotListContainer.setQohAffectsNets((bool)qtyCumulativeHotListCheckBox.IsChecked);
            if (!bincludePlan)
                model.fillEndOfWeekWithoutPlanned(hotListHdr,hotListContainer, bgetCumulQty);
        }else if (mainTabControl.SelectedItem.Equals(weeklyTabItem)) {                 
            listView = weeklyListView;
            model.loadColumnsOnHotListWeekly(listView,indexPastDue,splant);
            hotListContainer = model.getCoreFactory().readHotListByFiltersWeekly2(arrayFieldListWeekly,hotListHdr != null ? hotListHdr.Id : 0, splant, splant, sdept,smachine,0,spart,-1,smajGroup, sglExp,srepPoint,daysWithQoh.Days,false,bgetCumulQty, bqohAffects,0);            
        }else if (mainTabControl.SelectedItem.Equals(bomHotListTabItem)) {            
            listView = bomHotListListView;
            model.loadColumnsOnHotListWeeklyBom(listView,indexPastDue,splant);
            hotListContainer = model.generateHotListBom(listView,hotListSelected, bgetCumulQty,bqohAffects,srepPoint);
        }
                
        if (!(bool)qtyCumulativeHotListCheckBox.IsChecked)
            model.adjustPastDueBasedIndexWhenNoCumulative(hotListContainer,runDate,indexPastDue);

        if (bincludePlan)
            model.addPlannedProcessEndOfWeek(hotListHdr,hotListContainer,splant,bgetCumulQty,bisDaily);
        
        hotListCurrSel = hotListAlreadySel!= null ? hotListAlreadySel :(HotList)model.getSelected(listView);
        model.setDataContextListView(listView, hotListContainer);
        model.setSelected(listView,hotListCurrSel);             //ty select prior row selected
        
        model.removeButtonsListViewFunctions();//activate scroll buttons        

        timeLabel.Content = model.ProcessEndAndTex(hotListContainer.Count);

        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        model.cursorNormal();
    }                       
}  

private 
void delButton_Click(object sender, RoutedEventArgs e){
 
}

private 
void addButton_Click(object sender, RoutedEventArgs e){
 
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.plantComboBoxSelectionChanged(plantComboBox, deptComboBox);
}

private
HotList getSelectedHotList(ListView listView){
    HotList hotList = (HotList)model.getSelected(listView);
    return hotList;
}

private 
void bomButton_Click(object sender, RoutedEventArgs e){
  showBom();
}

private
ListView getListView(){
    ListView listView= null;                      
    
    switch (itabIndex) { 
        case 0: listView = weeklyListView;break;
        case 1: listView = dailyListView; break;
        case 2: listView = bomHotListListView;break;                        
    }
    return listView;
}

private 
void showBom(){
    try{       
        ListView listView= getListView();                      
        hotListSelected = null;
      
        if (listView!= null)
            hotListSelected = (HotList)model.getSelected(listView);

        if (hotListSelected!= null){
            BomWindow bomWindow = new BomWindow(hotListSelected.ProdID,hotListSelected.Seq, hotListSelected.Plt);            
            bomWindow.ShowDialog();
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("showBom Exception: " + ex.Message);
    }   
}

private 
void createHotListButton_Click(object sender, RoutedEventArgs e){
    createHotList();
}

private 
void createHotList(){
    try { 
        model.ProcessStart();
        if (demandModel.dumpTransCreateHotList()){
            timeLabel.Content = model.ProcessEndAndTex(0);
        }
        
    }catch (Exception ex){
        MessageBox.Show("createHotList Exception: " + ex.Message);
    } 
}

private 
void exportButton_Click(object sender, RoutedEventArgs e){
    //exportImage();
    model.exportToCsv((HotListContainer)weeklyListView.DataContext,arrayFieldListWeekly,deptComboBox);
}

private 
void exportImage(){
    try { 
        string                  sfileName = "";
        string                  sfileNameAux = "HotList" + DateUtil.getDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace('/','-') + ".jpg";

        sfileName = ExportModel.generateFileName(sfileNameAux, "Exports", false);
        bool bresult = ExportModel.snapShotPNG(this.dailyListView, sfileName,5);   
            
    }catch (Exception ex){
        MessageBox.Show("createHotList Exception: " + ex.Message);
    }              
}

private 
void matAvailabilitytButton_Click(object sender, RoutedEventArgs e){
    processShMaterial();
}

private 
void processShMaterial(){
    try { 
        ListView            listView            = getListView();
        HotListContainer    hotListContainer    = listView!= null ? (HotListContainer)listView.DataContext : model.getCoreFactory().createHotListContainer();
        HotList             hotListSelectedBkp  = null; 
        hotListSelected = null;
      
        if (listView!= null)
            hotListSelected = (HotList)model.getSelected(listView);
        
        if (hotListSelected!= null) { 
            hotListSelectedBkp = hotListSelected;
            model.processShMaterial(hotListSelected,hotListContainer);            
            
            search();
            model.setSelected(listView, hotListSelectedBkp);
            
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("processShMaterial Exception: " + ex.Message);
    } 
}

/*
private 
void processShMaterial(){
    try { 
        ListView listView = getListView();
        hotListSelected = null;
      
        if (listView!= null)
            hotListSelected = (HotList)model.getSelected(listView);        

        if (hotListSelected!= null) { 
            HotList             hotListSelectedBkp  = hotListSelected;
            HotListHdr          hotListHdr          = model.getCoreFactory().readLastHotList(Configuration.DftPlant);        
            HotListContainer    hotListContainer    = null;
            HotList             hotList             = null;
            Product             product             = model.getCoreFactory().readProduct(hotListSelected.ProdID);

            if (hotListHdr!= null && product!=null) { 
                Bom  bom    =  model.getCoreFactory().makeBom(hotListSelected.ProdID,hotListSelected.Seq, hotListHdr.Plant);

                if (bom!=null && bom.getBomContainer().Count > 0) { 

                    hotListContainer = model.getCoreFactory().readHotListByFilters(hotListHdr.Id,"","","","",0,hotListSelected.ProdID, hotListSelected.Seq ,"","",false,false,0);

                    if (hotListContainer.Count > 0) { 
                        hotList = hotListContainer[0];
                        HotListDayContainer hotDayContainer = hotList.getQtyDatesNonZero(hotListHdr.HotlistRunDate);

                        if (hotDayContainer.Count > 0) { 
                            HotListDay hotListDay = hotDayContainer.getByDate(DateTime.Now);
                                  
                            if (hotListDay == null)
                                hotListDay = hotDayContainer.getBiggerThanDate(DateTime.Now);
                              

                            if (hotListDay == null) { 
                                hotListDay = model.getCoreFactory().createHotListDay();
                                hotListDay.DateTime = DateTime.Now;
                                hotListDay.Qty      =0;
                            }

                            SchMaterialAvailWindow schMaterialAvailWindow = new SchMaterialAvailWindow(Configuration.DftPlant,hotList.IdAut, hotListSelected.ProdID, hotListSelected.Seq, hotListDay.DateTime, hotListDay.Qty);
                            if ((bool)schMaterialAvailWindow.ShowDialog()) { 
                                search();
                                model.setSelected(listView, hotListSelectedBkp);
                            }
                            //model.getCoreFactory().processSchMaterialAvail(Configuration.DftPlant, hotListSelected.ProdID, hotListSelected.Seq,hotDayContainer[0].DateTime);   
                        }
                    }else
                        MessageBox.Show("Can Not Find HotList Record For Part :" + hotListSelected.ProdID + " Seq :" + Convert.ToInt32(hotListSelected.Seq));

                }else
                    MessageBox.Show("Sorry, Part :" + hotListSelected.ProdID + " Seq :" + Convert.ToInt32(hotListSelected.Seq) + " Has Not Bom Associated.");
            }
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("processShMaterial Exception: " + ex.Message);
    } 
}*/

private 
void Window_KeyDown(object sender, KeyEventArgs e){
    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control){
            if (!bcontrol){
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) { 
                    model.startCellSelect();
                    model.addIfCurrCellFocused();
                }
                bcontrol=true;
            }
    }
}

private 
void Window_KeyUp(object sender, KeyEventArgs e){
    if (Keyboard.IsKeyUp(Key.LeftCtrl) || Keyboard.IsKeyUp(Key.RightCtrl)) { 
        bcontrol=false;        
    }
}

private 
void scheduleButton_Click(object sender, RoutedEventArgs e){
    model.scheduleW();
}

}
}

