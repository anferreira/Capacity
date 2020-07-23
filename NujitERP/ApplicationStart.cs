/*********************************************************************** 
File Name:               FormMain.cs
Created By:              Eric zhong
Created Date:            09/03/2004
***********************************************************************/

using System;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;

using Nujit.NujitERP.WinForms.Master;
using System.Globalization;
using System.Collections;
using Nujit.NujitERP.WinForms.Schedule.HotList;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.Utility{

	/// <summary>
	/// Summary description for AppStart
	/// </summary>
public 
class ApplicationStart{

public 
ApplicationStart(){
}

[STAThread]
static int Main(string[] args){
	try{                
		Configuration.OnApplicationStart();
		Culture.setCulture(CultureInfo.CurrentCulture);//set the Culture object

		if (Configuration.RunMode.Equals("Server")){
			UtilCoreFactory.createCoreFactory();
			FormServer serverForm = new FormServer();
			serverForm.ShowDialog();
			return 0;
		}
		
		bool blnContinue = false;

		User objUser = null;
		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();


        //ArrayList arrayList = coreFactory.getDemandForPart("AMF4739");// CBHD-4-4  AMF4739A C40000A
        //arrayList = coreFactory.getDemandForPart("AMF4739A");// CBHD-4-4  AMF4739A C40000A


        if (args.Length > 0)
            processArgs(args, coreFactory);

		UserContainer users = coreFactory.readUsers();

		if (users.Count == 0){
			FormAddUser formAddUser = new FormAddUser();
			formAddUser.ShowDialog();

			if (DialogResult.Yes == formAddUser.ShowDialog()){
				blnContinue = true;
				objUser = FormAddUser.Operator;
				formAddUser.Dispose();
			}
		}else if (users.Count > 0){
			FormLogin formLogin = new FormLogin();

			if (DialogResult.Yes == formLogin.ShowDialog()){
				blnContinue = true;
				objUser = formLogin.getLoggedUser();
				formLogin.Dispose();
			}
		}
        

		if (blnContinue == true){
            Configuration.UserLogged = objUser;

            FormMain formMain = new FormMain();
			FormMain.Operator  = objUser;
			Application.Run(formMain);
		}

		return FormMain.returnCode;
	}catch(Exception exc){
		FormException formException = new FormException(exc);
		formException.ShowDialog();
		return FormMain.returnCode;
	}      

			#region Login and check serial number
//			Configuration.OnApplicationStart();
//
//			//    Configuration.OnApplicationStart(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
//
//			bool blnContinue = false;
//
//			User objUser = null;
//
//			DataSet dsUsers = new DataSet();
//
//			UserCollection objUsercollection = new UserCollection();
//
//			dsUsers = objUsercollection.LoadUserDataSetByType();
//
//			if (dsUsers != null && dsUsers.Tables.Count >0 && dsUsers.Tables[0].Rows.Count == 0)
//			{
//				FormAddUser formAddUser = new FormAddUser();
//
//				if (DialogResult.Yes == formAddUser.ShowDialog())
//				{
//					blnContinue = true;
//					objUser = formAddUser.Operator ;
//					formAddUser.Dispose();
//				}
//			}
//			else if (dsUsers != null && dsUsers.Tables.Count >0 && dsUsers.Tables[0].Rows.Count > 0)
//			{
//				FormLogin formLogin = new FormLogin();
//
//				formLogin.UserDataSet = dsUsers;
//
//				if (DialogResult.Yes == formLogin.ShowDialog())
//				{
//					blnContinue = true;
//
//					objUser = formLogin.Operator ;
//
//					formLogin.Dispose();
//
//				}
//			}
//
//			if (blnContinue == true)
//			{
//				FormMain formMain = new FormMain();
//
//				formMain.Operator  = objUser;
//				
//				Application.Run(formMain);
//			}
//      
		#endregion Login and check serial number
}


private static
void processArgs(string[] args,CoreFactory coreFactory){    
    string stype  = args.Length > 0 ? args[0]  :"";
    string stask  = args.Length > 1 ? args[1]  :"";

    //for (int i=0; i < args.Length;i++ )
        //MessageBox.Show(args[i]);
    
    if (!string.IsNullOrEmpty(stype)){
        switch(stype.ToUpper()){
            case "-P":
                switch(stask){
                    case "1268":                       
                        store1268Report(coreFactory);
                        break;    
                    case "1268E":
                        exportToCSV1268Report(coreFactory);
                        break;
                    case "DEMAND":
                       if (args.Length > 3)
                            process830862(args[2], args[3]);
                        break;                                                                                                                                
                    default:
                        break;
                }
                break;                               
            default:
                break;                    
        }
    }
    
    if (!string.IsNullOrEmpty(stype))
        Environment.Exit(0);
}

private static
void store1268Report(CoreFactory coreFactory){
    try{                          
        ArrayList       alist=null;
        ExportModel     exportModel = new ExportModel();

        NujitMessageTimerForm nujitMessageTimerForm = new NujitMessageTimerForm("Starting Stored Report",1 * 1000);
        nujitMessageTimerForm.ShowDialog();

        coreFactory.runStoreReport1268(out alist);      
        if (alist.Count > 0)                
            exportModel.exportToCSVStored1268Report(coreFactory,null,false,true,true); //export CSV automatically

        NujitMessageTimerForm nujitMessageTimerForm2 = new NujitMessageTimerForm("End Stored Report",1 * 1000);
        nujitMessageTimerForm2.ShowDialog();
    }catch(Exception exc){		        
		//using(FormException formException = new FormException(exc))
		   // formException.ShowDialog();
	}finally{        
    }
}

private static
void exportToCSV1268Report(CoreFactory coreFactory){
    try{                                  
        ExportModel     exportModel = new ExportModel();

        NujitMessageTimerForm nujitMessageTimerForm = new NujitMessageTimerForm("Starting Stored Report",1 * 1000);
        nujitMessageTimerForm.ShowDialog();

        exportModel.exportToCSV1268Report(coreFactory,null);
                
        NujitMessageTimerForm nujitMessageTimerForm2 = new NujitMessageTimerForm("End Stored Report",1 * 1000);
        nujitMessageTimerForm2.ShowDialog();
    }catch(Exception exc){		        
		//using(FormException formException = new FormException(exc))
		   // formException.ShowDialog();
	}finally{        
    }
}

private static
void process830862(string sfromDate,string stoDate){        
    try{
        CoreFactory core    = UtilCoreFactory.createCoreFactory();
        DateTime    fromDate= DateUtil.parseDate(sfromDate, DateUtil.MMDDYYYY);
        DateTime    toDate  = DateUtil.parseDate(stoDate, DateUtil.MMDDYYYY);

        MessageBox.Show("fromDate:" + DateUtil.getDateRepresentation(fromDate,DateUtil.MMDDYYYY) + "\n" +
                        "toDate:"   + DateUtil.getDateRepresentation(toDate, DateUtil.MMDDYYYY));

        NujitMessageTimerForm nujitMessageTimerForm = new NujitMessageTimerForm("Starting Process Demand",1 * 1000);
        nujitMessageTimerForm.ShowDialog();

        core.processDemand830862ByDate("",fromDate, toDate,false,true);

        NujitMessageTimerForm nujitMessageTimerForm2 = new NujitMessageTimerForm("End Process Demand",1 * 1000);
        nujitMessageTimerForm2.ShowDialog();

    }catch (Exception ex){
       MessageBox.Show("Process 830/862 Exception: " + ex.Message);  
    }    
}
         

} // class

} // namespace

