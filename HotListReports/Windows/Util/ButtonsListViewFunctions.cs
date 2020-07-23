using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nujit.NujitWms.ClassLib.Core.Items;
using Nujit.NujitWms.ClassLib.Core;
using System.Windows.Controls;
using Nujit.NujitWms.WinForms.Util;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections;

namespace HotListReports.Windows.Util {



public
class ButtonsListViewFunctions {

private ListView listView;
private Button firstButton;
private Button prevButton;
private Button nextButton;
private Button lastButton;
private ArrayList arrayListListViews;
private bool bfocusListView;
private bool buseScroolButtons;

private WindowsModes modeItem;
private Object newObj;
private Object cloneNewObj;

private ListView activeListView;

public
ButtonsListViewFunctions(ListView listView,
                         Button firstButton,
                         Button prevButton,
                         Button nextButton,
                         Button lastButton){
    buseScroolButtons = true;
    initialize(firstButton, prevButton, nextButton, lastButton);
    this.listView = listView;
    this.activeListView = listView;
    arrayListListViews.Add(listView);
    bfocusListView = true;
    setListViewEvents();
    checkListViewIndex();

    if (this.listView != null)
        this.listView.AddHandler(ListView.SelectedEvent, new RoutedEventHandler(listView_SelectedEvent));            
}

private
void initialize(Button firstButton,
                Button prevButton,
                Button nextButton,
                Button lastButton)
{

    bfocusListView = false;    
    this.firstButton = firstButton;
    this.prevButton = prevButton;
    this.nextButton = nextButton;    
    this.lastButton = lastButton;

    arrayListListViews = new ArrayList();

    if (buseScroolButtons) {
        this.firstButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(firstButton_Click));
        this.prevButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(prevButton_Click));
        this.nextButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(nextButton_Click));
        this.lastButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(lastButton_Click));

        this.firstButton.Background=
        this.prevButton.Background =
        this.nextButton.Background =
        this.lastButton.Background = new System.Windows.Media.SolidColorBrush(UIColors.BUTTON_NORMAL_BACKGROUND);        

        this.firstButton.Foreground=
        this.prevButton.Foreground =
        this.nextButton.Foreground =
        this.lastButton.Foreground = new System.Windows.Media.SolidColorBrush(UIColors.BUTTON_NORMAL_FONT);        
    }           

    modeItem = WindowsModes.Update;
    newObj = null;
    cloneNewObj = null;
}

private
void setListViewEvents(){
    foreach(ListView listView in arrayListListViews)
        listView.AddHandler(ListView.GotFocusEvent, new RoutedEventHandler(listViewGotFocusEvent));
}

public
void enableDisableButtons(bool value) {
    if (buseScroolButtons) {
        this.firstButton.IsEnabled = value;
        this.prevButton.IsEnabled = value;
        this.nextButton.IsEnabled = value;
        this.lastButton.IsEnabled = value;
    }
    
    if (value)
        checkListViewIndex();
}

public
void checkListViewIndex() {
    if (buseScroolButtons) {
        //prevButton.IsEnabled = firstButton.IsEnabled = (listView.SelectedIndex != 0 && listView.Items.Count > 1);
        //nextButton.IsEnabled = lastButton.IsEnabled = ((listView.SelectedIndex + 1) < listView.Items.Count && listView.Items.Count > 1);
    }
}

public
ListView getListView() {
    return listView;
}

public
void firstButton_Click(object sender,RoutedEventArgs e) {
    listView.Focus();        
    if (bfocusListView && (this.activeListView.Equals(listView))){
        first(listView);    
        checkListViewIndex();
    }
}

public
void prevButton_Click(object sender,RoutedEventArgs e) {
    if (bfocusListView && (this.activeListView.Equals(listView))){
        prev(listView);       
        checkListViewIndex();
    }
}

public
void nextButton_Click(object sender,RoutedEventArgs e) {
    if (bfocusListView && (this.activeListView.Equals(listView))){
        next(listView);       
        checkListViewIndex();
    }
}

public
void lastButton_Click(object sender,RoutedEventArgs e) {
    if (bfocusListView && (this.activeListView.Equals(listView))){
        last(listView);    
        checkListViewIndex();
    }
}

private
void listViewGotFocusEvent(object sender, RoutedEventArgs e){    
    ListView listViewAux = (ListView)sender;

    if (listViewAux != null && listViewAux.Equals(listView))
        bfocusListView = true;
    else
        bfocusListView = false;

    checkListViewIndex();
}

private
void listViewLostFocusEvent(object sender, RoutedEventArgs e){

}

public
void setActiveListView(ListView listView) {
    this.activeListView = listView;
}

public
void listView_SelectedEvent(object sender, RoutedEventArgs e){    
    checkListViewIndex();
}

private 
void first(ListView mainListView){
    if (mainListView.Items.Count > 0)
        moveIndex(mainListView,0);            
    mainListView.Focus();    
}

private 
void prev(ListView mainListView){
    if (mainListView.Items.Count > 0){
        int selectedIndex = mainListView.SelectedIndex;
        if (selectedIndex < 0)          selectedIndex = 0;
        else if (selectedIndex == 0)    selectedIndex = mainListView.Items.Count - 1; //last
        else if (selectedIndex > 0)     selectedIndex = selectedIndex-1;
        
        moveIndex(mainListView, selectedIndex);
    }
    mainListView.Focus();
}

private
void moveIndex(ListView mainListView,int nextSelectedIndex){
    if (nextSelectedIndex>= 0 && nextSelectedIndex < mainListView.Items.Count) {
        mainListView.SelectedIndex = nextSelectedIndex;
        mainListView.ScrollIntoView(mainListView.SelectedItem);     
    }
}

private
void next(ListView mainListView){
    if (mainListView.Items.Count > 0){
        int selectedIndex = mainListView.SelectedIndex;
        if (selectedIndex < 0)          selectedIndex = 0;
        else if (selectedIndex == mainListView.Items.Count - 1)    selectedIndex = 0; //first
        else if (selectedIndex >= 0)    selectedIndex = selectedIndex+1;
        
        moveIndex(mainListView, selectedIndex);
    }
    mainListView.Focus();
}

public 
void next(){
    next(listView);    
}

private 
void last(ListView mainListView){
    if (mainListView.Items.Count > 0)
        moveIndex(mainListView, mainListView.Items.Count - 1);            
    mainListView.Focus();
}


/******************************************* ***********************************************************************/
public
WindowsModes ModeItem {
	get { return modeItem;}
	set {
        switch (value) {
            case WindowsModes.Insert:
                enableDisableButtons(false);
                break;
            case WindowsModes.Update:
                enableDisableButtons(true);
                break;
            default:
                break;
        }
       
        if (this.modeItem != value)
			this.modeItem = value;		
	}
}

public
Object NewObj {
    get { return this.newObj; }
    set {
        if (this.newObj != value)
            this.newObj = value;
    }
}

public
Object CloneNewObj {
    get { return this.cloneNewObj; }
    set {
        if (this.cloneNewObj != value)
            this.cloneNewObj = value;
    }
}

public
void addItemProcess(Object newObj) {
    this.newObj = newObj;
    this.cloneNewObj = null;

    if (listView.Items.Count > 0) {
        listView.SelectedIndex = listView.Items.Count - 1;        
    }
            
    ModeItem = WindowsModes.Insert;
    listView.Focus();
}

public
void modifyItemProcess(Object newObj,Object cloneNewObj) {
    this.newObj = newObj;
    this.cloneNewObj = cloneNewObj;
    ModeItem = WindowsModes.Update;    
}

public
void modifyItemProcess(Object newObj) {
     modifyItemProcess(newObj,null);
}

public
void removeItemProcess() {
    if (listView.Items.Count > 0) {        
        listView.SelectedIndex = 0;     //first              
    }
    ModeItem = WindowsModes.Update;    
    this.newObj = null;
    this.cloneNewObj = null;
}

public
bool couldAdd() {
    return (ModeItem != WindowsModes.Insert);
}

public
Object couldSave() {
    Object objRet=null;
    if (ModeItem == WindowsModes.Insert && NewObj != null)
        objRet = NewObj;

    return objRet;
}

public
Object couldModify() {
    Object objRet = null;
    if (ModeItem == WindowsModes.Update && NewObj != null)
        objRet = NewObj;

    return objRet;
}
 
public
Object couldRemove() {
    Object objRet=null;

    if (ModeItem == WindowsModes.Update && listView.SelectedItems.Count >= 0)
        objRet = listView.SelectedItems[0];
    return objRet;
}

public
Object couldCancel() {
    Object objRet = null;

    if (ModeItem == WindowsModes.Insert && listView.SelectedItems.Count >= 0)
        objRet = listView.SelectedItems[0];
    return objRet;
}

}
}
