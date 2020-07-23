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
using System.Windows.Threading;


namespace HotListReports.Windows.EmployeeSchedule{


class SheduleRptModel : BaseModel2{

public const int TIME_MILISECONDS =4000;

private ListView            listView;
private DispatcherTimer     timer;
private int                 imaxScroll;
private IEnumerable         objectCollection; //used to scroll to the first element(reload all list), becausd scroll into view does not work for firs element

public SheduleRptModel(Window window,ListView listView,int imaxScroll) : base(window){    
    this.window.Closing += Window_Closing;

    timer = new DispatcherTimer();
    this.listView = listView;
    this.imaxScroll = imaxScroll;
    this.objectCollection = null;
}

public
IEnumerable ObjectCollection {
	get { return objectCollection; }
	set { 
	      this.objectCollection = value;			
	}
}
 
private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
   stopTimer();  
}

public
void startTimer(){    
    try{
        timer.Interval = TimeSpan.FromMilliseconds(TIME_MILISECONDS);
	    timer.Tick += timer_Tick;
	    timer.Start();
    }catch (Exception ex){
        MessageBox.Show("startTimer Exception: " + ex.Message);
    }
}

public
void stopTimer(){       
    try{
        timer.Stop();        
        timer.Tick-= timer_Tick;
    }catch (Exception ex){
        MessageBox.Show("stopTimer Exception: " + ex.Message);
    }
}

public
void restartTimer(){    
    try{
        stopTimer();
        startTimer();
    }catch (Exception ex){
        MessageBox.Show("restartTimer Exception: " + ex.Message);
    }
}

private
void timer_Tick(object sender, EventArgs e){   
    timerTick();
}

private
void timerTick(){	
    try{
        stopTimer();
        moveToNextRow();
    }catch (Exception ex){
        MessageBox.Show("timerTick Exception: " + ex.Message);
    }finally{
        startTimer();
    }	
}

public
void startScroll(){
    try { 
        int index =0;
        if (listView.Items.Count > imaxScroll) { 
            listView.SelectedIndex= imaxScroll;
            
            startTimer();
        }
        index = listView.SelectedIndex;

    }catch (Exception ex){
        MessageBox.Show("startScroll Exception: " + ex.Message);
    }
}  
        
public
void moveToNextRow(){
    try { 
        int index= listView.SelectedIndex;
        
        if ( (index + 1) == listView.Items.Count)
            index=0;
        else {
            index+= imaxScroll;
            if (listView.Items.Count < index)  
                index= listView.Items.Count -1;
        }
        
        if (index == 0) { //reload all list
            loadListView(objectCollection);
            index = listView.SelectedIndex;
        }

        if (listView.Items.Count > index) { 
            listView.SelectedIndex= index;
            listView.ScrollIntoView(listView.SelectedItem); 
        }
                              
    }catch (Exception ex){
        MessageBox.Show("moveToNextRow Exception: " + ex.Message);
    }
}

public
void loadListView(IEnumerable objectCollection){
    listView.DataContext=null;
    setDataContextListView(listView,objectCollection);
}

}
}
