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
class TextNumericNewColumnListView : TextColumnListView{

public
TextNumericNewColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,listView) {
    
    setProperty(TextBox.FontWeightProperty, FontWeights.UltraBold);            
    setProperty(TextBox.MinHeightProperty, (double)10);
    setProperty(TextBox.HeightProperty, (double)17);
    setProperty(TextBox.FontSizeProperty, (double)11.25);
    setProperty(TextBox.PaddingProperty, new Thickness(0));    
    setProperty(TextBox.IsReadOnlyProperty,true);
    setProperty(TextBox.TextAlignmentProperty, TextAlignment.Right);
    setProperty(TextBox.FontFamilyProperty,new FontFamily(Nujit.NujitERP.ClassLib.Common.Constants.FONT_FAMILY_ARIALBLACK));         
}


}
}
