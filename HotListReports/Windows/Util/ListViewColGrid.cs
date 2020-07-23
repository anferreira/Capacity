using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Collections;

namespace HotListReports.Windows.Util{

class ListViewCol{

private DataTemplate dataTemplate;
private FrameworkElementFactory stackPanel;
private FrameworkElementFactory dockPanel;
private ArrayList arrayControls;

public
ListViewCol(){
    arrayControls = new ArrayList();    
    dataTemplate = null;        
    stackPanel = null;
}

public
DataTemplate getDataTemplate(){
    return dataTemplate;
}

public
DataTemplate getDataTemplate(string sbindPanel,double dcornerRadius,double dborderThickness,Color colorBorder){
    DataTemplate dataTemplate = new DataTemplate();
   
    #region  Control template Code(to show content)

    ControlTemplate template = new ControlTemplate(typeof(GroupItem));

    //Create border object
    FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));

    border.SetValue(Border.CornerRadiusProperty, new CornerRadius(dcornerRadius));
    border.SetValue(Border.BorderThicknessProperty, new Thickness(dborderThickness));
    border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(colorBorder));
    border.SetValue(Border.PaddingProperty, new Thickness(1));

    //create dockpanel to put inside border.
    FrameworkElementFactory dockPanel = new FrameworkElementFactory(typeof(DockPanel));
    dockPanel.SetValue(DockPanel.LastChildFillProperty, true);

    /*
    //stack panel to show group header
    FrameworkElementFactory stackPanel = new FrameworkElementFactory(typeof(StackPanel));
    stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
    stackPanel.SetValue(DockPanel.DockProperty, Dock.Top);
    //stackPanel.SetValue(DockPanel.HeightProperty,(double)40);
    */
    FrameworkElementFactory stackPanel = new FrameworkElementFactory(typeof(Grid));

    FrameworkElementFactory rowDefinition1 = new FrameworkElementFactory(typeof(RowDefinition));
    FrameworkElementFactory rowDefinition2 = new FrameworkElementFactory(typeof(RowDefinition));
    FrameworkElementFactory rowDefinition3 = new FrameworkElementFactory(typeof(RowDefinition));

    rowDefinition1.SetValue(RowDefinition.HeightProperty, new GridLength(0, GridUnitType.Star));
    rowDefinition2.SetValue(RowDefinition.HeightProperty, new GridLength(0, GridUnitType.Star));
    rowDefinition3.SetValue(RowDefinition.HeightProperty, new GridLength(0, GridUnitType.Star));
    
    //FrameworkElementFactory rowDefinitions = new FrameworkElementFactory(typeof(RowDefinitionCollection));
    stackPanel.AppendChild(rowDefinition1);
    stackPanel.AppendChild(rowDefinition2);
    stackPanel.AppendChild(rowDefinition3);
                
    if (!string.IsNullOrEmpty(sbindPanel))
        stackPanel.SetValue(StackPanel.DataContextProperty, new Binding() { Path = new PropertyPath(sbindPanel) });            

    int i=0;
    foreach(FrameworkElementFactory frameControl in arrayControls) {        
        stackPanel.AppendChild(frameControl);
        frameControl.SetValue(Grid.RowProperty, i);
        i++;
    }
    
    dataTemplate.VisualTree = border;
    //define items presenter
    FrameworkElementFactory itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
    itemsPresenter.SetValue(ItemsPresenter.MarginProperty, new Thickness(1));

    border.AppendChild(dockPanel);

    dockPanel.AppendChild(stackPanel);
    dockPanel.AppendChild(itemsPresenter);

    dataTemplate.VisualTree = border;

    #endregion

    return dataTemplate;
}

public
FrameworkElementFactory addTextBlock(string sbindName,double dwith,double dheight,double dfontSize,TextAlignment textAlignment,Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBlock   = new FrameworkElementFactory(typeof(TextBlock));
    
    //textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
    textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);    
    textBlock.SetValue(TextBlock.TextProperty, new Binding() { Path = new PropertyPath(sbindName) });       

    textBlock.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(colorForeGround));                        
    textBlock.SetValue(TextBlock.FontSizeProperty, dfontSize);
    textBlock.SetValue(TextBlock.WidthProperty, dwith);
    textBlock.SetValue(TextBlock.HeightProperty, dheight);
    textBlock.SetValue(TextBlock.BackgroundProperty, new SolidColorBrush(colorBackground));
    textBlock.SetValue(TextBlock.TextAlignmentProperty,textAlignment); 
    
    if (stackPanel!= null)
        stackPanel.AppendChild(textBlock);

    arrayControls.Add(textBlock);
    
    return textBlock;
}

public
FrameworkElementFactory addTextBox(string sbindName,bool bisEnabled,bool bisReadOnly,double dwith,double dheight,double dfontSize,TextAlignment textAlignment, Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBoxThatDoesntResizeWithText));    
            
    textBox.SetValue(TextBox.TextProperty, new Binding() { Path = new PropertyPath(sbindName) });                
    textBox.SetValue(TextBox.ForegroundProperty, new SolidColorBrush(Colors.Black));
    textBox.SetValue(TextBox.FontSizeProperty, dfontSize);
    textBox.SetValue(TextBox.WidthProperty, dwith);
    textBox.SetValue(TextBox.HeightProperty, dheight);
    textBox.SetValue(TextBox.IsEnabledProperty, bisEnabled);
    textBox.SetValue(TextBox.IsReadOnlyProperty, bisReadOnly);
    textBox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap); 

    textBox.SetValue(TextBox.TextAlignmentProperty,textAlignment); 
    
    if (stackPanel != null)
        stackPanel.AppendChild(textBox);
    arrayControls.Add(textBox);    

    return textBox;
}

/*
public
void setConverter(IValueConverter converter, object converterParameter){
    int indexControl = arrayBindings.Count-1;
    setConverter(indexControl, converter, converterParameter);    
}

public
void setConverter(int indexControl,IValueConverter converter, object converterParameter){
    Binding binding= null;

    if (indexControl >=0 && indexControl < this.arrayBindings.Count)
        binding = (Binding)arrayBindings[indexControl];

        if (binding != null){
            binding.Converter = converter;
            if (converterParameter != null)
                binding.ConverterParameter = converterParameter;
        }
    }
}

        */
public class TextBoxThatDoesntResizeWithText : TextBox{

protected override Size MeasureOverride(Size constraint){
    return new Size(100,30);
}
}


}
}
