using System;
using System.Drawing;
using System.Collections;

using System.Threading;

using GridScheduling.gui.Model;
using Nujit.NujitERP.WinForms;



namespace GridScheduling.gui.schedule{

/// <summary>
/// Summary description for AddForm.
/// </summary>
public
class BusyForm : System.Windows.Forms.Form, UpdatableForm {

private ScheduleModel model = null;
private int action = -1;
private object[] parameters;
private string currentStatus = "";

	private System.Windows.Forms.Panel backPanel;
	private System.Windows.Forms.Panel progressPanel;

/// <summary>
/// Required designer variable.
/// </summary>

public const int LOAD_DEMANDS = 1;
public const int LOAD_CAPACITY_MACHINES = 2;
public const int LOAD_TASKS_FROM_DEMAND = 3;

public
BusyForm(ScheduleModel model, int action){
	InitializeComponent();
	
	this.model = model;
	this.action = action;

}

#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
	this.backPanel = new System.Windows.Forms.Panel();
	this.progressPanel = new System.Windows.Forms.Panel();
	this.backPanel.SuspendLayout();
	this.SuspendLayout();
	// 
	// backPanel
	// 
	this.backPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.backPanel.Controls.Add(this.progressPanel);
	this.backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
	this.backPanel.Location = new System.Drawing.Point(0, 0);
	this.backPanel.Name = "backPanel";
	this.backPanel.Size = new System.Drawing.Size(400, 24);
	this.backPanel.TabIndex = 0;
	this.backPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backPanel_Paint);
	// 
	// progressPanel
	// 
	this.progressPanel.BackColor = System.Drawing.Color.Navy;
	this.progressPanel.ForeColor = System.Drawing.Color.Navy;
	this.progressPanel.Location = new System.Drawing.Point(0, 0);
	this.progressPanel.Name = "progressPanel";
	this.progressPanel.Size = new System.Drawing.Size(0, 24);
	this.progressPanel.TabIndex = 0;
	this.progressPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.progressPanel_Paint);
	// 
	// BusyForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(400, 24);
	this.Controls.Add(this.backPanel);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	this.Name = "BusyForm";
	this.ShowInTaskbar = false;
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
	this.Load += new System.EventHandler(this.BusyForm_Load);
	this.backPanel.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

public void updateStatus (string currentStatus, int progress)
{
	if (!this.currentStatus.Equals(currentStatus))
	{
		this.currentStatus = currentStatus;
		this.progressPanel.Width = (progress * this.Width) / 100;
		this.backPanel.Invalidate ();
	}
	else
		this.progressPanel.Width = (progress * this.Width) / 100;
}

public void processComplete()
{
	this.Close();
}

public void setParameters (object[] parameters)
{
	this.parameters = parameters;
}

private void start()
{
	try 
	{
		switch (action)
		{
			case BusyForm.LOAD_DEMANDS:
				model.loadDemands();
				break;
			case BusyForm.LOAD_CAPACITY_MACHINES:
				model.loadCapacityAndMachines((string)parameters[0], (string)parameters[1]);
				break;
			case BusyForm.LOAD_TASKS_FROM_DEMAND:
				model.setTimeScope(DateTime.Today, DateTime.Today.AddDays(7));
				model.insertTasksFromDemand();
				break;
		}
	}
	catch (Exception ex)
	{
		FormException frmEx = new FormException(ex);
		frmEx.ShowDialog();
		this.Close();
	}
}

private void BusyForm_Load(object sender, System.EventArgs e)
{
	model.setUpdatableForm(this);
	Thread thread = new Thread(new ThreadStart(this.start));
	thread.Start();
}

private void backPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
{
	Font font = new Font ("MS Sans Serif", 8, FontStyle.Regular);
	e.Graphics.DrawString (currentStatus, font, Brushes.Black, new RectangleF(10,4,this.Width-10, this.Height-8));
}

private void progressPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
{
	Font font = new Font ("MS Sans Serif", 8, FontStyle.Regular);
	e.Graphics.DrawString (currentStatus, font, Brushes.White, new RectangleF(10,4,this.Width-10, this.Height-8));
}


} // class

} // namespace
