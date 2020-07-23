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

class ListViewColFr{

private ArrayList arrayControls, arrayBindings;


public
ListViewColFr(){
    arrayControls = new ArrayList();    
    arrayBindings = new ArrayList();
}

public
FrameworkElementFactory addTextBlock(string sbindName,double dwith,double dheight,double dfontSize,FontWeight fontWeight,TextAlignment textAlignment,Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBlock   = new FrameworkElementFactory(typeof(TextBlock));
    Binding binding =            new Binding() { Path = new PropertyPath(sbindName) };
    
    //textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
    textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);    
    textBlock.SetValue(TextBlock.TextProperty, binding);       

    textBlock.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(colorForeGround));                        
    textBlock.SetValue(TextBlock.FontSizeProperty, dfontSize);
    textBlock.SetValue(TextBlock.WidthProperty, dwith);
    textBlock.SetValue(TextBlock.HeightProperty, dheight);
    textBlock.SetValue(TextBlock.BackgroundProperty, new SolidColorBrush(colorBackground));
    textBlock.SetValue(TextBlock.TextAlignmentProperty,textAlignment); 
    textBlock.SetValue(TextBlock.FontWeightProperty, fontWeight);        
      
    arrayControls.Add(textBlock);
    arrayBindings.Add(binding);
    
    return textBlock;
}

public
FrameworkElementFactory addTextBox(string sbindName,bool bisEnabled,bool bisReadOnly,double dwith,double dheight,double dfontSize,FontWeight fontWeight, TextAlignment textAlignment, Color colorForeGround,Color colorBackground){        
    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));    
    Binding                 binding = new Binding() { Path = new PropertyPath(sbindName) };
            
    textBox.SetValue(TextBox.TextProperty, binding);                
    textBox.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(colorForeGround));
    textBox.SetValue(TextBlock.BackgroundProperty, new SolidColorBrush(colorBackground));
    textBox.SetValue(TextBox.FontSizeProperty, dfontSize);
    textBox.SetValue(TextBox.WidthProperty, dwith); //Auto =  Double.NaN
    textBox.SetValue(TextBox.HeightProperty, dheight);
    textBox.SetValue(TextBox.IsEnabledProperty, bisEnabled);
    textBox.SetValue(TextBox.IsReadOnlyProperty, bisReadOnly);
    textBox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
    textBox.SetValue(TextBox.FontWeightProperty, fontWeight);
    textBox.SetValue(TextBox.TextAlignmentProperty,textAlignment);

    textBox.SetValue(TextBox.HorizontalAlignmentProperty,HorizontalAlignment.Stretch);
          
    arrayControls.Add(textBox);    
    arrayBindings.Add(binding);

    return textBox;
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

public
FrameworkElementFactory addStackPanel(string sbindName,double dwith,double dheight, TextAlignment textAlignment, Color colorForeGround,Color colorBackground){        
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
