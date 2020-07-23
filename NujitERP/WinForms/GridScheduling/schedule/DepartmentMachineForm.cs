using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GridScheduling.gui.schedule
{
	/// <summary>
	/// Summary description for DepartmentMachineForm.
	/// </summary>
	public class DepartmentMachineForm : System.Windows.Forms.Form
	{
		string[][] machines;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboDepartments;
		private System.Windows.Forms.ComboBox cboMachines;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DepartmentMachineForm()
		{
			InitializeComponent();
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
			this.label1 = new System.Windows.Forms.Label();
			this.cboDepartments = new System.Windows.Forms.ComboBox();
			this.cboMachines = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "On which machine would you like the report?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cboDepartments
			// 
			this.cboDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDepartments.Location = new System.Drawing.Point(128, 56);
			this.cboDepartments.Name = "cboDepartments";
			this.cboDepartments.Size = new System.Drawing.Size(136, 21);
			this.cboDepartments.TabIndex = 1;
			this.cboDepartments.SelectedIndexChanged += new System.EventHandler(this.cboDepartments_SelectedIndexChanged);
			// 
			// cboMachines
			// 
			this.cboMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMachines.Location = new System.Drawing.Point(128, 80);
			this.cboMachines.Name = "cboMachines";
			this.cboMachines.Size = new System.Drawing.Size(136, 21);
			this.cboMachines.TabIndex = 2;
			this.cboMachines.SelectedIndexChanged += new System.EventHandler(this.cboMachines_SelectedIndexChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(160, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccept.Enabled = false;
			this.btnAccept.Location = new System.Drawing.Point(64, 120);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(88, 24);
			this.btnAccept.TabIndex = 4;
			this.btnAccept.Text = "Accept";
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Department:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Machine:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DepartmentMachineForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 149);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cboMachines);
			this.Controls.Add(this.cboDepartments);
			this.Controls.Add(this.label1);
			this.Name = "DepartmentMachineForm";
			this.Text = "Report\'s Parameters";
			this.ResumeLayout(false);

		}
		#endregion

		public void setValues (SortedList machines)
		{
			this.machines = new string[machines.Count][];
			IEnumerator enu = machines.Values.GetEnumerator();
			int i=0;
			while (enu.MoveNext())
			{
				this.machines[i] = (string[])enu.Current;
				i++;
			}

			loadDepartments();
		}

		public void loadDepartments()
		{
			cboDepartments.Items.Clear();
			for (int i=0; i<machines.Length; i++)
				if (!cboDepartments.Items.Contains(machines[i][0]))
					cboDepartments.Items.Add(machines[i][0]);
			if (cboDepartments.Items.Count > 0)
				cboDepartments.SelectedIndex = 0;
		}

		public void loadMachines()
		{
			cboMachines.Items.Clear();
			for (int i=0; i<machines.Length; i++)
				if (cboDepartments.Text.Equals(machines[i][0]))
					cboMachines.Items.Add(machines[i][1]);
			if (cboMachines.Items.Count > 0)
				cboMachines.SelectedIndex = 0;
		}

		private void cboDepartments_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadMachines();
		}

		private void cboMachines_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (getDepartment().Equals("") || getMachine().Equals(""))
				btnAccept.Enabled = false;
			else
				btnAccept.Enabled = true;
		}

		private void btnAccept_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public string getDepartment()
		{
			return cboDepartments.Text;
		}

		public string getMachine()
		{
			return cboMachines.Text;
		}

	}
}
