using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;


namespace Nujit.NujitERP.ClassLib.Core.Print{

public class PrintManager{

private Font printFont;
private StreamReader streamToPrint;
private string filePath;

private string  sfontName;
private int		ifontSize;

public 
PrintManager(string filePath){

	this.filePath = filePath;
	
	sfontName="Courier New";
	ifontSize=10;	     	
}

public void setFont(string  sfontName,
					int		ifontSize)
{
	this.sfontName = sfontName;
	this.ifontSize = ifontSize;
}

// The PrintPage event is raised for each page to be printed.
private 
void pd_PrintPage(object sender, PrintPageEventArgs ev){
    float linesPerPage = 0;
    float yPos =  0;
    int count = 0;
    float leftMargin = ev.MarginBounds.Left;
    float topMargin = ev.MarginBounds.Top;
    String line = null;
        
    // Calculate the number of lines per page.
    linesPerPage = ev.MarginBounds.Height  / printFont.GetHeight(ev.Graphics);

    // Iterate over the file, printing each line.
    while(count < linesPerPage && ((line=streamToPrint.ReadLine()) != null)){
        yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
        ev.Graphics.DrawString (line, printFont, Brushes.Black, 
            leftMargin, yPos, new StringFormat());
        count++;
    }

    // If more lines exist, print another page.
    if (line != null) 
        ev.HasMorePages = true;
    else 
        ev.HasMorePages = false;
}

// Print the file.
public 
bool print(out string serror){
	bool bresult=true;

	serror="";
    try{
        streamToPrint = new StreamReader(filePath);
        try{

			printFont = new Font(sfontName, ifontSize);
            PrintDocument pd = new PrintDocument(); 
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Print the document.
            pd.Print();
        }finally{
            streamToPrint.Close() ;
        }
    }catch(System.Exception ex){ 
		bresult=false;
        serror =ex.Message;
    }

	return  bresult;
}
  
} // class

} // namespace