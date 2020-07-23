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
class RadMaskedTextInputColumnListView : ColumnListView {

public
RadMaskedTextInputColumnListView(string title,string bindName,BindingMode bindingMode,int with,ListView listView)
    : base(title,bindName,bindingMode,with,typeof(RadMaskedTextInput), RadMaskedTextInput.TextProperty,listView) {
    if (with > 0)
        setProperty(RadMaskedTextInput.WidthProperty,(double)with);
}


}
}
