using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

//using Nujit.NujitERP.ClassLib.Master;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormAddMacToCfg.
	/// </summary>
	public class FormAddMacToCfg : System.Windows.Forms.Form
	{
		#region Controls
		private System.Windows.Forms.ListBox ListBoxMacNotInCfg;
		private System.Windows.Forms.ListBox listBoxMacInCfg;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAddAll;
		private System.Windows.Forms.Button btnRemoveAll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblPlant;
		private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.Label lblCfg;
		private System.Windows.Forms.TextBox textBoxPlt;
		private System.Windows.Forms.TextBox textBoxDept;
		private System.Windows.Forms.TextBox textBoxCfg;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion Controls
	
		#region Vars

		private MacConfiguration _configuration;
		private ArrayList macAdded;
		private ArrayList macRemoved;
		private CoreFactory coreFactory;
		
		#endregion Vars
	
		#region Properties

		public MacConfiguration Configuration
		{
			get 
			{
				if (this._configuration == null)  {return new MacConfiguration();}
				return this._configuration;
			}
			set 
			{
				this._configuration = value;
			}
		}
		#endregion Properties

		#region Methods
		private void BindData()
		{
			if (this._configuration == null) return;

			this.textBoxPlt.Text   = this._configuration.getPlt();
			this.textBoxCfg.Text   = this._configuration.getCfg();
			this.textBoxDept.Text  = this._configuration.getDept();
			
			BindlistBoxMacInCfg();
			BindlistBoxMacNotInCfg();
		
		}

		private void BindlistBoxMacNotInCfg()
		{
			if (this._configuration == null) return;

			Machine[] macNotInCfg = coreFactory.getMachinesNotInConfiguration (this._configuration.getPlt(), this._configuration.getDept(), this._configuration.getCfg());

			ListBoxMacNotInCfg.BeginUpdate();

			this.ListBoxMacNotInCfg.Items.Clear();
			foreach (Machine mac in macNotInCfg)
			{
				this.ListBoxMacNotInCfg.Items.Add (mac);
			}

			this.ListBoxMacNotInCfg.EndUpdate();

		}
		private void BindlistBoxMacInCfg()
		{
			if (this._configuration == null) return;

			listBoxMacInCfg.BeginUpdate();

			Machine[] macInCfg = coreFactory.getMachinesFromConfiguration (_configuration.getPlt(), _configuration.getDept(), _configuration.getCfg());
			this.listBoxMacInCfg.Items.Clear();
			foreach (Machine mac in macInCfg)
			{
				this.listBoxMacInCfg.Items.Add (mac);
			}

			this.listBoxMacInCfg.EndUpdate();

		}

		private bool SaveData()
		{
			Machine[] macsNotInConfigurations = coreFactory.getMachinesNotInAnyConfiguration(_configuration.getPlt(),_configuration.getDept());

			ArrayList machinesToAdd = new ArrayList();
			string answer = "";
			IEnumerator enu = macAdded.GetEnumerator();
			while (enu.MoveNext())
			{
				Machine mac = (Machine)enu.Current;
				if (!answer.Equals(FormAddMacToCfgConfirmation.YES_TO_ALL) && !answer.Equals(FormAddMacToCfgConfirmation.NO_TO_ALL) && this.notIn (mac,macsNotInConfigurations))
				{
					FormAddMacToCfgConfirmation form = new FormAddMacToCfgConfirmation();
					form.Show ("The machine " + mac.ToString() + " belongs to another configuration.\nDo you wish to switch it to this one?","Warning!");
					answer = form.Result;
					form.Dispose();
				}
				else
					if (!answer.Equals(FormAddMacToCfgConfirmation.YES_TO_ALL) && !answer.Equals(FormAddMacToCfgConfirmation.NO_TO_ALL))
						answer = FormAddMacToCfgConfirmation.YES;

				if (answer.Equals (FormAddMacToCfgConfirmation.CANCEL))
					return false;
				if (answer.Equals(FormAddMacToCfgConfirmation.YES) || answer.Equals(FormAddMacToCfgConfirmation.YES_TO_ALL))
					machinesToAdd.Add (mac);
			}
			
			try
			{
				coreFactory.beginTransaction();
				foreach (Machine mac in machinesToAdd)
				{
					coreFactory.removeMachineFromAllConfigurations (mac);
					coreFactory.addMachineToCfg (mac,_configuration);
				}
				foreach (Machine mac in macRemoved)
				{
					coreFactory.removeMachineFromConfiguration (mac,_configuration);
				}
				coreFactory.commitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				coreFactory.rollbackTransaction();
				FormException formEx = new FormException (ex);
				formEx.ShowDialog();
			}
			return false;
		}

		private bool notIn(Machine mac, Machine[] list)
		{
			for (int i=0; i<list.Length; i++)
			{
				if (list[i].getMach().Equals(mac.getMach()))
					return false;
			}
			return true;
		}

		#endregion Methods

		#region Constructors
		public FormAddMacToCfg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			coreFactory = UtilCoreFactory.createCoreFactory();
			macAdded = new ArrayList();
			macRemoved = new ArrayList();
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
		#endregion Constructors

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ListBoxMacNotInCfg = new System.Windows.Forms.ListBox();
			this.listBoxMacInCfg = new System.Windows.Forms.ListBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAddAll = new System.Windows.Forms.Button();
			this.btnRemoveAll = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblPlant = new System.Windows.Forms.Label();
			this.lblDept = new System.Windows.Forms.Label();
			this.lblCfg = new System.Windows.Forms.Label();
			this.textBoxPlt = new System.Windows.Forms.TextBox();
			this.textBoxDept = new System.Windows.Forms.TextBox();
			this.textBoxCfg = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ListBoxMacNotInCfg
			// 
			this.ListBoxMacNotInCfg.Location = new System.Drawing.Point(16, 72);
			this.ListBoxMacNotInCfg.Name = "ListBoxMacNotInCfg";
			this.ListBoxMacNotInCfg.Size = new System.Drawing.Size(184, 251);
			this.ListBoxMacNotInCfg.TabIndex = 0;
			this.ListBoxMacNotInCfg.DoubleClick += new EventHandler(ListBoxMacNotInCfg_DoubleClick);
			// 
			// listBoxMacInCfg
			// 
			this.listBoxMacInCfg.Location = new System.Drawing.Point(320, 72);
			this.listBoxMacInCfg.Name = "listBoxMacInCfg";
			this.listBoxMacInCfg.Size = new System.Drawing.Size(184, 251);
			this.listBoxMacInCfg.TabIndex = 5;
			this.listBoxMacInCfg.DoubleClick += new EventHandler(listBoxMacInCfg_DoubleClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(216, 88);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(88, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add >";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(216, 128);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(88, 23);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "< Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAddAll
			// 
			this.btnAddAll.Location = new System.Drawing.Point(216, 224);
			this.btnAddAll.Name = "btnAddAll";
			this.btnAddAll.Size = new System.Drawing.Size(88, 23);
			this.btnAddAll.TabIndex = 3;
			this.btnAddAll.Text = "Add All >>";
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Location = new System.Drawing.Point(216, 264);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(88, 23);
			this.btnRemoveAll.TabIndex = 4;
			this.btnRemoveAll.Text = "<< Remove All";
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Machines not in the configuration";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(320, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Machines in configuration";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(344, 336);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(432, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblPlant
			// 
			this.lblPlant.Location = new System.Drawing.Point(24, 16);
			this.lblPlant.Name = "lblPlant";
			this.lblPlant.Size = new System.Drawing.Size(48, 23);
			this.lblPlant.TabIndex = 10;
			this.lblPlant.Text = "Plant";
			this.lblPlant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(176, 16);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(64, 23);
			this.lblDept.TabIndex = 11;
			this.lblDept.Text = "Department";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCfg
			// 
			this.lblCfg.Location = new System.Drawing.Point(344, 16);
			this.lblCfg.Name = "lblCfg";
			this.lblCfg.Size = new System.Drawing.Size(72, 23);
			this.lblCfg.TabIndex = 12;
			this.lblCfg.Text = "Configuration";
			this.lblCfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxPlt
			// 
			this.textBoxPlt.Location = new System.Drawing.Point(80, 16);
			this.textBoxPlt.Name = "textBoxPlt";
			this.textBoxPlt.ReadOnly = true;
			this.textBoxPlt.Size = new System.Drawing.Size(64, 20);
			this.textBoxPlt.TabIndex = 13;
			this.textBoxPlt.Text = "";
			// 
			// textBoxDept
			// 
			this.textBoxDept.Location = new System.Drawing.Point(248, 16);
			this.textBoxDept.Name = "textBoxDept";
			this.textBoxDept.ReadOnly = true;
			this.textBoxDept.Size = new System.Drawing.Size(64, 20);
			this.textBoxDept.TabIndex = 14;
			this.textBoxDept.Text = "";
			// 
			// textBoxCfg
			// 
			this.textBoxCfg.Location = new System.Drawing.Point(424, 16);
			this.textBoxCfg.Name = "textBoxCfg";
			this.textBoxCfg.ReadOnly = true;
			this.textBoxCfg.Size = new System.Drawing.Size(64, 20);
			this.textBoxCfg.TabIndex = 15;
			this.textBoxCfg.Text = "";
			// 
			// FormAddMacToCfg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 365);
			this.Controls.Add(this.textBoxCfg);
			this.Controls.Add(this.textBoxDept);
			this.Controls.Add(this.textBoxPlt);
			this.Controls.Add(this.lblCfg);
			this.Controls.Add(this.lblDept);
			this.Controls.Add(this.lblPlant);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnAddAll);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.listBoxMacInCfg);
			this.Controls.Add(this.ListBoxMacNotInCfg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAddMacToCfg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit machine-configuration relationship";
			this.Load += new System.EventHandler(this.FormAddMacToCfg_Load);
			this.ResumeLayout(false);

		}
		#endregion
			
		#region Events

		private void FormAddMacToCfg_Load(object sender, System.EventArgs e)
		{	 
			BindData();
		}

	
		
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.addMachine();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (SaveData())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			this.removeMachine();
		}

		private void addMachine()
		{
			if (this.ListBoxMacNotInCfg.SelectedItem == null)
				return;

			this.listBoxMacInCfg.Items.Add (this.ListBoxMacNotInCfg.SelectedItem);
			if (!this.removeFromList (this.macRemoved, (Machine)this.ListBoxMacNotInCfg.SelectedItem))
				this.macAdded.Add (this.ListBoxMacNotInCfg.SelectedItem);
			this.ListBoxMacNotInCfg.Items.RemoveAt (this.ListBoxMacNotInCfg.SelectedIndex);
		}
		
		private void removeMachine()
		{
			if (this.listBoxMacInCfg.SelectedItem == null)
				return;

			this.ListBoxMacNotInCfg.Items.Add (this.listBoxMacInCfg.SelectedItem);
			if (!this.removeFromList (this.macAdded, (Machine)this.listBoxMacInCfg.SelectedItem))
				this.macRemoved.Add (this.listBoxMacInCfg.SelectedItem);
			this.listBoxMacInCfg.Items.RemoveAt (this.listBoxMacInCfg.SelectedIndex);
		}

		private bool removeFromList (ArrayList list, Machine mac)
		{
			bool wasInList = false;
			int i=0;
			while (i < list.Count)
			{
				if (((Machine)list[i]).getMach().Equals (mac.getMach()))
				{
					list.RemoveAt (i);
					wasInList = true;
				}
				else
					i++;
			}
			return wasInList;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


       #endregion Events

		private void btnAddAll_Click(object sender, System.EventArgs e)
		{
			while (this.ListBoxMacNotInCfg.Items.Count > 0)
			{
				this.ListBoxMacNotInCfg.SelectedIndex = 0;
				this.addMachine();
			}
		}

		private void btnRemoveAll_Click(object sender, System.EventArgs e)
		{
			while (this.listBoxMacInCfg.Items.Count > 0)
			{
				this.listBoxMacInCfg.SelectedIndex = 0;
				this.removeMachine();
			}
		}

		private void ListBoxMacNotInCfg_DoubleClick(object sender, EventArgs e)
		{
			this.addMachine();
		}

		private void listBoxMacInCfg_DoubleClick(object sender, EventArgs e)
		{
			this.removeMachine();
		}
	}
}
