using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.WinForms.InventoryLayout.Picks
{
	/// <summary>
	/// Summary description for PickScreenForm.
	/// </summary>
	public class PickScreenForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private NujitCustomWinControls.NumericTextBox numericTextBox4;
        private NujitCustomWinControls.NumericTextBox numericTextBox5;
        private NujitCustomWinControls.NumericTextBox numericTextBox6;
        private NujitCustomWinControls.NumericTextBox numericTextBox7;
        private NujitCustomWinControls.NumericTextBox numericTextBox8;
        private NujitCustomWinControls.NumericTextBox numericTextBox9;
        private NujitCustomWinControls.NumericTextBox numericTextBox10;
        private NujitCustomWinControls.NumericTextBox numericTextBox11;
        private NujitCustomWinControls.NumericTextBox numericTextBox12;
        private NujitCustomWinControls.NumericTextBox numericTextBox13;
        private NujitCustomWinControls.NumericTextBox numericTextBox14;
        private NujitCustomWinControls.NumericTextBox numericTextBox15;
        private NujitCustomWinControls.NumericTextBox numericTextBox16;
        private NujitCustomWinControls.NumericTextBox numericTextBox17;
        private NujitCustomWinControls.NumericTextBox numericTextBox18;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private NujitCustomWinControls.NumericTextBox numericTextBox19;
        private NujitCustomWinControls.NumericTextBox numericTextBox20;
        private System.Windows.Forms.DataGrid dGridPicks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
		private DataTable dataTable;

		public PickScreenForm()		{
			
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericTextBox19 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox20 = new NujitCustomWinControls.NumericTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numericTextBox18 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox10 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox11 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox12 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox13 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox14 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox15 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox16 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox17 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox9 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox8 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox7 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox6 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox5 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox4 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGridPicks = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridPicks)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericTextBox19);
            this.groupBox1.Controls.Add(this.numericTextBox20);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.numericTextBox18);
            this.groupBox1.Controls.Add(this.numericTextBox10);
            this.groupBox1.Controls.Add(this.numericTextBox11);
            this.groupBox1.Controls.Add(this.numericTextBox12);
            this.groupBox1.Controls.Add(this.numericTextBox13);
            this.groupBox1.Controls.Add(this.numericTextBox14);
            this.groupBox1.Controls.Add(this.numericTextBox15);
            this.groupBox1.Controls.Add(this.numericTextBox16);
            this.groupBox1.Controls.Add(this.numericTextBox17);
            this.groupBox1.Controls.Add(this.numericTextBox9);
            this.groupBox1.Controls.Add(this.numericTextBox8);
            this.groupBox1.Controls.Add(this.numericTextBox7);
            this.groupBox1.Controls.Add(this.numericTextBox6);
            this.groupBox1.Controls.Add(this.numericTextBox5);
            this.groupBox1.Controls.Add(this.numericTextBox4);
            this.groupBox1.Controls.Add(this.numericTextBox3);
            this.groupBox1.Controls.Add(this.numericTextBox2);
            this.groupBox1.Controls.Add(this.numericTextBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // numericTextBox19
            // 
            this.numericTextBox19.Location = new System.Drawing.Point(440, 56);
            this.numericTextBox19.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox19.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox19.Name = "numericTextBox19";
            this.numericTextBox19.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox19.TabIndex = 37;
            this.numericTextBox19.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox20
            // 
            this.numericTextBox20.Location = new System.Drawing.Point(440, 36);
            this.numericTextBox20.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox20.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox20.Name = "numericTextBox20";
            this.numericTextBox20.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox20.TabIndex = 36;
            this.numericTextBox20.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(440, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // numericTextBox18
            // 
            this.numericTextBox18.Location = new System.Drawing.Point(88, 56);
            this.numericTextBox18.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox18.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox18.Name = "numericTextBox18";
            this.numericTextBox18.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox18.TabIndex = 34;
            this.numericTextBox18.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox10
            // 
            this.numericTextBox10.Location = new System.Drawing.Point(704, 132);
            this.numericTextBox10.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox10.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox10.Name = "numericTextBox10";
            this.numericTextBox10.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox10.TabIndex = 33;
            this.numericTextBox10.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox11
            // 
            this.numericTextBox11.Location = new System.Drawing.Point(176, 132);
            this.numericTextBox11.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox11.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox11.Name = "numericTextBox11";
            this.numericTextBox11.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox11.TabIndex = 32;
            this.numericTextBox11.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox12
            // 
            this.numericTextBox12.Location = new System.Drawing.Point(264, 132);
            this.numericTextBox12.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox12.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox12.Name = "numericTextBox12";
            this.numericTextBox12.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox12.TabIndex = 31;
            this.numericTextBox12.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox13
            // 
            this.numericTextBox13.Location = new System.Drawing.Point(352, 132);
            this.numericTextBox13.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox13.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox13.Name = "numericTextBox13";
            this.numericTextBox13.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox13.TabIndex = 30;
            this.numericTextBox13.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox14
            // 
            this.numericTextBox14.Location = new System.Drawing.Point(440, 132);
            this.numericTextBox14.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Name = "numericTextBox14";
            this.numericTextBox14.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox14.TabIndex = 29;
            this.numericTextBox14.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox15
            // 
            this.numericTextBox15.Location = new System.Drawing.Point(528, 132);
            this.numericTextBox15.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Name = "numericTextBox15";
            this.numericTextBox15.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox15.TabIndex = 28;
            this.numericTextBox15.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox16
            // 
            this.numericTextBox16.Location = new System.Drawing.Point(616, 132);
            this.numericTextBox16.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Name = "numericTextBox16";
            this.numericTextBox16.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox16.TabIndex = 27;
            this.numericTextBox16.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox17
            // 
            this.numericTextBox17.Location = new System.Drawing.Point(88, 132);
            this.numericTextBox17.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox17.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox17.Name = "numericTextBox17";
            this.numericTextBox17.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox17.TabIndex = 26;
            this.numericTextBox17.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox9
            // 
            this.numericTextBox9.Location = new System.Drawing.Point(704, 112);
            this.numericTextBox9.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Name = "numericTextBox9";
            this.numericTextBox9.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox9.TabIndex = 25;
            this.numericTextBox9.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox8
            // 
            this.numericTextBox8.Location = new System.Drawing.Point(176, 112);
            this.numericTextBox8.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox8.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox8.Name = "numericTextBox8";
            this.numericTextBox8.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox8.TabIndex = 24;
            this.numericTextBox8.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox7
            // 
            this.numericTextBox7.Location = new System.Drawing.Point(264, 112);
            this.numericTextBox7.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox7.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox7.Name = "numericTextBox7";
            this.numericTextBox7.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox7.TabIndex = 23;
            this.numericTextBox7.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox6
            // 
            this.numericTextBox6.Location = new System.Drawing.Point(352, 112);
            this.numericTextBox6.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Name = "numericTextBox6";
            this.numericTextBox6.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox6.TabIndex = 22;
            this.numericTextBox6.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox5
            // 
            this.numericTextBox5.Location = new System.Drawing.Point(440, 112);
            this.numericTextBox5.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox5.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox5.Name = "numericTextBox5";
            this.numericTextBox5.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox5.TabIndex = 21;
            this.numericTextBox5.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox4
            // 
            this.numericTextBox4.Location = new System.Drawing.Point(528, 112);
            this.numericTextBox4.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Name = "numericTextBox4";
            this.numericTextBox4.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox4.TabIndex = 20;
            this.numericTextBox4.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(616, 112);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox3.TabIndex = 19;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(88, 112);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox2.TabIndex = 18;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(88, 36);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox1.TabIndex = 17;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(176, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "Picks Today";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(264, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Day 2";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(360, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Day 3";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(440, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "Day4";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Day 5";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(616, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Day 6";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(712, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Day 7";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(88, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Picks Past Due";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Picked Today";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "To be Picked";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(320, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pics/Hr";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(320, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Available Pickers";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(320, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wave Creation Time";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "To be Picked";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Picked Today";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Wave";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGridPicks);
            this.groupBox2.Location = new System.Drawing.Point(8, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dGridPicks
            // 
            this.dGridPicks.DataMember = "";
            this.dGridPicks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridPicks.Location = new System.Drawing.Point(8, 16);
            this.dGridPicks.Name = "dGridPicks";
            this.dGridPicks.Size = new System.Drawing.Size(784, 152);
            this.dGridPicks.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(8, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 16);
            this.button1.Name = "button1";
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(720, 360);
            this.button2.Name = "button2";
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 360);
            this.button3.Name = "button3";
            this.button3.TabIndex = 4;
            this.button3.Text = "Ok";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(16, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "by Picker";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(96, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 24);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "by Carrier";
            // 
            // PickScreenForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(816, 398);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PickScreenForm";
            this.Text = "Pick Screen";
            this.Load += new System.EventHandler(this.PickScreenForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridPicks)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void PickScreenForm_Load(object sender, System.EventArgs e){
    loadGrid();

}

private void loadGrid(){
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "picks";
        string[][] vecNames = loadColumnsPicks();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridPicks);
        
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }    
}
       
       
private string[][] loadColumnsPicks(){
string[][] vec = new String[10][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		    case "0":
				v[0]="Wave";
				v[1] = "50";
				break;
		    case "1":
				v[0]="Pick #";
				v[1] = "60";
				break;
		    case "2":
				v[0]="Priority";
				v[1] = "90";
				break;	
		    case "3":
				v[0]="Pick Type";
				v[1] = "80";
				break;
		    case "4":
				v[0]="Carrier";
				v[1] = "90";
				break;							
			case "5":
				v[0]="Inv Status";
				v[1] = "80";
				break;
            case "6":
				v[0]="Order/Item/Rel";
				v[1] = "90";
				break;
  	       case "7":
				v[0]="Pickup Time";
				v[1] = "80";
				break;
   	       case "8":
				v[0]="Pkd";
				v[1] = "50";
				break;
  	       case "9":
  	       		v[0]="Customer";
				v[1] = "90";
				break;				
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}
       
}//end class
}//end namespace

