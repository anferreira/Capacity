using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using  Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class CompanyCoreFactory : CmsCustomCoreFactory{

protected
CompanyCoreFactory() : base(){
}

public
string[][] getCompaniesAsString(){
    try{
	    CompanyDataBaseContainer companyDataBaseContainer = new CompanyDataBaseContainer(dataBaseAccess);
	    companyDataBaseContainer.read();

		string[][] v = new string[companyDataBaseContainer.Count][];
		for(int i = 0; i < companyDataBaseContainer.Count; i++){
			CompanyDataBase companyDataBase = (CompanyDataBase)companyDataBaseContainer[i];

			string[] line = new string[3];
			line[0] = companyDataBase.getCIA_Company().ToString();
			line[1] = companyDataBase.getCIA_Name();
			line[2] = companyDataBase.getCIA_Description();

			v[i] = line;
		}

		return v;	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}
public
bool existsCompany(string sdb,int icompany){
	   
	try{
		CompanyDataBase companyDataBase = new CompanyDataBase(dataBaseAccess);

		companyDataBase.setCIA_DB(sdb);
		companyDataBase.setCIA_Company(icompany);
		
		return companyDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
Company readCompany(string sdb,int icompany){
    try{		
		CompanyDataBase companyDataBase = new CompanyDataBase(dataBaseAccess);

		companyDataBase.setCIA_DB(sdb);
		companyDataBase.setCIA_Company(icompany);

		if (!companyDataBase.exists())
			return null;

		companyDataBase.read();

		Company company = this.objectDataBaseToObject(companyDataBase);
		
		return company;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCompany(Company company){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        CompanyDataBase companyDataBase = this.objectToObjectDataBase(company);
			        
        companyDataBase.update();

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
  
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeCompany(Company company){
   try{
   
       if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        CompanyDataBase companyDataBase = this.objectToObjectDataBase(company);
			        
        companyDataBase.write();

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
  
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void deleteCompany(Company company){
   try{
   
       if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        CompanyDataBase companyDataBase = this.objectToObjectDataBase(company);
			        
        companyDataBase.delete();

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
  
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getCompanyByDesc(string desc,string sdb){
	
	try{
	
	    CompanyDataBaseContainer companyDataBaseContainer = new CompanyDataBaseContainer(dataBaseAccess);
	    companyDataBaseContainer.readByDesc(desc,sdb);

	    string[][] items = new string[companyDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = companyDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    CompanyDataBase companyDataBase = (CompanyDataBase) en.Current;
    			
		    string[] item = new String[4];
		    item[0] = companyDataBase.getCIA_DB();
		    item[1] = companyDataBase.getCIA_Company().ToString();
			item[2] = companyDataBase.getCIA_Name();
		    item[3] = companyDataBase.getCIA_Description();
		        			
		    items[i] = item;
		    i++;
	    }
	    return items;
	 
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

protected Company objectDataBaseToObject (CompanyDataBase companyDataBase)
{
	Company company = new Company();
		
	company.setCompany(companyDataBase.getCIA_Company());
	company.setDb(companyDataBase.getCIA_DB ());
	company.setName(companyDataBase.getCIA_Name());
	company.setDescription(companyDataBase.getCIA_Description());
	company.setCurrOrderNum(companyDataBase.getCIA_CurrOrderNum());
	company.setCurrInvoiceNum(companyDataBase.getCIA_CurrInvoiceNum());
	company.setCurrBillLadNum(companyDataBase.getCIA_CurrBillLadNum());
	company.setCurrQuoteNum(companyDataBase.getCIA_CurrQuoteNum());
	company.setCurrCreditNoteNum(companyDataBase.getCIA_CurrCreditNoteNum());

	return company;
}

protected CompanyDataBase objectToObjectDataBase (Company company)
{	
	CompanyDataBase companyDataBase = new CompanyDataBase(dataBaseAccess);
		
	companyDataBase.setCIA_Company(company.getCompany());
	companyDataBase.setCIA_DB (company.getDb());
	companyDataBase.setCIA_Name(company.getName());
	companyDataBase.setCIA_Description(company.getDescription());
	companyDataBase.setCIA_CurrOrderNum(company.getCurrOrderNum());
	companyDataBase.setCIA_CurrInvoiceNum(company.getCurrInvoiceNum());
	companyDataBase.setCIA_CurrBillLadNum(company.getCurrBillLadNum());
	companyDataBase.setCIA_CurrQuoteNum(company.getCurrQuoteNum());
	companyDataBase.setCIA_CurrCreditNoteNum(company.getCurrCreditNoteNum());

	return companyDataBase;
}

public
Company createCompany(){
	return new Company();
}

} // class

} // namespace