//Created by Eric Zhong 
//March 16 ,2004

using System;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;

using System.Data;

using Nujit.NujitERP.ClassLib.Common;
//using Nujit.NujitERP.ClassLib.Master;

namespace Nujit.NujitERP.WinForms.CustomControls
{
	
//	public class TreeNodePlt:System.Windows.Forms.TreeNode
//	{
//		private int intType = 0;
//
//		private Plt objPlt;
//
//		
//		public Plt Plt
//		{
//			get 
//			{  if (this.objPlt == null) return new Plt();
//
//				return this.objPlt;
//			}
//			set {this.objPlt = value;}
//		
//		}
//
//		public int Type
//		{
//			get {return this.intType;}
//			set {this.intType = value;}
//		
//		}
//	}
//
//	public class TreeNodePltDept:System.Windows.Forms.TreeNode
//	{
//		private int intType = 0;
//
//		private PltDept objPltDept;
//		
//		public PltDept PltDept
//		{
//			get 
//			{
//					if (this.objPltDept == null) return new PltDept();
//
//				return this.objPltDept;
//			}
//			set {this.objPltDept = value;}
//		
//		}
//
//		public string Type
//		{
//			get {return this.intType;}
//			set {this.intType = value;}
//		
//		}
//	}

	public class TypedTreeNode:System.Windows.Forms.TreeNode
	{
		private  TreeNodeType treeNodeType ;

		private DataRow objDataRow = null;

		private object content = null;

		private bool objectLoaded = false;

		private DataTable childNodesDataTable = null;

		public DataTable ChildNodesDataTable
		{
			get {return this.childNodesDataTable;}
			set {this.childNodesDataTable = value;}
		}

		public DataRow TagedDataRow
		{
			get {return this.objDataRow;}
			set {this.objDataRow= value;}
		
		}
		public TreeNodeType Type
		{
			get {return this.treeNodeType;}
			set {this.treeNodeType = value;}
		
		}

		public object Content
		{
			get {return this.content;}
			set 
			{
				this.content = value;
				objectLoaded = true;
			}
		}

		public bool ObjectLoaded
		{
			get {return objectLoaded;}
			set {objectLoaded = value;}
		}

		public void refresh()
		{
			if (content != null)
			{
				switch (treeNodeType)
				{
					case (TreeNodeType.PLANT):
						base.Text = ((Plant)content).getPlt() + " - " + ((Plant)content).getName();
						break;
					case (TreeNodeType.DEPARTMENT):
						base.Text = ((Departament)content).getDept() + " - " + ((Departament)content).getDes1();
						break;
					case (TreeNodeType.CONFIGURATION):
						base.Text = ((MacConfiguration)content).getCfg() + " - " + ((MacConfiguration)content).getDes1();
						break;
					case (TreeNodeType.MACHINE):
						base.Text = ((Machine)content).getMach() + " - " + ((Machine)content).getDes1();
						break;
					case (TreeNodeType.MACHINEINCONFIGURATION):
						base.Text = ((Machine)content).getMach() + " - " + ((Machine)content).getDes1();
						break;
					case (TreeNodeType.SHIFTHDR):
						base.Text = ((Shift)content).getShf() + " - " + ((Shift)content).getDes();
						break;
				}
			}
			else
				base.Text = "No object defined";
		}

		public new void Expand()
		{
			base.Expand();
			if (this.treeNodeType == TreeNodeType.CONFIGURATION)
			{
				foreach (TreeNode t in this.Nodes)
				{
					t.Expand();
				}
			}
		}

	}
}
