using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormBOM.
	/// </summary>
	public class FormBOM : System.Windows.Forms.Form
	{
		private Product product;
		private string prodId;
		private int seqId;
		private BomSumTempContainer bmsTemp;
		private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
		private bool isDirty = false;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TreeView tvProducts;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ComboBox cmBoxProdSeq;
		private System.Windows.Forms.TextBox tBoxOutput;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnUsage;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbProdDesc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormBOM()
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();
			this.prodId = "";
			this.seqId = 0;
			this.bmsTemp = new BomSumTempContainer();
		}

		public FormBOM(string prodId, int seqId)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.prodId = prodId;
			this.seqId = seqId;

			if (coreFactory.existsProduct(prodId)){
				product = coreFactory.readProduct(prodId);
				label2.Text = product.getProdID();
				prodId = product.getProdID();
				lbProdDesc.Text = product.getDes1();
                fillProdSeqCombo(coreFactory.getValidsSeqsForProduct(prodId));
                               
				if (cmBoxProdSeq.Items.IndexOf(seqId.ToString())>-1) {
					cmBoxProdSeq.SelectedIndex = cmBoxProdSeq.Items.IndexOf(seqId.ToString());
				} else if (cmBoxProdSeq.Items.Count>0) {
					cmBoxProdSeq.SelectedIndex = 0;
					seqId = int.Parse(cmBoxProdSeq.Items[cmBoxProdSeq.SelectedIndex].ToString());
				} else {
                    string[] items = new string[1];
                    items[0] = "0";
                    fillProdSeqCombo(items);                    
					cmBoxProdSeq.SelectedIndex = 0;
					seqId = 0;
					bmsTemp.Clear();
					bmsTemp = coreFactory.readBomSumTreeProdSeq(prodId, seqId);
				}
			}

			initializeTree();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBOM));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbProdDesc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.cmBoxProdSeq = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnUsage = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tvProducts = new System.Windows.Forms.TreeView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbProdDesc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.cmBoxProdSeq);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.btnUsage);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.tvProducts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product BOM";
            // 
            // lbProdDesc
            // 
            this.lbProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbProdDesc.Location = new System.Drawing.Point(80, 56);
            this.lbProdDesc.Name = "lbProdDesc";
            this.lbProdDesc.Size = new System.Drawing.Size(344, 24);
            this.lbProdDesc.TabIndex = 23;
            this.lbProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Description:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(440, 128);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 24);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(440, 304);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 16);
            this.button13.TabIndex = 20;
            this.button13.Text = "PrntMats";
            this.button13.Visible = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Location = new System.Drawing.Point(440, 288);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(72, 16);
            this.button12.TabIndex = 19;
            this.button12.Text = "srchInPrnt";
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(440, 272);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(72, 16);
            this.button11.TabIndex = 18;
            this.button11.Text = "SubChild";
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(440, 256);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 16);
            this.button10.TabIndex = 17;
            this.button10.Text = "SubMat";
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(440, 240);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(72, 16);
            this.button9.TabIndex = 16;
            this.button9.Text = "TempCont";
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(440, 224);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 16);
            this.button8.TabIndex = 15;
            this.button8.Text = "Submats";
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(440, 208);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 16);
            this.button7.TabIndex = 14;
            this.button7.Text = "Find nodes";
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cmBoxProdSeq
            // 
            this.cmBoxProdSeq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxProdSeq.Enabled = false;
            this.cmBoxProdSeq.Location = new System.Drawing.Point(336, 24);
            this.cmBoxProdSeq.Name = "cmBoxProdSeq";
            this.cmBoxProdSeq.Size = new System.Drawing.Size(88, 21);
            this.cmBoxProdSeq.Sorted = true;
            this.cmBoxProdSeq.TabIndex = 13;
            this.cmBoxProdSeq.SelectedIndexChanged += new System.EventHandler(this.cmBoxProdSeq_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(224, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 21);
            this.button6.TabIndex = 12;
            this.button6.Text = "...";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnUsage
            // 
            this.btnUsage.Enabled = false;
            this.btnUsage.Location = new System.Drawing.Point(440, 184);
            this.btnUsage.Name = "btnUsage";
            this.btnUsage.Size = new System.Drawing.Size(72, 24);
            this.btnUsage.TabIndex = 11;
            this.btnUsage.Text = "Mat. Usage";
            this.btnUsage.Click += new System.EventHandler(this.btnUsage_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(440, 152);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 24);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(440, 104);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 24);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tvProducts
            // 
            this.tvProducts.ContextMenu = this.contextMenu1;
            this.tvProducts.HideSelection = false;
            this.tvProducts.Location = new System.Drawing.Point(16, 96);
            this.tvProducts.Name = "tvProducts";
            this.tvProducts.ShowRootLines = false;
            this.tvProducts.Size = new System.Drawing.Size(408, 224);
            this.tvProducts.TabIndex = 8;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem7,
            this.menuItem2,
            this.menuItem3,
            this.menuItem5,
            this.menuItem6,
            this.menuItem4});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Add material";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Edit Material";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "Remove material";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "Material Usage";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.Text = "View properties";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(272, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sequence:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(80, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 2;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(176, 368);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(280, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tBoxOutput
            // 
            this.tBoxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxOutput.Location = new System.Drawing.Point(568, 8);
            this.tBoxOutput.Multiline = true;
            this.tBoxOutput.Name = "tBoxOutput";
            this.tBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxOutput.Size = new System.Drawing.Size(336, 376);
            this.tBoxOutput.TabIndex = 3;
            this.tBoxOutput.Visible = false;
            // 
            // FormBOM
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(560, 408);
            this.Controls.Add(this.tBoxOutput);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormBOM";
            this.Text = "Product BOM Maintenance";
            this.Load += new System.EventHandler(this.FormBOM_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormBOM_Closing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void initializeTree() {

			this.Refresh();
			tvProducts.Nodes.Clear();
			tvProducts.BeginUpdate();
			Cursor.Current = Cursors.WaitCursor;

			TreeNode Root=null;

			Root = new TreeNode(prodId);
			Root.Tag = (object)seqId;

			tvProducts.Nodes.Add(Root);
			loadChilds(prodId, seqId, Root,0);			
			tvProducts.ExpandAll();
			if (tvProducts.Nodes.Count>0) {
				tvProducts.Nodes[0].EnsureVisible();
				tvProducts.SelectedNode = tvProducts.Nodes[0];
			}
			tvProducts.EndUpdate();
			Cursor.Current = Cursors.Arrow;
		}

		private void loadChilds(string prodId, int prodSeq, TreeNode parentNode, int level) {
			if (level>100)
				return;		

			ArrayList subMats = bmsTemp.getProductChildren(prodId, prodSeq);

			TreeNode nodBOM=null;
            
			for(int i=0; i<subMats.Count; i++) {
				BomSum bomSumObj = (BomSum)subMats[i];

				string nodeMatId = bomSumObj.getBMS_MatID();
				int nodeMatSeq = bomSumObj.getBMS_MatSeq();

				if (validateNode(tvProducts, parentNode, nodeMatId, nodeMatSeq.ToString())) {
					nodBOM = new TreeNode(nodeMatId);
					nodBOM.Tag = (object)(nodeMatSeq);
					parentNode.Nodes.Add(nodBOM);
					loadChilds(nodeMatId, nodeMatSeq, nodBOM, level+1);
				}
			}
		}

		private BomSumTempContainer addSubTree(BomSumTempContainer bmsTempPar, BomSum bomSumObj) {
			BomSumTempContainer bmsTempTest = bmsTempPar.Copy();

			if (bmsTempTest.validateMaterial(bomSumObj)) {
				//ArrayList subMatArray = bmsTempTest.getProductChildren(bomSumObj.getBMS_MatID(), bomSumObj.getBMS_MatSeq());
				bmsTempTest.forceAddBomSum(bomSumObj);
				bmsTempTest = coreFactory.readBomSumTree(bmsTempTest, bomSumObj.getBMS_MatID(), bomSumObj.getBMS_MatSeq());
				return bmsTempTest;
			} else {
				MessageBox.Show("The selected material could create a cycle and cannot be added","Error");
				return bmsTempPar;
            }
		}

		private bool validateNode(TreeView treeView, TreeNode treeNode,string nodeMatId, string nodeMatSeq) {
			bool foundCycle = false;

			string[][] sumMatArray = getSubMaterialsArray(nodeMatId, int.Parse(nodeMatSeq));

			if (findMaterialInParents(treeNode, nodeMatId, int.Parse(nodeMatSeq)))
				return false;
			else {
				for (int p=0; p<sumMatArray.GetLength(0); p++) {
					string[] lineArray = (string[])sumMatArray[p];
					foundCycle = foundCycle || (materialCreatesCycle(treeView.Nodes[0], lineArray[0], lineArray[1], 0));
				}
				for (int p=0; p<sumMatArray.GetLength(0); p++) {
					string[] lineArray = (string[])sumMatArray[p];
					foundCycle = foundCycle || (findMaterialInParents(treeNode, lineArray[0], int.Parse(lineArray[1])));
				}
				return !foundCycle;
			}
		}

		private bool materialCreatesCycle(TreeNode treeRootNode, string matId, string matSeq, int level) {
		
			if (level>100)
				return true;
			if ((treeRootNode.Text==matId) && (treeRootNode.Tag.ToString()==matSeq.ToString()))
				return true;

			ArrayList nodesOfMat = new ArrayList();
			
			findNodes(treeRootNode, ref nodesOfMat, matId, matSeq);
           
			for(int i=0; i<nodesOfMat.Count; i++) {
				TreeNode node = (TreeNode)nodesOfMat[i];
				if (findMaterialInParents(node.Parent, matId, int.Parse(matSeq)))
					return true;
			}
			return false;
		}

		private void findNodes(TreeNode treeNode, ref ArrayList matNodes ,string matId, string matSeq) {

			if ((treeNode.Text==matId) && (treeNode.Tag.ToString()==matSeq))
				matNodes.Add(treeNode);
			for(int i=0; i<treeNode.Nodes.Count; i++ ){	
				TreeNode treeNodeC = treeNode.Nodes[i];
				findNodes(treeNodeC, ref matNodes, matId, matSeq);
			}
		}

		private void printTree(TreeNode treeNode, int level) {
			string s = " ";
			for (int x=0; x<level; x++)
				s = s + "  ";
			if (level>20)
				return;
						
			Console.WriteLine( s + treeNode.Text + " : " + treeNode.GetNodeCount(false).ToString());
			for(int i=0; i<treeNode.Nodes.Count; i++ ){
				TreeNode treeNodeC = treeNode.Nodes[i];
				printTree(treeNodeC, level+1);
			}
		}

		private bool findNodeInArray(string[] node, ArrayList list) {
			for(int x = 0; x < list.Count; x++){
				string[] lineArray = (string[])list[x];
				if ((node[0] == lineArray[0]) && (int.Parse(node[1]) == int.Parse(lineArray[1])))
					return true;
			}

			return false;
		}

		private bool matCycle(TreeNode treeNode, string matId, int matSeq, int level) {
		
			if (level>20)
				return true;
			if ((treeNode.Text==matId) && (treeNode.Tag.ToString()==matSeq.ToString()))
				return true;

			bool returnVal = false;
			for(int i=0; i<treeNode.Nodes.Count; i++ ){
				TreeNode treeNodeC = treeNode.Nodes[i];
				returnVal = returnVal || matCycle(treeNodeC, matId, matSeq, level+1);
			}
			return returnVal;
		}

		private bool findMaterialInParents(TreeNode treeNode, string matId, int matSeqId) {

			if (treeNode==null)
				return false;
			else if ((treeNode.Text==matId) && (treeNode.Tag.ToString()==matSeqId.ToString()))
				return true;
			else
				return findMaterialInParents(treeNode.Parent, matId, matSeqId);
		}

		private string[][] getSubMaterialsArray(string prodId, int prodSeq) {

			ArrayList matList = new ArrayList();

			string[] lineArrayP = new string[2];
			lineArrayP[0] = prodId;
			lineArrayP[1] = prodSeq.ToString();
			matList.Add(lineArrayP);

			matList = getSubMaterials(prodId, prodSeq, matList);
			string[][] returnArray = new string[matList.Count][];

			for(int x = 0; x < matList.Count; x++)
				returnArray[x] = (string[])matList[x];
			return returnArray;
		}


		private ArrayList getSubMaterials(string prodId, int prodSeq, ArrayList matList) {
		
			string[][] nodesDown = null;

            try {
				nodesDown = coreFactory.getSubMaterials(prodId,prodSeq);
				if (nodesDown.GetLength(0)>0) {
					for(int x = 0; x < nodesDown.GetLength(0); x++){
						string[] lineArray = new string[2];
						string matIdP = nodesDown[x][0];
						int matSeqP = int.Parse(nodesDown[x][1]);

						lineArray[0] = matIdP;
						lineArray[1] = matSeqP.ToString();
						if (!findNodeInArray(lineArray, matList)) {
							matList.Add(lineArray);
							matList = getSubMaterials(matIdP, matSeqP, matList);
						}						
					}
				} else {
					string[] lineArray = new string[2];
					lineArray[0] = prodId;
					lineArray[1] = prodSeq.ToString();
					if (!findNodeInArray(lineArray, matList)) {
						matList.Add(lineArray);
					}
				}
			} catch (NujitException ne) {
				MessageBox.Show(ne.Message);
			}
			return matList;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormBOM_Load(object sender, System.EventArgs e)
		{
			label2.Text = prodId;
			cmBoxProdSeq.Items.Clear();
			cmBoxProdSeq.Text = seqId.ToString();
            
            fillProdSeqCombo(coreFactory.getValidsSeqsForProduct(prodId));            
			if (cmBoxProdSeq.Items.IndexOf(seqId.ToString())>-1)
				cmBoxProdSeq.SelectedIndex = cmBoxProdSeq.Items.IndexOf(seqId.ToString());
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			if (tvProducts.SelectedNode!=null) {
				string matId = tvProducts.SelectedNode.Text;
				string seqId = tvProducts.SelectedNode.Tag.ToString();
				Product prod = coreFactory.readProduct(matId);
				string desc = prod.getDes1();
				MessageBox.Show("Material Id: " + matId + "\r\nDescription: " + desc + "\r\nSequence Id: " + seqId , "Material Info");
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			addMaterial();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			removeMaterial();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			coreFactory.updateBomSumTempContainer(bmsTemp);
			isDirty = false;
			this.Close();
		}

		private void btnAdd_Click(object sender, System.EventArgs e) {
			addMaterial();			
		}

		private void btnRemove_Click(object sender, System.EventArgs e) {
			removeMaterial();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			materialUsage();
		}

		private void btnUsage_Click(object sender, System.EventArgs e)
		{
			materialUsage();

		}

		private void materialUsage() {
			if (tvProducts.SelectedNode!=null) {
				string matId = tvProducts.SelectedNode.Text;
				int seqId = int.Parse(tvProducts.SelectedNode.Tag.ToString());
				FormMatUsage formMatUsage = new FormMatUsage(matId, seqId);
				formMatUsage.ShowDialog(this);
			}
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			if (isDirty) 
			{
				if (MessageBox.Show("If you continue, you will loose all changes made to the current product. \r\nAre you sure?","Current modifications not saved",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No) 
				{
					return;
				} 
				else 
				{
					isDirty = false;
				}
			}
			ProductSearchForm productSearchForm = new ProductSearchForm("Product search", true);
			productSearchForm.ShowDialog();
			
			if (productSearchForm.DialogResult == DialogResult.OK){
				string[] v = productSearchForm.getSelected();
				if (v!=null) {
					string id = v[0];
					objectToScreen(id);
					initializeTree();
					/*btnAdd.Enabled=true;
					btnEdit.Enabled=true;
					btnOK.Enabled=true;
					btnRemove.Enabled=true;
					btnUsage.Enabled=true;
					cmBoxProdSeq.Enabled=true;*/
				}
			}
		}

		private	void objectToScreen(string id){
			if (coreFactory.existsProduct(id)){
				product = coreFactory.readProduct(id);
				label2.Text = product.getProdID();
				lbProdDesc.Text = product.getDes1();
				prodId = product.getProdID();

                //Load the sequence numbers into combo box                
                fillProdSeqCombo(coreFactory.getValidsSeqsForProduct(prodId));

                if (cmBoxProdSeq.Items.IndexOf(product.getSeqLast().ToString())>-1) {
					cmBoxProdSeq.SelectedIndex = cmBoxProdSeq.Items.IndexOf(product.getSeqLast().ToString());
					seqId = product.getSeqLast();
				} else if (cmBoxProdSeq.Items.Count>0) {
					cmBoxProdSeq.SelectedIndex = 0;
					seqId = int.Parse(cmBoxProdSeq.Items[cmBoxProdSeq.SelectedIndex].ToString());
				} else {
                    
                    string[] items = new string[1];
                    items[0] = "0";
                    fillProdSeqCombo(items);                    
                    cmBoxProdSeq.SelectedIndex = 0;
					seqId = 0;
					bmsTemp.Clear();
					bmsTemp = coreFactory.readBomSumTreeProdSeq(prodId, seqId);
				}
			}
		}

        private
        void fillProdSeqCombo(string[] items){
            cmBoxProdSeq.Items.Clear();
            foreach (string s in items)
                cmBoxProdSeq.Items.Add(s);
        }

        private void cmBoxProdSeq_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmBoxProdSeq.SelectedIndex>-1) {
				if (isDirty) {
					DialogResult dr = MessageBox.Show("If you continue, you will loose all changes made to the current product. \r\nAre you sure?","Current modifications not saved",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
					if (dr == DialogResult.No) {
						cmBoxProdSeq.SelectedIndex = cmBoxProdSeq.Items.IndexOf(seqId.ToString());
					} else {
						isDirty = false;
						seqId = int.Parse(cmBoxProdSeq.Items[cmBoxProdSeq.SelectedIndex].ToString());
						bmsTemp.Clear();
						bmsTemp = coreFactory.readBomSumTreeProdSeq(prodId, seqId);
						initializeTree();
					}
				} else {
					seqId = int.Parse(cmBoxProdSeq.Items[cmBoxProdSeq.SelectedIndex].ToString());
					bmsTemp.Clear();
					bmsTemp = coreFactory.readBomSumTreeProdSeq(prodId, seqId);
					initializeTree();
				}	
			}
		}

		#region tests
		private void button7_Click(object sender, System.EventArgs e)
		{
			ArrayList nodesOfMat = new ArrayList();
			
			findNodes(tvProducts.Nodes[0], ref nodesOfMat, tvProducts.SelectedNode.Text, tvProducts.SelectedNode.Tag.ToString());

			string outStr =  "-----------------------\r\n>findNodes('" + tvProducts.SelectedNode.Text + "'," + tvProducts.SelectedNode.Tag.ToString() + "): [";
			for (int p=0; p<nodesOfMat.Count; p++) {
				TreeNode node = (TreeNode)nodesOfMat[p];
				outStr += node.Text + "/" + node.Tag.ToString();
				if (node.Parent!=null)
					outStr += " (p = " + node.Parent.Text + "), ";
				else
					outStr += " (root), ";
			}
			outStr += "]\r\n-----------------------\r\n\r\n";
			tBoxOutput.Text = outStr + tBoxOutput.Text;
		}

		private void button8_Click(object sender, System.EventArgs e)
		{	
			string outStr = "-----------------------\r\ngetSubMaterialsArray(" + tvProducts.SelectedNode.Text + "," + tvProducts.SelectedNode.Tag.ToString() + ")\r\n";
			string[][] sumMatArray = getSubMaterialsArray(tvProducts.SelectedNode.Text, int.Parse(tvProducts.SelectedNode.Tag.ToString()));
			outStr += "Submaterials: [";
			for (int p=0; p<sumMatArray.GetLength(0); p++)
				outStr += sumMatArray[p][0] + "/" + sumMatArray[p][1] + ", ";
			outStr += "]\r\n-----------------------\r\n\r\n";		

			tBoxOutput.Text = outStr + tBoxOutput.Text;
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			/*string prodId = tvProducts.SelectedNode.Text;
			int prodSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

			BomSumTempContainer bmsTemp = coreFactory.readBomSumTree(prodId, prodSeq);*/
			tBoxOutput.Text = "TempContainer: " + bmsTemp.ToString() + "\r\n\r\n" + tBoxOutput.Text;

		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			string prodId = tvProducts.SelectedNode.Text;
			int prodSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

			// BomSumTempContainer bmsTemp = coreFactory.readBomSumTree(prodId, prodSeq);
			ArrayList subMat = bmsTemp.getProductSubMaterials(prodId, prodSeq);
			string outStr = "Submaterials: [";
			for (int p=0; p<subMat.Count; p++) {
				BomSum bomSumObj = (BomSum)subMat[p];
				outStr += "('" + bomSumObj.getBMS_ProdID() + "'," + bomSumObj.getBMS_Seq() + "):('" + bomSumObj.getBMS_MatID() + "'," + bomSumObj.getBMS_MatSeq() + ") ";
			}
			outStr += "]";

			tBoxOutput.Text = outStr + "\r\n\r\n" + tBoxOutput.Text;
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			string prodId = tvProducts.SelectedNode.Text;
			int prodSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

			// BomSumTempContainer bmsTemp = coreFactory.readBomSumTree(prodId, prodSeq);
			ArrayList subMat = bmsTemp.getProductChildren(prodId, prodSeq);
			string outStr = "SubChildren: [";
			for (int p=0; p<subMat.Count; p++) {
				BomSum bomSumObj = (BomSum)subMat[p];
				outStr += "('" + bomSumObj.getBMS_ProdID() + "'," + bomSumObj.getBMS_Seq() + "):('" + bomSumObj.getBMS_MatID() + "'," + bomSumObj.getBMS_MatSeq() + ") ";
			}
			outStr += "]";

			tBoxOutput.Text = outStr + "\r\n\r\n" + tBoxOutput.Text;
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			/*string prodId = tvProducts.SelectedNode.Text;
			int prodSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

            string parentId = "";
			int parentSeq = 0;

			if (tvProducts.SelectedNode.Parent != null) {
				parentId = tvProducts.SelectedNode.Parent.Text;
				parentSeq = int.Parse(tvProducts.SelectedNode.Parent.Tag.ToString());
			}

			BomSum bomSumObj = new BomSum();
			bomSumObj.setBMS_ProdID(parentId);
			bomSumObj.setBMS_Seq(parentSeq);
			bomSumObj.setBMS_MatID(prodId);
			bomSumObj.setBMS_MatSeq(prodSeq);	
			
			string outStr = "findMaterialInParents= "+ (bmsTemp.findMaterialInParents(bomSumObj,prodId, prodSeq).ToString());
			tBoxOutput.Text = outStr + "\r\n\r\n" + tBoxOutput.Text;*/
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			/*string prodId = tvProducts.SelectedNode.Text;
			int prodSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

			ArrayList subMat = bmsTemp.findParentMaterials(prodId, prodSeq);
			string outStr = "findParentMaterials: [";
			for (int p=0; p<subMat.Count; p++) {
				BomSum bomSumObj = (BomSum)subMat[p];
				outStr += "('" + bomSumObj.getBMS_ProdID() + "'," + bomSumObj.getBMS_Seq() + "):('" + bomSumObj.getBMS_MatID() + "'," + bomSumObj.getBMS_MatSeq() + ") ";
			}
			outStr += "]";

			tBoxOutput.Text = outStr + "\r\n\r\n" + tBoxOutput.Text;*/
		}
		#endregion

		private void FormBOM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (isDirty) {
				DialogResult dr = MessageBox.Show("If you continue, you will loose all changes made to the current product. \r\nAre you sure?","Current modifications not saved",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
				if (dr == DialogResult.No)
					e.Cancel = true;
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e) {
			editMaterial();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			editMaterial();
		}

		private void addMaterial() {
			if (tvProducts.SelectedNode!=null) {
				string matId = tvProducts.SelectedNode.Text;
				int seqId = int.Parse(tvProducts.SelectedNode.Tag.ToString());
				FormAddBOM formAddBOM = new FormAddBOM(matId, seqId);
				formAddBOM.ShowDialog(this);
				if (formAddBOM.getReturnCode() == FormAddBOM.ADD_PRESSED){
					BomSum bomSumObj = formAddBOM.getBomSumObject();
					bmsTemp = addSubTree(bmsTemp, bomSumObj);
					isDirty = true;
					initializeTree();
				}
			}
		}

		private void removeMaterial() {
			if (tvProducts.SelectedNode!=null) {
				if (tvProducts.SelectedNode.Parent != null) {
					string matId = tvProducts.SelectedNode.Text;
					int matSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());

					string parentId = tvProducts.SelectedNode.Parent.Text;
					int parentMatSeq = int.Parse(tvProducts.SelectedNode.Parent.Tag.ToString());

					DialogResult dr = MessageBox.Show(this, "Delete material " + matId + " with sequence " + seqId.ToString() + "?","Delete material", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if (dr==DialogResult.Yes) {
						BomSum bomSumObj = new BomSum(parentId, "", parentMatSeq, "", 0, 0, 0, matId, matSeq, "", 0, "", 0, "", 0, "", "", 0, 0, 0, "", "", "", DateTime.Now, "");
						if (bmsTemp.existsBomSum(parentId, parentMatSeq,matId, matSeq))
							bmsTemp.deleteBomSum(parentId, parentMatSeq,matId, matSeq);
						isDirty = true;
						initializeTree();
					}
				}
			}
		}

		private void editMaterial() {
			if ((tvProducts.SelectedNode!=null) && (tvProducts.SelectedNode.Parent!=null)) {
				string matId = tvProducts.SelectedNode.Text;
				int matSeq = int.Parse(tvProducts.SelectedNode.Tag.ToString());
				string prodId = tvProducts.SelectedNode.Parent.Text;
				int prodSeq = int.Parse(tvProducts.SelectedNode.Parent.Tag.ToString());

				if (bmsTemp.existsBomSum(prodId, prodSeq, matId, matSeq)) {
					BomSum bomSumObj = bmsTemp.getBomSum(prodId, prodSeq, matId, matSeq);

					FormAddBOM formAddBOM = new FormAddBOM(bomSumObj);
					formAddBOM.ShowDialog(this);
					if (formAddBOM.getReturnCode() == FormAddBOM.ADD_PRESSED) {
						bomSumObj = formAddBOM.getBomSumObject();

						bmsTemp = addSubTree(bmsTemp, bomSumObj);
						isDirty = true;
						initializeTree();
					}
				}
			}
		}

	}
}
