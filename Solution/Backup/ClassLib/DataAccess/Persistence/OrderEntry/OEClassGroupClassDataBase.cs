using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class OEClassGroupDataBase : GenericDataBaseElement{

private int CG_Id;
private string CG_ClassGroup;
private string CG_ClassDescription;

public OEClassGroupDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){
   
    this.CG_Id = reader.GetInt32("CG_Id");
    this.CG_ClassGroup = reader.GetString("CG_ClassGroup");
    this.CG_ClassDescription = reader.GetString("CG_ClassDescription");
}

public override
void write(){

	try{
		string sql = "insert into oeclassgroup (CG_ClassGroup,CG_ClassDescription) " +
		             "values('" +
                                Converter.fixString(CG_ClassGroup) +"', '" +
                                Converter.fixString(CG_ClassDescription) +"')";
                                
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
}


public override
void update(){
	try{
		string sql = "update oeclassgroup set " +
                        "CG_ClassGroup  = '" + Converter.fixString(CG_ClassGroup) +"', " +
                        "CG_ClassDescription = '" + Converter.fixString(CG_ClassDescription) +"' " +
					"where CG_Id =" + NumberUtil.toString(CG_Id);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
}


public override
void delete(){
try{
		string sql = "delete from oeclassgroup " +
			         "where CG_Id =" + NumberUtil.toString(CG_Id);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}


public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeclassgroup " + 
			         "where CG_Id =" + NumberUtil.toString(CG_Id);

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from oeclassgroup " + 
			"where " +
			"CG_ClassGroup = '" + Converter.fixString(CG_ClassGroup) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			ret = true;
		}
		
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public void setCG_Id (int CG_Id){
    this.CG_Id = CG_Id;
}

public void setCG_ClassGroup (string CG_ClassGroup){
    this.CG_ClassGroup = CG_ClassGroup;
}

public void setCG_ClassDescription (string CG_ClassDescription){
    this.CG_ClassDescription = CG_ClassDescription;
}


//Getters
public int getCG_Id(){
    return CG_Id;
}

public string getCG_ClassGroup(){
    return CG_ClassGroup;
}

public string getCG_ClassDescription(){
    return CG_ClassDescription;
}




}//end class
}//end namespace
