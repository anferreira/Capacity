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
using Nujit.NujitWms.WinForms.Util.Grids;

namespace HotListReports.Windows.Util.Columns{

public
class TextNumericNewColumnListView : TextBlockColumnListView{

public
TextNumericNewColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,listView) {
      
}


}
}
