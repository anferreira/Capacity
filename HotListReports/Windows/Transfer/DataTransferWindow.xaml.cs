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

namespace HotListReports.Windows.Transfer{
/// <summary>
/// Interaction logic for DataTransferWindow.xaml
/// </summary>
public 
partial class DataTransferWindow : Window{

private DataTransferModel dataTransferModel;

public DataTransferWindow(){
    InitializeComponent();

    dataTransferModel = new DataTransferModel(this);
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    
}

private 
void initialize(){        
    try {
        dataTransferModel.loadPlantCombo(plantComboBox,true);
        dataTransferModel.Cursor = this.Cursor;      
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
string getSelectedPlant(){        
    string splant="";
    try {
        splant = plantComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)plantComboBox.SelectedItem).Content.ToString() : "";       
    } catch (Exception ex) {
        MessageBox.Show("getSelectedPlant Exception: " + ex.Message);        
    }
    return splant;
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private 
void cancel(){    
    this.DialogResult = true;
    Close();    
}

/************************************************* Items ****************************************************************/

private 
void itemMasterButton_Click(object sender, RoutedEventArgs e){
    itemMaster();
}

private 
void itemMaster(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;

        icopied = dataTransferModel.getCoreFactory().generateCMSItems(getSelectedPlant(),true); 	//Item Master

        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("itemMaster Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }        
}

private 
void familyPartsButton_Click(object sender, RoutedEventArgs e){
    familyParts();
}

private 
void familyParts(){
   try{
        int icopied=0;

        icopied = dataTransferModel.getCoreFactory().CMSFamilyCopy(); 	//familyParts

        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("familyParts Exception: " + ex.Message);        
    }
}

private 
void psscButton_Click(object sender, RoutedEventArgs e){
    pssc();
}

private 
void pssc(){
   try{
        int icopied=0;

        icopied = dataTransferModel.getCoreFactory().cms400ToNujitPssc(); 	//pssc

        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("pssc Exception: " + ex.Message);        
    }
}

private 
void mmgpButton_Click(object sender, RoutedEventArgs e){
    mmgp();
}

private 
void mmgp(){
   try{
        int icopied=0;

        icopied = dataTransferModel.getCoreFactory().generateCMSMmgp(); 	//mmgp

        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("mmgp Exception: " + ex.Message);        
    }
}

private 
void mainMaterialButton_Click(object sender, RoutedEventArgs e){
    mainMaterial();
}

private 
void mainMaterial(){
   try{
        int icopied=0;

        icopied = dataTransferModel.getCoreFactory().generateCMSMainMat(); 	//mainMaterial

        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("mainMaterial Exception: " + ex.Message);        
    }
}

/************************************************* Infraestructure ****************************************************************/

private 
void plantsDeptsButton_Click(object sender, RoutedEventArgs e){
    plantsDepts();
}

private 
void plantsDepts(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;

        string[]    recInsertDiscard = dataTransferModel.getCoreFactory().generateCMSDeptsRecords(); //depts to pltDepts
        icopied = dataTransferModel.getCoreFactory().generateCMSPlt();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("plantsDepts Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }        
}

private 
void machinesButton_Click(object sender, RoutedEventArgs e){
    machines();
}

private 
void machines(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSMachineRecords();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("machines Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }        
}

private 
void stockRoomsButton_Click(object sender, RoutedEventArgs e){
    stockRooms();
}

private 
void stockRooms(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSStkr();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("stockRooms Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }        
}

private 
void suppliersButton_Click(object sender, RoutedEventArgs e){
    suppliers();
}

private 
void suppliers(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCustVend();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("suppliers Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void toolingButton_Click(object sender, RoutedEventArgs e){
    tooling();
}

private 
void tooling(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSMthl();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("tooling Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void toolMasterButton_Click(object sender, RoutedEventArgs e){
    toolMaster();
}

private 
void toolMaster(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSTmst();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("toolMaster Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

/******************************************************** Inventory ****************************************************/
private 
void shippingScheduleButton_Click(object sender, RoutedEventArgs e){
    shippingSchedule();
}

private 
void shippingSchedule(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSJitToDelJit();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("shippingSchedule Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void materialReleaseButton_Click(object sender, RoutedEventArgs e){
    materialRelease();
}

private 
void materialRelease(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateRRLToDelFor();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("materialRelease Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void ediCrossRefButton_Click(object sender, RoutedEventArgs e){
    ediCrossRef();
}

private 
void ediCrossRef(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSTrlp();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("ediCrossRef Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void icstmButton_Click(object sender, RoutedEventArgs e){
    icstm();
}

private 
void icstm(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSIcstm();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("icstm Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void icstpButton_Click(object sender, RoutedEventArgs e){
    icstp();
}

private 
void icstp(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSIcstp();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("icstp Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void stktButton_Click(object sender, RoutedEventArgs e){
    stkt();
}

private 
void stkt(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSStkt();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("stkt Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

/*************************************************** History ********************************************************/
private 
void scrapButton_Click(object sender, RoutedEventArgs e){
    scrap();
}

private 
void scrap(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToNujitScrap();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("scrap Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void sprsnButton_Click(object sender, RoutedEventArgs e){
    sprsn();
}

private 
void sprsn(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToNujitSprsn();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("sprsn Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}
 
private 
void prhHistButton_Click(object sender, RoutedEventArgs e){
    prhHist();
}

private 
void prhHist(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCMSPrhist();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("prhHist Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void rprdButton_Click(object sender, RoutedEventArgs e){
    rprd();
}

private 
void rprd(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToCmsTempRprd();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("rprd Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void rprrButton_Click(object sender, RoutedEventArgs e){
    rprr();
}

private 
void rprr(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToCmsTempRprr();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("rprr Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void rprsButton_Click(object sender, RoutedEventArgs e){
    rprs();
}

private 
void rprs(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToCmsTempRprs();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("rprs Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void rprhButton_Click(object sender, RoutedEventArgs e){
    rprh();
}

private 
void rprh(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToCmsTempRprh();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("rprh Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}

private 
void rprpButton_Click(object sender, RoutedEventArgs e){
    rprp();
}

private 
void rprp(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().cms400ToCmsTempRprp();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("rprp Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}
          
         
private 
void custPartButton_Click(object sender, RoutedEventArgs e){
    custPart();
}

private 
void custPart(){
   try{
        int icopied=0;
        this.Cursor = System.Windows.Input.Cursors.Wait;
        
        icopied = dataTransferModel.getCoreFactory().generateCmsCustPart();
        
        MessageBox.Show("Process completed !!  " + icopied.ToString() + " items copied ...", "Information");

    } catch (Exception ex) {
        MessageBox.Show("custPart Exception: " + ex.Message);        
    }finally{
        this.Cursor = dataTransferModel.Cursor;    
    }
}
  
              
}
}
