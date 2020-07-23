using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using NujitWPFUtilities;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Common;
using System.Windows.Media;


namespace Nujit.NujitWms.WinForms.Util.Grids {

public
class ButtonColumnListView : ColumnListView{

public
ButtonColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,typeof(Button), Button.ContentProperty, listView) {
    setProperty(Button.WidthProperty,(double)with); 
    //setProperty(Button.HeightProperty,(double)20);        
            
    setProperty(Button.FontWeightProperty, FontWeights.UltraBold);            
    setProperty(Button.MinHeightProperty, (double)10);
    setProperty(Button.HeightProperty, (double)17);
    setProperty(Button.FontSizeProperty, (double)11.5);
    setProperty(Button.PaddingProperty, new Thickness(0));        
    setProperty(Button.FontFamilyProperty,new FontFamily(Nujit.NujitERP.ClassLib.Common.Constants.FONT_FAMILY_ARIALBLACK));              
}


}
}
