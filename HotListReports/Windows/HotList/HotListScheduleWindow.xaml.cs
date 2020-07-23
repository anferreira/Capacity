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
using System.Collections;
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
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace HotListReports.Windows.HotLists{

/// <summary>
/// Interaction logic for HotListScheduleWindow.xaml
/// </summary>
public partial 
class HotListScheduleWindow : Window{

private HotListScheduleModel model;

public HotListScheduleWindow(HotListContainer hotListContainerSelsSchedule, HotListHdr hotListHdr){
    InitializeComponent();
    
    this.model = new HotListScheduleModel(this, hotListContainerSelsSchedule, hotListHdr);
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {         
        model.addButtonsListViewFunctions(this.scheduleListView, firstButton, prevButton, nextButton, lastButton);

        model.loadColumnsOnHotList(scheduleListView);                    
        model.HotListContainerSelsSchedule.sortByMachine();
        model.setDataContextListView(scheduleListView,model.HotListContainerSelsSchedule);        

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
    }
}

private 
void closeButton_Click(object sender, RoutedEventArgs e){
   model.close();
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
   model.del(this.scheduleListView);
}

private 
void saveButton_Click(object sender, RoutedEventArgs e){
    save();  
}

public 
void save(){    
    try{                    
        if (model.schedule()){
            DialogResult = true;
            Close();                                
        }
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                           
}



}
}
