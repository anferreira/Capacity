/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class ShipExportSumDataBaseContainer : GenericDataBaseContainer {

public
ShipExportSumDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from shipexportsum";
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);
		shipExportSumDataBase.load(reader);
		this.Add(shipExportSumDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table shipexportsum";
	truncate(sql);
}

public
string readBaseFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){
    string sql = "";
    
    if (!string.IsNullOrEmpty(splant)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.Site", splant);
    if (!string.IsNullOrEmpty(sbillTo)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.BillTo", sbillTo);
    if (!string.IsNullOrEmpty(shipTo)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.ShipTo", shipTo);
            
    if (!string.IsNullOrEmpty(sbol))    
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (select sd.Bol from ShipExport sd where sd.OrderNum=s.OrderNum and sd.Item=s.Item and sd.ReleaseBase=s.Release and " + DBFormatter.equalLikeSql("CAST(sd.Bol AS varchar(15))", sbol) + ")";
    if (!string.IsNullOrEmpty(sorder))    
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CAST(s.OrderNum AS varchar(15))", sorder);
    
    if (!string.IsNullOrEmpty(scustPO))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.CustPO", scustPO);      

    if (!string.IsNullOrEmpty(sdocType))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.OrdType", sdocType);  
                       
    if (!string.IsNullOrEmpty(srelease))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.Release", srelease);  

    if (orderItem > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "s.Item =" + NumberUtil.toString(orderItem);

    if (blateOrders)     
        sql= DBFormatter.addWhereAndSentence(sql) + "CAST(s.ShipDate as date) <> CAST(s.DateRequest as date)";        
    

    if (!string.IsNullOrEmpty(sppap))
       sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("s.Ppap", sppap);      

    if (fromDate!= DateUtil.MinValue || toDate!= DateUtil.MinValue)
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("s.ShipDate", fromDate,toDate,false);    

    return sql;
}

public
void readByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){
    string  sql = "select * from shipexportsum s ";

    sql+= readBaseFilters(splant,sbillTo, shipTo, sbol,sorder, scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate, irows);    
    sql+= " order by ShipDate desc,OrderNum desc,Item";
   
    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);

    read(sql);
}

} // class
} // package