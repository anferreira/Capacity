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
        public decimal Net { get; set; }

        public
        string SDate {
	        get { return DateUtil.getDateRepresentation(Date,DateUtil.MMDDYYYY).Substring(0,5);}
	        set { 
	        }
        }
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

    for (int i=0; i < 14; i++) {         
        initialize(mon);
        mon = mon.AddDays(7);
        DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);    
    }

    model.screenFullArea();
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
    double                  dwith =95;
    double                  dwithMin = dwith / 3;
    double                  dheight =25;
    double                  dheightMin =5;
    double                  dfonSize =10;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewCol             listViewCol = null;
    System.Windows.FrameworkElementFactory frameworkElement = null;
    TextBox                 textBox = new TextBox();
    TextBlock               textBlock = new TextBlock();
    Border                  border = null;

    ListViewCol listViewCol2 = new ListViewCol();

    ColumnO c = new ColumnO();
    c.Date = date;
    c.Day = "Monday";
    c.TotDirect = 12 * date.Day;
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
    c.Net   = c.TotDirect - c.Total;

    Binding bind = new Binding("Date");

    StackPanel newStackPanel= new StackPanel();
    
    StackPanel col = new StackPanel();
    col.HorizontalAlignment = HorizontalAlignment.Left;
               
    textBox= new TextBox();
    textBox.Height= dheight;
    textBox.Width = dwith;
    textBox.IsReadOnly=true;
    bind = new Binding("SDate");
    //bind.Converter = new DateTimeToStringConverter();
    //bind.ConverterParameter = "Date";
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    textBox.VerticalAlignment = VerticalAlignment.Center;
    textBox.FontWeight = fontWeight;
    textBox.Background = new SolidColorBrush(Colors.Lavender);
    col.Children.Add(addBorder(textBox));
 
    textBox= new TextBox();
    textBox.Height= dheight;
    textBox.Width = dwith;
    textBox.IsReadOnly=true;
    bind = new Binding("Day");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    textBox.FontWeight = fontWeight;
    textBox.Background = new SolidColorBrush(Colors.Lavender);
    col.Children.Add(addBorder(textBox));
    
    textBox= new TextBox();
    textBox.Height= dheight;
    textBox.Width = dwith;
    textBox.IsReadOnly = true;
    bind = new Binding("TotDirect");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    textBox.FontWeight = fontWeight;
    col.Children.Add(addBorder(textBox));

    Label lab= new Label();
    lab.Height= dheight;
    lab.Width = dwith;
    lab.FontWeight = FontWeights.UltraBold;
    lab.Height     = dheightMin;    
    lab.Content = "";       
    lab.VerticalContentAlignment = VerticalAlignment.Center;
    textBox.TextAlignment = TextAlignment.Left;
    lab.Foreground = new SolidColorBrush(Colors.White);
    lab.Background = new SolidColorBrush(Colors.Lavender);
    col.Children.Add(lab);

    StackPanel subcol = new StackPanel();            
    subcol.Orientation = Orientation.Horizontal;    

    for (int i=0; i < 3; i++) {       
        textBox= new TextBox();
        textBox.Height= dheight;
        textBox.Width = dwithMin;
        textBox.IsReadOnly=true;
        bind = new Binding("Shift" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Center;
        textBox.FontSize = dfonSize;
        textBox.FontWeight = fontWeight;
        subcol.Children.Add(addBorder(textBox));
    }

    StackPanel subcol2 = new StackPanel();            
    subcol2.Orientation = Orientation.Horizontal;

    for (int i=0; i < 3; i++) { 
        textBox= new TextBox();
        textBox.Height= dheight;
        textBox.Width = dwithMin;
        bind = new Binding("DShift" + (i+1).ToString());
        bind.Converter = new DecimalToStringConverterNew();
        bind.ConverterParameter = "int";
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Right;
        textBox.FontSize = dfonSize;
        textBox.FontWeight = fontWeight;
        textBlock.FontFamily = new FontFamily("Segeoe UI");
        subcol2.Children.Add(textBox);
    }

    StackPanel subcol3 = new StackPanel();            
    subcol3.Orientation = Orientation.Horizontal;

    for (int i=0; i < 3; i++) { 
        textBox= new TextBox();
        textBox.Height= dheight;
        textBox.Width = dwithMin;
        textBox.IsReadOnly=true;
        bind = new Binding("ActiveNet" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Right;
        textBox.FontSize = dfonSize;
        textBox.FontWeight = fontWeight;
        subcol3.Children.Add(addBorder(textBox));
    }

    StackPanel subsubcol = new StackPanel();    
    textBox= new TextBox();
    textBox.Height= dheight;
    textBox.Width = dwith;
    textBox.IsReadOnly=true;
    bind = new Binding("Total");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    textBox.Background = new SolidColorBrush(Colors.Lavender);
    textBox.FontWeight = fontWeight;
    subsubcol.Children.Add(addBorder(textBox));

    lab= new Label();
    lab.Height= dheight;
    lab.Width = dwith;
    lab.FontWeight = FontWeights.UltraBold;
    lab.Height     = dheightMin;    
    lab.Content = "";       
    lab.VerticalContentAlignment = VerticalAlignment.Center;    
    lab.Foreground = new SolidColorBrush(Colors.White);
    lab.Background = new SolidColorBrush(Colors.White);
    subsubcol.Children.Add(addBorder(lab));

    textBox= new TextBox();
    textBox.Height= dheight;
    textBox.Width = dwith;
    textBox.IsReadOnly=true;
    bind = new Binding("Net");
    textBox.SetBinding(TextBox.TextProperty,bind);
    textBox.TextAlignment = TextAlignment.Center;
    textBox.Background = new SolidColorBrush(Colors.Lavender);
    textBox.FontWeight = fontWeight;
    subsubcol.Children.Add(addBorder(textBox));
                                      
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
    double                  dwith =56;
    double                  dwith2=55;
    double                  dheight =23;
    double                  dheightMin =5;
    double                  dfonSize =10.5;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewCol             listViewCol = null;
    System.Windows.FrameworkElementFactory frameworkElement = null;
    TextBox                 textBox = new TextBox();
    TextBlock               textBlock = new TextBlock();

    ListViewCol listViewCol2 = new ListViewCol();

    StackPanel new2StackPanel = new StackPanel();
    Label lab= new Label();
    lab.Width = dwith;
    lab.FontWeight = FontWeights.UltraBold;
    lab.Height     = 50;    
    lab.Content = "Capacity" + "\n" +"Required";       
    lab.VerticalContentAlignment = VerticalAlignment.Center;
    textBox.TextAlignment = TextAlignment.Left;
    lab.FontSize = dfonSize;
    lab.Foreground = new SolidColorBrush(Colors.White);
    lab.Background = new SolidColorBrush(Colors.CornflowerBlue);
    new2StackPanel.Children.Add(lab);

    lab= new Label();
    lab.Width = dwith;
    lab.FontWeight = FontWeights.UltraBold;
    lab.Height     = 145;    
    lab.Content = "Current" + "\n" + "Labour";
    lab.VerticalContentAlignment = VerticalAlignment.Center;
    textBox.TextAlignment = TextAlignment.Left;
    lab.Foreground = new SolidColorBrush(Colors.White);
    lab.Background = new SolidColorBrush(Colors.CornflowerBlue);
    lab.FontSize = dfonSize;
    new2StackPanel.Children.Add(lab);
    
    lab= new Label();
    lab.Width = dwith;
    lab.FontWeight = FontWeights.UltraBold;
    lab.Height     = 31;    
    lab.Content = "Net Calc";           
    lab.VerticalContentAlignment = VerticalAlignment.Center;
    textBox.TextAlignment = TextAlignment.Left;
    lab.FontSize = dfonSize;
    lab.Foreground = new SolidColorBrush(Colors.White);
    lab.Background = new SolidColorBrush(Colors.CornflowerBlue);
    new2StackPanel.Children.Add(lab);
    mainStack.Children.Add(new2StackPanel);


    Binding bind = new Binding("Title1");
    StackPanel newStackPanel= new StackPanel();

    CellTitles c = new CellTitles();
    
    c.Title1 = "Week#";
    c.Title2 = "";
    c.Title3 = "TotDire." + "\n" +"Labour";
    c.Title4 = "Shift";
    c.Title5 = "Actual";
    c.Title6 = "Active" + "\n"+"Net";
    c.Title7 = "Totals";
    c.Title8 = "Net";

    for (int i=0; i <= 7 ; i++){
        if (i == 3 || i== 7){
            lab= new Label();
            lab.Width = dwith2;
            lab.FontWeight = FontWeights.UltraBold;
            lab.Height     = dheightMin;    
            lab.Content = "";           
            lab.VerticalContentAlignment = VerticalAlignment.Center;            
            lab.FontSize = dfonSize;
            lab.Foreground = new SolidColorBrush(Colors.White);

            if (i == 7)
                lab.Background = new SolidColorBrush(Colors.White);
            else
                lab.Background = new SolidColorBrush(Colors.Lavender);
            newStackPanel.Children.Add(lab);                  
        }

        textBox= new TextBox();
        textBox.Height= dheight;
        textBox.Width = dwith2;
        textBox.IsReadOnly=true;
        bind = new Binding("Title" + (i+1).ToString());
        textBox.SetBinding(TextBox.TextProperty,bind);
        textBox.TextAlignment = TextAlignment.Left;
        textBox.VerticalAlignment = VerticalAlignment.Center;
        textBox.FontWeight = fontWeight;                
        textBox.FontSize = dfonSize;        
        if ( i == 2 || i == 5)
             textBox.FontSize = dfonSize-1;        
        textBox.Foreground = new SolidColorBrush(Colors.Black);
        textBox.FontFamily = new FontFamily("Segeoe UI");
        if (i >=6)
            textBox.Background = new SolidColorBrush(Colors.Lavender);

        newStackPanel.Children.Add(addBorder(textBox));
    }
    
    mainStack.Children.Add(newStackPanel);
    newStackPanel.DataContext = c;    
}

 private 
void checkButt_Click(object sender, RoutedEventArgs e){
    arrayV=arrayV;

}

private
Border addBorder(TextBlock textBlock){
    Border border = new Border();    
    border.Child = textBlock;
    border.Width = textBlock.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(0.5);
    border.VerticalAlignment = VerticalAlignment.Center;
    return border;                
}

private
Border addBorder(TextBox textBox){
    Border border = new Border();    
    border.Child = textBox;
    border.Width = textBox.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(0.5);
    border.VerticalAlignment = VerticalAlignment.Center;
    border.FocusVisualStyle = null;
    return border;                
}

private
Border addBorder(Label label){
    Border border = new Border();    
    border.Child = label;
    border.Width = label.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(0.5);
    border.VerticalAlignment = VerticalAlignment.Center;
    return border;                
}

}
}
