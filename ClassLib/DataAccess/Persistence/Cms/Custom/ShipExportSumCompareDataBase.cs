/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class ShipExportSumCompareDataBase : ShipExportSumDataBase {

private int QtyOrderedExcel;
private int QtyShippedExcel;
private DateTime OrderDateExcel;
private DateTime CustRequestDateExcel;
private DateTime ShipDateExcel;
private int PPMQtyExcel;
private int ActLeadTimeExcel;
private string PPAPExcel;

public
ShipExportSumCompareDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void load(NotNullDataReader reader){
    base.load(reader);
	this.QtyOrderedExcel = reader.GetInt32("QtyOrderedExcel");
	this.QtyShippedExcel = reader.GetInt32("QtyShippedExcel");
	this.OrderDateExcel = reader.GetDateTime("OrderDateExcel");
	this.CustRequestDateExcel = reader.GetDateTime("CustRequestDateExcel");
	this.ShipDateExcel = reader.GetDateTime("ShipDateExcel");
	this.PPMQtyExcel = reader.GetInt32("PPMQtyExcel");

    this.ActLeadTimeExcel   = reader.GetInt32("ActLeadTimeExcel");
    this.PPAPExcel          = reader.GetString("PPAPExcel");
}

public
void setQtyShippedExcel(int QtyShippedExcel){
	this.QtyShippedExcel = QtyShippedExcel;
}

public
void setOrderDateExcel(DateTime OrderDateExcel){
	this.OrderDateExcel = OrderDateExcel;
}

public
void setCustRequestDateExcel(DateTime CustRequestDateExcel){
	this.CustRequestDateExcel = CustRequestDateExcel;
}

public
void setShipDateExcel(DateTime ShipDateExcel){
	this.ShipDateExcel = ShipDateExcel;
}

public
void setPPMQtyExcel(int PPMQtyExcel){
	this.PPMQtyExcel = PPMQtyExcel;
}

public
void setActLeadTimeExcel(int ActLeadTimeExcel){
	this.ActLeadTimeExcel = ActLeadTimeExcel;
}

public
void setPPAPExcel(string PPAPExcel){
	this.PPAPExcel = PPAPExcel;
}

public
int getQtyOrderedExcel(){
	return QtyOrderedExcel;
}

public
int getQtyShippedExcel(){
	return QtyShippedExcel;
}

public
DateTime getOrderDateExcel(){
	return OrderDateExcel;
}

public
DateTime getCustRequestDateExcel(){
	return CustRequestDateExcel;
}

public
DateTime getShipDateExcel(){
	return ShipDateExcel;
}

public
int getPPMQtyExcel(){
	return PPMQtyExcel;
}

public
int getActLeadTimeExcel(){
	return ActLeadTimeExcel;
}

public
string getPPAPExcel(){
	return PPAPExcel;
}

} // class
} // package