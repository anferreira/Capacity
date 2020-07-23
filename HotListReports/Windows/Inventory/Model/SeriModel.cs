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
using Telerik.Windows.Controls;
using FarsiLibrary.FX.Win.Controls;


namespace HotListReports.Windows.Inventories{


class SeriModel : BaseModel2{

public SeriModel(Window window) : base(window){    
    
}

public
void loadStatus(ComboBox statusComboBox) {
    try{
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
       
        //A,C,H,N,S,V
        string saux="A/H";

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.SHOW_ALL, ""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'A','H'"));

        saux = "A";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,"'" + saux + "'"));
        saux="C";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'" + saux + "'"));
        saux = "H";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'" + saux + "'"));
        saux = "N";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'" + saux + "'"));
        saux = "S";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'" + saux + "'"));
        saux = "V";
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, "'" + saux + "'"));

        statusComboBox.ItemsSource = list;
        statusComboBox.SelectedIndex = 0;

        if (statusComboBox.Items.Count > 1)
            statusComboBox.SelectedIndex = 1;

    } catch (Exception ex) {
       MessageBox.Show("loadStatusByCombo Exception: " + ex.Message);       
    }
}

public
void loadColumnsOnHeaderGrid(ListView listView) {
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                        
        textBlockColumnListView = new TextBlockColumnListView("Serial", "HTSERN", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "HTPART", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "HTSEQ", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Weight", "WEIGHT_SHOW", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;  
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.", "HTQTY", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.Comp.", "HTQTYC", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lot", "HTLOTN", BindingMode.OneWay,90, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Job Num.", "HTJOBN", BindingMode.OneWay,90, listView);
        gridView.Columns.Add(textBlockColumnListView.process());                

        textBlockColumnListView = new TextBlockColumnListView("Sts.", "HTSTS", BindingMode.OneWay,30, listView);
        gridView.Columns.Add(textBlockColumnListView.process());        

        textBlockColumnListView = new TextBlockColumnListView("Uom","HTUNIT", BindingMode.OneWay,40, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Act.Date", "HTADAT", BindingMode.OneWay,70, listView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());


        listView.View = gridView;

    } catch (Exception ex) {
       MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);       
    }
}

      

}
}
