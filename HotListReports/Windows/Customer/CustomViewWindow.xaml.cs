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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Customers{

/// <summary>
/// Interaction logic for CustomViewWindow.xaml
/// </summary>
public partial 
class CustomViewWindow : Window{

private CustomViewModel model;
private UpCum01PView    upCum01PView;

public CustomViewWindow(UpCum01PView upCum01PView){
    InitializeComponent();

    model = new CustomViewModel(this);
    this.upCum01PView = upCum01PView;
}


private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {                        
        this.DataContext = upCum01PView;      

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{         
    }
}




}
}
