using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;

namespace HotListReports.Windows{
    /// <summary>
    /// Interaction logic for AddMainMaterialWindow.xaml
    /// </summary>
public partial 
class AddMainMaterialWindow : Window{

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private MainMat mainMat;
private MainMat mainMatChild;
private bool bmodeAdd = true;
private bool baddChild=false;

public AddMainMaterialWindow(MainMat mainMat,bool baddChild){
    InitializeComponent();

    this.bmodeAdd = true;
    this.mainMat = mainMat;
    this.mainMatChild = coreFactory.createMainMat();
    this.baddChild = baddChild;

    this.Loaded += AddMainMaterialWindow_Load;
}

public AddMainMaterialWindow(MainMat mainMat,MainMat mainMatChild){
    InitializeComponent();

    baddChild = bmodeAdd = false;

    this.mainMat = mainMat;
    this.mainMatChild = mainMatChild;

    this.Title = "Edit Main Material";
    this.Loaded += AddMainMaterialWindow_Load;
}

private
void AddMainMaterialWindow_Load(object sender,RoutedEventArgs e) {
    objectToScreen();
}
private
void objectToScreen(){
    if (bmodeAdd)
        mainMat.MainMatContainer.Add(mainMatChild);
    mainMat.fillRedundances();
    this.DataContext = mainMatChild;

    if (bmodeAdd){
        if (baddChild){
            this.partTextBox.IsEnabled = false;
            this.partTextBox.IsReadOnly = true;
            this.mainMatTextBox.Focus();
        }else
            this.partTextBox.Focus();
    }else{ //edit
        this.partTextBox.IsEnabled = false;
        this.partTextBox.IsReadOnly = true;
        this.mainMatTextBox.Focus();
    }
}

private
void screenToObject(){
    if (bmodeAdd){
        if (!baddChild){        
            mainMat.PART = mainMatChild.PART;
            this.mainMatTextBox.Focus();
        }
        mainMat.fillRedundances();    
    }
}

private
bool dataOk(out MainMat mainMatAux){    
    mainMatAux = null;
    try{
        if (string.IsNullOrEmpty(mainMatChild.PART)){
            MessageBox.Show("Part Is Empty, Please Reenter.");
            this.partTextBox.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(mainMatChild.MAINPART)){
            MessageBox.Show("Material Part Is Empty, Please Reenter.");        
            this.mainMatTextBox.Focus();
            return false;
        }

        mainMatAux = coreFactory.readMainMat(mainMat.PART);
        if (mainMatAux!=null){             
            MainMat mainMatChildAux = mainMatAux.MainMatContainer.getByMainMaterial(mainMatChild.MAINPART);
            if (mainMatChildAux!=null){
                MessageBox.Show("Main Material Already Added, Please Reenter.");
                this.mainMatTextBox.Focus();
                return false;
            }        
        }

        return true;
    }catch (Exception ex){
        MessageBox.Show("MainMaterial Data OK Exception: " + ex.Message);
    }
    return false;
}

private
void save(){
    MainMat mainMatAux = null;

    try{
        screenToObject();
        if (dataOk(out mainMatAux)){
            if (mainMatAux!=null){
                coreFactory.updateMainMat(mainMat);        
                MessageBox.Show("Main Material Properly Updated.");

            }else{
                coreFactory.writeMainMat(mainMat);
                MessageBox.Show("Main Material Properly Stored.");
            }
            this.DialogResult = true;
            Close();
        }

    }catch (Exception ex){
        MessageBox.Show("MainMaterial Save Exception: " + ex.Message);
    }
}

private 
void partTextBox_LostFocus(object sender, RoutedEventArgs e){
    partLostFocus();
}

private 
void partLostFocus(){
    try{
        if (!string.IsNullOrEmpty(partTextBox.Text)){
            MainMat mainMatAux = coreFactory.readMainMat(partTextBox.Text); //check if already exists part configurated
            if (mainMatAux!=null){
                baddChild=true;
                this.mainMat = mainMatAux;
                objectToScreen();
            }
        }

    }catch (Exception ex){
        MessageBox.Show("MainMaterial Lost Focus Exception: " + ex.Message);
    }
}

private 
void okButton_Click(object sender, RoutedEventArgs e){
    save();
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private 
void cancel(){
    this.DialogResult = false;
    Close();
}

}
}
