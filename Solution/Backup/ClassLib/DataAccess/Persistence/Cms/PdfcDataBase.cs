using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PdfcDataBase : GenericDataBaseElement{

private string PXFMPT;
private string PXPART;
private decimal PXALT;
private decimal PXCQTY;
private string PXUNIT;
private string PXBLCK;
private decimal PXBRDP;
private decimal PXCEFF;
private decimal PXPREF;

public 
PdfcDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
			
public 
void load(NotNullDataReader reader){
    this.PXFMPT = reader.GetString("PXFMPT");
    this.PXPART = reader.GetString("PXPART");
	
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.PXALT = reader.GetDecimal("PXALT#");
	else
		this.PXALT = reader.GetDecimal("PXALT");

    this.PXCQTY = reader.GetDecimal("PXCQTY");
    this.PXUNIT = reader.GetString("PXUNIT");
    this.PXBLCK = reader.GetString("PXBLCK");
    this.PXBRDP = reader.GetDecimal("PXBRDP");
    this.PXCEFF = reader.GetDecimal("PXCEFF");
    this.PXPREF = reader.GetDecimal("PXPREF");
}

public override	
void write(){
	try{
		string sql = "insert into pdfc values('" +
			Converter.fixString(PXFMPT) + "', '" +
			Converter.fixString(PXPART) + "', " +
			NumberUtil.toString(PXALT) + ", " +
			NumberUtil.toString(PXCQTY) + ", '" +
			Converter.fixString(PXUNIT) + "', '" +
			Converter.fixString(PXBLCK) + "', " +
			NumberUtil.toString(PXBRDP) + ", " +
			NumberUtil.toString(PXCEFF) + ", " +
			NumberUtil.toString(PXPREF) + ")";

		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
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
void setPXFMPT(string PXFMPT){	
	this.PXFMPT = PXFMPT; 
}
public
void setPXPART(string PXPART){	
	this.PXPART = PXPART; 
}

public 
void setPXALT(decimal PXALT){	
	this.PXALT = PXALT; 
}

public 
void setPXCQTY(decimal PXCQTY){	
	this.PXCQTY = PXCQTY; 
}

public 
void setPXUNIT(string PXUNIT){	
	this.PXUNIT = PXUNIT; 
}

public 
void setPXBLCK(string PXBLCK){	
	this.PXBLCK = PXBLCK; 
}

public 
void setPXBRDP(decimal PXBRDP){	
	this.PXBRDP = PXBRDP; 
}

public 
void setPXCEFF(decimal PXCEFF){	
	this.PXCEFF = PXCEFF; 
}

public 
void setPXPREF(decimal PXPREF){	
	this.PXPREF = PXPREF; 
}


public 
string getPXFMPT(){ 
	return PXFMPT; 
}

public 
string getPXPART(){ 
	return PXPART; 
}

public 
decimal getPXALT(){ 
	return PXALT; 
}

public 
decimal getPXCQTY(){ 
	return PXCQTY; 
}

public 
string getPXUNIT(){ 
	return PXUNIT; 
}

public
string getPXBLCK(){ 
	return PXBLCK; 
}

public 
decimal getPXBRDP(){ 
	return PXBRDP; 
}

public 
decimal getPXCEFF(){ 
	return PXCEFF; 
}

public 
decimal getPXPREF(){ 
	return PXPREF; 
}

} // class

} // namespace