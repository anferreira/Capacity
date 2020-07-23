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
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Util {

public delegate void ContextMenuListViewEventHandler(object sender, string optionSelected);

public
class ContextMenuListViewFunctions {

private ListView listView;
private ContextMenu contextMenu;

public event ContextMenuListViewEventHandler contextMenuListViewEventHandler;

private bool showHistoryMenu = false;
private bool showColorLegendMenu = false;
private bool showSaveMenu = false;
private bool showEditMenu = false;

//MENU INDEXES
private int MENU_FIRST_INDEX = 0;
private int MENU_PRIOR_INDEX = 1;
private int MENU_NEXT_INDEX = 2;
private int MENU_LAST_INDEX = 3;
private int MENU_INSERT_INDEX = 4;
private int MENU_DELETE_INDEX = 5;
private int MENU_EDIT_INDEX = 6;
private int MENU_SAVE_INDEX = 7;
private int MENU_CANCEL_INDEX = 8;
private int MENU_REFRESH_INDEX = 9;

public
ContextMenuListViewFunctions(ListView listView){
    this.listView = listView;

    LoadMenuItems();
    initializeEnableDisableButtons();
}

public
ContextMenuListViewFunctions(ListView listView, bool showHistoryMenu, bool showColorLegendMenu, bool showSaveMenu, bool showEditMenu){
    this.listView = listView;

    this.showHistoryMenu = showHistoryMenu;
    this.showColorLegendMenu = showColorLegendMenu;
    this.showSaveMenu = showSaveMenu;
    this.showEditMenu = showEditMenu;
    LoadMenuItems();
    initializeEnableDisableButtons();
}

private
void LoadMenuItems() {

    contextMenu = new ContextMenu();
    MenuItem menuItem = new MenuItem();

    menuItem.Header = Constants.OPTION_FIRST;
    menuItem.Click += new RoutedEventHandler(firstButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_PRIOR;
    menuItem.Click += new RoutedEventHandler(prevButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_NEXT;
    menuItem.Click += new RoutedEventHandler(nextButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_LAST;
    menuItem.Click += new RoutedEventHandler(lastButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = "__________________________________________________";
    menuItem.IsEnabled = false;
    contextMenu.Items.Add(menuItem);
        
    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_INSERT;
    menuItem.Click += new RoutedEventHandler(insertButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_DELETE;
    menuItem.Click += new RoutedEventHandler(deleteButton_Click);
    contextMenu.Items.Add(menuItem);


    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_EDIT;
    menuItem.Click += new RoutedEventHandler(editButton_Click);
    menuItem.IsEnabled = this.showEditMenu;
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_SAVE;
    menuItem.Click += new RoutedEventHandler(saveButton_Click);
    menuItem.IsEnabled = this.showSaveMenu;
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_CANCEL;
    menuItem.Click += new RoutedEventHandler(cancelButton_Click);
    contextMenu.Items.Add(menuItem);

    menuItem = new MenuItem();
    menuItem.Header = Constants.OPTION_REFRESH;
    menuItem.Click += new RoutedEventHandler(refreshButton_Click);
    contextMenu.Items.Add(menuItem);

    if (this.showHistoryMenu){
        menuItem = new MenuItem();
        menuItem.Header = "__________________________________________________";
        menuItem.IsEnabled = false;
        contextMenu.Items.Add(menuItem);

        menuItem = new MenuItem();
        menuItem.Header = Constants.OPTION_HISTORY;
        menuItem.Click += new RoutedEventHandler(historyButton_Click);
        contextMenu.Items.Add(menuItem);
    }

    if (this.showColorLegendMenu){
        menuItem = new MenuItem();
        menuItem.Header = "__________________________________________________";
        menuItem.IsEnabled = false;
        contextMenu.Items.Add(menuItem);

        menuItem = new MenuItem();
        menuItem.Header = Constants.OPTION_COLORLEGEND;
        menuItem.Click += new RoutedEventHandler(colorLegendButton_Click);
        contextMenu.Items.Add(menuItem);
    }

    listView.ContextMenu = contextMenu;
}

public
void addMenuItem(string text){
    ContextMenu contextMenu = listView.ContextMenu;
    MenuItem    menuItem = new MenuItem();

    menuItem.Header = text;
    menuItem.Tag = text;
    menuItem.Click += new RoutedEventHandler(newAddedMenuItemsButton_Click);

    if (contextMenu!= null)
        contextMenu.Items.Add(menuItem);
}

private
void firstButton_Click(object sender, RoutedEventArgs e) {    
    selectFirstItem(sender, e, listView);
    OnContextMenuEvent(sender, Constants.OPTION_FIRST);
}

private
void prevButton_Click(object sender, RoutedEventArgs e) {
    selectPreviousItem(sender, e, listView);
    OnContextMenuEvent(sender, Constants.OPTION_PRIOR);
}

private
void nextButton_Click(object sender, RoutedEventArgs e) {
    selectNextItem(sender, e, listView);
    OnContextMenuEvent(sender, Constants.OPTION_NEXT);
}

private
void lastButton_Click(object sender, RoutedEventArgs e) {
    selectLastItem(sender, e, listView);
    OnContextMenuEvent(sender, Constants.OPTION_LAST);
}

private
void insertButton_Click(object sender, RoutedEventArgs e) {
    if (this.showSaveMenu){
        ((MenuItem)contextMenu.Items[MENU_INSERT_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_EDIT_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_DELETE_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_SAVE_INDEX]).IsEnabled = true;
        ((MenuItem)contextMenu.Items[MENU_CANCEL_INDEX]).IsEnabled = true;
        ((MenuItem)contextMenu.Items[MENU_REFRESH_INDEX]).IsEnabled = false;

        ((MenuItem)contextMenu.Items[MENU_FIRST_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_PRIOR_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_NEXT_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_LAST_INDEX]).IsEnabled = false;
    }
    OnContextMenuEvent(sender, Constants.OPTION_INSERT);
}

private
void deleteButton_Click(object sender, RoutedEventArgs e) {
    OnContextMenuEvent(sender, Constants.OPTION_DELETE);
}

private
void editButton_Click(object sender, RoutedEventArgs e) {
    ((MenuItem)contextMenu.Items[MENU_INSERT_INDEX]).IsEnabled = false;
    ((MenuItem)contextMenu.Items[MENU_EDIT_INDEX]).IsEnabled = false;
    ((MenuItem)contextMenu.Items[MENU_DELETE_INDEX]).IsEnabled = false;
    ((MenuItem)contextMenu.Items[MENU_SAVE_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_CANCEL_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_REFRESH_INDEX]).IsEnabled = false;

    ((MenuItem)contextMenu.Items[MENU_FIRST_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_PRIOR_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_NEXT_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_LAST_INDEX]).IsEnabled = true;
    OnContextMenuEvent(sender, Constants.OPTION_EDIT);
}

private
void saveButton_Click(object sender, RoutedEventArgs e) {   
    OnContextMenuEvent(sender, Constants.OPTION_SAVE);
}

private
void cancelButton_Click(object sender, RoutedEventArgs e) {
    OnContextMenuEvent(sender, Constants.OPTION_CANCEL);
    initializeEnableDisableButtons();
}

private
void refreshButton_Click(object sender, RoutedEventArgs e) {
    OnContextMenuEvent(sender, Constants.OPTION_REFRESH);
}

private
void historyButton_Click(object sender, RoutedEventArgs e) {
    OnContextMenuEvent(sender, Constants.OPTION_HISTORY);
}

private
void colorLegendButton_Click(object sender, RoutedEventArgs e) {
    OnContextMenuEvent(sender, Constants.OPTION_COLORLEGEND);
}

private
void newAddedMenuItemsButton_Click(object sender, RoutedEventArgs e) {
    string   optionSelected = "";
    MenuItem menuItem = null;

    if (sender is MenuItem) {
        menuItem = (MenuItem)sender;
        if (menuItem.Tag is string)
            optionSelected = (string)menuItem.Tag;
    }
    OnContextMenuEvent(sender, optionSelected);
}

public
void OnContextMenuEvent(object sender, string optionSelected) {
    if (contextMenuListViewEventHandler != null)
        contextMenuListViewEventHandler(sender, optionSelected);
}

public
void setShowHistoryMenu(bool showHistoryMenu) {
    this.showHistoryMenu = showHistoryMenu;
}

public
void setShowColorLegendMenu(bool showColorLegendMenu) {
    this.showColorLegendMenu = showColorLegendMenu;
}

public
void initializeEnableDisableButtons(){
    ((MenuItem)contextMenu.Items[MENU_INSERT_INDEX]).IsEnabled = true;
            /*
    if (!(this.listView.Items.Count > 0)){
        ((MenuItem)contextMenu.Items[MENU_EDIT_INDEX]).IsEnabled = false;
        ((MenuItem)contextMenu.Items[MENU_DELETE_INDEX]).IsEnabled = false;
    }else{*/
        ((MenuItem)contextMenu.Items[MENU_EDIT_INDEX]).IsEnabled = true;
        ((MenuItem)contextMenu.Items[MENU_DELETE_INDEX]).IsEnabled = true;
    //}
    ((MenuItem)contextMenu.Items[MENU_SAVE_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_CANCEL_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_REFRESH_INDEX]).IsEnabled = true;

    ((MenuItem)contextMenu.Items[MENU_FIRST_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_PRIOR_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_NEXT_INDEX]).IsEnabled = true;
    ((MenuItem)contextMenu.Items[MENU_LAST_INDEX]).IsEnabled = true;
}


/*****************        ********************************/

/*
private 
void first(ListView mainListView){
    if (mainListView.Items.Count > 0){
        mainListView.SelectedIndex = 0;
        mainListView.ScrollIntoView(mainListView.SelectedItem);        
    }
    mainListView.Focus();    
}

private 
void prev(ListView mainListView){
    if (mainListView.Items.Count > 0){
        int selectedIndex = 0;
        if (mainListView.SelectedIndex > 0)
            selectedIndex = mainListView.SelectedIndex;
        int nextSelectedIndex = mainListView.Items.Count - 1;
        if (selectedIndex > 0){
            nextSelectedIndex = selectedIndex - 1;
        }
        mainListView.SelectedIndex = nextSelectedIndex;
        mainListView.ScrollIntoView(mainListView.SelectedItem);     
    }
    mainListView.Focus();
}

private 
void next(ListView mainListView){
    if (mainListView.Items.Count > 0){
        int selectedIndex = 0;
        if (mainListView.SelectedIndex > 0)
            selectedIndex = mainListView.SelectedIndex;
        int nextSelectedIndex = 0;
        if (selectedIndex < mainListView.Items.Count - 1){
            nextSelectedIndex = selectedIndex + 1;
        }
        mainListView.SelectedIndex = nextSelectedIndex;
        mainListView.ScrollIntoView(mainListView.SelectedItem);     
    }
    mainListView.Focus();
}

private 
void last(ListView mainListView){
    if (mainListView.Items.Count > 0){
        mainListView.SelectedIndex = mainListView.Items.Count - 1;        
        mainListView.ScrollIntoView(mainListView.SelectedItem);        
    }
    mainListView.Focus();
}*/

public
bool selectFirstItem(object sender, RoutedEventArgs e, System.Windows.Controls.ListView listView){
    bool bresult = false;
    if (listView.Items.Count > 0){
        listView.SelectedIndex = 0;
        listView.ScrollIntoView(listView.SelectedItem);

        bresult = true;
    }
    listView.Focus();
    return bresult;
}

public
bool selectPreviousItem(object sender, RoutedEventArgs e, System.Windows.Controls.ListView listView) {
    bool bresult = false;

    if (listView.Items.Count > 0){
        int selectedIndex = 0;
        if (listView.SelectedIndex > 0)
            selectedIndex = listView.SelectedIndex;
        int nextSelectedIndex = listView.Items.Count - 1;
        if (selectedIndex > 0){
            nextSelectedIndex = selectedIndex - 1;
        }
        listView.SelectedIndex = nextSelectedIndex;
        listView.ScrollIntoView(listView.SelectedItem);

        bresult = true;
    }
    listView.Focus();
    return bresult;
}

public
bool selectNextItem(object sender, RoutedEventArgs e, System.Windows.Controls.ListView listView) {
    bool bresult = false;

    if (listView.Items.Count > 0){
        int selectedIndex = 0;
        if (listView.SelectedIndex > 0)
            selectedIndex = listView.SelectedIndex;
        int nextSelectedIndex = 0;
        if (selectedIndex < listView.Items.Count - 1){
            nextSelectedIndex = selectedIndex + 1;
        }
        listView.SelectedIndex = nextSelectedIndex;
        listView.ScrollIntoView(listView.SelectedItem);

        bresult = true;
    }
    listView.Focus();
    return bresult;
}

public
bool selectLastItem(object sender, RoutedEventArgs e, System.Windows.Controls.ListView listView){
    bool bresult = false;
    if (listView.Items.Count > 0){
        listView.SelectedIndex = listView.Items.Count - 1;
        listView.ScrollIntoView(listView.SelectedItem);

        bresult = true;
    }
    listView.Focus();
    return bresult;
}
    
}
}
