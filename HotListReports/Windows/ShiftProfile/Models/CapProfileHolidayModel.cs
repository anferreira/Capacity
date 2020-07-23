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


namespace HotListReports.Windows.ShiftProfile{

class CapProfileHolidayModel : BaseModel2{

private CapProfileHoliday capProfileHoliday;

public CapProfileHolidayModel(Window window) : base(window){    
    this.capProfileHoliday = null;
}

public
CapProfileHoliday CapProfileHoliday {
	get { return capProfileHoliday; }
	set { if (this.capProfileHoliday != value){
			this.capProfileHoliday = value;			
		}
	}
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    searchByComboBox.Items.Add("Code");
    searchByComboBox.Items.Add("Des1");
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}

public
void loadHolidayType(ComboBox combo,bool baddAll){       
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        if (baddAll)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(CapProfileHoliday.HOLIDAY_TYPE_HOLIDAY + " - Holiday",CapProfileHoliday.HOLIDAY_TYPE_HOLIDAY));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(CapProfileHoliday.HOLIDAY_TYPE_WEEKEND + " - Weekend",CapProfileHoliday.HOLIDAY_TYPE_WEEKEND));
                                               
        setDataContextCombo(combo,list);        
        
    } catch (Exception ex) {
        MessageBox.Show("loadHolidayType Exception: " + ex.Message);        
    }
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        gridView.Columns.Add(textBlockColumnListView.process());
         
        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,85, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("HolidayType", "HolidayType", BindingMode.OneWay,70, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTime");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTime");
        gridView.Columns.Add(textBlockColumnListView.process());
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public 
void add(out CapProfileHoliday capProfileHoliday){    
    this.capProfileHoliday = capProfileHoliday = coreFactory.createCapProfileHoliday();        
    try{            
       capProfileHoliday.Plant = Configuration.DftPlant;
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

public 
bool del(ListView listView){
    bool bresult = false;
    try { 
        capProfileHoliday = (CapProfileHoliday)deleltedSelected(listView);
        if (capProfileHoliday != null)   {             
            getCoreFactory().deleteCapProfileHoliday(capProfileHoliday.Id);
            bresult = true;
        }
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }
    return bresult;
}

public
void save(){
    try{
        if (capProfileHoliday.Id > 0)
            getCoreFactory().updateCapProfileHoliday(capProfileHoliday);
        else
            getCoreFactory().writeCapProfileHoliday(capProfileHoliday);

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}

public 
bool autoWeekCurrentYear(string splant){
    bool bresult=false;
    try{
        CapProfileHoliday           capProfileHoliday = null;
        CapProfileHoliday           capProfileHolidayFound = null;
        CapProfileHolidayContainer  capProfileHolidayContainer = getCoreFactory().createCapProfileHolidayContainer();
        CapProfileHolidayContainer  capProfileHolidayFoundContainer = getCoreFactory().createCapProfileHolidayContainer();
        DateTime                    firstDay=  new DateTime(DateTime.Now.Year,1,1,0,0,0);
        DateTime                    lastDay =  new DateTime(DateTime.Now.Year,12,31,23,59,59);
        DateTime                    currDay = DateTime.Now;
        int                         icurrDaysOnYear = Convert.ToInt32((lastDay- firstDay).TotalDays);
        int                         irecordsCreated=0;

        if (string.IsNullOrEmpty(splant))
            splant = Configuration.DftPlant;

        capProfileHoliday = getCoreFactory().createCapProfileHoliday();
        capProfileHoliday.Plant = splant;
        capProfileHoliday.StartDate = firstDay;
        capProfileHoliday.EndDate   = new DateTime(firstDay.Year,firstDay.Month,firstDay.Day,23,59,59);
        capProfileHolidayContainer.Add(capProfileHoliday);

        for (int i=1; i < icurrDaysOnYear;i++){

            currDay = firstDay.AddDays(i);

            if (currDay.DayOfWeek == DayOfWeek.Saturday){
                capProfileHoliday = getCoreFactory().createCapProfileHoliday();
                capProfileHoliday.Plant = splant;
                capProfileHoliday.HolidayType   = CapProfileHoliday.HOLIDAY_TYPE_WEEKEND;
                capProfileHoliday.StartDate     = currDay;
                capProfileHoliday.EndDate       = currDay.AddDays(1);
                capProfileHoliday.EndDate       = new DateTime(capProfileHoliday.EndDate.Year, capProfileHoliday.EndDate.Month, capProfileHoliday.EndDate.Day,23,59,59);
                capProfileHolidayContainer.Add(capProfileHoliday);
                i = i+6;
            }
        }

        capProfileHolidayFoundContainer = getCoreFactory().readCapProfileHolidayByFilters("",splant,"",firstDay,lastDay,0);

        for (int i=1; i < capProfileHolidayContainer.Count;i++){
            capProfileHoliday = capProfileHolidayContainer[i];

            capProfileHolidayFound = capProfileHolidayFoundContainer.getByRangeDate(capProfileHoliday.StartDate);

            if (capProfileHolidayFound == null){
                getCoreFactory().writeCapProfileHoliday(capProfileHoliday);
                bresult=true;
                irecordsCreated++;
            }
        }

        if (irecordsCreated > 0)    MessageBox.Show(irecordsCreated.ToString() + " Holidays Records Created.");
        else                        MessageBox.Show("No Records Created, Already Exists Holidays Created.");

    } catch (Exception ex) {
        MessageBox.Show("autoWeekCurrentYear Exception: " + ex.Message);        
    }    
    return bresult;
}

public
void adjustEndDate(){
    try { 
        if (capProfileHoliday!= null){        
            if (capProfileHoliday.StartDate.DayOfWeek == DayOfWeek.Saturday){
                capProfileHoliday.EndDate = capProfileHoliday.StartDate.AddDays(1);
            }else
                capProfileHoliday.EndDate = capProfileHoliday.StartDate;
            capProfileHoliday.EndDate = new DateTime(capProfileHoliday.EndDate.Year, capProfileHoliday.EndDate.Month, capProfileHoliday.EndDate.Day, 23,59,59);
        }

    } catch (Exception ex) {
        MessageBox.Show("adjustEndDate Exception: " + ex.Message);        
    }
}

}
}
