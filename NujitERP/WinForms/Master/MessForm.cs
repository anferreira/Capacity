using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

//using Messenger;
// must be included too the reference to 
//the com objects (look up for MESSENGER)

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for MessForm.
	/// </summary>
	public class MessForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MessForm()
		{

			InitializeComponent();
/*
			object objTemp = null;
			string guidstr = "{716238D9-8ED3-48aa-A7A0-A73CA6FDF1EF}";

			EnvDTE.Window windowToolWindow = 
				applicationObject.Windows.CreateToolWindow (
				addInInstance,
				"VSUserControlHost.VSUserControlHostCtl",
				"Messenger", guidstr, ref objTemp);
*/
/*
			Messenger.MsgrObjectClass msg;
			Messenger.IMsgrUser currentUser;
			Messenger.IMsgrUsers users;

			msg = new Messenger.MsgrObjectClass();
		

			try{
			if (msg.LocalState == Messenger.MSTATE.MSTATE_OFFLINE){
				Messenger.MessengerAppClass app = 

					new Messenger.MessengerAppClass();

			try{
				app.IMessengerApp_LaunchLogonUI();
			}catch(Exception e2){
				MessageBox.Show(e2.Message);
			}			
				//app.LaunchLogonUI();

				// HACK: Must be a better way
				// wait for the login to complete
//				while(msg.LocalState != Messenger.MSTATE.MSTATE_ONLINE)
//				System.Threading.Thread.Sleep(5000);
System.Console.WriteLine("msg.LocalState : " + msg.LocalState);
System.Console.WriteLine("app.StatusText : " + app.StatusText);
			}

			// Get the User list and fill the list view
			users = msg.get_List(Messenger.MLIST.MLIST_CONTACT);

			for(int i = 0; i < users.Count; i++){
				Messenger.IMsgrUser u = users.Item(i);
				//userList.Items.Add(new ListViewItem(u.FriendlyName, GetStateImage(u.State)));
				System.Console.WriteLine("FriendlyName : " + u.FriendlyName);
			}

			// Recieve notification for messages recieved
			//  msg.OnTextReceived +=
			//    new Messenger.DMsgrObjectEvents_OnTextReceivedEventHandler
//												(this.OnTextRecieved);

			// Recieve notification for user state change
			//  msg.OnUserStateChanged += new 
				//Messenger.DMsgrObjectEvents_OnUserStateChangedEventHandler
				//                               (this.OnUserStateChanged);
				
			}catch(Exception e){
				MessageBox.Show(e.Message);
			}			
*/			
/*			
			obj.IMsgrObject_Logon("gmuller2004@hotmail.com", "3982390", obj.IMsgrObject_Services.PrimaryService);

			Messenger.MessengerAppClass app = new Messenger.MessengerAppClass();



			obj.IMsgrObject_Logoff();
*/
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MessForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 286);
			this.Name = "MessForm";
			this.Text = "MessForm";

		}
		#endregion
	}
}
