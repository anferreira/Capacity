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
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Util;
using FarsiLibrary.FX.Win.Controls;

namespace HotListReports.Windows.Inventories { 

/// <summary>
/// Interaction logic for SchMaterialAvailWindow.xaml
/// </summary>
public partial 
class SchMaterialAvailWindow : Window{

private SchMaterialAvailModel   model;
private bool                    bnextPart;

public SchMaterialAvailWindow(HotListHdr hotListHdr, int ihotListIdAut,string spart,int seq,DateTime dateTime,decimal dqty,int imachId){
    InitializeComponent();

    this.model          = new SchMaterialAvailModel(this,hdrListView,detailsListView,serialsListView,hotListHdr, ihotListIdAut, spart, seq, dateTime, dqty, imachId);  
    this.bnextPart      = false;
}

public
void setMaterials(BomSumContainer materials){ //to not load again, and waste time
    model.MatBomSumContainer= materials;
}

public
bool getNextPart(){
    return bnextPart;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){
    try{
          
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnDtlGrid(detailsListView);
        model.loadColumnsOnSerialGrid(serialsListView);

        model.addButtonsListViewFunctions(hdrListView,firstButton,prevButton,nextButton,lastButton);
        model.addButtonsListViewFunctions(serialsListView,firstSButton,prevSButton,nextSButton,lastSButton);

        serialsListView.DataContext = model.getCoreFactory().createSeriContainer();
        loadInfo();
                     
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void loadInfo(){
    try{
        showSelected();
        model.processMatAvailable(seqTextBox,qohTextBox);        
        qtyAdjustTextBox.Focus();
    } catch (Exception ex) {
        MessageBox.Show("loadInfo Exception: " + ex.Message);        
    }
}

private 
void showSelected(){
    try{
          
        partTextBox.Text    = model.Part;        
        seqTextBox.Text     = Convert.ToInt32(model.Seq).ToString();        
        dateTextBox.Text    = DateUtil.getDateRepresentation(model.DateTime,DateUtil.MMDDYYYY);
        qtyTextBox.Text     = Math.Abs(Convert.ToInt32(model.Qty)).ToString();        
                     
    } catch (Exception ex) {
        MessageBox.Show("showSelected Exception: " + ex.Message);        
    }
}


private 
void closeButton_Click(object sender, RoutedEventArgs e){
   model.close();
}

private 
void saveButton_Click(object sender, RoutedEventArgs e){
    this.bnextPart=false;
    save();
}

private 
void saveNextButton_Click(object sender, RoutedEventArgs e){
    this.bnextPart=true;
   save();
}

private 
void saveNext(){    
    if (save())
        this.bnextPart=true;
}


private 
bool save(){
    bool bresult = model.save();
    if (bresult){
        DialogResult = true;     
        Close();
    }
    return bresult;
}

private 
void hdrListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    model.hdrListViewSelectionChanged();
}

private 
void qtyAdjustTextBox_LostFocus(object sender, RoutedEventArgs e){    
    model.processAdjust(qtyAdjustTextBox);
}

private 
void qtyAdjustTextBox_KeyUp(object sender, KeyEventArgs e){  
  model.processAdjust(qtyAdjustTextBox);
}

/***************************** serials **********************************************************************/
private 
void serialsListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    
}

private 
void addSButton_Click(object sender, RoutedEventArgs e){
    model.searchSeris();
}

private 
void delSButton_Click(object sender, RoutedEventArgs e){
    
}


private 
void moveNextButton_Click(object sender, RoutedEventArgs e){
    moveNext();
}

private 
void moveNext(){
    try{ 
        this.bnextPart=true;    
        DialogResult = true;     
        Close();
    } catch (Exception ex) {
        MessageBox.Show("moveNext Exception: " + ex.Message);        
    }
}

private 
void moveNextDateButton_Click(object sender, RoutedEventArgs e){
   moveNextDate();
}

private 
void movePriorDateButton_Click(object sender, RoutedEventArgs e){
    movePriorDate();
}

private 
void moveNextDate(){    
    model.DateTime = model.DateTime.AddDays(1);
    model.getScheduledQty();    
    loadInfo();
}

private 
void movePriorDate(){    
    model.DateTime = model.DateTime.AddDays(-1);
    //model.loadQtySchMaterialAvail();    
    loadInfo();
}

                    
}
}
