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
class UtilityCoreFactory : UserCoreFactory{

protected
UtilityCoreFactory() : base(){
}

public 
string[][] getPaintOrdersHotListAsString(int pONum){
	try{
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readPO();

		string[][] returnArray = new string[20][];
		int i = 0;
		int j = 0;

        int po = pONum+1;
		string[] lineArray = new string[12];

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			if ( (i>=pONum*20) && (i<pONum*20+20) ) {
                lineArray = new string[12];
				string prodId = hotListDataBase.getHOT_ProdID();
				string prodSeq = hotListDataBase.getHOT_Seq().ToString(); 
				string[] mat = UtilCoreFactory.createCoreFactory().getMainMaterial(prodId, prodSeq);
				int qraw = i*10;
				int qplan = i*13;
				lineArray[0] = prodId;
				lineArray[1] = prodSeq;
				lineArray[2] = mat[0];
				lineArray[3] = mat[1];
				lineArray[4] = qraw.ToString();
				lineArray[5] = qplan.ToString();
				lineArray[6] = hotListDataBase.getHOT_PastDue().ToString();
				lineArray[7] = hotListDataBase.getHOT_Day001().ToString();
				lineArray[8] = hotListDataBase.getHOT_Day002().ToString();
				lineArray[9] = hotListDataBase.getHOT_Day003().ToString();
				lineArray[10] = hotListDataBase.getHOT_Day004().ToString();
				lineArray[11] = hotListDataBase.getHOT_Day005().ToString();
				returnArray[j] = lineArray;
				i++;
				j++;
				if (j>19)
					break;
			} else {
				i++;
			}
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getPaintOrdersHotListSumAsString(){
	try{
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readPO();

		string[][] returnArray = new string[4][];
		int i = 0;

        int poCount = 0;
		decimal[] poSubTotal = new decimal[5];
		string[] lineArray = new string[7];
		
		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			poSubTotal[0] += hotListDataBase.getHOT_Day001();
			poSubTotal[1] += hotListDataBase.getHOT_Day002();
			poSubTotal[2] += hotListDataBase.getHOT_Day003();
			poSubTotal[3] += hotListDataBase.getHOT_Day004();
			poSubTotal[4] += hotListDataBase.getHOT_Day005();

			poCount++;
			if (poCount==21) {
                lineArray = new string[7];
				//lineArray[0] = hotListDataBase.getHOT_ProdID();
				int j = i+1;
				lineArray[0] = "";
				lineArray[1] = hotListDataBase.getHOT_PastDue().ToString();
				lineArray[2] = poSubTotal[0].ToString();
				lineArray[3] = poSubTotal[1].ToString();
				lineArray[4] = poSubTotal[2].ToString();
				lineArray[5] = poSubTotal[3].ToString();
				lineArray[6] = poSubTotal[4].ToString();
				poSubTotal = new decimal[5];
				returnArray[i] = lineArray;
				poCount=0;
				i++;
				if (i>3)
					break;
			}
		}
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


//---------------------- Shortage Report for Daryl  we use  STKT in cmstemp instead of IvTransact--------------------------

public 
string[][] getShortageReportAsString(string[] vecMajorFilter,string[] vecMinorFilter, DateTime dateFrom){
	try{
	
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		ArrayList array =  prodFmActPlanDataBaseContainer.readForShortageReport(vecMajorFilter,vecMinorFilter);
        
        ArrayList lst = new ArrayList();
        DateTime[] weeks = new DateTime[4];
        //DateTime[] months = new DateTime[4];
        loadWeeks(weeks,dateFrom); 
        //loadMonths(months,weeks[3].AddDays(7)); 
	    
	    dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE); //read STKT table
	    string majorGrp = "";
        string part = "";
	    string qoh = "";
	    string minInv = "";
	        
	    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		    string[] lineArray = (string[])en.Current;
	        
	        if (!majorGrp.Equals(lineArray[2])||(!part.Equals(lineArray[0]))){
	            majorGrp = lineArray[2];
	            part = lineArray[0];
	            qoh = lineArray[5];
	            minInv = lineArray[3];
	        
		        StktDataBaseContainer stktDataBaseContainer= new StktDataBaseContainer(dataBaseAccess);    
		        stktDataBaseContainer.readForReport(dateFrom,weeks[3].AddDays(-7),part);
    		    
		        string[] line = new string[8];
     	       
	            line[0] = majorGrp; //MajorGrp
	            line[1] = part; //Part
	            line[2] = qoh; //Qoh
	            line[3] = minInv; //MinInv
	            
	            decimal addWeek1 = 0;
	            decimal addWeek2 = 0;
	            decimal addWeek3 = 0;
	            decimal addWeek4 = 0;
	            bool existStkt =false;
	     	    
	    	    for(IEnumerator enStkt = stktDataBaseContainer.GetEnumerator(); enStkt.MoveNext(); ){
			        StktDataBase stktDataBase = (StktDataBase) enStkt.Current;
    		        
                    int inWeek = findWeek(stktDataBase.getBYTDAT(),weeks);
                    if (inWeek == 0)
                        addWeek1 = addWeek1 + stktDataBase.getBYQTY();
                    if (inWeek == 1)
                        addWeek2 = addWeek2 + stktDataBase.getBYQTY();
                    if (inWeek == 2)
                        addWeek3 = addWeek3 + stktDataBase.getBYQTY();
                    if (inWeek == 3)
                        addWeek4 = addWeek4 + stktDataBase.getBYQTY();
                    
                    existStkt = true;
	            }
	            if (existStkt){
	                line[4] = addWeek1.ToString();
	                line[5] = addWeek2.ToString();
	                line[6] = addWeek3.ToString();
	                line[7] = addWeek4.ToString();
	                lst.Add(line);
	            }
	        }
	    }
	    
	    int index = 0;
	    string[][] returnArray = new string[lst.Count][];
	    for(IEnumerator enLst = lst.GetEnumerator(); enLst.MoveNext(); ){
		    string[] lineArray = (string[])enLst.Current;
		    returnArray[index] = lineArray;
		    index++;
	    }
	    
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
        
        return returnArray;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


private void loadWeeks(DateTime[] weeks,DateTime startDate){

    DayOfWeek  startDay = startDate.DayOfWeek;
    weeks[0] = startDate;
    for (int i=1; i<weeks.Length;i++){
                weeks[i] = weeks[i-1].AddDays(-7);
    }

}

private int findWeek(DateTime date,DateTime[] weeks){
    
    
     if (((DateTime.Compare(date,weeks[3]) < 0 )) ||
        ((DateTime.Compare(date,weeks[3]) == 0 )))
            return 3;

    if (((DateTime.Compare(date,weeks[2]) < 0 )) ||
        ((DateTime.Compare(date,weeks[2]) == 0 )))
            return 2;
                        
    if (((DateTime.Compare(date,weeks[1]) < 0 )) ||
        ((DateTime.Compare(date,weeks[1]) == 0 )))
            return 1;
                        
    if (((DateTime.Compare(date,weeks[0]) < 0 )) ||
        ((DateTime.Compare(date,weeks[0]) == 0 )))
            return 0;
    return -1;    
}



} // class

} // namespace