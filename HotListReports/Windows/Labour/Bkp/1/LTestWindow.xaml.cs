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
using HotListReports.Windows.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitWms.WinForms.Util.Converters;

namespace HotListReports.Windows.Labour{
    /// <summary>
    /// Interaction logic for LTestWindow.xaml
    /// </summary>
    /// 

  public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
    }

     public class MachPart
    {
        public string Part { get; set; }

        public int Seq { get; set; }

        public string Desc { get; set; }

        public Def Def1 { get; set; }
        public Def Def2 { get; set; }
        public Def Def3 { get; set; }

        public Titles Titles { get; set; }
    }

    public class Def
    {        
        public decimal Plan { get; set; }

        public decimal Req { get; set; }
        public decimal Net { get; set; }
    }

    public class Titles
    {
        public string Title1 { get; set; }

        public string Title2 { get; set; }
        public string Title3 { get; set; }
    }


    public class ColumnO
    {
        public DateTime  Date { get; set; }
        public string Day { get; set; }

        public int TotDirect { get; set; }

        public string Shift1 { get; set; }
        public string Shift2 { get; set; }
        public string Shift3 { get; set; }

        public decimal DShift1 { get; set; }
        public decimal DShift2 { get; set; }
        public decimal DShift3 { get; set; }

        public decimal ActiveNet1 { get; set; }
        public decimal ActiveNet2 { get; set; }
        public decimal ActiveNet3 { get; set; }

        public decimal Total { get; set; }
    }


public partial 
class LTestWindow : Window{

private ReportTypeViewsModel model;

ArrayList arrayV = new ArrayList();


public LTestWindow()    {
    InitializeComponent();

    model = new ReportTypeViewsModel(this);
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    mainStack.Orientation = Orientation.Horizontal;
    titles();

    DateTime mon = DateTime.Now;
    DateTime sun = DateTime.Now;

    DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);
    initialize(mon);
    mon = mon.AddDays(7);
    DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);
    initialize(mon);
}
       /*
private 
void initialize(){
    model.createListViewColumns(testListView,2);
    GridView                view = (GridView)testListView.View;        
    string                  sweek ="";
    string                  space ="   ";
    double                  dcornerRadius = 6;
    double                  dwith =60;
    double                  dheight =20;
    double                  dfonSize =12;
    string                  sbindPanel = "";
    int                     icolumnIndex = 3;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewCol             listViewCol = null;
    System.Windows.FrameworkElementFactory frameworkElement = null;

    for (int i=0; i < view.Columns.Count;i++){
        GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        listViewCol = new ListViewCol();    

        if (i == 0) { 
            column.Header = "Part";  
            listViewCol.addTextBlock("Part",100,80,dfonSize,fontWeight,TextAlignment.Left, Colors.Black, Colors.Gray);
            sbindPanel = "Part";
        }else { 
            column.Header = "Multiples";  
            frameworkElement = listViewCol.addStackPanel("Def1", 200,60, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.Gray);

            frameworkElement.SetValue(StackPanel.OrientationProperty,Orientation.Horizontal);

            ListViewCol listViewCol2 = new ListViewCol();            
    
            //frameworkElement.AppendChild(listViewCol2.addTextBlock("Plan",60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));
            //frameworkElement.AppendChild(listViewCol2.addTextBlock("Req", 60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));
            //frameworkElement.AppendChild(listViewCol2.addTextBlock("Net", 60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));

            frameworkElement.AppendChild(listViewCol2.addTextBox("Plan",false,true,60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));
            frameworkElement.AppendChild(listViewCol2.addTextBox("Req",false,true,60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));
            frameworkElement.AppendChild(listViewCol2.addTextBox("Net",false,true,60, 60, 12, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray));
          
            
           
            sbindPanel = "Def1";
            //listViewCol2.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);
            
        }
        column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver); 
    }

    ArrayList array= new ArrayList();
    MachPart m = new MachPart();

    m.Part="P1";
    m.Def1 = new Def();
    m.Def1.Plan=11;m.Def1.Req=23;
    array.Add(m);

    m = new MachPart();
    m.Part="P2";
    m.Def1 = new Def();
    m.Def1.Plan=22;m.Def1.Req=33;
    array.Add(m);

    testListView.DataContext = array;
    testListView.ItemsSource = array;     
    
    //frameworkElement.SetValue(ListView.co)

}

        */
            
private 
void initialize(DateTime date){
    //GridView                view = (GridView)testListView.View;        
    string                  sweek ="";
    string                  space ="   ";
    double                  dcornerRadius = 6;
    double                  dwith =60;
    double                  dheight =20;
    double                  dfonSize =12;
    string                  sbindPanel = "";
    int                     icolumnIndex = 3;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewCol             listViewCol = null;
    System.Windows.FrameworkElementFactory frameworkElement = null;
    TextBox                 textBox = new TextBox();

    ListViewCol listViewCol2 = new ListViewCol();

    ColumnO c = new ColumnO();
    c.Date = date;
    c.Day = "Monday";
    c.TotDirect = 128;
    c.Shift1 = "1";
    c.Shift2 = "2";
    c.Shift3 = "3";

    c.DShift1 = date.Day * 3;
    c.DShift2 = date.Day * 4;
    c.DShift3 = date.Day * 7; 

    c.ActiveNet1 = c.DShift1;
    c.ActiveNet2 = c.DShift2;
    c.ActiveNet3 = c.DShift3;

    c.Total = c.ActiveNet1 + c.ActiveNet2 + c.ActiveNet3;

    Binding bind = new Binding("Date");

    StackPanel newStackPanel= new StackPanel();
    
    StackPanel col = new StackPanel();
    col.HorizontalAlignment = HorizontalAlignment.Left;
    
    textBox= new TextBox();
    textBox.Width = 180;
    bind.Converter = new DateTimeToStringConverter();
    bind.ConverterParameter = "Date";
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    col.Children.Add(textBox);

    textBox= new TextBox();
    textBox.Width = 180;
    bind = new Binding("Day");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    col.Children.Add(textBox);

    textBox= new TextBox();
    textBox.Width = 180;    
    textBox.IsEnabled=false;
    bind = new Binding("TotDirect");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    col.Children.Add(textBox);

    StackPanel subcol = new StackPanel();            
    subcol.Orientation = Orientation.Horizontal;    

    for (int i=0; i < 3; i++) { 
        textBox= new TextBox();
        textBox.Width = 60;
        textBox.IsEnabled=false;
        bind = new Binding("Shift" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Center;
        subcol.Children.Add(textBox);
    }

    StackPanel subcol2 = new StackPanel();            
    subcol2.Orientation = Orientation.Horizontal;

    for (int i=0; i < 3; i++) { 
        textBox= new TextBox();
        textBox.Width = 60;
        bind = new Binding("DShift" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Center;
        subcol2.Children.Add(textBox);
    }

    StackPanel subcol3 = new StackPanel();            
    subcol3.Orientation = Orientation.Horizontal;

    for (int i=0; i < 3; i++) { 
        textBox= new TextBox();
        textBox.Width = 60;
        textBox.IsEnabled=false;
        bind = new Binding("ActiveNet" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Center;
        subcol3.Children.Add(textBox);
    }

    StackPanel subsubcol = new StackPanel();    
    textBox= new TextBox();
    textBox.Width = 180;
    textBox.IsEnabled=false;
    bind = new Binding("Total");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    subsubcol.Children.Add(textBox);
                                      
    newStackPanel.Children.Add(col);
    newStackPanel.Children.Add(subcol);
    newStackPanel.Children.Add(subcol2);
    newStackPanel.Children.Add(subcol3);
    newStackPanel.Children.Add(subsubcol);
    mainStack.Children.Add(newStackPanel);

    newStackPanel.DataContext = c;

    arrayV.Add(c);    
}

private 
void titles(){
    //GridView                view = (GridView)testListView.View;        
    string                  sweek ="";
    string                  space ="   ";
    double                  dcornerRadius = 6;
    double                  dwith =60;
    double                  dheight =20;
    double                  dfonSize =12;
    string                  sbindPanel = "";
    int                     icolumnIndex = 3;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewCol             listViewCol = null;
    System.Windows.FrameworkElementFactory frameworkElement = null;
    TextBox                 textBox = new TextBox();

    ListViewCol listViewCol2 = new ListViewCol();

 
               
    Binding bind = new Binding("Title1");
    StackPanel newStackPanel= new StackPanel();

    CellTitles c = new CellTitles();
    
    c.Title1 = "Week#";
    c.Title2 = "";
    c.Title3 = "Tot Dirrect Labour";
    c.Title4 = "Shift";
    c.Title5 = "Actual";
    c.Title6 = "ActiveNet";
    c.Title7 = "Totals";

    for (int i=0; i < 7 ; i++){
        textBox= new TextBox();
        textBox.Width = 180;
        textBox.IsReadOnly = true;
        textBox.IsEnabled = false;
        textBox.FontWeight = FontWeights.UltraBold;
        textBox.Height= i==0? textBox.Height * 2 : textBox.Height;    
        bind = new Binding("Title" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Center;
        newStackPanel.Children.Add(textBox);
    }

    mainStack.Children.Add(newStackPanel);
    newStackPanel.DataContext = c;    
}

 private 
void checkButt_Click(object sender, RoutedEventArgs e){
    arrayV=arrayV;

}

}
}
