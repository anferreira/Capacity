using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public class TPartnerLocDataBase : GenericDataBaseElement {

private string TPL_TPartnerType;
private string TPL_Tpartner;
private string TPL_TpartnerLoc;
private string TPL_LocationName;
private string TPL_LocQualifier;
private string TPL_DefBillToNum;
private string TPL_DefShipToCust;
private string TPL_RAPartProfile;


public TPartnerLocDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public
void load(NotNullDataReader reader){
this.TPL_TPartnerType = reader.GetString("TPL_TPartnerType");
this.TPL_Tpartner = reader.GetString("TPL_Tpartner");
this.TPL_TpartnerLoc = reader.GetString("TPL_TpartnerLoc");
this.TPL_LocationName = reader.GetString("TPL_LocationName");
this.TPL_LocQualifier = reader.GetString("TPL_LocQualifier");
this.TPL_DefBillToNum = reader.GetString("TPL_DefBillToNum");
this.TPL_DefShipToCust = reader.GetString("TPL_DefShipToCust");
this.TPL_RAPartProfile = reader.GetString("TPL_RAPartProfile");
}

public override
void write(){
try{
		string sql = "insert into tpartner values('" + 
                        Converter.fixString(TPL_TPartnerType) +"', '" +
                        Converter.fixString(TPL_Tpartner) +"', '" +
                        Converter.fixString(TPL_TpartnerLoc) +"', '" +
                        Converter.fixString(TPL_LocationName) +"', '" +
                        Converter.fixString(TPL_LocQualifier) +"', '" +
                        Converter.fixString(TPL_DefBillToNum) +"', '" +
                        Converter.fixString(TPL_DefShipToCust) +"', '" +
                        Converter.fixString(TPL_RAPartProfile) +"')";
            dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
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

//Setters
public void setTPL_TPartnerType (string TPL_TPartnerType){
    this.TPL_TPartnerType = TPL_TPartnerType;
}

public void setTPL_Tpartner (string TPL_Tpartner){
    this.TPL_Tpartner = TPL_Tpartner;
}

public void setTPL_TpartnerLoc (string TPL_TpartnerLoc){
    this.TPL_TpartnerLoc = TPL_TpartnerLoc;
}

public void setTPL_LocationName (string TPL_LocationName){
    this.TPL_LocationName = TPL_LocationName;
}

public void setTPL_LocQualifier (string TPL_LocQualifier){
    this.TPL_LocQualifier = TPL_LocQualifier;
}

public void setTPL_DefBillToNum (string TPL_DefBillToNum){
    this.TPL_DefBillToNum = TPL_DefBillToNum;
}

public void setTPL_DefShipToCust (string TPL_DefShipToCust){
    this.TPL_DefShipToCust = TPL_DefShipToCust;
}

public void setTPL_RAPartProfile (string TPL_RAPartProfile){
    this.TPL_RAPartProfile = TPL_RAPartProfile;
}


//Getters
public string getTPL_TPartnerType(){
    return TPL_TPartnerType;
}

public string getTPL_Tpartner(){
    return TPL_Tpartner;
}

public string getTPL_TpartnerLoc(){
    return TPL_TpartnerLoc;
}

public string getTPL_LocationName(){
    return TPL_LocationName;
}

public string getTPL_LocQualifier(){
    return TPL_LocQualifier;
}

public string getTPL_DefBillToNum(){
    return TPL_DefBillToNum;
}

public string getTPL_DefShipToCust(){
    return TPL_DefShipToCust;
}

public string getTPL_RAPartProfile(){
    return TPL_RAPartProfile;
}


}//end class
}//end namespace
