using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class ProductCoreFactory : ProductActCostCoreFactory{

protected
ProductCoreFactory() : base(){
}

/// <summary>
/// return all products codes 
/// </summary>
/// <returns></returns>
public
string[] getProductCodes(){
    
    try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getProductCodes();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getManufacturedProductCodes(string plantCode){
	try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getManufacturedProductCodes(plantCode);
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByDescOrId(string desc, string retailProductType){
	
	try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByDescOrId(desc, retailProductType);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase) en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	 
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByProdId(string prod){
	try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByProdId(prod);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByProdIdAndFamily(string prod, bool family){
	try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByProdIdAndFamily(prod, family);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByDesc(string desc){

    try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByDesc(desc);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// return all family codes
/// </summary>
/// <returns></returns>
public
string[] getProductFamilyCodes(){
    try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getProductFamilyCodes();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Returns true is the part number is a family of products
/// </summary>
/// <param name="partNum"></param>
/// <returns></returns>
public 
bool isFamilyPart(string partNum){
    try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);

	    prodFmInfoDataBase.setPFS_ProdID(partNum);
	    if (prodFmInfoDataBase.exists()) {
            prodFmInfoDataBase.read();
		    return (prodFmInfoDataBase.getPFS_FamProd() == "F");
	    }
	    else
		    return false;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return all seqs valids for a product code
/// </summary>
/// <param name="productCode"></param>
/// <returns></returns>
public
string[] getValidsSeqsForProduct(string productCode){
    try{
	    ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
	    prodFmActHDataBaseContainer.readByProduct(productCode);

	    string[] vec = new string[prodFmActHDataBaseContainer.Count];
	    int i = 0;
	    for(IEnumerator en = prodFmActHDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActHDataBase prodFmActHDataBase = (ProdFmActHDataBase) en.Current;
		    vec[i] = prodFmActHDataBase.getPAH_Seq().ToString();
		    i++;
	    }
	    return vec;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getValidsSeqsByProdAndDept(string productCode, string department){
    try{
	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.readByProdAndDept(productCode, department);

	    string[] vec = new string[prodFmActSubDataBaseContainer.Count];
	    int i = 0;
	    for(IEnumerator en = prodFmActSubDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;
		    vec[i] = prodFmActSubDataBase.getPC_Seq().ToString();
		    i++;
	    }
	    return vec;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return if exists a product
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsProduct(string id){
	try{
	
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(id);
	    return prodFmInfoDataBase.exists();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Product createProduct(){
	return new Product();
}

/// <summary>
/// Read and return a Product object
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
Product readProduct(string id){
	try{
	
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(id);
    	
	    if (!prodFmInfoDataBase.exists())
		    return null;

	    prodFmInfoDataBase.read();

	    Product product = new Product(prodFmInfoDataBase.getPFS_ProdID(),prodFmInfoDataBase.getPFS_Db(),
	        prodFmInfoDataBase.getPFS_Des1(),
		    prodFmInfoDataBase.getPFS_Des2(), prodFmInfoDataBase.getPFS_Des3(),
		    prodFmInfoDataBase.getPFS_VarFam(), prodFmInfoDataBase.getPFS_SeqLast(),
		    prodFmInfoDataBase.getPFS_ActIDLast(), prodFmInfoDataBase.getPFS_FamProd(),
		    prodFmInfoDataBase.getPFS_PartType(), prodFmInfoDataBase.getPFS_InvStatus(),
		    prodFmInfoDataBase.getPFS_ABCCode(), prodFmInfoDataBase.getPFS_MajorGroup(),
		    prodFmInfoDataBase.getPFS_MinorGroup(), prodFmInfoDataBase.getPFS_GLExp(),
		    prodFmInfoDataBase.getPFS_GLDistr(), prodFmInfoDataBase.getPFS_MajorSales(),
		    prodFmInfoDataBase.getPFS_MinorSales(), prodFmInfoDataBase.getPFS_LastRevision(),
		    prodFmInfoDataBase.getPFS_RetailProductType(), prodFmInfoDataBase.getPFS_StdPackSize(),
		    prodFmInfoDataBase.getPFS_StdPackUnit(),prodFmInfoDataBase.getPFS_ProdCode());
    	
	    return product;
	 }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Write to the database a Product object
/// </summary>
/// <param name="proccess"></param>
public
void writeProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(product.getProdID());
		prodFmInfoDataBase.setPFS_Db(product.getDb());
		prodFmInfoDataBase.setPFS_Des1(product.getDes1());
		prodFmInfoDataBase.setPFS_Des2(product.getDes2());
		prodFmInfoDataBase.setPFS_Des3(product.getDes3());
		prodFmInfoDataBase.setPFS_VarFam(product.getVarFam());
		prodFmInfoDataBase.setPFS_SeqLast(product.getSeqLast());
		prodFmInfoDataBase.setPFS_ActIDLast(product.getActIDLast());
		prodFmInfoDataBase.setPFS_FamProd(product.getFamProd());
		prodFmInfoDataBase.setPFS_PartType(product.getPartType());
		prodFmInfoDataBase.setPFS_InvStatus(product.getInvStatus());
		prodFmInfoDataBase.setPFS_ABCCode(product.getABCCode());
		prodFmInfoDataBase.setPFS_MajorGroup(product.getMajorGroup());
		prodFmInfoDataBase.setPFS_MinorGroup(product.getMinorGroup());
		prodFmInfoDataBase.setPFS_GLExp(product.getGLExp());
		prodFmInfoDataBase.setPFS_GLDistr(product.getGLDistr());
		prodFmInfoDataBase.setPFS_MajorSales(product.getMajorSales());
		prodFmInfoDataBase.setPFS_MinorSales(product.getMinorSales());
		prodFmInfoDataBase.setPFS_LastRevision(product.getLastRevision());
		prodFmInfoDataBase.setPFS_RetailProductType(product.getRetailProductType());
		prodFmInfoDataBase.setPFS_StdPackSize(product.getStdPackSize());
		prodFmInfoDataBase.setPFS_StdPackUnit(product.getStdPackUnit());
        prodFmInfoDataBase.setPFS_ProdCode(product.getProdCode());
		prodFmInfoDataBase.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Update a Product object
/// </summary>
/// <param name="proccess"></param>
public
void updateProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(product.getProdID());
		prodFmInfoDataBase.setPFS_Db(product.getDb());
		prodFmInfoDataBase.setPFS_Des1(product.getDes1());
		prodFmInfoDataBase.setPFS_Des2(product.getDes2());
		prodFmInfoDataBase.setPFS_Des3(product.getDes3());
		prodFmInfoDataBase.setPFS_VarFam(product.getVarFam());
		prodFmInfoDataBase.setPFS_SeqLast(product.getSeqLast());
		prodFmInfoDataBase.setPFS_ActIDLast(product.getActIDLast());
		prodFmInfoDataBase.setPFS_FamProd(product.getFamProd());
		prodFmInfoDataBase.setPFS_PartType(product.getPartType());
		prodFmInfoDataBase.setPFS_InvStatus(product.getInvStatus());
		prodFmInfoDataBase.setPFS_ABCCode(product.getABCCode());
		prodFmInfoDataBase.setPFS_MajorGroup(product.getMajorGroup());
		prodFmInfoDataBase.setPFS_MinorGroup(product.getMinorGroup());
		prodFmInfoDataBase.setPFS_GLExp(product.getGLExp());
		prodFmInfoDataBase.setPFS_GLDistr(product.getGLDistr());
		prodFmInfoDataBase.setPFS_MajorSales(product.getMajorSales());
		prodFmInfoDataBase.setPFS_MinorSales(product.getMinorSales());
		prodFmInfoDataBase.setPFS_LastRevision(product.getLastRevision());
		prodFmInfoDataBase.setPFS_RetailProductType(product.getRetailProductType());
		prodFmInfoDataBase.setPFS_StdPackSize(product.getStdPackSize());
		prodFmInfoDataBase.setPFS_StdPackUnit(product.getStdPackUnit());
		prodFmInfoDataBase.setPFS_ProdCode(product.getProdCode());

		prodFmInfoDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Delete a Product object
/// </summary>
/// <param name="proccess"></param>
public
void deleteProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(product.getProdID());
		prodFmInfoDataBase.delete();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getComponentsFromFamily(string familyCode){
	
	try{
	    ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
	    prodFmActPlanDtDataBaseContainer.readByFamily(familyCode);

	    string[][] components = new string[prodFmActPlanDtDataBaseContainer.Count][];
	    int i = 0;
    	
	    for(IEnumerator en = prodFmActPlanDtDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = (ProdFmActPlanDtDataBase) en.Current;
    		
		    string[] line = new string[2];
		    line[0] = prodFmActPlanDtDataBase.getPFPD_ProdID();
		    line[1] = prodFmActPlanDtDataBase.getPFPD_FamSeq().ToString();
		    components[i] = line;
		    i++;
	    }	
    	
	    return components;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getAllMaterialsForProduct(string prodId, int seqId){
	try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(prodId);
	    prodFmInfoDataBase.read();
    	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
    	
	    ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
	    prodFmActSubDataBase.setPC_ProdID(prodId);
	    prodFmActSubDataBase.setPC_Seq(seqId);
	    prodFmActSubDataBase.read();

	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);

	    Bom bom = this.makeBom(prodId, seqId, prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer);
    	
	    string[][] v = bom.toArray();
	    string[][] returnArray = new string[v.Length][];
    	
	    for(int i = 0; i < v.Length; i++){
		    string[] line = new string[7];

		    decimal inv = 0;
		    string desc = "";
			string type = "";

		    ProdFmInfoDataBase seeked = 
			    prodFmInfoDataBaseContainer.getProdFmInfo(v[i][1]);

		    if (seeked != null){
			    seeked.read();
			    desc = seeked.getPFS_Des1();
				type = seeked.getPFS_PartType();
		    }

		    InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
		    invPltLocDataBase.setIPL_ProdID(v[i][1]);
		    invPltLocDataBase.setIPL_Seq(seqId);
		    if (invPltLocDataBase.exists()){
			    invPltLocDataBase.read();
			    inv = invPltLocDataBase.getIPL_Qoh();
		    }

		    line[0] = v[i][1];         // prod
		    line[1] = v[i][0];         // level
		    line[2] = desc;            // desc
		    line[3] = v[i][3];         // qty req
		    line[4] = decimal.Round(inv, 2).ToString();  // inventory
		    line[5] = v[i][2];  // sequence
			line[6] = type.Equals("P") ? "Purchased" : "Manufatured";

		    returnArray[i] = line;
	    }
	    return returnArray;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[] getMainMaterial(string prodId, string seq){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(prodId.Trim());
		bomSumDataBase.setBMS_Seq(int.Parse(seq.Trim()));
		
		string[] returnArray = new string[2];

		if (bomSumDataBase.exists()){
			bomSumDataBase.read();
			returnArray[0] = bomSumDataBase.getBMS_MatID();
			returnArray[1] = bomSumDataBase.getBMS_MatSeq().ToString();
		}else{
			returnArray[0] = prodId;
			returnArray[1] = seq;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getProductsForReportAsString(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		prodFmInfoDataBaseContainer.readForReport(infMayGroup,infMinGroup,supMayGroup,supMinGroup,prodsID);

		string[][] returnArray = new string[prodFmInfoDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)  en.Current;

			string[] lineArray = new string[18];
			lineArray[0] = prodFmInfoDataBase.getPFS_ProdID();
			lineArray[1] = prodFmInfoDataBase.getPFS_Des1();
			lineArray[2] = prodFmInfoDataBase.getPFS_Des2();
			lineArray[3] = prodFmInfoDataBase.getPFS_Des3();
			lineArray[4] = prodFmInfoDataBase.getPFS_VarFam();
			lineArray[5] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
			lineArray[6] = prodFmInfoDataBase.getPFS_ActIDLast();
			lineArray[7] = prodFmInfoDataBase.getPFS_FamProd();
			lineArray[8] = prodFmInfoDataBase.getPFS_PartType();
			lineArray[9] = prodFmInfoDataBase.getPFS_InvStatus();
			lineArray[10] = prodFmInfoDataBase.getPFS_ABCCode();
			lineArray[11] = prodFmInfoDataBase.getPFS_MajorGroup();
			lineArray[12] = prodFmInfoDataBase.getPFS_MinorGroup();
			lineArray[13] = prodFmInfoDataBase.getPFS_GLExp();
			lineArray[14] = prodFmInfoDataBase.getPFS_GLDistr();
			lineArray[15] = prodFmInfoDataBase.getPFS_MajorSales();
			lineArray[16] = prodFmInfoDataBase.getPFS_MinorSales();
			lineArray[17] = prodFmInfoDataBase.getPFS_LastRevision().ToString();
	
			returnArray[i] = lineArray;
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//------------------ Select the Major Group from ProdFmInfo

public 
string[] getMajorGroupASString(string major){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		return prodFmInfoDataBaseContainer.readMajorGroup(major);
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//------------------ Select the Minor Group from ProdFmInfo

public 
string[] getMinorGroupASString(){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		return prodFmInfoDataBaseContainer.readMinorGroup();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

} // class
} // namespace