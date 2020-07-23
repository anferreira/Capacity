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
	public class FormConfirmEmployee : System.Windows.Forms.Form
	{
		private Employee employee;

		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonAccept;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormConfirmEmployee(Employee emp)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
			employee = emp;
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
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(8, 16);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(64, 20);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Password:";
			this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.textBoxPassword.Location = new System.Drawing.Point(72, 16);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = 'l';
			this.textBoxPassword.Size = new System.Drawing.Size(128, 20);
			this.textBoxPassword.TabIndex = 1;
			this.textBoxPassword.Text = "";
			this.textBoxPassword.WordWrap = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(112, 48);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(24, 48);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(72, 24);
			this.buttonAccept.TabIndex = 3;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// FormConfirmEmployee
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(210, 82);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.labelPassword);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfirmEmployee";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Insert Password";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			if (employee.getPassword().Equals(textBoxPassword.Text))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				textBoxPassword.Text = string.Empty;
				textBoxPassword.Focus();
			}
		}

	}
}
