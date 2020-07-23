using System;
using System.Drawing;

using Nujit.NujitERP.ClassLib.Core;
namespace Nujit.NujitERP.ClassLib.Common{

public
class Constants{

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

	public const string DEFAULT_UOM = "EA";

	//CmsVersion
	public const string CMS_VERSION_5_0 = "5.0";
	public const string CMS_VERSION_5_1 = "5.1";
	public const string CMS_VERSION_5_2 = "5.2";
				
} // class
} // namespace
