using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Nujit.NujitERP.WinForms.Util{
public partial class NujitMessageTimerForm : Form{

private string smessage;
private int itimer;

private System.Timers.Timer otimer;

public NujitMessageTimerForm(string smessage,int itimer){
    InitializeComponent();

    this.smessage = smessage;
    this.itimer = itimer;
}

private 
void NujitMessageTimerForm_Load(object sender, EventArgs e){
    init();
}

private 
void init(){
    this.messLabel.Text=smessage;
    setTimer();
}

private 
void setTimer(){  
    otimer = new System.Timers.Timer(itimer);
    otimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);    
    otimer.Enabled=true;    
}

private void OnTimedEvent(object source, ElapsedEventArgs e){    
    ok();
}

private void okButton_Click(object sender, EventArgs e){
    ok();
}

private void ok(){
    if (otimer != null){
        otimer.Stop();
        otimer.Dispose();
        otimer = null;
    }
    Close();
}


}
}
