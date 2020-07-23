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

class ListViewColManual{

private ArrayList   arrayControls, arrayBindings;

public
ListViewColManual(){
    arrayControls = new ArrayList();    
    arrayBindings = new ArrayList();    
}

public
TextBox createTextBox(string sbindName,bool bisEnabled,bool bisReadOnly,double dwith,double dheight,double dfontSize,FontWeight fontWeight, TextAlignment textAlignment,VerticalAlignment verticalAlignment, Color colorForeGround, Color colorBackground, string sfontFamily=""){
    TextBox     textBox = new TextBox();    
    Binding     binding = !string.IsNullOrEmpty(sbindName) ? new Binding() { Path = new PropertyPath(sbindName) } : null;            
                         
    if (dheight != 0)
        textBox.Height= dheight;
    textBox.Width = dwith;

    if (!bisEnabled)
        textBox.IsEnabled= bisEnabled;
    textBox.IsReadOnly= bisReadOnly;
    
    textBox.VerticalAlignment   = verticalAlignment;
    textBox.TextAlignment       = textAlignment;
    if (dfontSize > 0)
        textBox.FontSize = dfontSize;    
    textBox.FontWeight = fontWeight;
    textBox.TextWrapping = TextWrapping.WrapWithOverflow;
    textBox.Padding = new Thickness(0); //so text fill full textbox

    textBox.Foreground = new SolidColorBrush(colorForeGround);
    textBox.Background = new SolidColorBrush(colorBackground);
    if (!string.IsNullOrEmpty(sfontFamily))
        textBox.FontFamily = new FontFamily(sfontFamily);
    
    arrayControls.Add(textBox);    
    if (binding!= null) { 
        textBox.SetBinding(TextBox.TextProperty, binding);
        arrayBindings.Add(binding);
    }

    return textBox;
}

public
TextBox createTextBox(string sbindName,bool bisEnabled,bool bisReadOnly,double dwith,double dheight,double dfontSize,FontWeight fontWeight, TextAlignment textAlignment,VerticalAlignment verticalAlignment, Color colorForeGround, Color colorBackground,IValueConverter converter, Object converterParameter, string sfontFamily=""){
    TextBox     textBox = createTextBox("",bisEnabled,bisReadOnly,dwith,dheight,dfontSize,fontWeight, textAlignment,verticalAlignment, colorForeGround, colorBackground,sfontFamily);

    if (!string.IsNullOrEmpty(sbindName)){            
        Binding     binding = !string.IsNullOrEmpty(sbindName) ? new Binding() { Path = new PropertyPath(sbindName) } : null;            
   
        if (converter!= null)
            binding.Converter = converter;
        if (converterParameter!= null)
            binding.ConverterParameter = converterParameter;

        if (binding!= null)        
            textBox.SetBinding(TextBox.TextProperty, binding);
        
         if (binding!= null)
            arrayBindings.Add(binding);
    }

    return textBox;
}

public
Label createLabel(string sbindName,string scontent,double dwith,double dheight,double dfontSize,FontWeight fontWeight, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalContentAlignment, Color colorForeGround,Color colorBackground, string sfontFamily=""){
    Label       label = new Label();    
    Binding     binding = !string.IsNullOrEmpty(sbindName) ? new Binding() { Path = new PropertyPath(sbindName) } : null ;
            
    if (binding!= null)
        label.SetBinding(Label.ContentProperty, binding);

    label.Content = scontent;
    if (dheight != 0)
        label.Height= dheight;
    label.Width = dwith;
    
    label.HorizontalContentAlignment = horizontalAlignment;
    label.VerticalContentAlignment = verticalContentAlignment;
    label.FontSize = dfontSize;    
    label.FontWeight = fontWeight;
    
    label.Foreground = new SolidColorBrush(colorForeGround);
    label.Background = new SolidColorBrush(colorBackground);
    if (!string.IsNullOrEmpty(sfontFamily))
        label.FontFamily = new FontFamily(sfontFamily);
    
    arrayControls.Add(label);    
    if (binding!= null)
        arrayBindings.Add(binding);

    return label;
}

public
StackPanel createStackPanel(Orientation orientation = Orientation.Vertical,HorizontalAlignment horizontalAlignment= HorizontalAlignment.Left){
    StackPanel  stackPanel  = new StackPanel();    
     
    stackPanel.Orientation = orientation;
    stackPanel.HorizontalAlignment = horizontalAlignment;
    
    return stackPanel;
}

public
Border addBorder(TextBlock textBlock,double dthickness=0.5){
    Border border = new Border();    
    border.Child = textBlock;
    border.Width = textBlock.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(dthickness);
    border.VerticalAlignment = VerticalAlignment.Center;
    return border;                
}

public
Border addBorder(TextBox textBox,double dthickness=0.5){
    Border border = new Border();    
    border.Child = textBox;
    border.Width = textBox.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(dthickness);
    border.VerticalAlignment = VerticalAlignment.Center;
    border.FocusVisualStyle = null;
    return border;                
}

public
Border addBorder(Label label,double dthickness=0.5){
    Border border = new Border();    
    border.Child = label;
    border.Width = label.Width;
    border.BorderBrush = Brushes.Black;
    border.BorderThickness = new Thickness(0.5);
    border.VerticalAlignment = VerticalAlignment.Center;
    return border;                
}

public
void setConverter(IValueConverter converter, object converterParameter){
    int indexControl = arrayBindings.Count-1;
    setConverter(indexControl, converter, converterParameter);    
}

public
void setConverter(int indexControl,IValueConverter converter, object converterParameter){
    Binding binding= null;

    if (indexControl >=0 && indexControl < this.arrayBindings.Count) { 
        binding = (Binding)arrayBindings[indexControl];

        if (binding != null){
            binding.Converter = converter;
            if (converterParameter != null)
                binding.ConverterParameter = converterParameter;
        }
    }
}

        
public class TextBoxThatDoesntResizeWithText : TextBox{

protected override Size MeasureOverride(Size constraint){
    return new Size(100,30);
}
}


public
FrameworkElementFactory addListView(string sbindName,double dwith,double dheight,double dfontSize,FontWeight fontWeight,TextAlignment textAlignment,Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBlock   = new FrameworkElementFactory(typeof(ListView));
    Binding binding =            new Binding() { Path = new PropertyPath(sbindName) };
    
    //textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
    textBlock.SetValue(ListView.FontWeightProperty, FontWeights.Bold);    
    textBlock.SetValue(ListView.DataContextProperty, binding);       

    textBlock.SetValue(ListView.ForegroundProperty, new SolidColorBrush(colorForeGround));                        
    textBlock.SetValue(ListView.FontSizeProperty, dfontSize);
    textBlock.SetValue(ListView.WidthProperty, dwith);
    textBlock.SetValue(ListView.HeightProperty, dheight);
    textBlock.SetValue(ListView.BackgroundProperty, new SolidColorBrush(colorBackground));
    //textBlock.SetValue(ListView.TextAlignmentProperty,textAlignment); 
    textBlock.SetValue(ListView.FontWeightProperty, fontWeight);        
        
    arrayControls.Add(textBlock);
    arrayBindings.Add(binding);
    
    return textBlock;
}

/*
public
FrameworkElementFactory addStackPanelListViewCol(string sbindName,double dwith,double dheight,double dfontSize,FontWeight fontWeight,TextAlignment textAlignment,Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBlock   = new FrameworkElementFactory(typeof(ListViewCol));
    Binding binding =            new Binding() { Path = new PropertyPath(sbindName) };
    
    //textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
    textBlock.SetValue(ListView.FontWeightProperty, FontWeights.Bold);    
    textBlock.SetValue(ListView.DataContextProperty, binding);       

    textBlock.SetValue(ListView.ForegroundProperty, new SolidColorBrush(colorForeGround));                        
    textBlock.SetValue(ListView.FontSizeProperty, dfontSize);
    textBlock.SetValue(ListView.WidthProperty, dwith);
    textBlock.SetValue(ListView.HeightProperty, dheight);
    textBlock.SetValue(ListView.BackgroundProperty, new SolidColorBrush(colorBackground));
    //textBlock.SetValue(ListView.TextAlignmentProperty,textAlignment); 
    textBlock.SetValue(ListView.FontWeightProperty, fontWeight);        
    
    if (stackPanel!= null)
        stackPanel.AppendChild(textBlock);

    arrayControls.Add(textBlock);
    arrayBindings.Add(binding);
    
    return textBlock;
}*/

public
FrameworkElementFactory addStackPanel(string sbindName,double dwith,double dheight,double dfontSize,FontWeight fontWeight, TextAlignment textAlignment, Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(StackPanel));    
    Binding                 binding = new Binding() { Path = new PropertyPath(sbindName) };
            
    textBox.SetValue(StackPanel.BindingGroupProperty, binding);                
    //textBox.SetValue(StackPanel.ForegroundProperty, new SolidColorBrush(colorForeGround));
    textBox.SetValue(StackPanel.BackgroundProperty, new SolidColorBrush(colorBackground));
    //textBox.SetValue(StackPanel.FontSizeProperty, dfontSize);
    textBox.SetValue(StackPanel.WidthProperty, dwith); //Auto =  Double.NaN
    textBox.SetValue(StackPanel.HeightProperty, dheight);
            /*
    textBox.SetValue(TextBox.IsEnabledProperty, bisEnabled);
    textBox.SetValue(TextBox.IsReadOnlyProperty, bisReadOnly);
    textBox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
    textBox.SetValue(TextBox.FontWeightProperty, fontWeight);
    textBox.SetValue(TextBox.TextAlignmentProperty,textAlignment);
    
    textBox.SetValue(TextBox.HorizontalAlignmentProperty,HorizontalAlignment.Stretch);
    */    
    
    arrayControls.Add(textBox);    
    arrayBindings.Add(binding);

    return textBox;
}

}
}
