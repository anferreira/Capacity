using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CustPartDataBaseContainer : GenericDataBaseContainer{

public 
CustPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);
		custPartDataBase.load(reader);
		this.Add(custPartDataBase);
	}
}

public 
void read(){
	string sql = "select * from custpart";
    read(sql);
}

public 
void readByDb(string db){
	string sql = "select * from custpart " + 
		            "where CP_Db = '" + Converter.fixString(db) +"'";

    read(sql);            
}

public 
void truncate(){	
	string sql = "delete from custpart";
	truncate(sql);	
}


public
void readByFilters(string spart,string sbillTo,string shipTo,string scustPart,int irows){
    string sql = "select * from custpart";
       
	if (!string.IsNullOrEmpty(spart)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CP_ProdID", spart);
    if (!string.IsNullOrEmpty(sbillTo)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CP_BillToCust", sbillTo);
    if (!string.IsNullOrEmpty(shipTo)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CP_ShipToCust", shipTo);
    if (!string.IsNullOrEmpty(scustPart)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CP_CustPart", scustPart);
    
    sql+= " order by CP_ProdID";
    if (irows > 0)
       sql = DBFormatter.selectTopRows(sql,irows);
	
    read(sql);
}

}//end class
}//end namespace
