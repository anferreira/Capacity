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
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Customer{

public
class CustLeadDataBaseContainer : GenericDataBaseContainer {

public
CustLeadDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from custlead order by CustId,MajSalesCode,MinSalesCode";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from custlead";
	if (searchText.Length > 0){
		sql += " where CustId like '" + Converter.fixString(searchText) + "%'";
		sql += " or MajSalesCode like '" + Converter.fixString(searchText) + "%'";
		sql += " or MinSalesCode like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CustLeadDataBase custLeadDataBase = new CustLeadDataBase(dataBaseAccess);
		custLeadDataBase.load(reader);
		this.Add(custLeadDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table custlead";
	truncate(sql);
}

public
void readByFilters(string scustID,string sexactCustId,string smajSalesCode,string sminSalesCode,int irows){
    string sql = "select * from custlead";
                
	if (!string.IsNullOrEmpty(scustID) || (scustID!= null && !string.IsNullOrEmpty(sexactCustId) && sexactCustId.Equals(Constants.STRING_YES))) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CustId", scustID);
    if (!string.IsNullOrEmpty(smajSalesCode)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("MajSalesCode", smajSalesCode);
    if (!string.IsNullOrEmpty(sminSalesCode)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("MinSalesCode", sminSalesCode);
        
    sql+= " order by CustId,MajSalesCode,MinSalesCode";
    if (irows > 0)
       sql = DBFormatter.selectTopRows(sql,irows);
	
    read(sql);
}

public
void readByCustomerFilters(string scustID,string smajSalesCode){
    string sql = "select * from custlead";
                        	
	sql= DBFormatter.addWhereAndSentence(sql) + " (CustId = '"+ Converter.fixString(scustID) + "' or CustId='')"; //if exactly Customer or Empty
    if (!string.IsNullOrEmpty(smajSalesCode)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("MajSalesCode", smajSalesCode);
        
    sql+= " order by CustId desc,MajSalesCode"; //order by customer desc, because by specific customer will be first    
    read(sql);
}

} // class
} // package