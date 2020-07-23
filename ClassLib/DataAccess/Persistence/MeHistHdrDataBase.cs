using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class MeHistHdrDataBase : GenericDataBaseElement{

private int SHH_Id;
private DateTime SHH_Date;
private DateTime SHH_StartDate;
private DateTime SHH_EndDate;
private string SHH_Plt;

public 
MeHistHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.SHH_Id = reader.GetInt32("SHH_Id");
    this.SHH_Date = reader.GetDateTime("SHH_Date");
    this.SHH_StartDate = reader.GetDateTime("SHH_StartDate");
    this.SHH_EndDate = reader.GetDateTime("SHH_EndDate");
    this.SHH_Plt = reader.GetString("SHH_Plt");
}

public override
void write(){
	try{
		string sql = "insert into mehisthdr (SHH_Date,SHH_StartDate,SHH_EndDate,SHH_Plt) " +
		    "values('" + 
                DateUtil.getCompleteDateRepresentation(SHH_Date) +"', '" +
                DateUtil.getCompleteDateRepresentation(SHH_StartDate) +"', '" +
                DateUtil.getCompleteDateRepresentation(SHH_EndDate) +"', '" +
                Converter.fixString(SHH_Plt) +"')";
	 	dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class MeHistHdrDataBase <write>: " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class MeHistHdrDataBase <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
bool exists(){
	try{
		bool returnValue = false;

		string sql = "select * from mehisthdr " +
		             "where " +
                            "SHH_StartDate = '" + DateUtil.getDateRepresentation(SHH_StartDate) +"' and " +
                            "SHH_EndDate = '" +  DateUtil.getDateRepresentation(SHH_EndDate) +"' and " +
                            "SHH_Date = '" + DateUtil.getDateRepresentation(SHH_Date) +"' and " +
                            "SHH_Plt ='" + SHH_Plt + "'";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class PltDataBase <read>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class PltDataBase <read>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}
}

//Setters
public 
void setSHH_Id (int SHH_Id){
    this.SHH_Id = SHH_Id;
}

public 
void setSHH_Date (DateTime SHH_Date){
    this.SHH_Date = SHH_Date;
}

public 
void setSHH_StartDate (DateTime SHH_StartDate){
    this.SHH_StartDate = SHH_StartDate;
}

public 
void setSHH_EndDate (DateTime SHH_EndDate){
    this.SHH_EndDate = SHH_EndDate;
}

public 
void setSHH_Plt (string SHH_Plt){
    this.SHH_Plt = SHH_Plt;
}


//Getters
public 
int getSHH_Id(){
    return SHH_Id;
}

public 
DateTime getSHH_Date(){
    return SHH_Date;
}

public 
DateTime getSHH_StartDate(){
    return SHH_StartDate;
}

public 
DateTime getSHH_EndDate(){
    return SHH_EndDate;
}

public 
string getSHH_Plt(){
    return SHH_Plt;
}

}//end class

}//end namespace
