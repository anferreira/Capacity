using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class NoteDataBase : GenericDataBaseElement{
	
private int N_ID;
private string N_Type;
private int N_Key1;
private int N_Key2;
private int N_Key3;
private int N_LineNum;
private string N_Note;

public
NoteDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.N_ID		= reader.GetInt32("N_ID");
	this.N_Type		= reader.GetString("N_Type");
	this.N_Key1		= reader.GetInt32("N_Key1");
	this.N_Key2		= reader.GetInt32("N_Key2");
	this.N_Key3		= reader.GetInt32("N_Key3");
	this.N_LineNum	= reader.GetInt32("N_LineNum");
	this.N_Note		= reader.GetString("N_Note");
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql ="select * from Note where " + getWhereCondition();			
					
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class NoteDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class NoteDataBase <read>: " + de.Message,de);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from Note where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		
		if (reader.Read())
			return true;
		else
			return false;
		
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class NoteDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class NoteDataBase <exists>: " + de.Message,de);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public override 
void write(){
	try{
		string sql ="insert into Note(" +					
					"N_Type,"+
					"N_Key1,"+
					"N_Key2,"+
					"N_Key3,"+
					"N_LineNum,"+
					"N_Note) values(" + 

			" '" +	Converter.fixString(N_Type) + "', " +
			NumberUtil.toString(N_Key1)			+ "," +
			NumberUtil.toString(N_Key2)			+ "," +
			NumberUtil.toString(N_Key3)			+ "," +
			NumberUtil.toString(N_LineNum)		+ "," +
			" '" +	Converter.fixString(N_Note) + "')";			

		dataBaseAccess.executeUpdate(sql);

	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class NoteDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class NoteDataBase <write>: " + de.Message,de);
	}

}

public override
void update(){
	try{
		string sql ="update Note set N_Note='" + Converter.fixString(N_Note) + "'" +			
					" where " + this.getWhereCondition();

 		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class NoteDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class NoteDataBase <update>: " + de.Message,de);
	}

}

public override
void delete(){
	try{
		string sql = "delete from Note where " + this.getWhereCondition();

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class NoteDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class NoteDataBase <delete>: " + de.Message,de);
	}
}

public void deleteAllFromTypeKey()
{
	try
	{
		string sql ="delete from note where " +										
					"N_Type= '" + Converter.fixString(N_Type)   + "' and " +
					"N_Key1="	+ NumberUtil.toString(N_Key1);
												
				if (!NumberUtil.isNull(N_Key2))
					sql+= " and N_Key2=" + NumberUtil.toString(N_Key2);

				if (!NumberUtil.isNull(N_Key3))	
					sql+= " and N_Key3=" + NumberUtil.toString(N_Key3);

				if (!NumberUtil.isNull(N_LineNum))	
					sql+=" and N_LineNum="+ NumberUtil.toString(N_LineNum);

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class NoteDataBase <deleteAllFromTypeKey1>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBase <deleteAllFromTypeKey1>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteAllFromTypeKey1> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class NoteDataBase <deleteAllFromTypeKey1>: " + de.Message,de);
	}
}

public
void setN_ID(int N_ID){
	this.N_ID = N_ID;
}

public
void setN_Type(string N_Type){
	this.N_Type = N_Type;
}

public
void setN_Key1(int N_Key1){
	this.N_Key1 = N_Key1;
}

public
void setN_Key2(int N_Key2){
	this.N_Key2 = N_Key2;
}

public
void setN_Key3(int N_Key3){
	this.N_Key3 = N_Key3;
}

public
void setN_LineNum(int N_LineNum){
	this.N_LineNum = N_LineNum;
}
	
public
void setN_Note(string N_Note){
	this.N_Note = N_Note;
}

public
int getN_ID(){
	return N_ID;
}

public
string getN_Type(){
	return N_Type;
}

public
int getN_Key1(){
	return N_Key1;
}

public
int getN_Key2(){
	return N_Key2;
}

public
int getN_Key3(){
	return N_Key3;
}

public
int getN_LineNum(){
	return N_LineNum;
}

public
string getN_Note(){
	return N_Note;
}

string getWhereCondition()
{
		string	sql=	"N_Type= '" + Converter.fixString(N_Type)   + "' and ";
				sql+=	"N_Key1="	+ NumberUtil.toString(N_Key1)	+ " and ";
				
				sql+= "N_Key2";
				if (NumberUtil.isNull(N_Key2))	sql+= " is ";	
				else							sql+= "=";					
				sql+=  NumberUtil.toString(N_Key2)	+ " and ";

				sql+= "N_Key3";
				if (NumberUtil.isNull(N_Key3))	sql+= " is ";
				else							sql+= "=";				
				sql+=  NumberUtil.toString(N_Key3)	+ " and ";
					
				sql+="N_LineNum="+ NumberUtil.toString(N_LineNum);

		return sql;
}

} // class

} // namespace
