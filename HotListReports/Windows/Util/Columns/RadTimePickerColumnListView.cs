using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using NujitWPFUtilities;
using Nujit.NujitWms.WinForms.Util.Grids;
using Telerik.Windows.Controls;

namespace HotListReports.Windows.Util{

public
class RadTimePickerColumnListView : ColumnListView {

public
RadTimePickerColumnListView(string title,string bindName,BindingMode bindingMode,int with,ListView listView)
    : base(title,bindName,bindingMode,with,typeof(RadTimePicker), RadTimePicker.SelectedTimeProperty,listView) {
    if (with > 0)
        setProperty(RadTimePicker.WidthProperty,(double)with);
}

public
void setProperty(DependencyProperty dependencyProperty, object obj){    
    base.setProperty(dependencyProperty, obj);
}

public
void removeEvent(RoutedEvent routedEvent, Delegate handler){
    frameworkElementFactory.RemoveHandler(routedEvent, handler);
}

}
}
