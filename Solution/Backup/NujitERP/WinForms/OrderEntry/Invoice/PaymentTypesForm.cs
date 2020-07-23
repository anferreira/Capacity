using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.OrderEntry.Invoice
{
	/// <summary>
	/// Summary description for PaymentTypesForm.
	/// </summary>
	public class PaymentTypesForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox gBoxCreditCard;
        private System.Windows.Forms.Label label52;
        private NujitCustomWinControls.NumericTextBox numericTextBox17;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label50;
        private NujitCustomWinControls.NumericTextBox numericTextBox16;
        private System.Windows.Forms.TextBox tBoxIH_CreditCardNumber;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label lIHCreditCardNumber;
        private System.Windows.Forms.CheckBox cBoxIH_Authorization;
        private System.Windows.Forms.Label label1;
        private NujitCustomWinControls.NumericTextBox ntbIH_ExpiryDateMonth;
        private NujitCustomWinControls.NumericTextBox ntbIH_ExpiryDateYear;
        private System.Windows.Forms.Label lIHExpiryDate;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label45;
        private NujitCustomWinControls.NumericTextBox numericTextBox15;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label lIH_DepositAmt;
        private NujitCustomWinControls.NumericTextBox ntbIH_DepositAmt;
        private System.Windows.Forms.Label lIH_AmtOwed;
        private NujitCustomWinControls.NumericTextBox ntbIH_AmtOwed;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gBoxGriftCertificate;
        private System.Windows.Forms.GroupBox gBoxTravelCheques;
        private System.Windows.Forms.RadioButton rbtnCDCard;
        private System.Windows.Forms.RadioButton rbtnCheck;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnTravelCheques;
        private System.Windows.Forms.RadioButton rbtnOnAccount;
        private System.Windows.Forms.GroupBox gBoxCDCard;
        private System.Windows.Forms.GroupBox gBoxOnAccount;
        private System.Windows.Forms.GroupBox gBoxCheck;
        private System.Windows.Forms.GroupBox gBoxCash;
        private System.Windows.Forms.RadioButton rbtnGriftCertificate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton rbtnAmrExpress;
        private System.Windows.Forms.GroupBox gBoxAmerExpress;
        private System.Windows.Forms.RadioButton rBtnDebitCard;
        private System.Windows.Forms.GroupBox gBoxDebitCard;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaymentTypesForm()
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
            this.gBoxCreditCard = new System.Windows.Forms.GroupBox();
            this.gBoxGriftCertificate = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.numericTextBox17 = new NujitCustomWinControls.NumericTextBox();
            this.gBoxTravelCheques = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.numericTextBox16 = new NujitCustomWinControls.NumericTextBox();
            this.rbtnGriftCertificate = new System.Windows.Forms.RadioButton();
            this.rbtnCDCard = new System.Windows.Forms.RadioButton();
            this.rbtnCheck = new System.Windows.Forms.RadioButton();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnTravelCheques = new System.Windows.Forms.RadioButton();
            this.rbtnOnAccount = new System.Windows.Forms.RadioButton();
            this.gBoxCDCard = new System.Windows.Forms.GroupBox();
            this.tBoxIH_CreditCardNumber = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.lIHCreditCardNumber = new System.Windows.Forms.Label();
            this.cBoxIH_Authorization = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ntbIH_ExpiryDateMonth = new NujitCustomWinControls.NumericTextBox();
            this.ntbIH_ExpiryDateYear = new NujitCustomWinControls.NumericTextBox();
            this.lIHExpiryDate = new System.Windows.Forms.Label();
            this.gBoxCash = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.numericTextBox15 = new NujitCustomWinControls.NumericTextBox();
            this.gBoxOnAccount = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.lIH_DepositAmt = new System.Windows.Forms.Label();
            this.ntbIH_DepositAmt = new NujitCustomWinControls.NumericTextBox();
            this.lIH_AmtOwed = new System.Windows.Forms.Label();
            this.ntbIH_AmtOwed = new NujitCustomWinControls.NumericTextBox();
            this.gBoxCheck = new System.Windows.Forms.GroupBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbtnAmrExpress = new System.Windows.Forms.RadioButton();
            this.gBoxAmerExpress = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rBtnDebitCard = new System.Windows.Forms.RadioButton();
            this.gBoxDebitCard = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.gBoxCreditCard.SuspendLayout();
            this.gBoxGriftCertificate.SuspendLayout();
            this.gBoxTravelCheques.SuspendLayout();
            this.gBoxCDCard.SuspendLayout();
            this.gBoxCash.SuspendLayout();
            this.gBoxOnAccount.SuspendLayout();
            this.gBoxCheck.SuspendLayout();
            this.gBoxAmerExpress.SuspendLayout();
            this.gBoxDebitCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxCreditCard
            // 
            this.gBoxCreditCard.Controls.Add(this.rBtnDebitCard);
            this.gBoxCreditCard.Controls.Add(this.gBoxDebitCard);
            this.gBoxCreditCard.Controls.Add(this.rbtnAmrExpress);
            this.gBoxCreditCard.Controls.Add(this.gBoxAmerExpress);
            this.gBoxCreditCard.Controls.Add(this.gBoxGriftCertificate);
            this.gBoxCreditCard.Controls.Add(this.gBoxTravelCheques);
            this.gBoxCreditCard.Controls.Add(this.rbtnGriftCertificate);
            this.gBoxCreditCard.Controls.Add(this.rbtnCDCard);
            this.gBoxCreditCard.Controls.Add(this.rbtnCheck);
            this.gBoxCreditCard.Controls.Add(this.rbtnCash);
            this.gBoxCreditCard.Controls.Add(this.rbtnTravelCheques);
            this.gBoxCreditCard.Controls.Add(this.rbtnOnAccount);
            this.gBoxCreditCard.Controls.Add(this.gBoxCDCard);
            this.gBoxCreditCard.Controls.Add(this.gBoxCash);
            this.gBoxCreditCard.Controls.Add(this.gBoxOnAccount);
            this.gBoxCreditCard.Controls.Add(this.gBoxCheck);
            this.gBoxCreditCard.Controls.Add(this.btnOk);
            this.gBoxCreditCard.Controls.Add(this.btnCancel);
            this.gBoxCreditCard.Location = new System.Drawing.Point(8, 0);
            this.gBoxCreditCard.Name = "gBoxCreditCard";
            this.gBoxCreditCard.Size = new System.Drawing.Size(752, 520);
            this.gBoxCreditCard.TabIndex = 68;
            this.gBoxCreditCard.TabStop = false;
            // 
            // gBoxGriftCertificate
            // 
            this.gBoxGriftCertificate.Controls.Add(this.label52);
            this.gBoxGriftCertificate.Controls.Add(this.numericTextBox17);
            this.gBoxGriftCertificate.Enabled = false;
            this.gBoxGriftCertificate.Location = new System.Drawing.Point(152, 432);
            this.gBoxGriftCertificate.Name = "gBoxGriftCertificate";
            this.gBoxGriftCertificate.Size = new System.Drawing.Size(584, 48);
            this.gBoxGriftCertificate.TabIndex = 91;
            this.gBoxGriftCertificate.TabStop = false;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(16, 16);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(104, 20);
            this.label52.TabIndex = 73;
            this.label52.Text = "Certificate Number";
            // 
            // numericTextBox17
            // 
            this.numericTextBox17.Location = new System.Drawing.Point(136, 16);
            this.numericTextBox17.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox17.MaxPrecision = 2;
            this.numericTextBox17.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox17.Name = "numericTextBox17";
            this.numericTextBox17.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox17.TabIndex = 74;
            this.numericTextBox17.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // gBoxTravelCheques
            // 
            this.gBoxTravelCheques.Controls.Add(this.label49);
            this.gBoxTravelCheques.Controls.Add(this.textBox28);
            this.gBoxTravelCheques.Controls.Add(this.label50);
            this.gBoxTravelCheques.Controls.Add(this.numericTextBox16);
            this.gBoxTravelCheques.Enabled = false;
            this.gBoxTravelCheques.Location = new System.Drawing.Point(152, 384);
            this.gBoxTravelCheques.Name = "gBoxTravelCheques";
            this.gBoxTravelCheques.Size = new System.Drawing.Size(584, 48);
            this.gBoxTravelCheques.TabIndex = 90;
            this.gBoxTravelCheques.TabStop = false;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(208, 16);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(56, 20);
            this.label49.TabIndex = 80;
            this.label49.Text = "Currency";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(272, 16);
            this.textBox28.MaxLength = 5;
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(72, 20);
            this.textBox28.TabIndex = 79;
            this.textBox28.Text = "";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(16, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(64, 20);
            this.label50.TabIndex = 73;
            this.label50.Text = "Amount";
            // 
            // numericTextBox16
            // 
            this.numericTextBox16.Location = new System.Drawing.Point(80, 16);
            this.numericTextBox16.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox16.MaxPrecision = 2;
            this.numericTextBox16.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Name = "numericTextBox16";
            this.numericTextBox16.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox16.TabIndex = 74;
            this.numericTextBox16.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // rbtnGriftCertificate
            // 
            this.rbtnGriftCertificate.Location = new System.Drawing.Point(8, 440);
            this.rbtnGriftCertificate.Name = "rbtnGriftCertificate";
            this.rbtnGriftCertificate.TabIndex = 89;
            this.rbtnGriftCertificate.Text = "Gift Certificate";
            this.rbtnGriftCertificate.CheckedChanged += new System.EventHandler(this.rbtnGriftCertificate_CheckedChanged);
            // 
            // rbtnCDCard
            // 
            this.rbtnCDCard.Location = new System.Drawing.Point(8, 200);
            this.rbtnCDCard.Name = "rbtnCDCard";
            this.rbtnCDCard.Size = new System.Drawing.Size(112, 24);
            this.rbtnCDCard.TabIndex = 88;
            this.rbtnCDCard.Text = "Credit Card";
            this.rbtnCDCard.CheckedChanged += new System.EventHandler(this.rbtnCDCard_CheckedChanged);
            // 
            // rbtnCheck
            // 
            this.rbtnCheck.Location = new System.Drawing.Point(8, 96);
            this.rbtnCheck.Name = "rbtnCheck";
            this.rbtnCheck.Size = new System.Drawing.Size(104, 16);
            this.rbtnCheck.TabIndex = 87;
            this.rbtnCheck.Text = "Check";
            this.rbtnCheck.CheckedChanged += new System.EventHandler(this.rbtnCheck_CheckedChanged);
            // 
            // rbtnCash
            // 
            this.rbtnCash.Location = new System.Drawing.Point(8, 144);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.TabIndex = 86;
            this.rbtnCash.Text = "Cash";
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // rbtnTravelCheques
            // 
            this.rbtnTravelCheques.Location = new System.Drawing.Point(8, 392);
            this.rbtnTravelCheques.Name = "rbtnTravelCheques";
            this.rbtnTravelCheques.TabIndex = 85;
            this.rbtnTravelCheques.Text = "Travel Cheques";
            this.rbtnTravelCheques.CheckedChanged += new System.EventHandler(this.rbtnTravelCheques_CheckedChanged);
            // 
            // rbtnOnAccount
            // 
            this.rbtnOnAccount.Checked = true;
            this.rbtnOnAccount.Location = new System.Drawing.Point(8, 16);
            this.rbtnOnAccount.Name = "rbtnOnAccount";
            this.rbtnOnAccount.Size = new System.Drawing.Size(104, 16);
            this.rbtnOnAccount.TabIndex = 84;
            this.rbtnOnAccount.TabStop = true;
            this.rbtnOnAccount.Text = "On Account";
            this.rbtnOnAccount.CheckedChanged += new System.EventHandler(this.rbtnOnAccount_CheckedChanged);
            // 
            // gBoxCDCard
            // 
            this.gBoxCDCard.Controls.Add(this.tBoxIH_CreditCardNumber);
            this.gBoxCDCard.Controls.Add(this.label48);
            this.gBoxCDCard.Controls.Add(this.textBox27);
            this.gBoxCDCard.Controls.Add(this.label47);
            this.gBoxCDCard.Controls.Add(this.textBox26);
            this.gBoxCDCard.Controls.Add(this.lIHCreditCardNumber);
            this.gBoxCDCard.Controls.Add(this.cBoxIH_Authorization);
            this.gBoxCDCard.Controls.Add(this.label1);
            this.gBoxCDCard.Controls.Add(this.ntbIH_ExpiryDateMonth);
            this.gBoxCDCard.Controls.Add(this.ntbIH_ExpiryDateYear);
            this.gBoxCDCard.Controls.Add(this.lIHExpiryDate);
            this.gBoxCDCard.Enabled = false;
            this.gBoxCDCard.Location = new System.Drawing.Point(152, 192);
            this.gBoxCDCard.Name = "gBoxCDCard";
            this.gBoxCDCard.Size = new System.Drawing.Size(584, 72);
            this.gBoxCDCard.TabIndex = 83;
            this.gBoxCDCard.TabStop = false;
            // 
            // tBoxIH_CreditCardNumber
            // 
            this.tBoxIH_CreditCardNumber.Location = new System.Drawing.Point(56, 16);
            this.tBoxIH_CreditCardNumber.MaxLength = 16;
            this.tBoxIH_CreditCardNumber.Name = "tBoxIH_CreditCardNumber";
            this.tBoxIH_CreditCardNumber.Size = new System.Drawing.Size(112, 20);
            this.tBoxIH_CreditCardNumber.TabIndex = 65;
            this.tBoxIH_CreditCardNumber.Text = "";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 40);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 16);
            this.label48.TabIndex = 82;
            this.label48.Text = "Name";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(56, 40);
            this.textBox27.MaxLength = 30;
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(200, 20);
            this.textBox27.TabIndex = 81;
            this.textBox27.Text = "";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(280, 40);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(80, 16);
            this.label47.TabIndex = 80;
            this.label47.Text = "Security Code";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(360, 40);
            this.textBox26.MaxLength = 16;
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(112, 20);
            this.textBox26.TabIndex = 79;
            this.textBox26.Text = "";
            // 
            // lIHCreditCardNumber
            // 
            this.lIHCreditCardNumber.Location = new System.Drawing.Point(8, 16);
            this.lIHCreditCardNumber.Name = "lIHCreditCardNumber";
            this.lIHCreditCardNumber.Size = new System.Drawing.Size(48, 16);
            this.lIHCreditCardNumber.TabIndex = 66;
            this.lIHCreditCardNumber.Text = "Card #";
            // 
            // cBoxIH_Authorization
            // 
            this.cBoxIH_Authorization.Checked = true;
            this.cBoxIH_Authorization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIH_Authorization.Location = new System.Drawing.Point(376, 16);
            this.cBoxIH_Authorization.Name = "cBoxIH_Authorization";
            this.cBoxIH_Authorization.Size = new System.Drawing.Size(96, 16);
            this.cBoxIH_Authorization.TabIndex = 78;
            this.cBoxIH_Authorization.Text = "Authorization";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(304, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntbIH_ExpiryDateMonth
            // 
            this.ntbIH_ExpiryDateMonth.Location = new System.Drawing.Point(320, 16);
            this.ntbIH_ExpiryDateMonth.Maximum = new System.Decimal(new int[] {
                                                                                  31,
                                                                                  0,
                                                                                  0,
                                                                                  0});
            this.ntbIH_ExpiryDateMonth.Minimum = new System.Decimal(new int[] {
                                                                                  1,
                                                                                  0,
                                                                                  0,
                                                                                  0});
            this.ntbIH_ExpiryDateMonth.Name = "ntbIH_ExpiryDateMonth";
            this.ntbIH_ExpiryDateMonth.Size = new System.Drawing.Size(24, 20);
            this.ntbIH_ExpiryDateMonth.TabIndex = 76;
            this.ntbIH_ExpiryDateMonth.Value = new System.Decimal(new int[] {
                                                                                1,
                                                                                0,
                                                                                0,
                                                                                0});
            // 
            // ntbIH_ExpiryDateYear
            // 
            this.ntbIH_ExpiryDateYear.Location = new System.Drawing.Point(272, 16);
            this.ntbIH_ExpiryDateYear.Maximum = new System.Decimal(new int[] {
                                                                                 3000,
                                                                                 0,
                                                                                 0,
                                                                                 0});
            this.ntbIH_ExpiryDateYear.Minimum = new System.Decimal(new int[] {
                                                                                 1999,
                                                                                 0,
                                                                                 0,
                                                                                 0});
            this.ntbIH_ExpiryDateYear.Name = "ntbIH_ExpiryDateYear";
            this.ntbIH_ExpiryDateYear.Size = new System.Drawing.Size(32, 20);
            this.ntbIH_ExpiryDateYear.TabIndex = 75;
            this.ntbIH_ExpiryDateYear.Value = new System.Decimal(new int[] {
                                                                               1999,
                                                                               0,
                                                                               0,
                                                                               0});
            // 
            // lIHExpiryDate
            // 
            this.lIHExpiryDate.Location = new System.Drawing.Point(208, 16);
            this.lIHExpiryDate.Name = "lIHExpiryDate";
            this.lIHExpiryDate.Size = new System.Drawing.Size(64, 16);
            this.lIHExpiryDate.TabIndex = 68;
            this.lIHExpiryDate.Text = "Expiry Date";
            // 
            // gBoxCash
            // 
            this.gBoxCash.Controls.Add(this.label46);
            this.gBoxCash.Controls.Add(this.textBox25);
            this.gBoxCash.Controls.Add(this.label45);
            this.gBoxCash.Controls.Add(this.numericTextBox15);
            this.gBoxCash.Enabled = false;
            this.gBoxCash.Location = new System.Drawing.Point(152, 136);
            this.gBoxCash.Name = "gBoxCash";
            this.gBoxCash.Size = new System.Drawing.Size(584, 56);
            this.gBoxCash.TabIndex = 82;
            this.gBoxCash.TabStop = false;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(216, 16);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(56, 20);
            this.label46.TabIndex = 80;
            this.label46.Text = "Currency";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(272, 16);
            this.textBox25.MaxLength = 5;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(72, 20);
            this.textBox25.TabIndex = 79;
            this.textBox25.Text = "";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(16, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 20);
            this.label45.TabIndex = 73;
            this.label45.Text = "Amount";
            // 
            // numericTextBox15
            // 
            this.numericTextBox15.Location = new System.Drawing.Point(80, 16);
            this.numericTextBox15.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox15.MaxPrecision = 2;
            this.numericTextBox15.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Name = "numericTextBox15";
            this.numericTextBox15.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox15.TabIndex = 74;
            this.numericTextBox15.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // gBoxOnAccount
            // 
            this.gBoxOnAccount.Controls.Add(this.label44);
            this.gBoxOnAccount.Controls.Add(this.textBox24);
            this.gBoxOnAccount.Controls.Add(this.label43);
            this.gBoxOnAccount.Controls.Add(this.textBox23);
            this.gBoxOnAccount.Controls.Add(this.lIH_DepositAmt);
            this.gBoxOnAccount.Controls.Add(this.ntbIH_DepositAmt);
            this.gBoxOnAccount.Controls.Add(this.lIH_AmtOwed);
            this.gBoxOnAccount.Controls.Add(this.ntbIH_AmtOwed);
            this.gBoxOnAccount.Location = new System.Drawing.Point(152, 16);
            this.gBoxOnAccount.Name = "gBoxOnAccount";
            this.gBoxOnAccount.Size = new System.Drawing.Size(584, 72);
            this.gBoxOnAccount.TabIndex = 81;
            this.gBoxOnAccount.TabStop = false;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(208, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(72, 20);
            this.label44.TabIndex = 78;
            this.label44.Text = "Bank Name";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(280, 16);
            this.textBox24.MaxLength = 40;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(256, 20);
            this.textBox24.TabIndex = 77;
            this.textBox24.Text = "";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(8, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 20);
            this.label43.TabIndex = 76;
            this.label43.Text = "Account #";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(80, 16);
            this.textBox23.MaxLength = 16;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(120, 20);
            this.textBox23.TabIndex = 75;
            this.textBox23.Text = "";
            // 
            // lIH_DepositAmt
            // 
            this.lIH_DepositAmt.Location = new System.Drawing.Point(208, 36);
            this.lIH_DepositAmt.Name = "lIH_DepositAmt";
            this.lIH_DepositAmt.Size = new System.Drawing.Size(72, 20);
            this.lIH_DepositAmt.TabIndex = 71;
            this.lIH_DepositAmt.Text = "Deposit Amt";
            // 
            // ntbIH_DepositAmt
            // 
            this.ntbIH_DepositAmt.Location = new System.Drawing.Point(280, 36);
            this.ntbIH_DepositAmt.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.ntbIH_DepositAmt.MaxPrecision = 2;
            this.ntbIH_DepositAmt.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbIH_DepositAmt.Name = "ntbIH_DepositAmt";
            this.ntbIH_DepositAmt.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_DepositAmt.TabIndex = 72;
            this.ntbIH_DepositAmt.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIH_AmtOwed
            // 
            this.lIH_AmtOwed.Location = new System.Drawing.Point(8, 36);
            this.lIH_AmtOwed.Name = "lIH_AmtOwed";
            this.lIH_AmtOwed.Size = new System.Drawing.Size(64, 20);
            this.lIH_AmtOwed.TabIndex = 69;
            this.lIH_AmtOwed.Text = "Amt Owed";
            // 
            // ntbIH_AmtOwed
            // 
            this.ntbIH_AmtOwed.Location = new System.Drawing.Point(80, 36);
            this.ntbIH_AmtOwed.Maximum = new System.Decimal(new int[] {
                                                                          1874919424,
                                                                          2328306,
                                                                          0,
                                                                          0});
            this.ntbIH_AmtOwed.MaxPrecision = 2;
            this.ntbIH_AmtOwed.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbIH_AmtOwed.Name = "ntbIH_AmtOwed";
            this.ntbIH_AmtOwed.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_AmtOwed.TabIndex = 70;
            this.ntbIH_AmtOwed.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // gBoxCheck
            // 
            this.gBoxCheck.Controls.Add(this.textBox21);
            this.gBoxCheck.Controls.Add(this.textBox22);
            this.gBoxCheck.Controls.Add(this.textBox5);
            this.gBoxCheck.Controls.Add(this.label42);
            this.gBoxCheck.Controls.Add(this.label41);
            this.gBoxCheck.Controls.Add(this.label4);
            this.gBoxCheck.Enabled = false;
            this.gBoxCheck.Location = new System.Drawing.Point(152, 88);
            this.gBoxCheck.Name = "gBoxCheck";
            this.gBoxCheck.Size = new System.Drawing.Size(584, 48);
            this.gBoxCheck.TabIndex = 80;
            this.gBoxCheck.TabStop = false;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(368, 16);
            this.textBox21.MaxLength = 30;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(200, 20);
            this.textBox21.TabIndex = 75;
            this.textBox21.Text = "";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(232, 16);
            this.textBox22.MaxLength = 5;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(72, 20);
            this.textBox22.TabIndex = 77;
            this.textBox22.Text = "";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(64, 16);
            this.textBox5.MaxLength = 16;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(112, 20);
            this.textBox5.TabIndex = 73;
            this.textBox5.Text = "";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(184, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 20);
            this.label42.TabIndex = 78;
            this.label42.Text = "Currency";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(320, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 20);
            this.label41.TabIndex = 76;
            this.label41.Text = "Name";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Check #";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(560, 488);
            this.btnOk.Name = "btnOk";
            this.btnOk.TabIndex = 69;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(656, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnAmrExpress
            // 
            this.rbtnAmrExpress.Location = new System.Drawing.Point(8, 272);
            this.rbtnAmrExpress.Name = "rbtnAmrExpress";
            this.rbtnAmrExpress.Size = new System.Drawing.Size(144, 24);
            this.rbtnAmrExpress.TabIndex = 93;
            this.rbtnAmrExpress.Text = "American Express Card";
            // 
            // gBoxAmerExpress
            // 
            this.gBoxAmerExpress.Controls.Add(this.textBox1);
            this.gBoxAmerExpress.Controls.Add(this.label2);
            this.gBoxAmerExpress.Controls.Add(this.textBox2);
            this.gBoxAmerExpress.Controls.Add(this.label3);
            this.gBoxAmerExpress.Controls.Add(this.textBox3);
            this.gBoxAmerExpress.Controls.Add(this.label5);
            this.gBoxAmerExpress.Controls.Add(this.checkBox1);
            this.gBoxAmerExpress.Controls.Add(this.label7);
            this.gBoxAmerExpress.Controls.Add(this.numericTextBox1);
            this.gBoxAmerExpress.Controls.Add(this.numericTextBox2);
            this.gBoxAmerExpress.Controls.Add(this.label8);
            this.gBoxAmerExpress.Enabled = false;
            this.gBoxAmerExpress.Location = new System.Drawing.Point(152, 264);
            this.gBoxAmerExpress.Name = "gBoxAmerExpress";
            this.gBoxAmerExpress.Size = new System.Drawing.Size(584, 72);
            this.gBoxAmerExpress.TabIndex = 92;
            this.gBoxAmerExpress.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 16);
            this.textBox1.MaxLength = 16;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 65;
            this.textBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 82;
            this.label2.Text = "Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 40);
            this.textBox2.MaxLength = 30;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 81;
            this.textBox2.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "Security Code";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(352, 40);
            this.textBox3.MaxLength = 16;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 20);
            this.textBox3.TabIndex = 79;
            this.textBox3.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "Card #";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(376, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 78;
            this.checkBox1.Text = "Authorization";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(304, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 77;
            this.label7.Text = "-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(320, 16);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            31,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            1,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(24, 20);
            this.numericTextBox1.TabIndex = 76;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          1,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(272, 16);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            3000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            1999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(32, 20);
            this.numericTextBox2.TabIndex = 75;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          1999,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(208, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "Expiry Date";
            // 
            // rBtnDebitCard
            // 
            this.rBtnDebitCard.Location = new System.Drawing.Point(8, 344);
            this.rBtnDebitCard.Name = "rBtnDebitCard";
            this.rBtnDebitCard.Size = new System.Drawing.Size(144, 24);
            this.rBtnDebitCard.TabIndex = 95;
            this.rBtnDebitCard.Text = "Debit Card";
            // 
            // gBoxDebitCard
            // 
            this.gBoxDebitCard.Controls.Add(this.textBox4);
            this.gBoxDebitCard.Controls.Add(this.label6);
            this.gBoxDebitCard.Controls.Add(this.textBox6);
            this.gBoxDebitCard.Controls.Add(this.label10);
            this.gBoxDebitCard.Controls.Add(this.checkBox2);
            this.gBoxDebitCard.Enabled = false;
            this.gBoxDebitCard.Location = new System.Drawing.Point(152, 336);
            this.gBoxDebitCard.Name = "gBoxDebitCard";
            this.gBoxDebitCard.Size = new System.Drawing.Size(584, 48);
            this.gBoxDebitCard.TabIndex = 94;
            this.gBoxDebitCard.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(56, 16);
            this.textBox4.MaxLength = 16;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 20);
            this.textBox4.TabIndex = 65;
            this.textBox4.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(184, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 82;
            this.label6.Text = "Name";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(232, 16);
            this.textBox6.MaxLength = 30;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(200, 20);
            this.textBox6.TabIndex = 81;
            this.textBox6.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 66;
            this.label10.Text = "Card #";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(456, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 78;
            this.checkBox2.Text = "Authorization";
            // 
            // PaymentTypesForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(776, 534);
            this.Controls.Add(this.gBoxCreditCard);
            this.Name = "PaymentTypesForm";
            this.Text = "Payment Types";
            this.gBoxCreditCard.ResumeLayout(false);
            this.gBoxGriftCertificate.ResumeLayout(false);
            this.gBoxTravelCheques.ResumeLayout(false);
            this.gBoxCDCard.ResumeLayout(false);
            this.gBoxCash.ResumeLayout(false);
            this.gBoxOnAccount.ResumeLayout(false);
            this.gBoxCheck.ResumeLayout(false);
            this.gBoxAmerExpress.ResumeLayout(false);
            this.gBoxDebitCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void enableGBox(){

    this.gBoxCDCard.Enabled = false;
    this.gBoxCheck.Enabled = false;
    this.gBoxCreditCard.Enabled = false;
    this.gBoxGriftCertificate.Enabled = false;
    this.gBoxOnAccount.Enabled = false;
    this.gBoxTravelCheques.Enabled = false;
    this.gBoxCash.Enabled = false;

}

private void rbtnOnAccount_CheckedChanged(object sender, System.EventArgs e){
    enableGBox();
    this.gBoxOnAccount.Enabled = true;

}

private void rbtnCheck_CheckedChanged(object sender, System.EventArgs e){
    enableGBox();
    this.gBoxCheck.Enabled = true;
}

private void rbtnCash_CheckedChanged(object sender, System.EventArgs e){

    enableGBox();
    this.gBoxCash.Enabled = true;
}

private void rbtnCDCard_CheckedChanged(object sender, System.EventArgs e){

    enableGBox();
    this.gBoxCDCard.Enabled = true;
}

private void rbtnTravelCheques_CheckedChanged(object sender, System.EventArgs e){

    enableGBox();
    this.gBoxTravelCheques.Enabled = true;
}

private void rbtnGriftCertificate_CheckedChanged(object sender, System.EventArgs e){
    
    enableGBox();
    this.gBoxGriftCertificate.Enabled = true;
}

private void btnOk_Click(object sender, System.EventArgs e){
    this.Close();

}

private void btnCancel_Click(object sender, System.EventArgs e){

    this.Close();
}




}
}
