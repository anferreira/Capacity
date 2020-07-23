using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.GridScheduling.Tooling
{
	/// <summary>
	/// Summary description for ScheduleTreeViewForm.
	/// </summary>
	public class ScheduleTreeViewForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ScheduleTreeViewForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(24, 32);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Customer 1", new System.Windows.Forms.TreeNode[] {
																																										  new System.Windows.Forms.TreeNode("Order 01", new System.Windows.Forms.TreeNode[] {
																																																																new System.Windows.Forms.TreeNode("Prod GM-1010 Release 1/1/2006"),
																																																																new System.Windows.Forms.TreeNode("Prod GM-1011 Release 1/1/2006"),
																																																																new System.Windows.Forms.TreeNode("Prod GM-1012 Release 1/1/2006")}),
																																										  new System.Windows.Forms.TreeNode("Order 02", new System.Windows.Forms.TreeNode[] {
																																																																new System.Windows.Forms.TreeNode("Prod GM-1013 Release 1/1/2006"),
																																																																new System.Windows.Forms.TreeNode("Prod GM-1014 Release 1/1/2006")})}),
																				  new System.Windows.Forms.TreeNode("Customer 2", new System.Windows.Forms.TreeNode[] {
																																										  new System.Windows.Forms.TreeNode("Order 03", new System.Windows.Forms.TreeNode[] {
																																																																new System.Windows.Forms.TreeNode("Prod GM-1010 Release 1/1/2006")})})});
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(312, 328);
			this.treeView1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(184, 368);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "View 2A";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(104, 368);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "View 2";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 368);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "View 2A";
			// 
			// ScheduleTreeViewForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 398);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.treeView1);
			this.Name = "ScheduleTreeViewForm";
			this.Text = "Schedule Tree View";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
