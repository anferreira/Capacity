using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Util{

public partial 
class NujitCustomMessageBox : Form{

private static NujitCustomMessageBox nujitMessageBox;
private static DialogResult result = DialogResult.Cancel;
private static int disposeFormTimer;

public NujitCustomMessageBox(){
    InitializeComponent();
}

public static
DialogResult ShowBox(string txtMessage){
    nujitMessageBox = new NujitCustomMessageBox();
    nujitMessageBox.lblMessage.Text = txtMessage;
    nujitMessageBox.ShowDialog();
    return result;
}

public static 
DialogResult ShowBox(string txtMessage, string txtTitle){
    nujitMessageBox = new NujitCustomMessageBox();
    nujitMessageBox.lblMessage.Text = txtMessage;
    nujitMessageBox.Text = txtTitle;
    nujitMessageBox.ShowDialog();
    return result;
}

private 
void btnOk_Click(object sender, EventArgs e){
    result = DialogResult.OK;
    nujitMessageBox.Dispose();
}

private 
void btnCancel_Click(object sender, EventArgs e){
    result = DialogResult.Cancel;
    nujitMessageBox.Dispose();
}

private 
void NujitMessageBox_Load(object sender, EventArgs e){
    Timer  msgTimer = new Timer();
    disposeFormTimer = 30;
    msgTimer.Interval = 1000;
    msgTimer.Enabled = true;
    msgTimer.Start();
    msgTimer.Tick += new EventHandler(this.timer_tick); 
}

private
void timer_tick(object sender, EventArgs e){
    disposeFormTimer--;

    if (disposeFormTimer >= 0){
        nujitMessageBox.lblTimer.Text = disposeFormTimer.ToString();
    }else{
        nujitMessageBox.Dispose();
    }
}

}
}
