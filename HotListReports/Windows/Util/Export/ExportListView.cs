using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Collections;
using System.Data;

namespace HotListReports.Windows.Util{

class ExportListView{

private ListView listView;

public
ExportListView(ListView listView){
    this.listView= listView;
}

public
string getHeaderValues(){
    int                 i=0;
    GridView            view = (GridView)listView.View;
    string              stotal="";
    string              sline="";
    char                sep =';';
    
                    
    for (i=0; i < view.Columns.Count;i++){
        GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        sline+= ((string)column.Header).Replace("\n","-") + sep;
    }
    stotal = sline+"\n";
    return stotal;
}

public
bool exportToFile(){
    int                 i=0;
    GridView            view = (GridView)listView.View;
    string              stotal="";
    string              sline="";
    char                sep =';';
    
                    
    for (i=0; i < view.Columns.Count;i++){
        GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        sline+= ((string)column.Header).Replace("\n","") + sep;
    }
    stotal = sline+"\n";

    //var lv = listView.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
    foreach(DataRowView drv in this.listView.Items){
     Console.WriteLine(drv[0].ToString());
     Console.WriteLine(drv[1].ToString());
     Console.WriteLine(drv[2].ToString());
     Console.WriteLine(drv[0].ToString());
    }

    for (i=0; i < listView.Items.Count;i++){
        Object obj = listView.Items[i];
        
    }

     foreach (ListViewItem lvi in this.listView.Items)
    {
       DataRowView drv = (DataRowView)lvi.Content;
       string thisRowsValueForColumnName = drv["Part"].ToString();
    }
    foreach (ListViewItem item in listView.Items){        
        
        //textStream.WriteLine("{0},{1},{2},{3},{4}", item1.Text, item1.SubItems[1].Text, item1.SubItems[2].Text, item1.SubItems[3].Text, item1.SubItems[4].Text);
    }
    return true;
}


}
}
