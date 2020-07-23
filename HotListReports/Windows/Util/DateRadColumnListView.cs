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
class DateRadColumnListView : ColumnListView {

public
DateRadColumnListView(string title,string bindName,BindingMode bindingMode,int with,ListView listView)
    : base(title,bindName,bindingMode,with,typeof(RadDateTimePicker), RadDateTimePicker.SelectedDateProperty,listView) {
    if (with > 0)
        setProperty(RadDateTimePicker.WidthProperty,(double)with);

    //setEvent(TextBlock.GotFocusEvent, new RoutedEventHandler(TextBlock_GotFocus));
}

public
void TextBlock_GotFocus(object sender, RoutedEventArgs args){
    TextBlock textBlock = (TextBlock)sender;

    if ((textBlock.DataContext != null) && (this.listView != null)){
        listView.SelectedItem = textBlock.DataContext;
    }
}

public
void setProperty(DependencyProperty dependencyProperty, object obj){
    if (dependencyProperty == TextBlock.TextAlignmentProperty)
        setProperty(TextBlock.WidthProperty,base.width);

    base.setProperty(dependencyProperty, obj);
}

public
void removeEvent(RoutedEvent routedEvent, Delegate handler){
    frameworkElementFactory.RemoveHandler(routedEvent, handler);
}

}
}
