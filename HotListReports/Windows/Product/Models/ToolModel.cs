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



namespace HotListReports.Windows.Products{

class ToolModel : BaseModel2{

public ToolModel(Window window) : base(window){    
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    searchByComboBox.Items.Add("Company");
    searchByComboBox.Items.Add("Plant");
    searchByComboBox.Items.Add("Tool");        
    searchByComboBox.Items.Add("Description");        
        
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}
        
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id","[0]", BindingMode.OneWay,60, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Company","[2]", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant","[3]", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Toool","[4]", BindingMode.OneWay,90, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1","[5]", BindingMode.OneWay,180, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 2","[6]", BindingMode.OneWay,180, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 3","[7]", BindingMode.OneWay,180, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void removeLabTool(Routing routing,ListView dtlListView){
    try {
        RoutingLabTool routingLabTool = (RoutingLabTool)this.deleltedSelected(dtlListView);

        if (routingLabTool!=null){
            routing.RoutingLabToolContainer.Remove(routingLabTool);
            save(routing);
        }

    } catch (Exception ex) {
        MessageBox.Show("removeLabTool Exception: " + ex.Message);        
    }
}

public
RoutingLabTool addModifyLabTool(Routing routing,RoutingLabTool routingLabToolNew,string sdesc,bool baddDtl){    
    RoutingLabTool routingLabTool = null;
    try {        
        if (routing!= null && routingLabToolNew != null){
            routingLabToolNew.NameShow = sdesc;            
            if (baddDtl){
                routingLabTool = routingLabToolNew;
                routing.RoutingLabToolContainer.Add(routingLabTool);         
            }else{
                routingLabTool = routing.RoutingLabToolContainer.getByKey(routingLabToolNew.HdrId, routingLabToolNew.Detail);//find original object
                if (routingLabTool!=null)
                    routingLabTool.copy(routingLabToolNew); //copy from cloned object                    
                else
                    MessageBox.Show("Sorry, Can Not Find LabourTool :" + routingLabToolNew.HdrId + "/" +  routingLabToolNew.Detail);
            }
                
        }
    } catch (Exception ex) {
        MessageBox.Show("addModifyLabTool Exception: " + ex.Message);        
    }
    return routingLabTool;
}

public
void save(Routing routing){
    try{
        routing.fillRedundances();
        getCoreFactory().updateRouting(routing);                    

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}


}
}
