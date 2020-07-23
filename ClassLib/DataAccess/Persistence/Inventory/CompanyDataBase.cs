using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class CompanyDataBase	: GenericDataBaseElement{ 

private string	CIA_DB;
private int		CIA_Company;
private string	CIA_Name;
private string	CIA_Description;
private int		CIA_CurrOrderNum;
private int		CIA_CurrInvoiceNum;
private int		CIA_CurrBillLadNum;
private int		CIA_CurrQuoteNum;
private int		CIA_CurrCreditNoteNum;

public CompanyDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

    this.CIA_DB					= reader.GetString("CIA_DB");
    this.CIA_Company			= reader.GetInt32("CIA_Company");
    this.CIA_Name				= reader.GetString("CIA_Name");
    this.CIA_Description		= reader.GetString("CIA_Description");
    this.CIA_CurrOrderNum		= reader.GetInt32("CIA_CurrOrderNum");
    this.CIA_CurrInvoiceNum		= reader.GetInt32("CIA_CurrInvoiceNum");	
	this.CIA_CurrBillLadNum		= reader.GetInt32("CIA_CurrBillLadNum");
	this.CIA_CurrQuoteNum		= reader.GetInt32("CIA_CurrQuoteNum");
	this.CIA_CurrCreditNoteNum	= reader.GetInt32("CIA_CurrCreditNoteNum");
}

public 
bool exists(){

	string sql ="select * from company  where " + this.getWhereCondition();
    return exists(sql);

}

public override
void write(){
	string sql ="insert into company ("+
					"CIA_DB," +
					"CIA_Company," +
					"CIA_Name," +
					"CIA_Description," +
					"CIA_CurrOrderNum," +
					"CIA_CurrInvoiceNum," +
					"CIA_CurrBillLadNum," +
					"CIA_CurrQuoteNum," +
					"CIA_CurrCreditNoteNum) values (" + 
					"'" +	Converter.fixString(CIA_DB)					+"'," +
							NumberUtil.toString(CIA_Company)	        +"," +
                     "'" +	Converter.fixString(CIA_Name)				+"'," +
                     "'" +	Converter.fixString(CIA_Description)		+"'," +
							NumberUtil.toString(CIA_CurrOrderNum)		+"," +
							NumberUtil.toString(CIA_CurrInvoiceNum)		+"," +
							NumberUtil.toString(CIA_CurrBillLadNum)		+"," +
							NumberUtil.toString(CIA_CurrQuoteNum)		+"," +
							NumberUtil.toString(CIA_CurrCreditNoteNum)	+")";
	write(sql);
}

public override
void update(){
	
	string sql = "update company set " +
				    "CIA_Name='"			+	Converter.fixString(CIA_Name)			+"'," +
				    "CIA_Description='"		+	Converter.fixString(CIA_Description)	+"'," +
				    "CIA_CurrOrderNum="		+	NumberUtil.toString(CIA_CurrOrderNum)	+"," +
				    "CIA_CurrInvoiceNum="	+	NumberUtil.toString(CIA_CurrInvoiceNum)	+"," +
				    "CIA_CurrBillLadNum="	+	NumberUtil.toString(CIA_CurrBillLadNum)	+"," +
				    "CIA_CurrQuoteNum="		+	NumberUtil.toString(CIA_CurrQuoteNum)	+"," +
				    "CIA_CurrCreditNoteNum="+	NumberUtil.toString(CIA_CurrCreditNoteNum) + 
				  " where " + this.getWhereCondition();

    update(sql);

}

public override
void delete(){
    string sql =  "delete from company where " + this.getWhereCondition();
    delete(sql);
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from company " +
		             " where "+
                            "CIA_Company = " + NumberUtil.toString(CIA_Company)+" and " +
			                "CIA_DB='"+	Converter.fixString(CIA_DB) + "'" ;

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


//Setters
public void setCIA_Company (int CIA_Company){
    this.CIA_Company = CIA_Company;
}

public void setCIA_DB (string CIA_DB){
    this.CIA_DB = CIA_DB;
}

public void setCIA_Name (string CIA_Name){
    this.CIA_Name = CIA_Name;
}

public void setCIA_Description (string CIA_Description){
    this.CIA_Description = CIA_Description;
}

public void setCIA_CurrOrderNum (int CIA_CurrOrderNum){
    this.CIA_CurrOrderNum = CIA_CurrOrderNum;
}

public void setCIA_CurrInvoiceNum (int CIA_CurrInvoiceNum){
    this.CIA_CurrInvoiceNum = CIA_CurrInvoiceNum;
}

public void setCIA_CurrBillLadNum (int CIA_CurrBillLadNum){
    this.CIA_CurrBillLadNum = CIA_CurrBillLadNum;
}

public void setCIA_CurrQuoteNum (int CIA_CurrQuoteNum){
    this.CIA_CurrQuoteNum = CIA_CurrQuoteNum;
}

public void setCIA_CurrCreditNoteNum (int CIA_CurrCreditNoteNum){
    this.CIA_CurrCreditNoteNum = CIA_CurrCreditNoteNum;
}

//Getters
public int getCIA_Company(){
    return CIA_Company;
}

public string getCIA_DB (){
    return CIA_DB;
}

public string getCIA_Name(){
    return CIA_Name;
}

public string getCIA_Description(){
    return CIA_Description;
}

public int getCIA_CurrOrderNum(){
    return CIA_CurrOrderNum;
}

public int getCIA_CurrInvoiceNum(){
    return CIA_CurrInvoiceNum;
}

public int getCIA_CurrBillLadNum (){
    return CIA_CurrBillLadNum;
}

public int getCIA_CurrQuoteNum (){
    return CIA_CurrQuoteNum;
}

public int getCIA_CurrCreditNoteNum (){
    return CIA_CurrCreditNoteNum;
}


private string getWhereCondition(){
    string sql = "CIA_Company = " + NumberUtil.toString(CIA_Company) +" and " +
                 "CIA_DB='"+	Converter.fixString(CIA_DB) + "'" ;
    return sql;         
}
}//end class
}//end namespace

