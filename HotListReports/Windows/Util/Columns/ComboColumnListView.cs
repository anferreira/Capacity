using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using NujitWPFUtilities;

namespace Nujit.NujitWms.WinForms.Util.Grids {

public
class ComboColumnListView: ColumnListView {

public
ComboColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,typeof(ComboBox),ComboBox.SelectedValueProperty, listView) {
    if (with > 0)
        setProperty(ComboBox.WidthProperty,(double)with);

    setProperty(ComboBox.SelectedValuePathProperty, "Content");
    setProperty(ComboBox.DisplayMemberPathProperty, "Display");
            
    //setEvent(TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
}

/*
public
void TextBox_GotFocus(object sender, RoutedEventArgs args){
    TextBox textBox = (TextBox)sender;

    if ((textBox.DataContext != null) && (this.listView != null)){
        listView.SelectedItem = textBox.DataContext;
    }
}*/

}
}
