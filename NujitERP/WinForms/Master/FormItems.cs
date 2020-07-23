using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormItems.
	/// </summary>
	public class FormItems : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;

		private FormMain formMainParent;
		private System.Windows.Forms.PictureBox pBoxProducts;
		private System.Windows.Forms.PictureBox pBoxInventory;
		private System.Windows.Forms.PictureBox pBoxBOM;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public FormItems()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FormItems(FormMain formParent)
		{
			InitializeComponent();

			this.MdiParent = formParent;
			this.formMainParent = formParent;
			//this.toolTip1.
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormItems));
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pBoxProducts = new System.Windows.Forms.PictureBox();
            this.pBoxInventory = new System.Windows.Forms.PictureBox();
            this.pBoxBOM = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBOM)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(160, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 92);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(160, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 4);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // pBoxProducts
            // 
            this.pBoxProducts.Image = ((System.Drawing.Image)(resources.GetObject("pBoxProducts.Image")));
            this.pBoxProducts.Location = new System.Drawing.Point(160, 208);
            this.pBoxProducts.Name = "pBoxProducts";
            this.pBoxProducts.Size = new System.Drawing.Size(72, 72);
            this.pBoxProducts.TabIndex = 18;
            this.pBoxProducts.TabStop = false;
            this.pBoxProducts.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pBoxProducts.MouseEnter += new System.EventHandler(this.pBoxProducts_MouseEnter);
            this.pBoxProducts.MouseLeave += new System.EventHandler(this.pBoxProducts_MouseLeave);
            // 
            // pBoxInventory
            // 
            this.pBoxInventory.Image = ((System.Drawing.Image)(resources.GetObject("pBoxInventory.Image")));
            this.pBoxInventory.Location = new System.Drawing.Point(160, 296);
            this.pBoxInventory.Name = "pBoxInventory";
            this.pBoxInventory.Size = new System.Drawing.Size(72, 72);
            this.pBoxInventory.TabIndex = 19;
            this.pBoxInventory.TabStop = false;
            this.pBoxInventory.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pBoxInventory.MouseEnter += new System.EventHandler(this.pBoxInventory_MouseEnter);
            this.pBoxInventory.MouseLeave += new System.EventHandler(this.pBoxInventory_MouseLeave);
            // 
            // pBoxBOM
            // 
            this.pBoxBOM.Image = ((System.Drawing.Image)(resources.GetObject("pBoxBOM.Image")));
            this.pBoxBOM.Location = new System.Drawing.Point(160, 384);
            this.pBoxBOM.Name = "pBoxBOM";
            this.pBoxBOM.Size = new System.Drawing.Size(72, 72);
            this.pBoxBOM.TabIndex = 20;
            this.pBoxBOM.TabStop = false;
            this.pBoxBOM.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pBoxBOM.MouseEnter += new System.EventHandler(this.pBoxBOM_MouseEnter);
            this.pBoxBOM.MouseLeave += new System.EventHandler(this.pBoxBOM_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(248, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 22;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(248, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 23;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(248, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 24;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormItems
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(760, 486);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBoxBOM);
            this.Controls.Add(this.pBoxInventory);
            this.Controls.Add(this.pBoxProducts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Name = "FormItems";
            this.Text = "Items";
            this.Closed += new System.EventHandler(this.OnClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBOM)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void pictureBox4_Click(object sender, System.EventArgs e)
		{
			FormBOM formBOM = new FormBOM();
			formBOM.ShowDialog(this);
		}

		private 
			void pictureBox1_Click(object sender, System.EventArgs e)
		{
			ProductForm productForm = new ProductForm();
			productForm.ShowDialog();
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			InvPltLocForm ipl = new InvPltLocForm();
			ipl.ShowDialog();
		}

		private void pBoxProducts_MouseEnter(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Hand;
		}

		private void pBoxProducts_MouseLeave(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Default;
		}

		private void pBoxInventory_MouseEnter(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Hand;
		}

		private void pBoxInventory_MouseLeave(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Default;
		}

		private void pBoxBOM_MouseEnter(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Hand;
		}

		private void pBoxBOM_MouseLeave(object sender, System.EventArgs e)
		{
			Cursor=Cursors.Default;
		}

		private void OnClosed(object sender, System.EventArgs e)
		{
			if (this.formMainParent != null)
			{
				this.formMainParent.RemoveTab(this.Tag);

				this.formMainParent.SetButtons();
			}	
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			ProductForm productForm = new ProductForm();
			productForm.ShowDialog();
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			InvPltLocForm ipl = new InvPltLocForm();
			ipl.ShowDialog();
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
			FormBOM formBOM = new FormBOM();
			formBOM.ShowDialog(this);
		}

	}
}
