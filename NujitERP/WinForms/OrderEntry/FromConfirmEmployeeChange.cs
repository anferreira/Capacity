using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Descripción breve de ConfirmEmployee.
	/// </summary>
	public class FormConfirmEmployeeChange : System.Windows.Forms.Form
	{
		private Employee oldEmployee;
		private Employee newEmployee;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Label labelOldEmpPassword;
		private System.Windows.Forms.TextBox textBoxOldEmpPassword;
		private System.Windows.Forms.Label labelNewEmpPassword;
		private System.Windows.Forms.TextBox textBoxNewEmpPassword;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormConfirmEmployeeChange(Employee oldEmp,Employee newEmp)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
			oldEmployee = oldEmp;
			newEmployee = newEmp;
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
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

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelOldEmpPassword = new System.Windows.Forms.Label();
			this.textBoxOldEmpPassword = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.labelNewEmpPassword = new System.Windows.Forms.Label();
			this.textBoxNewEmpPassword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelOldEmpPassword
			// 
			this.labelOldEmpPassword.Location = new System.Drawing.Point(8, 16);
			this.labelOldEmpPassword.Name = "labelOldEmpPassword";
			this.labelOldEmpPassword.Size = new System.Drawing.Size(160, 20);
			this.labelOldEmpPassword.TabIndex = 0;
			this.labelOldEmpPassword.Text = "Former Employee\'s Password:";
			this.labelOldEmpPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxOldEmpPassword
			// 
			this.textBoxOldEmpPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.textBoxOldEmpPassword.Location = new System.Drawing.Point(168, 16);
			this.textBoxOldEmpPassword.Name = "textBoxOldEmpPassword";
			this.textBoxOldEmpPassword.PasswordChar = 'l';
			this.textBoxOldEmpPassword.Size = new System.Drawing.Size(128, 20);
			this.textBoxOldEmpPassword.TabIndex = 1;
			this.textBoxOldEmpPassword.Text = "";
			this.textBoxOldEmpPassword.WordWrap = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(168, 88);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 20;
			this.buttonCancel.Text = "Cancel";
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(72, 88);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(72, 24);
			this.buttonAccept.TabIndex = 10;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// labelNewEmpPassword
			// 
			this.labelNewEmpPassword.Location = new System.Drawing.Point(8, 48);
			this.labelNewEmpPassword.Name = "labelNewEmpPassword";
			this.labelNewEmpPassword.Size = new System.Drawing.Size(160, 20);
			this.labelNewEmpPassword.TabIndex = 4;
			this.labelNewEmpPassword.Text = "New Employee\'s Password:";
			this.labelNewEmpPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxNewEmpPassword
			// 
			this.textBoxNewEmpPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.textBoxNewEmpPassword.Location = new System.Drawing.Point(168, 48);
			this.textBoxNewEmpPassword.Name = "textBoxNewEmpPassword";
			this.textBoxNewEmpPassword.PasswordChar = 'l';
			this.textBoxNewEmpPassword.Size = new System.Drawing.Size(128, 20);
			this.textBoxNewEmpPassword.TabIndex = 5;
			this.textBoxNewEmpPassword.Text = "";
			this.textBoxNewEmpPassword.WordWrap = false;
			// 
			// FormConfirmEmployeeChange
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(306, 122);
			this.Controls.Add(this.textBoxNewEmpPassword);
			this.Controls.Add(this.labelNewEmpPassword);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxOldEmpPassword);
			this.Controls.Add(this.labelOldEmpPassword);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfirmEmployeeChange";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Insert Password";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			if ((oldEmployee.getPassword().Equals(textBoxOldEmpPassword.Text)) && 
				(newEmployee.getPassword().Equals(textBoxNewEmpPassword.Text)))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				textBoxNewEmpPassword.Text = string.Empty;
				textBoxOldEmpPassword.Text = string.Empty;
				textBoxOldEmpPassword.Focus();
			}
		}

	}
}
