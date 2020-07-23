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

namespace HotListReports.Windows.Boms{
    
/// <summary>
/// Interaction logic for BomWindow.xaml
/// </summary>
public 
partial class BomWindow : Window{

private BomModel model;
private string spart;
private int iseq;
private string splant;

public BomWindow(string spart,int iseq,string splant){
    InitializeComponent();

    model = new BomModel(this);
    this.spart = spart;
    this.iseq = iseq;
    this.splant = splant;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    closing();
}

private 
void closing(){
    if (model != null)
        model.Dispose();
}

private 
void initialize(){
    try { 
        this.partTextBox.Text = spart;
        this.seqTextBox.Text = iseq.ToString();

       // BomContainer  b = model.getCoreFactory().makeBoms(Configuration.DftPlant);

        model.loadColumnsOnListView(bomListView);        
        model.screenFullArea();
        loadBom();

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
            
}

private
void loadBom(){
    try { 
        Product                 product = model.getCoreFactory().readProduct(spart);
        Bom                     bom = null;
        
        if (product!= null){            
            bom = model.getCoreFactory().makeBom(spart,iseq,splant);

            if (bom!= null){
                model.loadBomView1(bomListView,bom, splant);
                model.loadBomView2(bomsListView,bom);            
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("loadBom Exception: " + ex.Message);        
    }
}


private 
void cancelButton_Click(object sender, RoutedEventArgs e){
   cancel();
}

private 
void cancel(){    
    this.DialogResult = false;
    Close();    
}


}
}
