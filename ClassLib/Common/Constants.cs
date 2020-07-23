using System;
using System.Drawing;
using System.Windows;

using Nujit.NujitERP.ClassLib.Core;
namespace Nujit.NujitERP.ClassLib.Common{

public
class Constants{
    public const string FUNNEL_TITLE				= "FunnelCloud";

	public const string STRING_YES					= "Y";
	public const string STRING_NO					= "N";

	public const int	TCP_PORT					= 991;

	public const int    COLOR_BACKGROUND_BUTTON		= 0xB0C4DE;	
	public const int    COLOR_BACKGROUND_LISTBOX	= 0xE0FFFF;
	public const int    COLOR_BACKGROUND_LABEL		= 0xE0FFFF;
	public const int    COLOR_BACKGROUND_TEXTBOX	= 0xE0FFFF;
	public const int    COLOR_BACKGROUND_COMBOBOX	= 0xE0FFFF;

	public const int    COLOR_FOREGROUND_BUTTON		= 0x6B8E23;
	public const int	COLOR_FOREGROUND_LABEL		= 0x00008B;
	public const int	COLOR_FOREGROUND_LISTVIEW	= 0x006400;
	
	public const int    COLOR_LIST_VIEW_ROW			= 0xF8F8FF;

    public static Color COLOR_SELECT                = Color.LightSeaGreen;
	
	public const bool   USE_COLORS = true;

	public const int	QUANTITY_TO_SHOW_IN_REPORTS = -1;
	public const int	ETX_CHARACTER = 3;
	public const int	END_CHARACTER_BARCODEREADER =13;//Enter
	public const string PATH_PROJECT = "\\My Documents\\";

	public const string COMPANY_NAME				="Precidio Inc.";
	public const string COMPANY_ADDRESS1			="35 Precidio Court";
	public const string COMPANY_ADDRESS2			="Brampton, ON,";
	public const string COMPANY_ADDRESS3			="L6S 6B7, CANADA";
	public const string COMPANY_PHONE1				="Tel: (905) 790-0790";
	public const string COMPANY_PHONE2				="800-387-2304";
	public const string COMPANY_FAX					="Fax: (905) 790-0791";
	public const string COMPANY_EMAIL				="info@precidio.com";
	public const string ORDER_PRINT_TAX_LEGEND		="Plus applicable taxes and freight";

	public const string CUST_DEFAULT_PLANT		= "DFT";

	public const string ORDER_STATUS_CREATED	= "C";
	public const string ORDER_STATUS_FINISHED	= "F";
	public const string ORDER_STATUS_REMOVED	= "R";	

	public const string NOTE_TYPE_ORDER			= "O";
	public const string NOTE_TYPE_ORDER_DTL		= "O1";	
	
	public const string ORDER_TYPE_ORDER		= "ORDER";
	public const string ORDER_TYPE_QUOTE		= "QUOTE";	

	public enum TYPE_CLIENT : int 
	{
		TYPE_CLIENT_BILL	= 0,
		TYPE_CLIENT_SHIP	= 1,
		TYPE_CLIENT_ALL		= 3
	}


	public const string MONEY_SYMBOL				= "$";
	
	public const string	RETAIL_PRODUCT_TYPE_RHUBARB	= "RB";
	public const string	RETAIL_PRODUCT_TYPE_RETAIL	= "RT";		

	public const string DISCOUNT_TYPE_CREDIT		= "C";
	public const string DISCOUNT_TYPE_DEBIT			= "D";
	public const string DISCOUNT_TYPE_FIXEDUNIT_ONE = "U";
	public const string DISCOUNT_TYPE_FIXEDUNIT_ALL = "F";	

	public const string DISCOUNT_TYPE_TOTAL_BASE	= "B";	
	public const string DISCOUNT_TYPE_TOTAL_NET		= "N";	

	public const string PERSON_TYPE_CUSTOMER		= "C";
	public const string PERSON_TYPE_VENDOR			= "V";

	public const string PRICE_TYPE_CUSTOMER			= "CU";
	public const string PRICE_TYPE_CLASS			= "CL";
	public const string PRICE_TYPE_GENERIC			= "GR";

	public const string ITEM_IN_VALUATION_STANDARD	= "S";
	public const string ITEM_IN_VALUATION_ACTUAL	= "C";
	public const string ITEM_IN_VALUATION_AVERAGE	= "V";
	
	//Use for Abm Screens
	public const  int UPDATE  = 100;
    public const  int DELETE  = 200;
    public const  int ADD  = 300;

    //Report Format for use with the GenericReportFormat Class				
    public const  int PDF_FORMAT  = 100;
    public const  int HTML_FORMAT = 200;
    public const  int XLS_FORMAT  = 300;
    public const  int RTF_FORMAT  = 400;

	//IvSerial , label status
	public const string SERIAL_LABEL_STATUS_ACTIVE	= "A";	
	public const string SERIAL_LABEL_STATUS_INACTIVE= "I";	
	public const string SERIAL_LABEL_STATUS_VOIDED	= "V";	
	public const string SERIAL_LABEL_STATUS_SHIPPED	= "S";	
	public const string SERIAL_LABEL_STATUS_COMPLETE= "C";		

	//keys
	public const int WM_KEYDOWN = 0x100;
	public const int WM_SYSKEYDOWN = 0x104;


	//IvSerial , label status
	public const string SERIAL_LABEL_TYPE_MIXED_INTERNAL = "XI";	
	public const string SERIAL_LABEL_TYPE_MASTER_INTERNAL= "MI";	
	public const string SERIAL_LABEL_TYPE_MASTER_SHIPPING= "MS";	
	public const string SERIAL_LABEL_TYPE_SERIAL_INTERNAL= "SI";	
	public const string SERIAL_LABEL_TYPE_SERIAL_SHIPING = "SS";		
	public const string SERIAL_LABEL_TYPE_SHIPING		 = "S";
	
	//Status
	public const string STATUS_ACTIVE = "A";
	public const string STATUS_INACTIVE = "I";

    public const string STATUS_COMPLETE = "C";
    public const string STATUS_TRANSFORM = "T";
    public const string STATUS_HOTLIST_CREATED = "H";
    public const string STATUS_OVERTIME = "O";

    public const string DEFAULT_UOM = "EA";

	//CmsVersion
	public const string CMS_VERSION_5_0 = "5.0";
	public const string CMS_VERSION_5_1 = "5.1";
	public const string CMS_VERSION_5_2 = "5.2";

    //Separators??
    public const char DEFAULT_SEP = (char)11;

    public const int MAX_SHIFTS=3;

    public const int INDEX_HOTLIST_START_PASTUE = 14; 
    public const int INDEX_HOTLIST_MAX = 109;         
    public const int INDEX_HOTLIST_START_QOH = 9;                    
    public const int INDEX_INVENTORY_START_QOH = 10;                    
    public const int INDEX_INVENTORY_FUTURE = 4;                    

    public const string TASK_DIRECT="D";
    public const string TASK_INDIRECT="I";


    public const string OPTION_FIRST = "First";
    public const string OPTION_PRIOR = "Prior";
    public const string OPTION_NEXT = "Next";
    public const string OPTION_LAST = "Last";
    public const string OPTION_INSERT = "Insert";
    public const string OPTION_DELETE = "Delete";
    public const string OPTION_EDIT = "Edit";
    public const string OPTION_SAVE = "Save";
    public const string OPTION_CANCEL = "Cancel";
    public const string OPTION_REFRESH = "Refresh";
    public const string OPTION_HISTORY = "History";
    public const string OPTION_COLORLEGEND = "Color Legend";

    public const string OPTIONS_ROUTINGS                = "Routings";
    public const string OPTIONS_CAPACITY                = "Capacity";
    public const string OPTIONS_CAPACITY_REPORT         = "Capacity Report";
    public const string OPTIONS_CAPACITY_MACHPRIORITY   = "Machine Priority";

    public const string OPTIONS_MACHINE_VIEWS           = "Machine Views";
    public const string OPTIONS_MACHINE                 = "Machine";
    public const string OPTIONS_MACHINE_DEFAULT         = "Machine Defaults";

    public const string OPTIONS_ADJUST_LEATETIME        = "Adjust LeadTime";
    public const string OPTIONS_EDIT_SHIPEXPORTSUM      = "Edit Ship Export Sum";
    
    public const string TIME_CODE_DAILY     = "D";
    public const string TIME_CODE_WEEKLY    = "W";
    public const string TIME_CODE_MONTHLY   = "M";

    public const string TYPE_MACHINE    = "M";
    public const string TYPE_LABOUR     = "L";
    public const string TYPE_TOOL       = "T";

    public const string DATETIME_STAMP_TABLE_MESSAGE  = "Already Modified By Other Place.";

    public const int PRODUCTION_DAYS_PERWEEK = 5;

    public const int COLOR_GROUP = 0xFFD700;                                   
    public const int WIDTH_HOTLIST_CELL = 50;
    public const int MAX_HOTLIST_DAYS = 90;

    public const int MAX_MINS_CHECK_PR_HIST = 15;

    public const string SHIFT_TYPE_OVERTIME="O";
    public const string SHIFT_TYPE_REGULAR="R";

    public const string FONT_FAMILY_ARIALBLACK  ="Arial Black";
    public const string FONT_FAMILY_ARIAL       ="Arial";
    public const string FONT_FAMILY_SEGEOEUI    ="Segeoe UI";
    public const string FONT_FAMILY_COURIERNEW  ="Courier New";
        
    public const int BEGIN_TEXT_ASCII_VALUE = 2;//STX
    public const int END_TEXT_ASCII_VALUE = 3;//ETX
    public const int ENTER_ASCII_VALUE = 13;//Enter
    public const int RECORD_SEPARATOR_ASCII_VALUE = 30;//Record Separator

    public const string SHOW_ALL                = "All";

    public const string DOWN_TYPE       = "DW";
    public const string DOWN_HOLIDAY    = "HO";
    public const string DOWN_BREAK      = "BR";
    public const string DOWN_LUNCH      = "LU";
    public const string DOWN_SETUP      = "ST";
    public const string DOWN_TIER       = "TI";        

    public static
    string[][] getDownTypeList() {
        string[][] item = new string[6][];
   
        item[0] = new string[] { "Down"     , Constants.DOWN_TYPE };
        item[1] = new string[] { "Holiday"  , Constants.DOWN_HOLIDAY };
        item[2] = new string[] { "Break"    , Constants.DOWN_BREAK };
        item[3] = new string[] { "Lunch"    , Constants.DOWN_LUNCH };
        item[4] = new string[] { "Setup"    , Constants.DOWN_SETUP };
        item[5] = new string[] { "Tier"     , Constants.DOWN_TIER };
        return item;
    }

    public         
    static string getDownTypeShow(string stype) {        	        
        switch (stype) {
            case DOWN_TYPE:
                return "Down";
	        case DOWN_HOLIDAY:
                return "Holiday";
	        case DOWN_BREAK:
                return "Break";
            case DOWN_LUNCH:
                return "Lunch";
            case DOWN_SETUP:
                return "Setup";
            case DOWN_TIER:
                return "Tier";            
            default:
                return "";
        }
    }

    public const int MAX_EMPLOYEE_SCHEDULE_COLUMNS = 5;

    public static
    string getMatTypeDesc(string smatType) {
	    string sdesc="";        

        if (!string.IsNullOrEmpty(smatType)) {
            switch(smatType) {
                case "M": sdesc = "Manufactured";break;
                case "P": sdesc = "Purchased";break;                    
            }
        }
        return sdesc;                    
	}

    public static
    string getTimeCodeDesc(string stimeCode) {
	    string sdesc="";        

        if (!string.IsNullOrEmpty(stimeCode)) {
            switch(stimeCode) {
                case TIME_CODE_DAILY:   sdesc = "Daily";    break;
                case TIME_CODE_WEEKLY:  sdesc = "Weekly";   break;
                case TIME_CODE_MONTHLY: sdesc = "Monthly";  break;
            }
        }
        return sdesc;                    
	}
  

} // class
} // namespace
