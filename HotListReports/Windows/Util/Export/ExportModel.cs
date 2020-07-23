using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;

using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;

namespace HotListReports.Windows.Util{

public
class ExportModel{
    
public 
ExportModel(){
    
}
/*
public
cNetworkDrive mapDrive() {
    cNetworkDrive oNetDrive = new cNetworkDrive();
    try {
        //set propertys
        oNetDrive.Force = true;
        oNetDrive.Persistent = false;
        oNetDrive.LocalDrive = "N";
        oNetDrive.PromptForCredentials = false;
        oNetDrive.ShareName = Configuration.CustomPOExportPath;
        oNetDrive.SaveCredentials = false;
        oNetDrive.MapDrive(Configuration.CustomPOExportPathUser, Configuration.CustomPOExportPathPassword);
    } catch (Exception err) {
        MessageBox.Show("Cannot Map Drive To :" + Configuration.CustomPOExportPath + ": " + err.Message);
        oNetDrive = null;
    }
    return oNetDrive;
}*/

public static
bool exportFile(string sfileName,string sinfo) {              
    return exportFile(sfileName,sinfo,true);
}

public static
bool exportFile(string sfileName,string sinfo,bool breplaceCommas) {
    bool        bresult = false;
    string      pathFile = sfileName;    
    string[]    linesToBeWrited = sinfo.Split((char)Constants.END_TEXT_ASCII_VALUE);
    
    checkFolderExists(sfileName);
    TextWriter  textWriter = new StreamWriter(pathFile);// create a writer and open the file        
              
    for (int i = 0; i < linesToBeWrited.Length; i++) {
        if (!string.IsNullOrEmpty(linesToBeWrited[i])) {
            string line = linesToBeWrited[i];
            if (breplaceCommas)
                line = linesToBeWrited[i].Replace(",", " ");

            line = line.Replace(((char)Constants.RECORD_SEPARATOR_ASCII_VALUE).ToString(), ",");
            textWriter.WriteLine(line);// write a line of text to the file                    
        }
    }
    textWriter.Close();// close the stream    
    bresult = true;            
           
    return bresult;
}

public static
bool checkFolderExists(string sfileName){
    bool        bresult = false;
    string      sfolder = Path.GetDirectoryName(sfileName);

    if (!Directory.Exists(sfolder))
        Directory.CreateDirectory(sfolder);

    bresult = true;           
    return bresult;
}

/*
public static
cNetworkDrive mapDrive(string spath,string suser,string spassword) {
    cNetworkDrive oNetDrive = new cNetworkDrive();
    try {
        //set propertys
        oNetDrive.Force = true;
        oNetDrive.Persistent = false;
        oNetDrive.LocalDrive = "N";
        oNetDrive.PromptForCredentials = false;
        oNetDrive.ShareName = spath;
        oNetDrive.SaveCredentials = false;
        oNetDrive.MapDrive(suser, spassword);
    } catch (Exception err) {
        MessageBox.Show("Cannot Map Drive To :" + Configuration.CustomPOExportPath + ": " + err.Message);
        oNetDrive = null;
    }
    return oNetDrive;
}
*/
     
public static
bool writeFile(string sfileName,string stotal,bool bshowMessage){
    bool bresult=false;

    try{
         if (!string.IsNullOrEmpty(stotal)){
            if (File.Exists(sfileName) && fileLocked(sfileName)){
                if (bshowMessage)
                    MessageBox.Show("Please Close File :" + sfileName + " ," + "\n" + "Then Try Export Again.");
            }else{
                TextWriter textWriter = new StreamWriter(sfileName);// create a writer and open the file      
                textWriter.Write(stotal);
                textWriter.Close();// close the stream      

                bresult=false;                
                if (bshowMessage)
                    MessageBox.Show("File Exported : " + sfileName);
            }
        }     

    }catch(Exception exc){		
        MessageBox.Show("Error writeFile:" + exc.Message);
	}
    return bresult;
}

public static
bool fileLocked(string FileName){
    FileStream fs = null;

    try {
        // NOTE: This doesn't handle situations where file is opened for writing by another process but put into write shared mode, it will not throw an exception and won't show it as write locked
        fs = File.Open(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None); // If we can't open file for reading and writing then it's locked by another process for writing
    }catch (UnauthorizedAccessException){
        // This is because the file is Read-Only and we tried to open in ReadWrite mode, now try to open in Read only mode
        try{
            fs = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
        }catch (Exception){
            return true; // This file has been locked, we can't even open it to read
        }
    }catch (Exception){
        return true; // This file has been locked
    }
    finally{
        if (fs != null)
            fs.Close();
    }
    return false;
}

public static
string generateFileName(string sname,string sfolder, bool baddDateSubFolder){  
    string      spath = Configuration.AppRoot + @"\" + sfolder + @"\";

    if (!Directory.Exists(spath))
        Directory.CreateDirectory(spath);

    if (baddDateSubFolder)
        spath+= DateUtil.getDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace("/","-") + @"\";

    if (!Directory.Exists(spath))
        Directory.CreateDirectory(spath);

    spath += sname;

    //MessageBox.Show("generateFileName:"+spath);

    return spath;
}


public static
bool snapShotPNG(ListView source, string destination, int zoom){
    bool bresult=false;
    try{
        double actualWidth = source.ActualWidth;
        source.Measure(new Size(source.ActualWidth, Double.PositiveInfinity));
        source.Arrange(new Rect(0, 0, actualWidth, source.DesiredSize.Height));
        double actualHeight = source.ActualHeight;

        double renderHeight = actualHeight * zoom;
        double renderWidth = actualWidth * zoom;

        RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
        VisualBrush sourceBrush = new VisualBrush(source);

        DrawingVisual drawingVisual = new DrawingVisual();
        DrawingContext drawingContext = drawingVisual.RenderOpen();

        using (drawingContext){
            drawingContext.PushTransform(new ScaleTransform(zoom, zoom));
            drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
        }
        renderTarget.Render(drawingVisual);

        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
        using (FileStream stream = new FileStream(destination, FileMode.Create, FileAccess.Write)){
            encoder.Save(stream);
        }
    }catch (Exception e){
        MessageBox.Show("Error snapShotPNG:" + e.Message);        
    }
    return bresult;
}
}
}
