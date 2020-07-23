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


namespace HotListReports.Windows.Boms{



class BomModel : BaseModel2{

public BomModel(Window window) : base(window){    
}

 

public
void loadColumnsOnListView(ListView listView){
  try {
    GridView                gridView = new GridView();
    TextBlockColumnListView textBlockColumnListView = null;
    Style                   cell = new Style(typeof(GridViewColumnHeader));
    cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));                                                                         

    textBlockColumnListView = new TextBlockColumnListView("Part", "Prod", BindingMode.OneWay,150, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());

    textBlockColumnListView = new TextBlockColumnListView("Level", "Level", BindingMode.OneWay,60, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());
        
    textBlockColumnListView = new TextBlockColumnListView("Purch", "Purchased", BindingMode.OneWay,60, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());        
                
    textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    gridView.Columns.Add(textBlockColumnListView.process());        
                                                    
    textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,40, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());                                       
          
    listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnListView Exception: " + ex.Message);        
    }
}

public
void loadBomView2(ListView listView,Bom bom){
    try {         
        int     imaxLevel = 0;
        bom.getMaxLevel(bom,ref imaxLevel);
        createListViewColumns(listView, imaxLevel);

        GridView                view = (GridView)listView.View;
        double                  dcornerRadius = 6;        
        double                  dheight =20;
        double                  dfonSize =12;        
        FontWeight              fontWeight = FontWeights.UltraBold;        
        ListViewCol             listViewCol = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty, dfonSize));
        Setter          textAlignSetter = new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        cell.Setters.Add(textAlignSetter);
                                
        BomPartBig  bomPartBig = new BomPartBig();
        string      sline = "";
        Color       color = UIColors.COLOR_SELECT;


        List<BomPartBig> bigList = new List<BomPartBig>();

        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
                                
            BomContainer bomCurrContainer = new BomContainer();
            bom.getFromLevel(bom, (i+1), bomCurrContainer);

            listViewCol = new ListViewCol();

            column.Header = "Level " + (i+1);
            column.Width = 180;
            column.HeaderContainerStyle = cell;                                
            BomPart bomPart = new BomPart();

            for (int j=0; j < bomCurrContainer.Count && j < 50; j++){
                listViewCol.addTextBlock("Part"+(j+1), 180,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,color);

                Bom bomChild = (Bom)bomCurrContainer[j];
                sline = StringUtil.AddChar("Pa:"   + bomChild.Prod,' ',20,true) + 
                        StringUtil.AddChar(" Seq:" + bomChild.Seq.ToString(),' ',10,true);

                switch (j+1){
                    case 1:   bomPart.Part1 =  sline; break;
                    case 2:   bomPart.Part2 =  sline; break;
                    case 3:   bomPart.Part3 =  sline; break;
                    case 4:   bomPart.Part4 =  sline; break;
                    case 5:   bomPart.Part5 =  sline; break;
                    case 6:   bomPart.Part6 =  sline; break;
                    case 7:   bomPart.Part7 =  sline; break;
                    case 8:   bomPart.Part8 =  sline; break;
                    case 9:   bomPart.Part9 =  sline; break;
                    case 10:  bomPart.Part10 =  sline; break;

                    case 11:   bomPart.Part11 =  sline; break;
                    case 12:   bomPart.Part12 =  sline; break;
                    case 13:   bomPart.Part13 =  sline; break;
                    case 14:   bomPart.Part14 =  sline; break;
                    case 15:   bomPart.Part15 =  sline; break;
                    case 16:   bomPart.Part16 =  sline; break;
                    case 17:   bomPart.Part17 =  sline; break;
                    case 18:   bomPart.Part18 =  sline; break;
                    case 19:   bomPart.Part19 =  sline; break;
                    case 20:   bomPart.Part20 =  sline; break;

                    case 21:   bomPart.Part21 =  sline; break;
                    case 22:   bomPart.Part22 =  sline; break;
                    case 23:   bomPart.Part23 =  sline; break;
                    case 24:   bomPart.Part24 =  sline; break;
                    case 25:   bomPart.Part25 =  sline; break;
                    case 26:   bomPart.Part26 =  sline; break;
                    case 27:   bomPart.Part27 =  sline; break;
                    case 28:   bomPart.Part28 =  sline; break;
                    case 29:   bomPart.Part29 =  sline; break;
                    case 30:   bomPart.Part30 =  sline; break;

                    case 31:   bomPart.Part31 =  sline; break;
                    case 32:   bomPart.Part32 =  sline; break;
                    case 33:   bomPart.Part33 =  sline; break;
                    case 34:   bomPart.Part34 =  sline; break;
                    case 35:   bomPart.Part35 =  sline; break;
                    case 36:   bomPart.Part36 =  sline; break;
                    case 37:   bomPart.Part37 =  sline; break;
                    case 38:   bomPart.Part38 =  sline; break;
                    case 39:   bomPart.Part39 =  sline; break;
                    case 40:   bomPart.Part40 =  sline; break;

                    case 41:   bomPart.Part41 =  sline; break;
                    case 42:   bomPart.Part42 =  sline; break;
                    case 43:   bomPart.Part43 =  sline; break;
                    case 44:   bomPart.Part44 =  sline; break;
                    case 45:   bomPart.Part45 =  sline; break;
                    case 46:   bomPart.Part46 =  sline; break;
                    case 47:   bomPart.Part47 =  sline; break;
                    case 48:   bomPart.Part48 =  sline; break;
                    case 49:   bomPart.Part49 =  sline; break;
                    case 50:   bomPart.Part50 =  sline; break;
                }
                                
            }   

            switch(i+1){
                case 1:   bomPartBig.BomPart1 = bomPart; color = Colors.Goldenrod; break;
                case 2:   bomPartBig.BomPart2 = bomPart; color = Colors.Peru; break;
                case 3:   bomPartBig.BomPart3 = bomPart; color = Colors.SandyBrown; break;
                case 4:   bomPartBig.BomPart4 = bomPart; color = Colors.Tan; break;
                case 5:   bomPartBig.BomPart5 = bomPart; color = Colors.Wheat; break;
                case 6:   bomPartBig.BomPart6 = bomPart; color = Colors.LightGoldenrodYellow; break;                         
                case 7:   bomPartBig.BomPart7 = bomPart; color = UIColors.COLOR_SELECT; break;
                case 8:   bomPartBig.BomPart8 = bomPart; color = Colors.Goldenrod; break;
                case 9:   bomPartBig.BomPart9 = bomPart; color = Colors.Peru; break;
                case 10:  bomPartBig.BomPart10= bomPart; color = Colors.SandyBrown; break;    
            }
            
            column.CellTemplate = listViewCol.getDataTemplate("BomPart"+(i+1), dcornerRadius,1,Colors.Silver);                                             
            
        }    
        bigList.Add(bomPartBig);

        setDataContextListView(listView, bigList);


    } catch (Exception ex) {
        MessageBox.Show("rewriteBomListView Exception: " + ex.Message);        
    }
}

public class BomPart{
    public string Part1 { get; set; }
    public string Part2 { get; set; }
    public string Part3 { get; set; }
    public string Part4 { get; set; }
    public string Part5 { get; set; }
    public string Part6 { get; set; }
    public string Part7 { get; set; }
    public string Part8 { get; set; }
    public string Part9 { get; set; }
    public string Part10 { get; set; }


    public string Part11 { get; set; }
    public string Part12 { get; set; }
    public string Part13 { get; set; }
    public string Part14 { get; set; }
    public string Part15 { get; set; }
    public string Part16 { get; set; }
    public string Part17 { get; set; }
    public string Part18 { get; set; }
    public string Part19 { get; set; }
    public string Part20 { get; set; }


    public string Part21 { get; set; }
    public string Part22 { get; set; }
    public string Part23 { get; set; }
    public string Part24 { get; set; }
    public string Part25 { get; set; }
    public string Part26 { get; set; }
    public string Part27 { get; set; }
    public string Part28 { get; set; }
    public string Part29 { get; set; }
    public string Part30 { get; set; }

    public string Part31 { get; set; }
    public string Part32 { get; set; }
    public string Part33 { get; set; }
    public string Part34 { get; set; }
    public string Part35 { get; set; }
    public string Part36 { get; set; }
    public string Part37 { get; set; }
    public string Part38 { get; set; }
    public string Part39 { get; set; }
    public string Part40 { get; set; }

    public string Part41 { get; set; }
    public string Part42 { get; set; }
    public string Part43 { get; set; }
    public string Part44 { get; set; }
    public string Part45 { get; set; }
    public string Part46 { get; set; }
    public string Part47 { get; set; }
    public string Part48 { get; set; }
    public string Part49 { get; set; }
    public string Part50 { get; set; }

}

public class BomPartBig{    
    public BomPart BomPart1 { get; set; }
    public BomPart BomPart2 { get; set; }    
    public BomPart BomPart3 { get; set; }
    public BomPart BomPart4 { get; set; }  
    public BomPart BomPart5 { get; set; }
    public BomPart BomPart6 { get; set; }    
    public BomPart BomPart7 { get; set; }
    public BomPart BomPart8 { get; set; }  
    public BomPart BomPart9 { get; set; }
    public BomPart BomPart10 { get; set; }  
 
}

public
void loadBomView1(ListView listView,Bom bom,string splant){
    try { 
        BomContainer    sumBomContainer = new BomContainer();
        BomContainer    currBomContainer = new BomContainer();
        Bom             bomChild = null;
        HotListHdr      hotListHdr = getCoreFactory().readLastHotList(splant);

        if (bom != null){            

            int     imaxLevel = 0;
            bom.getMaxLevel(bom,ref imaxLevel);
                    
            for (int i=1; i <= imaxLevel; i++){
                currBomContainer.Clear();
                bom.getFromLevel(bom,i,currBomContainer);
                sumBomContainer.AddRange(currBomContainer);
                        
                        /*
                for (int j=0; hotListHdr!= null && j < currBomContainer.Count; j++){
                    bomChild = (Bom) currBomContainer[j];
                    HotListContainer hotListContainer = getCoreFactory().readHotListByFiltersWeekly(hotListHdr.Id, hotListHdr.Plant,"","","",0, bomChild.Prod, bomChild.Seq,"",true,true,1);
                }*/
            }
        }

        setDataContextListView(listView, sumBomContainer);            

    } catch (Exception ex) {
        MessageBox.Show("loadBomView Exception: " + ex.Message);        
    }
}


}
}
