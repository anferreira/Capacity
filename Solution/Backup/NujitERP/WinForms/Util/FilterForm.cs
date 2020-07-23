using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Util{

	
public 
class FilterForm : System.Windows.Forms.Form{

private System.Windows.Forms.CheckedListBox listBox;
private System.Windows.Forms.Button allButton;
private System.Windows.Forms.Button deSelectButton;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.Button cancelButton;
private System.ComponentModel.Container components = null;
private System.Windows.Forms.TextBox seekTextBox;
private System.Windows.Forms.Button goButton;
private System.Windows.Forms.Button prevButton;
private System.Windows.Forms.Button nextButton;
private System.Windows.Forms.Button reverseButton;
private string[][] items;

public 
FilterForm(string[][] items){
	InitializeComponent();

	this.items = items;
	//listBox.Sorted = true;
	order();

	
	setItems(items);
	
	listBox.CheckOnClick = true;
}

protected override 
void Dispose(bool disposing){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code

private 
void InitializeComponent(){
	this.listBox = new System.Windows.Forms.CheckedListBox();
	this.allButton = new System.Windows.Forms.Button();
	this.deSelectButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.cancelButton = new System.Windows.Forms.Button();
	this.seekTextBox = new System.Windows.Forms.TextBox();
	this.goButton = new System.Windows.Forms.Button();
	this.prevButton = new System.Windows.Forms.Button();
	this.nextButton = new System.Windows.Forms.Button();
	this.reverseButton = new System.Windows.Forms.Button();
	this.SuspendLayout();
	// 
	// listBox
	// 
	this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.listBox.IntegralHeight = false;
	this.listBox.Location = new System.Drawing.Point(16, 16);
	this.listBox.Name = "listBox";
	this.listBox.Size = new System.Drawing.Size(195, 244);
	this.listBox.TabIndex = 0;
	// 
	// allButton
	// 
	this.allButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.allButton.Location = new System.Drawing.Point(237, 168);
	this.allButton.Name = "allButton";
	this.allButton.Size = new System.Drawing.Size(76, 23);
	this.allButton.TabIndex = 1;
	this.allButton.Text = "Select All";
	this.allButton.Click += new System.EventHandler(this.allButton_Click);
	// 
	// deSelectButton
	// 
	this.deSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.deSelectButton.Location = new System.Drawing.Point(237, 200);
	this.deSelectButton.Name = "deSelectButton";
	this.deSelectButton.Size = new System.Drawing.Size(76, 23);
	this.deSelectButton.TabIndex = 2;
	this.deSelectButton.Text = "Deselect All";
	this.deSelectButton.Click += new System.EventHandler(this.deselectAllButton_Click);
	// 
	// okButton
	// 
	this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.okButton.Location = new System.Drawing.Point(237, 24);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(76, 23);
	this.okButton.TabIndex = 4;
	this.okButton.Text = "Ok";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// cancelButton
	// 
	this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.cancelButton.Location = new System.Drawing.Point(237, 56);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.Size = new System.Drawing.Size(76, 23);
	this.cancelButton.TabIndex = 5;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// seekTextBox
	// 
	this.seekTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.seekTextBox.Location = new System.Drawing.Point(224, 104);
	this.seekTextBox.Name = "seekTextBox";
	this.seekTextBox.Size = new System.Drawing.Size(102, 20);
	this.seekTextBox.TabIndex = 6;
	this.seekTextBox.Text = "";
	this.seekTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seekTextBox_KeyDown);
	// 
	// goButton
	// 
	this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.goButton.Location = new System.Drawing.Point(256, 128);
	this.goButton.Name = "goButton";
	this.goButton.Size = new System.Drawing.Size(35, 18);
	this.goButton.TabIndex = 7;
	this.goButton.Text = "GO";
	this.goButton.Click += new System.EventHandler(this.goButton_Click);
	// 
	// prevButton
	// 
	this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.prevButton.Location = new System.Drawing.Point(224, 128);
	this.prevButton.Name = "prevButton";
	this.prevButton.Size = new System.Drawing.Size(35, 18);
	this.prevButton.TabIndex = 8;
	this.prevButton.Text = "Prev";
	this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
	// 
	// nextButton
	// 
	this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.nextButton.Location = new System.Drawing.Point(291, 128);
	this.nextButton.Name = "nextButton";
	this.nextButton.Size = new System.Drawing.Size(35, 18);
	this.nextButton.TabIndex = 9;
	this.nextButton.Text = "Next";
	this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
	// 
	// reverseButton
	// 
	this.reverseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.reverseButton.Location = new System.Drawing.Point(237, 232);
	this.reverseButton.Name = "reverseButton";
	this.reverseButton.Size = new System.Drawing.Size(76, 23);
	this.reverseButton.TabIndex = 10;
	this.reverseButton.Text = "Reverse";
	this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
	// 
	// FilterForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(336, 278);
	this.Controls.Add(this.reverseButton);
	this.Controls.Add(this.nextButton);
	this.Controls.Add(this.prevButton);
	this.Controls.Add(this.goButton);
	this.Controls.Add(this.seekTextBox);
	this.Controls.Add(this.cancelButton);
	this.Controls.Add(this.okButton);
	this.Controls.Add(this.deSelectButton);
	this.Controls.Add(this.allButton);
	this.Controls.Add(this.listBox);
	this.MinimumSize = new System.Drawing.Size(256, 305);
	this.Name = "FilterForm";
	this.Text = "Select an Item";
	this.ResumeLayout(false);

}
#endregion

private 
void allButton_Click(object sender, System.EventArgs e){
	for(int i = 0; i < listBox.Items.Count; i++)
		listBox.SetItemChecked(i, true);
}

private 
void deselectAllButton_Click(object sender, System.EventArgs e){
	for(int i = 0; i < listBox.Items.Count; i++)
		listBox.SetItemChecked(i, false);
}

private 
void reverseButton_Click(object sender, System.EventArgs e){
	for(int i = 0; i < listBox.Items.Count; i++){
		if (listBox.GetItemChecked(i))
			listBox.SetItemChecked(i, false);
		else
			listBox.SetItemChecked(i, true);
	}
}

private 
void okButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.OK;
	this.Close();
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	this.Close();
}

public
string[][] getItems(){
	for(int i = 0; i < items.Length; i++){
		if (listBox.GetItemChecked(i))
			items[i][1] = "true";
		else
			items[i][1] = "false";
	}
	return items;
}

private
void setItems(string[][] parItems){
	this.items = parItems;
	
	for(int i = 0; i < items.Length; i++){
		bool checkedItem = bool.Parse(items[i][1]);
		listBox.Items.Add(items[i][0], checkedItem);
	}
}

private 
void goButton_Click(object sender, System.EventArgs e){
	goText();
}

private 
void goText(){
	if ((seekTextBox.Text == null) || (seekTextBox.Text.Equals("")))
		listBox.SelectedIndex = 0;
	else
		listBox.SelectedIndex = listBox.FindString(this.seekTextBox.Text);

	if (listBox.SelectedIndex == -1)
		listBox.SelectedIndex = 0;
}

private 
void seekTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if (e.KeyData.ToString().Equals("Enter"))
		goText();
}

private 
void prevButton_Click(object sender, System.EventArgs e){
	int current = listBox.SelectedIndex;
	if (current > 0)
		current--;
	else
		current = 0;
	listBox.SelectedIndex = current;
}

private 
void nextButton_Click(object sender, System.EventArgs e){
	int current = listBox.SelectedIndex;
	if (current != items.Length - 1)
		current++;
	listBox.SelectedIndex = current;
}

private
void order(){
	for(int i = 0; i < items.Length; i++){
		for(int x = i + 1; x < items.Length; x++){
			if (items[x][0].CompareTo(items[i][0]) < 0){
				string swap1 = items[i][0];
				string swap2 = items[i][1];
				
				items[i][0] = items[x][0];
				items[i][1] = items[x][1];

				items[x][0] = swap1;
				items[x][1] = swap2;
			}
		}
	}
}


} // class

} // namespace
