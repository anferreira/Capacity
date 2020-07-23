using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.ClassLib.ErpException;



namespace Nujit.NujitERP.WinForms.OrderEntry
{
	/// <summary>
	/// Summary description for ShipFromForm.
	/// </summary>
	public class ShipFromForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox gBoxShipNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lPSFAdd4;
        private System.Windows.Forms.Label lPSFAdd3;
        private System.Windows.Forms.Label lPSFAdd2;
        private System.Windows.Forms.Label lPSFAdd1;
        private System.Windows.Forms.Button btnSchSFContact;
        private System.Windows.Forms.Label lPSFContact;
        private System.Windows.Forms.Label lPSFPostZip;
        private System.Windows.Forms.Label lPSFProvCountry;
        private System.Windows.Forms.Label lPSFProvState;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.TextBox tBoxCustTerritory;
        private System.Windows.Forms.TextBox tBoxCustRegion;
        private System.Windows.Forms.TextBox tBoxCustId;
        private System.Windows.Forms.TextBox tBoxCustName;
        private System.Windows.Forms.TextBox tBoxCustCountry;
        private System.Windows.Forms.TextBox tBoxCustAddr1;
        private System.Windows.Forms.TextBox tBoxCustAddr2;
        private System.Windows.Forms.TextBox tBoxCustAdrr3;
        private System.Windows.Forms.TextBox tBoxCustStateProv;
        private System.Windows.Forms.TextBox tBoxCustPostZip;
        private System.Windows.Forms.TextBox tBoxCustCity;
        private System.Windows.Forms.TextBox tBoxContactPhone;
        private System.Windows.Forms.TextBox tBoxtContactName;
        private CoreFactory coreFactory;

		public ShipFromForm()		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			coreFactory = UtilCoreFactory.createCoreFactory();
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
            this.gBoxShipNotes = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxContactPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxCustTerritory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxCustRegion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tBoxCustId = new System.Windows.Forms.TextBox();
            this.tBoxCustName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lPSFAdd4 = new System.Windows.Forms.Label();
            this.tBoxCustCountry = new System.Windows.Forms.TextBox();
            this.tBoxCustAddr1 = new System.Windows.Forms.TextBox();
            this.tBoxCustAddr2 = new System.Windows.Forms.TextBox();
            this.lPSFAdd3 = new System.Windows.Forms.Label();
            this.lPSFAdd2 = new System.Windows.Forms.Label();
            this.lPSFAdd1 = new System.Windows.Forms.Label();
            this.tBoxCustAdrr3 = new System.Windows.Forms.TextBox();
            this.btnSchSFContact = new System.Windows.Forms.Button();
            this.tBoxtContactName = new System.Windows.Forms.TextBox();
            this.lPSFContact = new System.Windows.Forms.Label();
            this.tBoxCustStateProv = new System.Windows.Forms.TextBox();
            this.lPSFPostZip = new System.Windows.Forms.Label();
            this.tBoxCustPostZip = new System.Windows.Forms.TextBox();
            this.lPSFProvCountry = new System.Windows.Forms.Label();
            this.tBoxCustCity = new System.Windows.Forms.TextBox();
            this.lPSFProvState = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gBoxShipNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxShipNotes
            // 
            this.gBoxShipNotes.Controls.Add(this.label3);
            this.gBoxShipNotes.Controls.Add(this.tBoxContactPhone);
            this.gBoxShipNotes.Controls.Add(this.label2);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustTerritory);
            this.gBoxShipNotes.Controls.Add(this.label1);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustRegion);
            this.gBoxShipNotes.Controls.Add(this.label4);
            this.gBoxShipNotes.Controls.Add(this.button1);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustId);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustName);
            this.gBoxShipNotes.Controls.Add(this.label6);
            this.gBoxShipNotes.Controls.Add(this.lPSFAdd4);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustCountry);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustAddr1);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustAddr2);
            this.gBoxShipNotes.Controls.Add(this.lPSFAdd3);
            this.gBoxShipNotes.Controls.Add(this.lPSFAdd2);
            this.gBoxShipNotes.Controls.Add(this.lPSFAdd1);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustAdrr3);
            this.gBoxShipNotes.Controls.Add(this.btnSchSFContact);
            this.gBoxShipNotes.Controls.Add(this.tBoxtContactName);
            this.gBoxShipNotes.Controls.Add(this.lPSFContact);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustStateProv);
            this.gBoxShipNotes.Controls.Add(this.lPSFPostZip);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustPostZip);
            this.gBoxShipNotes.Controls.Add(this.lPSFProvCountry);
            this.gBoxShipNotes.Controls.Add(this.tBoxCustCity);
            this.gBoxShipNotes.Controls.Add(this.lPSFProvState);
            this.gBoxShipNotes.Location = new System.Drawing.Point(8, 8);
            this.gBoxShipNotes.Name = "gBoxShipNotes";
            this.gBoxShipNotes.Size = new System.Drawing.Size(456, 272);
            this.gBoxShipNotes.TabIndex = 74;
            this.gBoxShipNotes.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 103;
            this.label3.Text = "Phone #";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxContactPhone
            // 
            this.tBoxContactPhone.Location = new System.Drawing.Point(320, 240);
            this.tBoxContactPhone.MaxLength = 20;
            this.tBoxContactPhone.Name = "tBoxContactPhone";
            this.tBoxContactPhone.ReadOnly = true;
            this.tBoxContactPhone.Size = new System.Drawing.Size(128, 20);
            this.tBoxContactPhone.TabIndex = 102;
            this.tBoxContactPhone.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 101;
            this.label2.Text = "Territory";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxCustTerritory
            // 
            this.tBoxCustTerritory.Location = new System.Drawing.Point(96, 216);
            this.tBoxCustTerritory.MaxLength = 20;
            this.tBoxCustTerritory.Name = "tBoxCustTerritory";
            this.tBoxCustTerritory.ReadOnly = true;
            this.tBoxCustTerritory.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustTerritory.TabIndex = 100;
            this.tBoxCustTerritory.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 99;
            this.label1.Text = "Region";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxCustRegion
            // 
            this.tBoxCustRegion.Location = new System.Drawing.Point(96, 196);
            this.tBoxCustRegion.MaxLength = 20;
            this.tBoxCustRegion.Name = "tBoxCustRegion";
            this.tBoxCustRegion.ReadOnly = true;
            this.tBoxCustRegion.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustRegion.TabIndex = 98;
            this.tBoxCustRegion.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 93;
            this.label4.Text = "Supplier";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 16);
            this.button1.TabIndex = 97;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBoxCustId
            // 
            this.tBoxCustId.Location = new System.Drawing.Point(96, 16);
            this.tBoxCustId.MaxLength = 10;
            this.tBoxCustId.Name = "tBoxCustId";
            this.tBoxCustId.Size = new System.Drawing.Size(72, 20);
            this.tBoxCustId.TabIndex = 96;
            this.tBoxCustId.Text = "";
            // 
            // tBoxCustName
            // 
            this.tBoxCustName.Location = new System.Drawing.Point(96, 36);
            this.tBoxCustName.MaxLength = 40;
            this.tBoxCustName.Multiline = true;
            this.tBoxCustName.Name = "tBoxCustName";
            this.tBoxCustName.ReadOnly = true;
            this.tBoxCustName.Size = new System.Drawing.Size(256, 20);
            this.tBoxCustName.TabIndex = 95;
            this.tBoxCustName.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 94;
            this.label6.Text = "Name";
            // 
            // lPSFAdd4
            // 
            this.lPSFAdd4.Location = new System.Drawing.Point(16, 116);
            this.lPSFAdd4.Name = "lPSFAdd4";
            this.lPSFAdd4.Size = new System.Drawing.Size(40, 20);
            this.lPSFAdd4.TabIndex = 71;
            this.lPSFAdd4.Text = "City";
            // 
            // tBoxCustCountry
            // 
            this.tBoxCustCountry.Location = new System.Drawing.Point(96, 156);
            this.tBoxCustCountry.MaxLength = 30;
            this.tBoxCustCountry.Multiline = true;
            this.tBoxCustCountry.Name = "tBoxCustCountry";
            this.tBoxCustCountry.ReadOnly = true;
            this.tBoxCustCountry.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustCountry.TabIndex = 72;
            this.tBoxCustCountry.Text = "";
            // 
            // tBoxCustAddr1
            // 
            this.tBoxCustAddr1.Location = new System.Drawing.Point(96, 56);
            this.tBoxCustAddr1.MaxLength = 40;
            this.tBoxCustAddr1.Multiline = true;
            this.tBoxCustAddr1.Name = "tBoxCustAddr1";
            this.tBoxCustAddr1.ReadOnly = true;
            this.tBoxCustAddr1.Size = new System.Drawing.Size(256, 20);
            this.tBoxCustAddr1.TabIndex = 66;
            this.tBoxCustAddr1.Text = "";
            // 
            // tBoxCustAddr2
            // 
            this.tBoxCustAddr2.Location = new System.Drawing.Point(96, 76);
            this.tBoxCustAddr2.MaxLength = 40;
            this.tBoxCustAddr2.Multiline = true;
            this.tBoxCustAddr2.Name = "tBoxCustAddr2";
            this.tBoxCustAddr2.ReadOnly = true;
            this.tBoxCustAddr2.Size = new System.Drawing.Size(256, 20);
            this.tBoxCustAddr2.TabIndex = 70;
            this.tBoxCustAddr2.Text = "";
            // 
            // lPSFAdd3
            // 
            this.lPSFAdd3.Location = new System.Drawing.Point(16, 96);
            this.lPSFAdd3.Name = "lPSFAdd3";
            this.lPSFAdd3.Size = new System.Drawing.Size(40, 20);
            this.lPSFAdd3.TabIndex = 67;
            this.lPSFAdd3.Text = "Addr3";
            // 
            // lPSFAdd2
            // 
            this.lPSFAdd2.Location = new System.Drawing.Point(16, 76);
            this.lPSFAdd2.Name = "lPSFAdd2";
            this.lPSFAdd2.Size = new System.Drawing.Size(40, 20);
            this.lPSFAdd2.TabIndex = 69;
            this.lPSFAdd2.Text = "Addr2";
            // 
            // lPSFAdd1
            // 
            this.lPSFAdd1.Location = new System.Drawing.Point(16, 56);
            this.lPSFAdd1.Name = "lPSFAdd1";
            this.lPSFAdd1.Size = new System.Drawing.Size(40, 20);
            this.lPSFAdd1.TabIndex = 65;
            this.lPSFAdd1.Text = "Addr1";
            // 
            // tBoxCustAdrr3
            // 
            this.tBoxCustAdrr3.Location = new System.Drawing.Point(96, 96);
            this.tBoxCustAdrr3.MaxLength = 40;
            this.tBoxCustAdrr3.Multiline = true;
            this.tBoxCustAdrr3.Name = "tBoxCustAdrr3";
            this.tBoxCustAdrr3.ReadOnly = true;
            this.tBoxCustAdrr3.Size = new System.Drawing.Size(256, 20);
            this.tBoxCustAdrr3.TabIndex = 68;
            this.tBoxCustAdrr3.Text = "";
            // 
            // btnSchSFContact
            // 
            this.btnSchSFContact.Location = new System.Drawing.Point(232, 240);
            this.btnSchSFContact.Name = "btnSchSFContact";
            this.btnSchSFContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchSFContact.TabIndex = 90;
            this.btnSchSFContact.Text = "...";
            this.btnSchSFContact.Click += new System.EventHandler(this.btnSchSFContact_Click);
            // 
            // tBoxtContactName
            // 
            this.tBoxtContactName.Location = new System.Drawing.Point(96, 236);
            this.tBoxtContactName.MaxLength = 20;
            this.tBoxtContactName.Name = "tBoxtContactName";
            this.tBoxtContactName.Size = new System.Drawing.Size(128, 20);
            this.tBoxtContactName.TabIndex = 89;
            this.tBoxtContactName.Text = "";
            // 
            // lPSFContact
            // 
            this.lPSFContact.Location = new System.Drawing.Point(16, 236);
            this.lPSFContact.Name = "lPSFContact";
            this.lPSFContact.Size = new System.Drawing.Size(60, 20);
            this.lPSFContact.TabIndex = 88;
            this.lPSFContact.Text = "Contact";
            this.lPSFContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxCustStateProv
            // 
            this.tBoxCustStateProv.Location = new System.Drawing.Point(96, 136);
            this.tBoxCustStateProv.MaxLength = 20;
            this.tBoxCustStateProv.Name = "tBoxCustStateProv";
            this.tBoxCustStateProv.ReadOnly = true;
            this.tBoxCustStateProv.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustStateProv.TabIndex = 87;
            this.tBoxCustStateProv.Text = "";
            // 
            // lPSFPostZip
            // 
            this.lPSFPostZip.Location = new System.Drawing.Point(16, 176);
            this.lPSFPostZip.Name = "lPSFPostZip";
            this.lPSFPostZip.Size = new System.Drawing.Size(60, 20);
            this.lPSFPostZip.TabIndex = 86;
            this.lPSFPostZip.Text = "Post Zip";
            this.lPSFPostZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxCustPostZip
            // 
            this.tBoxCustPostZip.Location = new System.Drawing.Point(96, 176);
            this.tBoxCustPostZip.MaxLength = 20;
            this.tBoxCustPostZip.Name = "tBoxCustPostZip";
            this.tBoxCustPostZip.ReadOnly = true;
            this.tBoxCustPostZip.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustPostZip.TabIndex = 85;
            this.tBoxCustPostZip.Text = "";
            // 
            // lPSFProvCountry
            // 
            this.lPSFProvCountry.Location = new System.Drawing.Point(16, 156);
            this.lPSFProvCountry.Name = "lPSFProvCountry";
            this.lPSFProvCountry.Size = new System.Drawing.Size(60, 20);
            this.lPSFProvCountry.TabIndex = 84;
            this.lPSFProvCountry.Text = "Country";
            // 
            // tBoxCustCity
            // 
            this.tBoxCustCity.Location = new System.Drawing.Point(96, 116);
            this.tBoxCustCity.MaxLength = 20;
            this.tBoxCustCity.Name = "tBoxCustCity";
            this.tBoxCustCity.ReadOnly = true;
            this.tBoxCustCity.Size = new System.Drawing.Size(128, 20);
            this.tBoxCustCity.TabIndex = 83;
            this.tBoxCustCity.Text = "";
            // 
            // lPSFProvState
            // 
            this.lPSFProvState.Location = new System.Drawing.Point(16, 136);
            this.lPSFProvState.Name = "lPSFProvState";
            this.lPSFProvState.Size = new System.Drawing.Size(80, 20);
            this.lPSFProvState.TabIndex = 82;
            this.lPSFProvState.Text = "State/Province";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 288);
            this.button2.Name = "button2";
            this.button2.TabIndex = 75;
            this.button2.Text = "Ok";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 288);
            this.button3.Name = "button3";
            this.button3.TabIndex = 76;
            this.button3.Text = "Cancel";
            // 
            // ShipFromForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 318);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gBoxShipNotes);
            this.Name = "ShipFromForm";
            this.Text = "Ship From";
            this.gBoxShipNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void button1_Click(object sender, System.EventArgs e){

    	PersonSearchForm personSearchForm = new PersonSearchForm("Customers ...");
		personSearchForm.setFilter(Constants.PERSON_TYPE_CUSTOMER);
		personSearchForm.ShowDialog();

		if ((personSearchForm.DialogResult == DialogResult.OK) &&
			(personSearchForm.getSelected() != null))		{
			
			string custId = personSearchForm.getSelected()[1];
			string custPlt = personSearchForm.getSelected()[0];
			loadCust(custId,custPlt);
		}
}

private void loadCust(string custId, string custPlt){
try{
    Person person = coreFactory.readPerson(custPlt,custId);
    this.tBoxCustAddr1.Text = person.getAddress1();
    this.tBoxCustAddr2.Text = person.getAddress2();
    this.tBoxCustAdrr3.Text = person.getAddress3();
    this.tBoxCustCountry.Text = person.getCountry();
    this.tBoxCustId.Text = person.getId();
    this.tBoxCustName.Text = person.getName();
    this.tBoxCustPostZip.Text = person.getZipCode();
    this.tBoxCustRegion.Text = "";
    this.tBoxCustStateProv.Text = person.getState_Prov();
    this.tBoxCustTerritory.Text = person.getTerritory();
   

}catch (Exception ex){
	FormException formException = new FormException(ex);
	formException.ShowDialog(this);
}

}

private void btnSchSFContact_Click(object sender, System.EventArgs e){

    ContactSearchForm contactSearchForm= new ContactSearchForm("Search Contacts");
    contactSearchForm.ShowDialog();

    if (contactSearchForm.DialogResult.Equals(DialogResult.OK)){
        if (contactSearchForm.getSelected()!=null){
            int idContact = int.Parse(contactSearchForm.getSelected()[0]);
            Contact contact = coreFactory.readContact(idContact);
            this.tBoxtContactName.Text = contact.getDisplayName();
            this.tBoxContactPhone.Text = contact.getPhone();
        }

    }
}

}//end class
}//end namespace
