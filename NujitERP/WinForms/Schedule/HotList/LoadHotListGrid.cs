using System;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using System.Windows.Forms;
//using Nujit.NujitERP.ClassLib.Schedule;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.WinForms.Schedule.HotList{


public 
class LoadHotListGrid{
	 
public static 
DataTable addColumns(DataTable hotListDataTable) {
	if (hotListDataTable.Columns.Count > 0)
		return hotListDataTable;

	hotListDataTable.Columns.Add(new DataColumn("HOT_Dept", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_MinorGroup", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_MajorGroup", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Finalized", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_ProdID", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Seq", typeof(int)));	
	hotListDataTable.Columns.Add(new DataColumn("HOT_Uom", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_MachCyc", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Qoh", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_QohCml", typeof(decimal)));
	
	hotListDataTable.Columns.Add(new DataColumn("HOT_MainMaterial", typeof(string)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_MainMaterialSeq", typeof(int)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_MainMaterialQoh", typeof(decimal)));
	
	hotListDataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day006", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day007", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day008", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day009", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day010", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day011", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day012", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day013", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day014", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day015", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day016", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day017", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day018", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day019", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day020", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day021", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day022", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day023", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day024", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day025", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day026", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day027", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day028", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day029", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day030", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day031", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day032", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day033", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day034", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day035", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day036", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day037", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day038", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day039", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day040", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day041", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day042", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day043", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day044", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day045", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day046", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day047", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day048", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day049", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day050", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day051", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day052", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day053", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day054", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day055", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day056", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day057", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day058", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day059", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day060", typeof(decimal)));
	
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day061", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day062", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day063", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day064", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day065", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day066", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day067", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day068", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day069", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day070", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day071", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day072", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day073", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day074", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day075", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day076", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day077", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day078", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day079", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day080", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day081", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day082", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day083", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day084", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day085", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day086", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day087", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day088", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day089", typeof(decimal)));
	hotListDataTable.Columns.Add(new DataColumn("HOT_Day090", typeof(decimal)));

	hotListDataTable.Columns.Add(new DataColumn("HOT_Id", typeof(string)));
	return hotListDataTable;
}

public static 
DataTable addColumnsHours(DataTable hotListDataTable,DateTime hotlistDateCreated){
	if (hotListDataTable.Columns.Count > 0)
		return hotListDataTable;

	hotListDataTable.Columns.Add("Configuration", typeof(string));
	hotListDataTable.Columns.Add("Past Due", typeof(string));

	for(int i = 1; i < 61; i++)
		hotListDataTable.Columns.Add("Day " + i.ToString() + " " + hotlistDateCreated.AddDays(i-1).ToString("MM-dd"), typeof(string));
	return hotListDataTable;
}

public static 
DataSet setColumnName(DataSet dsHotList, DateTime dateCreated){
	dsHotList.Tables[0].Columns["HOT_MinorGroup"].ColumnName = "Minor Group";
	dsHotList.Tables[0].Columns["HOT_MajorGroup"].ColumnName = "Major Group";
	dsHotList.Tables[0].Columns["HOT_Finalized"].ColumnName = "Finished";
	dsHotList.Tables[0].Columns["HOT_ProdID"].ColumnName = "Part";
	dsHotList.Tables[0].Columns["HOT_Seq"].ColumnName = "Seq";
	dsHotList.Tables[0].Columns["HOT_Uom"].ColumnName = "Uom";
	dsHotList.Tables[0].Columns["HOT_Dept"].ColumnName = "Dept";
	dsHotList.Tables[0].Columns["HOT_Mach"].ColumnName = "Mach";
	dsHotList.Tables[0].Columns["HOT_MachCyc"].ColumnName = "Mach Cyc";
	dsHotList.Tables[0].Columns["HOT_Qoh"].ColumnName = "Qoh";
	dsHotList.Tables[0].Columns["HOT_QohCml"].ColumnName = "Qoh Cml";

	dsHotList.Tables[0].Columns["HOT_MainMaterial"].ColumnName = "Main Material";
	dsHotList.Tables[0].Columns["HOT_MainMaterialSeq"].ColumnName = "M.Mat Seq";
	dsHotList.Tables[0].Columns["HOT_MainMaterialQoh"].ColumnName = "M.M.QtyAvail";

	dsHotList.Tables[0].Columns["HOT_PastDue"].ColumnName = "Past Due";
    if (dateCreated.Year == DateTime.Today.Year && dateCreated.Month == DateTime.Today.Month && dateCreated.Day == DateTime.Today.Day)
	    dsHotList.Tables[0].Columns["HOT_Day001"].ColumnName = "Today";
    else
	    dsHotList.Tables[0].Columns["HOT_Day001"].ColumnName = dateCreated.ToString("ddd MM-dd");

	dsHotList.Tables[0].Columns["HOT_Day002"].ColumnName = dateCreated.AddDays(1).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day003"].ColumnName = dateCreated.AddDays(2).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day004"].ColumnName = dateCreated.AddDays(3).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day005"].ColumnName = dateCreated.AddDays(4).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day006"].ColumnName = dateCreated.AddDays(5).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day007"].ColumnName = dateCreated.AddDays(6).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day008"].ColumnName = dateCreated.AddDays(7).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day009"].ColumnName = dateCreated.AddDays(8).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day010"].ColumnName = dateCreated.AddDays(9).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day011"].ColumnName = dateCreated.AddDays(10).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day012"].ColumnName = dateCreated.AddDays(11).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day013"].ColumnName = dateCreated.AddDays(12).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day014"].ColumnName = dateCreated.AddDays(13).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day015"].ColumnName = dateCreated.AddDays(14).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day016"].ColumnName = dateCreated.AddDays(15).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day017"].ColumnName = dateCreated.AddDays(16).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day018"].ColumnName = dateCreated.AddDays(17).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day019"].ColumnName = dateCreated.AddDays(18).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day020"].ColumnName = dateCreated.AddDays(19).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day021"].ColumnName = dateCreated.AddDays(20).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day022"].ColumnName = dateCreated.AddDays(21).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day023"].ColumnName = dateCreated.AddDays(22).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day024"].ColumnName = dateCreated.AddDays(23).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day025"].ColumnName = dateCreated.AddDays(24).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day026"].ColumnName = dateCreated.AddDays(25).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day027"].ColumnName = dateCreated.AddDays(26).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day028"].ColumnName = dateCreated.AddDays(27).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day029"].ColumnName = dateCreated.AddDays(28).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day030"].ColumnName = dateCreated.AddDays(29).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day031"].ColumnName = dateCreated.AddDays(30).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day032"].ColumnName = dateCreated.AddDays(31).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day033"].ColumnName = dateCreated.AddDays(32).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day034"].ColumnName = dateCreated.AddDays(33).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day035"].ColumnName = dateCreated.AddDays(34).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day036"].ColumnName = dateCreated.AddDays(35).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day037"].ColumnName = dateCreated.AddDays(36).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day038"].ColumnName = dateCreated.AddDays(37).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day039"].ColumnName = dateCreated.AddDays(38).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day040"].ColumnName = dateCreated.AddDays(39).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day041"].ColumnName = dateCreated.AddDays(40).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day042"].ColumnName = dateCreated.AddDays(41).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day043"].ColumnName = dateCreated.AddDays(42).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day044"].ColumnName = dateCreated.AddDays(43).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day045"].ColumnName = dateCreated.AddDays(44).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day046"].ColumnName = dateCreated.AddDays(45).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day047"].ColumnName = dateCreated.AddDays(46).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day048"].ColumnName = dateCreated.AddDays(47).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day049"].ColumnName = dateCreated.AddDays(48).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day050"].ColumnName = dateCreated.AddDays(49).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day051"].ColumnName = dateCreated.AddDays(50).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day052"].ColumnName = dateCreated.AddDays(51).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day053"].ColumnName = dateCreated.AddDays(52).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day054"].ColumnName = dateCreated.AddDays(53).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day055"].ColumnName = dateCreated.AddDays(54).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day056"].ColumnName = dateCreated.AddDays(55).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day057"].ColumnName = dateCreated.AddDays(56).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day058"].ColumnName = dateCreated.AddDays(57).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day059"].ColumnName = dateCreated.AddDays(58).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day060"].ColumnName = dateCreated.AddDays(59).ToString("ddd MM-dd");

	dsHotList.Tables[0].Columns["HOT_Day061"].ColumnName = dateCreated.AddDays(60).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day062"].ColumnName = dateCreated.AddDays(61).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day063"].ColumnName = dateCreated.AddDays(62).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day064"].ColumnName = dateCreated.AddDays(63).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day065"].ColumnName = dateCreated.AddDays(64).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day066"].ColumnName = dateCreated.AddDays(65).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day067"].ColumnName = dateCreated.AddDays(66).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day068"].ColumnName = dateCreated.AddDays(67).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day069"].ColumnName = dateCreated.AddDays(68).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day070"].ColumnName = dateCreated.AddDays(69).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day071"].ColumnName = dateCreated.AddDays(70).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day072"].ColumnName = dateCreated.AddDays(71).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day073"].ColumnName = dateCreated.AddDays(72).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day074"].ColumnName = dateCreated.AddDays(73).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day075"].ColumnName = dateCreated.AddDays(74).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day076"].ColumnName = dateCreated.AddDays(75).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day077"].ColumnName = dateCreated.AddDays(76).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day078"].ColumnName = dateCreated.AddDays(77).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day079"].ColumnName = dateCreated.AddDays(78).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day080"].ColumnName = dateCreated.AddDays(79).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day081"].ColumnName = dateCreated.AddDays(80).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day082"].ColumnName = dateCreated.AddDays(81).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day083"].ColumnName = dateCreated.AddDays(82).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day084"].ColumnName = dateCreated.AddDays(83).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day085"].ColumnName = dateCreated.AddDays(84).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day086"].ColumnName = dateCreated.AddDays(85).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day087"].ColumnName = dateCreated.AddDays(86).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day088"].ColumnName = dateCreated.AddDays(87).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day089"].ColumnName = dateCreated.AddDays(88).ToString("ddd MM-dd");
	dsHotList.Tables[0].Columns["HOT_Day090"].ColumnName = dateCreated.AddDays(89).ToString("ddd MM-dd");

	return dsHotList;
}

public static 
DataGrid initializeItemsGrid(DataSet dsHotList, DataGrid gridHotList){
	DataTable dataTable = null;
	dataTable = dsHotList.Tables[0];
			    
	DataView dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;

	//gridHotList.DataSource = dataView;
	gridHotList.PreferredColumnWidth = 150;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();

	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	gridHotList.TableStyles.Clear(); 
	gridHotList.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;

	//Take the columns in a GridColumnStylesCollection object and set //the size of the 
	//individual columns	
	GridColumnStylesCollection	colStyle;
	colStyle				= gridHotList.TableStyles[0].GridColumnStyles;	

	colStyle[0].Width      	= 50;
	colStyle[1].Width      	= 70;
	colStyle[2].Width      	= 70;
	colStyle[3].Width      	= 50;
	colStyle[4].Width		= 90;
	colStyle[5].Width		= 50;
	colStyle[6].Width		= 50;
	colStyle[7].Width      	= 70;
	colStyle[8].Width		= 50;
	colStyle[9].Width		= 50;
	//colStyle[10].Width		= 50;
	
	for (int i=11;i<colStyle.Count;i++){
		colStyle[i].Width		= 60; //100
        colStyle[i].Alignment = HorizontalAlignment.Right;
	}

	return gridHotList;
}

public static 
DataGrid initializeItemsGridHours(DataSet dsHotList, DataGrid gridHotList){
	DataTable dataTable = null;
	dataTable = dsHotList.Tables[0];
			    
	DataView dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;

	//gridHotList.DataSource = dataView;
	gridHotList.PreferredColumnWidth = 150;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();

	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	gridHotList.TableStyles.Clear(); 
	gridHotList.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;

	//Take the columns in a GridColumnStylesCollection object and set //the size of the 
	//individual columns	
	GridColumnStylesCollection	colStyle;
	colStyle				= gridHotList.TableStyles[0].GridColumnStyles;	

	for (int i = 0; i<colStyle.Count; i++)
		colStyle[i].Width = 80;

	return gridHotList;
}

public static 
DataSet generateHotListDataSet(bool onlyDemand, DataSet dataSet, DataTable hotListDataTable, int hlid,DateTime hotListCreted){
	string[] filter = {};
	return generateHotListDataSet(filter, filter, filter, onlyDemand, "B", hlid, hotListCreted);
}

public static 
DataSet generateHotListDataSet(string[] filterDept, string[] filterPart, string[] vecFilterMg, bool onlyDemand, string type, int hlid,DateTime hotListCreated){
	DataRow dataRow;

	DataTable dataTable = LoadHotListGrid.addColumns(new DataTable());

	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	string[][] vec = coreFactory.getHotListAsString(hlid,"", filterDept, filterPart, vecFilterMg, onlyDemand, type);//CM 11/10/2005
	coreFactory = null;

	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
		dataRow.ItemArray = vec[x];
		dataTable.Rows.Add(dataRow);
	}

	DataSet hotListDataSet = new DataSet();
	hotListDataSet.Tables.Add(dataTable);
	hotListDataSet = LoadHotListGrid.setColumnName(hotListDataSet, hotListCreated);

	return hotListDataSet;
}

public static 
DataSet generateHotListHoursDataSet(HotListHourContainer hotListHourContainer,DateTime hotListDateCreated){
	DataRow dataRow;

	DataTable dataTable = LoadHotListGrid.addColumnsHours(new DataTable(), hotListDateCreated);

	for(int x = 0; x < hotListHourContainer.Count; x++){
		HotListHour hotListHour = (HotListHour)hotListHourContainer[x];

		dataRow = dataTable.NewRow();
		dataRow[0]  = hotListHour.getConfiguration();
		dataRow[1]  = hotListHour.getHourRemaining(0).ToString("##0.#0");
		dataRow[2]  = hotListHour.getHourRemaining(1).ToString("##0.#0");
		dataRow[3]  = hotListHour.getHourRemaining(2).ToString("##0.#0");
		dataRow[4]  = hotListHour.getHourRemaining(3).ToString("##0.#0");
		dataRow[5]  = hotListHour.getHourRemaining(4).ToString("##0.#0");
		dataRow[6]  = hotListHour.getHourRemaining(5).ToString("##0.#0");
		dataRow[7]  = hotListHour.getHourRemaining(6).ToString("##0.#0");
		dataRow[8]  = hotListHour.getHourRemaining(7).ToString("##0.#0");
		dataRow[9]  = hotListHour.getHourRemaining(8).ToString("##0.#0");
		dataRow[10]  = hotListHour.getHourRemaining(9).ToString("##0.#0");
		dataRow[11]  = hotListHour.getHourRemaining(10).ToString("##0.#0");
		dataRow[12]  = hotListHour.getHourRemaining(11).ToString("##0.#0");
		dataRow[13]  = hotListHour.getHourRemaining(12).ToString("##0.#0");
		dataRow[14]  = hotListHour.getHourRemaining(13).ToString("##0.#0");
		dataRow[15]  = hotListHour.getHourRemaining(14).ToString("##0.#0");
		dataRow[16]  = hotListHour.getHourRemaining(15).ToString("##0.#0");
		
		dataRow[17]  = hotListHour.getHourRemaining(16).ToString("##0.#0");
		dataRow[18]  = hotListHour.getHourRemaining(17).ToString("##0.#0");
		dataRow[19]  = hotListHour.getHourRemaining(18).ToString("##0.#0");
		dataRow[20]  = hotListHour.getHourRemaining(19).ToString("##0.#0");
		dataRow[21]  = hotListHour.getHourRemaining(20).ToString("##0.#0");
		dataRow[22]  = hotListHour.getHourRemaining(21).ToString("##0.#0");
		dataRow[23]  = hotListHour.getHourRemaining(22).ToString("##0.#0");
		dataRow[24]  = hotListHour.getHourRemaining(23).ToString("##0.#0");
		dataRow[25]  = hotListHour.getHourRemaining(24).ToString("##0.#0");
		dataRow[26]  = hotListHour.getHourRemaining(25).ToString("##0.#0");
		dataRow[27]  = hotListHour.getHourRemaining(26).ToString("##0.#0");
		dataRow[28]  = hotListHour.getHourRemaining(27).ToString("##0.#0");
		dataRow[29]  = hotListHour.getHourRemaining(28).ToString("##0.#0");
		dataRow[30]  = hotListHour.getHourRemaining(29).ToString("##0.#0");
		dataRow[31]  = hotListHour.getHourRemaining(30).ToString("##0.#0");
		dataRow[32]  = hotListHour.getHourRemaining(31).ToString("##0.#0");
		dataRow[33]  = hotListHour.getHourRemaining(32).ToString("##0.#0");
		dataRow[34]  = hotListHour.getHourRemaining(33).ToString("##0.#0");
		dataRow[35]  = hotListHour.getHourRemaining(34).ToString("##0.#0");
		dataRow[36]  = hotListHour.getHourRemaining(35).ToString("##0.#0");
		dataRow[37]  = hotListHour.getHourRemaining(36).ToString("##0.#0");

		dataRow[38]  = hotListHour.getHourRemaining(37).ToString("##0.#0");
		dataRow[39]  = hotListHour.getHourRemaining(38).ToString("##0.#0");
		dataRow[40]  = hotListHour.getHourRemaining(39).ToString("##0.#0");
		dataRow[41]  = hotListHour.getHourRemaining(40).ToString("##0.#0");
		dataRow[42]  = hotListHour.getHourRemaining(41).ToString("##0.#0");
		dataRow[43]  = hotListHour.getHourRemaining(42).ToString("##0.#0");
		dataRow[44]  = hotListHour.getHourRemaining(43).ToString("##0.#0");
		dataRow[45]  = hotListHour.getHourRemaining(44).ToString("##0.#0");
		dataRow[46]  = hotListHour.getHourRemaining(45).ToString("##0.#0");
		dataRow[47]  = hotListHour.getHourRemaining(46).ToString("##0.#0");
		dataRow[48]  = hotListHour.getHourRemaining(47).ToString("##0.#0");
		dataRow[49]  = hotListHour.getHourRemaining(48).ToString("##0.#0");
		dataRow[50]  = hotListHour.getHourRemaining(49).ToString("##0.#0");
		dataRow[51]  = hotListHour.getHourRemaining(50).ToString("##0.#0");
		dataRow[52]  = hotListHour.getHourRemaining(51).ToString("##0.#0");
		dataRow[53]  = hotListHour.getHourRemaining(52).ToString("##0.#0");
		dataRow[54]  = hotListHour.getHourRemaining(53).ToString("##0.#0");
		dataRow[55]  = hotListHour.getHourRemaining(54).ToString("##0.#0");
		dataRow[56]  = hotListHour.getHourRemaining(55).ToString("##0.#0");
		dataRow[57]  = hotListHour.getHourRemaining(56).ToString("##0.#0");
		dataRow[58]  = hotListHour.getHourRemaining(57).ToString("##0.#0");
		dataRow[59]  = hotListHour.getHourRemaining(58).ToString("##0.#0");
		dataRow[60]  = hotListHour.getHourRemaining(59).ToString("##0.#0");
		dataRow[61]  = hotListHour.getHourRemaining(60).ToString("##0.#0");

		dataTable.Rows.Add(dataRow);
	}

	DataSet hotListDataSet = new DataSet();
	hotListDataSet.Tables.Add(dataTable);
//	hotListDataSet = LoadHotListGrid.setColumnNameHours(hotListDataSet);

	return hotListDataSet;
}


} // class

} // namespace
