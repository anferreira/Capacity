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
using Nujit.NujitERP.ClassLib.Common;

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

        public
        string SProdWeek {
	        get { return "Wk#" + DateUtil.weekNumber(Date).ToString("00");}
	        set { 
	        }
        }      

        public
        string STitDate {
	        get {
                return SDate + "\n" + SProdWeek;}
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
        initialize(mon,i);
        mon = mon.AddDays(7);
        DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);    
    }

    model.screenFullArea();
}
            
private 
void initialize(DateTime date,int index){    
    double                  dwith       = 95;
    double                  dwithMin    = dwith / 3;
    double                  dheight     = 25;
    double                  dheightMin  = 5;
    double                  dfonSize    = 9.7;
    FontWeight              fontWeight  = FontWeights.UltraBold;        
    ListViewColManual       listViewCol = new ListViewColManual();    
    TextBox                 textBox     = new TextBox();
    Label                   label       = new Label();
    
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
 
    
    StackPanel newStackPanel= listViewCol.createStackPanel();
                 
    //start capacity required                               
    StackPanel colCapacityRequired = listViewCol.createStackPanel();
    textBox = listViewCol.createTextBox("STitDate", true, true, dwith, dheight + 10, 12, fontWeight, TextAlignment.Center, VerticalAlignment.Center, Colors.Black, Colors.Lavender,"Arial");        
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));
 
    textBox =  listViewCol.createTextBox("Day",true,true, dwith, dheight,0, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.Lavender);        
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));
    
    textBox =  listViewCol.createTextBox("TotDirect", true,true, dwith, dheight,0,fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.White,new DecimalToStringConverterNew(),"int","");        
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("","",dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.Lavender);          
    colCapacityRequired.Children.Add(listViewCol.addBorder(label));

    //start shift
    StackPanel stackShiftTitleCol = listViewCol.createStackPanel(Orientation.Horizontal);      //Shift title 1/2/3     
    for (int i=0; i < Constants.MAX_SHIFTS; i++) {       
        textBox =  listViewCol.createTextBox("Shift" + (i + 1).ToString(), true,true, dwithMin, dheight, dfonSize, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.White,Constants.FONT_FAMILY_SEGEOEUI);                        
        stackShiftTitleCol.Children.Add(listViewCol.addBorder(textBox));
    }

    StackPanel stackShiftValuesCol = listViewCol.createStackPanel(Orientation.Horizontal);      //Shift values             
    for (int i=0; i < Constants.MAX_SHIFTS; i++) {       
        textBox =  listViewCol.createTextBox("DShift" + (i + 1).ToString(), true,false, dwithMin, dheight, dfonSize, FontWeights.UltraBlack, TextAlignment.Right, VerticalAlignment.Center,Colors.Black,Colors.White, new DecimalToStringConverterNew(),"int",Constants.FONT_FAMILY_SEGEOEUI);                        
        stackShiftValuesCol.Children.Add(listViewCol.addBorder(textBox));
    }
    
    StackPanel stackShiftActiveCol = listViewCol.createStackPanel(Orientation.Horizontal);      //Active Net
    for (int i=0; i < Constants.MAX_SHIFTS; i++) {       
        textBox =  listViewCol.createTextBox("ActiveNet" + (i + 1).ToString(), true, false, dwithMin, dheight, dfonSize, FontWeights.UltraBlack, TextAlignment.Right,VerticalAlignment.Center,Colors.Black,Colors.White, new DecimalToStringConverterNew(),"int",Constants.FONT_FAMILY_SEGEOEUI);                        
        stackShiftActiveCol.Children.Add(listViewCol.addBorder(textBox));
    }
        
    StackPanel stackTotalsCol = listViewCol.createStackPanel();    //Totals
    textBox =  listViewCol.createTextBox("Total", true,true, dwith, dheight,0, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.Lavender);                    
    stackTotalsCol.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("","",dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.White);          
    stackTotalsCol.Children.Add(listViewCol.addBorder(label));            

    textBox =  listViewCol.createTextBox("Net",true,true, dwith, dheight, 0, fontWeight,TextAlignment.Center,VerticalAlignment.Center,Colors.Black,Colors.Lavender, new DecimalToStringConverterNew(),"int","");  
    stackTotalsCol.Children.Add(listViewCol.addBorder(textBox));
                                      
    newStackPanel.Children.Add(colCapacityRequired);
    newStackPanel.Children.Add(stackShiftTitleCol);
    newStackPanel.Children.Add(stackShiftValuesCol);
    newStackPanel.Children.Add(stackShiftActiveCol);
    newStackPanel.Children.Add(stackTotalsCol);
    mainStack.Children.Add(newStackPanel);

    newStackPanel.DataContext = c;

    arrayV.Add(c);    
}

private 
void titles(){    
    double                  dwith =56;
    double                  dwith2=55;
    double                  dheight =25;
    double                  dheightMin =5;
    double                  dfonSize =10.5;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewColManual       listViewCol = new ListViewColManual();    
    TextBox                 textBox     = null;
    Label                   label       = null;
    
    StackPanel stackPanelLeftCol = listViewCol.createStackPanel();

    label = listViewCol.createLabel("","Capacity" + "\n" + "Required", dwith,50,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.CornflowerBlue);    
    stackPanelLeftCol.Children.Add(label);

    label = listViewCol.createLabel("", "Current" + "\n" + "Labour", dwith,145,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.CornflowerBlue);
    stackPanelLeftCol.Children.Add(label);

    label = listViewCol.createLabel("", "Net Calc", dwith,40,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.CornflowerBlue);
    stackPanelLeftCol.Children.Add(label);
    mainStack.Children.Add(stackPanelLeftCol);
    
    StackPanel newStackPanel= listViewCol.createStackPanel();

    CellTitles c = new CellTitles();    
    c.Title1 = "Week#";
    c.Title2 = "";
    c.Title3 = "TotDire." + "\n" +"Labour";
    c.Title4 = "Shift";
    c.Title5 = "Actual";
    c.Title6 = "Active" + "\n"+"Net";
    c.Title7 = "Totals";
    c.Title8 = "Net";

    for (int i=0; i <= 7 ; i++){ //Titles
        if (i == 3 || i== 7){
            label = listViewCol.createLabel("", "", dwith2, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
            label.Background = (i == 7) ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Lavender);
            newStackPanel.Children.Add(listViewCol.addBorder(label));                  
        }

        textBox =  listViewCol.createTextBox("Title" + (i + 1).ToString(), true,true, dwith2, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center,Colors.Black,Colors.White,Constants.FONT_FAMILY_SEGEOEUI);
                
        if ( i == 0)
            textBox.Height= 35;
        if ( i == 2 || i == 5)
             textBox.FontSize = dfonSize-1;                
        if (i >=6)
            textBox.Background = new SolidColorBrush(Colors.Lavender);

        newStackPanel.Children.Add(listViewCol.addBorder(textBox));
    }
    
    mainStack.Children.Add(newStackPanel);
    newStackPanel.DataContext = c;    
}

 private 
void checkButt_Click(object sender, RoutedEventArgs e){
    arrayV=arrayV;

}
        /*
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
}*/

}
}
