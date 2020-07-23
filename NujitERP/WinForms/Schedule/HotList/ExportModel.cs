using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core;
using System.Data;
using Nujit.NujitERP.WinForms.Util;

namespace Nujit.NujitERP.WinForms.Schedule.HotList{

class ExportModel{


public
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
		using(FormException formException = new FormException(exc))
		    formException.ShowDialog();
	}
    return bresult;
}

public 
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

private
bool checkFolderExists(string sfileName){
    bool        bresult = false;
    string      sfolder = Path.GetDirectoryName(sfileName);

    if (!Directory.Exists(sfolder))
        Directory.CreateDirectory(sfolder);

    bresult = true;           
    return bresult;
}
    
private
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

private
string generateFileNameConfigurated(string sname,bool baddDateSubFolder){  
    string      spath = Configuration.Report1268ExportPath + @"\";

    if (!Directory.Exists(spath))
        Directory.CreateDirectory(spath);

    if (baddDateSubFolder)
        spath+= DateUtil.getDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace("/","-") + @"\";

    if (!Directory.Exists(spath))
        Directory.CreateDirectory(spath);

    spath += sname;

    //MessageBox.Show("generateFileNameConfigurated:" + spath);

    return spath;
}

public
void callBatchFile(string sbatchName,string sarguments,bool bwaitForResult){
    try {                                
        Process p = new Process();

        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = sbatchName;

        //arguments
        if (!string.IsNullOrEmpty(sarguments))
            p.StartInfo.Arguments = sarguments;
        
        p.StartInfo.CreateNoWindow = true;
        p.Start();

        if (bwaitForResult){
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit(1);//not wait
        }
        
    }catch (Exception ex){
       using(FormException formException = new FormException(ex))
		    formException.ShowDialog();   
    }
}

public
void hotlistExportToCSV(CoreFactory coreFactory,Form form,DataGrid gridHotList,string stype){       
    try{              
        form.Cursor = Cursors.WaitCursor;  

        bool            onlyDemand=false;        
        int             hlid=0;
        string[]        filter = { };            
	    string[][]      vec = coreFactory.getHotListAsString(hlid,"", filter, filter, filter, onlyDemand, stype);//CM 11/10/2005
                        
        DataTable       dataTable = (DataTable)gridHotList.DataSource;
        string[]        items = null;
        int             icols = dataTable.Columns.Count;
        int             irows = dataTable.Rows.Count;

        string          sep= ",";
        string          sline = "";
        string          stotal = "";        
                
        string[]        v = coreFactory.getHotListLogData();
        string          shotListGenerated = v.Length > 0 ? "DT " + v[0].Replace("/","-").Replace(":"," ") :"";
        string          sname = "Hotlist Generated " + shotListGenerated + ".csv";
        string          sfileName = generateFileName(sname, "Reports", false);                

        checkFolderExists(sfileName);

        //tittle        
        for (int j=0; j < icols;j++)
            sline += (string.IsNullOrEmpty(sline) ? "":sep) + dataTable.Columns[j].Caption.Replace(",", "");            
        stotal=sline +"\n";
             
        for (int i = 0; i < vec.Length; i++){
            items = vec[i];
            
            if (items!=null){
                sline = "";
                for (int j = 0;items!=null && j < items.Length; j++)
                    sline += (string.IsNullOrEmpty(sline) ? "" : sep) + items[j].Replace(",", "");

                 stotal+=sline +"\n";
            }
        }

        writeFile(sfileName,stotal,true);
              
    }catch(Exception exc){		
		using(FormException formException = new FormException(exc))
		    formException.ShowDialog();
	}finally{        
        form.Cursor = System.Windows.Forms.Cursors.Default;    
    }
}

public
void exportToCSV1268Report(CoreFactory coreFactory,Form form){
    try{        
        if (form!=null)
            form.Cursor = Cursors.WaitCursor; 
        
        ArrayList           alist = coreFactory.runReport1268();
        string[]            v = coreFactory.getHotListLogData();        
        string              sreportGenerated = DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY).Replace("/","-").Replace(":"," ") ;
        string              sname = "1268 Report Generated " + sreportGenerated + ".csv";
        string              sfileName = generateFileName(sname,"Reports",false);

        string             stotal ="";                
        string              sep = ",";
        string[]            item = null;
        int                 j = 0;
        string              saux ="/";
        
        checkFolderExists(sfileName);

        stotal+= "Part Number";
        stotal+= sep + "Main Material";
        stotal+= sep + "MT-Part";
        stotal+= sep + "RT-Part";       
        for (j=10; j <=160;j=j+10)
            stotal+= sep + "Part-" + j.ToString();

        stotal+= sep + "QtyHold";
        stotal+= sep + "F/G";
        stotal+= sep + "Net WOH";
        stotal+= sep + "PAST";
                
        //customer demand                        
        for (j=1; j <=8;j++)
            stotal+= sep + "WEEK" + j.ToString();
        stotal+= "\r\n";
                           
        for (int i=0; i < alist.Count;i++){
	        item = (string[])alist[i];

            for (j=0; j < item.Length && j <= 31;j++){

                bool b = item[j].Equals("RTA6200");
                if (b){
                    b=b;
                    //stotal = "";
                }
                stotal += (j == 0? "":sep) + item[j].Replace("\n",saux).Replace("\"","").Replace(",", "");
            }
            stotal+= "\r\n";
        }

        writeFile(sfileName, stotal,true);                               
              
    }catch(Exception exc){		
		using(FormException formException = new FormException(exc))
		    formException.ShowDialog();
	}finally{
        if (form!=null)
            form.Cursor = Cursors.Default; 
    }
}
  
private
void exportToCSVItem(CoreFactory coreFactory,DataGrid gridHotList){
    try{              
        DataTable       dataTable = (DataTable)gridHotList.DataSource;
        string[]        items = null;
        int             icols = dataTable.Columns.Count;
        int             irows = dataTable.Rows.Count;
        string          sline = "";
        string          stSep = "=\"";
        string          endSep = "\",";
        
        string[]        v = coreFactory.getHotListLogData();
        string          shotListGenerated = v.Length > 0 ? "DT " + v[0].Replace("/","-").Replace(":"," ") :"";        
        string          sname = "Hotlist Generated " + shotListGenerated + ".csv";
        string          sfileName = generateFileName(sname, "Reports",false);

        checkFolderExists(sfileName);

        //tittle
        for (int j=0; j < icols;j++)
            sline += stSep + dataTable.Columns[j].Caption.Replace(",", "") + endSep;
        
        sline +="\n";
             
        for (int i = 0; i < irows;i++){
            items = Grid.getSelected2(i,0,gridHotList,dataTable);

            if (items!=null){
                for (int j = 0;items!=null && j < items.Length; j++)
                    sline += stSep + items[j].Replace(",", "") + endSep;
                sline += "\n";
            }
        }

        if (!string.IsNullOrEmpty(sline)){
            if (File.Exists(sfileName) && fileLocked(sfileName))
                MessageBox.Show("Please Close File :" + sfileName + " ," + "\n" + "Then Try Export Again.");
            else{
                TextWriter textWriter = new StreamWriter(sfileName);// create a writer and open the file      
                textWriter.Write(sline);
                textWriter.Close();// close the stream      

                MessageBox.Show("File Exported : " + sfileName);
            }
        }
              
    }catch(Exception exc){		
		using(FormException formException = new FormException(exc))
		    formException.ShowDialog();
	}
}
    
public
void exportToCSVStored1268Report(CoreFactory coreFactory,Form form,bool bshowMessage,bool bexportToConfigurtedPath,bool baddDateSubFolder){
    try{      
        if (form!=null)
            form.Cursor = Cursors.WaitCursor; 

        DateTime            dateTime = DateUtil.MinValue;
        ArrayList           alist = coreFactory.getStoredReport1268(0,out dateTime);
        
        dateTime = DateTime.Now;
        string              sname  = "1268 StoredReport Generated " + DateUtil.getCompleteDateRepresentation(dateTime, DateUtil.MMDDYYYY).Replace("/", "-").Replace(":", " ") + ".csv";
        string              sfileName = bexportToConfigurtedPath ? generateFileNameConfigurated(sname,baddDateSubFolder) : generateFileName(sname, "Reports", baddDateSubFolder);
        string              stotal ="";                
        string              sep = ",";
        string[]            item = null;
        int                 j = 0;
        string              saux ="/";
        
        if (alist.Count < 1){
            if (bshowMessage)
                MessageBox.Show("There Are Not Stored Reports Results Yet.");
            return;
        }
        
        checkFolderExists(sfileName);

        stotal+= "Part Number";
        stotal+= sep + "Main Material";
        stotal+= sep + "MT-Part";
        stotal+= sep + "MajGroup";
        stotal+= sep + "MinGroup";
        stotal+= sep + "RT-Part";       
        for (j=10; j <=160;j=j+10)
            stotal+= sep + "Part-" + j.ToString();

        stotal+= sep + "PartStatus";
        stotal+= sep + "QtyHold";
        stotal+= sep + "QtyGP12";
        stotal+= sep + "F/G";
        stotal+= sep + "Net WOH";
        stotal+= sep + "PAST";
                
        //customer demand                        
        for (j=1; j <=14;j++)
            stotal+= sep + "WEEK" + j.ToString();
        //received qty and dates
        stotal += sep + "1st Rec.Qty";
        stotal += sep + "1st Rec.Date";
        stotal += sep + "2nd Rec.Qty";
        stotal += sep + "2nd Rec.Date";
        stotal += sep + "3rd Rec.Qty";
        stotal += sep + "4th Rec.Qty";               
        stotal+= "\r\n";
                           
        for (int i=0; i < alist.Count;i++){
	        item = (string[])alist[i];

            for (j=0; j < item.Length && j <= 47;j++){            /*37 = Customer Demand*/    
                stotal += (j == 0? "":sep) + item[j].Replace("\n",saux).Replace("\"","").Replace(",", "");
            }
            stotal+= "\r\n";
        }
        
        if (form!=null)
            form.Cursor = Cursors.Default;
        writeFile(sfileName,stotal,bshowMessage);
              
    }catch(Exception exc){
		using(FormException formException = new FormException(exc))
		    formException.ShowDialog();
	}finally{
        if (form!=null)
            form.Cursor = Cursors.Default;
    }
}
}
}
