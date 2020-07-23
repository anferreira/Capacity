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

namespace Nujit.Utility{

	/// <summary>
	/// Summary description for AppStart.
	/// </summary>
public 
class ApplicationStart{

public 
ApplicationStart(){
}

[STAThread]
static int Main(){
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

} // class

} // namespace

