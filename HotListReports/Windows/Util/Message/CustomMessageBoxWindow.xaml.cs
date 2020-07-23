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
using System.Timers;

namespace HotListReports.Windows.Util.Message{

/// <summary>
/// Interaction logic for CustomMessageBoxWindow.xaml
/// </summary>
public partial 
class CustomMessageBoxWindow : Window{

private string  smessage;
private int     itimer;

private System.Timers.Timer otimer;

public CustomMessageBoxWindow(string smessage,int itimer){
    InitializeComponent();

    this.smessage = smessage;
    this.itimer = itimer;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){
    this.msgTextBox.Text=smessage;
    setTimer();
}

private 
void setTimer(){  
    try{
        otimer = new System.Timers.Timer(itimer);
        otimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);    
        otimer.Enabled=true;    

    }catch (Exception ex){
        MessageBox.Show("setTimer Exception: " + ex.Message);
    }
}

private void OnTimedEvent(object source, ElapsedEventArgs e){    
    ok();
}

private void okButton_Click(object sender, EventArgs e){
    ok();
}

private void ok(){
    try { 
        if (otimer != null){
            otimer.Stop();
            otimer.Dispose();
            otimer = null;
        }
        Close();

    }catch (Exception ex){
        MessageBox.Show("ok Exception: " + ex.Message);
    }
}

}
}
