using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdPriceDataBaseContainer : GenericDataBaseContainer{

public
ProdPriceDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from ";

#if !POCKET_PC
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";		
#endif
		sql += "ProdPrice";
		

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);
			prodPriceDataBase.load(reader);
			this.Add(prodPriceDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <read>: " + de.Message,de);
	}
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision,int iquantity){
	try{

		string field = lastRevision.getFieldId();		
		
		string sproduct = "";
		string svolume="0";
		string scustClass="";
		string stype="";		
		string sdateBigger="";
		string sdateBiggerAndEqualSql="";
		
		/*
		sidToSync = prodPrice.getProduct()		+ Constants.FIELD_SEPARATOR + 
										//prodPrice.GetType()		+ Constants.FIELD_SEPARATOR + 
										//prodPrice.getCustClassID()+ Constants.FIELD_SEPARATOR + 										
                                		NumberUtil.toString(prodPrice.getVolume())	+ Constants.FIELD_SEPARATOR; 
		*/																	

		if (StringUtil.getQuantFields(field,Constants.FIELD_SEPARATOR) > 0)
		{
			StringUtil.getField(field,out sproduct,		0,Constants.FIELD_SEPARATOR);
			StringUtil.getField(field,out stype,		1,Constants.FIELD_SEPARATOR);
			StringUtil.getField(field,out scustClass,	2,Constants.FIELD_SEPARATOR);
			StringUtil.getField(field,out svolume,		3,Constants.FIELD_SEPARATOR);			
		}

		sdateBigger				="Prc_LastChgDate > '" + DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'";
		sdateBiggerAndEqualSql	="Prc_LastChgDate >= '" + DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'";
		
		string sql = "select * from prodprice "	+ 
					" where " +
					"("		+	sdateBigger				+ ") or " +					
					"(("	+	sdateBiggerAndEqualSql	+ " and Prc_Product > '"	+ sproduct	+ "') or " + 
					"("		+	sdateBiggerAndEqualSql	+ " and Prc_Product = '"	+ sproduct  + "' and Prc_Type > '" + stype + "') or" +
					"("		+	sdateBiggerAndEqualSql	+ " and Prc_Product = '"	+ sproduct  + "' and Prc_Type = '" + stype + "' and Prc_CustClassID >'" + scustClass + "') or " +
					"("		+	sdateBiggerAndEqualSql	+ " and Prc_Product = '"	+ sproduct  + "' and Prc_Type = '" + stype + "' and Prc_CustClassID ='" + scustClass + "' and Prc_Volume >" + svolume	+ "))" + 
					" order by Prc_LastChgDate,Prc_Product,Prc_Type,Prc_CustClassID,Prc_Volume";		
	/*
		string sql = "select * from prodprice "	+ 
			" where "				+ 
			" (Prc_LastChgDate >='"		+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and Prc_Product >= '"		+ sproduct	+ "' " + 
			" and Prc_Type >='"			+ stype		+ "' " + 	
			" and Prc_CustClassID >='"	+ scustClass+ "' " + 				
			" and Prc_Volume > "		+ svolume	+ ")" + 
			" or " +
			" (Prc_LastChgDate > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by Prc_LastChgDate,Prc_Product,Prc_Type,Prc_CustClassID,Prc_Volume";
	*/			

		sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType,iquantity);		
					
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);
			prodPriceDataBase.load(reader);
			this.Add(prodPriceDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readToSynchronize>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readToSynchronize>: " + de.Message,de);
	}
}
#endif

public 
void readProductPrice(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive,decimal quantity){
	try{
		DateTime	dateTime = DateTime.Now;		
		string		sql = "select * from prodprice ";
		
		sql+=" where Prc_Product='" + sproduct + "'";

		if (scustomer.Length > 0)
			sql+=	" and Prc_CustClassID = '" + scustomer + "'" +
					" and Prc_Type = '" + Constants.PRICE_TYPE_CUSTOMER + "'";

		if (scustomersClass.Length > 0)
			sql+=	" and Prc_CustClassID = '" + scustomersClass + "'" +
					" and Prc_Type = '" + Constants.PRICE_TYPE_CLASS + "'";

		if ((scustomersClass.Length == 0) && (scustomer.Length == 0))
			sql+=	" and Prc_Type = '" + Constants.PRICE_TYPE_GENERIC + "'";

		if (sdateTime.Length > 0)
		{			
			//we must create a DateTime to use the Persistence/UtilDb
			dateTime = DateUtil.parseDate(sdateTime,DateUtil.MMDDYYYY);
			sdateTime = DateUtil.getCompleteDateRepresentation(dateTime);
		
			sql+=" and Prc_EffecToDate >= '" + sdateTime	+ "' "; //between date
			sql+=" and Prc_EffecFrmDate<= '" + sdateTime	+ "'";
		}

		if (sactive.Length > 0)
			sql+=" and Prc_Active = '"		+ sactive	+ "'";//if active

		if (quantity >= 0)
		{
			sql+=" and (Prc_Volume <= '"		+ NumberUtil.toString(quantity)	+ "'" +
				" or Prc_Volume is NULL)"; //volume
		}

		sql+= " order by Prc_Volume desc";//order by volume
 
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);
			prodPriceDataBase.load(reader);
			this.Add(prodPriceDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readProductPrice>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readProductPrice>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProductPrice> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <readProductPrice>: " + de.Message,de);
	}
}
public
void truncate(){
	try{
		string sql = "delete from prodprice";
		
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class ProdPriceDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
ProdPriceDataBase getProdPriceInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (ProdPriceDataBase)this[pos];
}

} // class

} // namespace