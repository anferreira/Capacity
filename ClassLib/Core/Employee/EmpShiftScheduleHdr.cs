/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class EmpShiftScheduleHdr : BusinessObject {

private int id;
private string plant;
private DateTime date;
private int shiftNum;
private string dept;
private string notes;
private string createdByEmpId;

private string preShiftNote;
private string postShiftNote;

private string createdByEmpNameShow="";

private EmpShiftScheduleDtlContainer empShiftScheduleDtlContainer;
private EmpShiftScheduleNotesContainer empShiftScheduleNotesContainer;

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleHdr(){
	this.id = 0;
	this.plant = "";
	this.date = DateUtil.MinValue;
	this.shiftNum = 0;
	this.dept = "";
	this.notes = "";
	this.createdByEmpId = "";
    this.preShiftNote ="";
    this.postShiftNote="";
    this.empShiftScheduleDtlContainer = new EmpShiftScheduleDtlContainer();
    this.empShiftScheduleNotesContainer = new EmpShiftScheduleNotesContainer();
}

internal
EmpShiftScheduleHdr(
	int id,
	string plant,
	DateTime date,
	int shiftNum,
	string dept,
	string notes,
	string createdByEmpId,
    string preShiftNote,
    string postShiftNote){
	this.id = id;
	this.plant = plant;
	this.date = date;
	this.shiftNum = shiftNum;
	this.dept = dept;
	this.notes = notes;
	this.createdByEmpId = createdByEmpId;

    this.preShiftNote = preShiftNote;
    this.postShiftNote = postShiftNote;

    this.empShiftScheduleDtlContainer = new EmpShiftScheduleDtlContainer();
    this.empShiftScheduleNotesContainer = new EmpShiftScheduleNotesContainer(); 
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime Date {
	get { return date;}
	set { if (this.date != value){
			this.date = value;
			Notify("Date");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNum {
	get { return shiftNum;}
	set { if (this.shiftNum != value){
			this.shiftNum = value;
			Notify("ShiftNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept {
	get { return dept;}
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Notes {
	get { return notes;}
	set { if (this.notes != value){
			this.notes = value;
			Notify("Notes");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string NotesWithouBreakLines {
	get { return notes.Replace('\n',' ');}
	set {
		Notify("NotesWithouBreakLines");		
	}
}

[System.Runtime.Serialization.DataMember]
public
string CreatedByEmpId {
	get { return createdByEmpId;}
	set { if (this.createdByEmpId != value){
			this.createdByEmpId = value;
			Notify("CreatedByEmpId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PreShiftNote {
	get { return preShiftNote; }
	set { if (this.preShiftNote != value){
			this.preShiftNote = value;
			Notify("PreShiftNote");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PostShiftNote {
	get { return postShiftNote; }
	set { if (this.postShiftNote != value){
			this.postShiftNote = value;
			Notify("PostShiftNote");
		}
	}
}
 
[System.Runtime.Serialization.DataMember]
public
string CreatedByEmpNameShow {
	get { return createdByEmpNameShow; }
	set { if (this.createdByEmpNameShow != value){
			this.createdByEmpNameShow = value;
			Notify("CreatedByEmpNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
EmpShiftScheduleDtlContainer EmpShiftScheduleDtlContainer {
	get { return empShiftScheduleDtlContainer; }
	set { this.empShiftScheduleDtlContainer = value;
			Notify("EmpShiftScheduleDtlContainer");		
	}
}

[System.Runtime.Serialization.DataMember]
public
EmpShiftScheduleNotesContainer EmpShiftScheduleNotesContainer{
	get { return empShiftScheduleNotesContainer; }
	set { this.empShiftScheduleNotesContainer = value;
			Notify("EmpShiftScheduleNotesContainer");		
	}
}

public override
bool Equals(object obj){
	if (obj is EmpShiftScheduleHdr)
		return	this.id.Equals(((EmpShiftScheduleHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){    
    Hashtable   hashEmployeeInvolved= new Hashtable();//load labour count each employee involved, so we calculate labmultiplier
    int         icounterLabInvolved=0;

    for (int i=0; i < empShiftScheduleDtlContainer.Count; i++){
        EmpShiftScheduleDtl empShiftScheduleDtl = empShiftScheduleDtlContainer[i];
        empShiftScheduleDtl.HdrId = Id;
        empShiftScheduleDtl.Detail= (i+1);

        if (hashEmployeeInvolved.Contains(empShiftScheduleDtl.EmpId)){
            icounterLabInvolved = (int)hashEmployeeInvolved[empShiftScheduleDtl.EmpId];
            hashEmployeeInvolved[empShiftScheduleDtl.EmpId] = icounterLabInvolved+1;
        }else
            hashEmployeeInvolved.Add(empShiftScheduleDtl.EmpId,1);
    }

    //set lab multipler automatically
    for (int i=0; i < empShiftScheduleDtlContainer.Count; i++){
        EmpShiftScheduleDtl empShiftScheduleDtl = empShiftScheduleDtlContainer[i];
        empShiftScheduleDtl.LabMultiplier = 1;
        if (hashEmployeeInvolved.Contains(empShiftScheduleDtl.EmpId)){
            icounterLabInvolved = (int)hashEmployeeInvolved[empShiftScheduleDtl.EmpId];
            empShiftScheduleDtl.LabMultiplier = icounterLabInvolved!= 0 ? empShiftScheduleDtl.LabMultiplier / icounterLabInvolved : empShiftScheduleDtl.LabMultiplier;
        }
    }

    //notes    
    for (int i=0; i < empShiftScheduleNotesContainer.Count; i++){
        EmpShiftScheduleNotes empShiftScheduleNotes = empShiftScheduleNotesContainer[i];
        empShiftScheduleNotes.HdrId = Id;
        empShiftScheduleNotes.Detail= (i+1);
    }

}

public static
string[][] getNotesTopics() {
    string[][] item = new string[6][];

    item[0] = new string[] { "1", "People" };
    item[1] = new string[] { "2", "Environment" };
    item[2] = new string[] { "3", "Equipment" };
    item[3] = new string[] { "4", "Process" };
    item[4] = new string[] { "5", "Material" };
    item[5] = new string[] { "6", "Performance" };            

    return item;
}

public
void copy(EmpShiftScheduleHdr empShiftScheduleHdr){
	this.Id=empShiftScheduleHdr.Id;
	this.Plant=empShiftScheduleHdr.Plant;
	this.Date=empShiftScheduleHdr.Date;
	this.ShiftNum=empShiftScheduleHdr.ShiftNum;
	this.Dept=empShiftScheduleHdr.Dept;
	this.Notes=empShiftScheduleHdr.Notes;
	this.CreatedByEmpId=empShiftScheduleHdr.CreatedByEmpId;
    this.CreatedByEmpNameShow = empShiftScheduleHdr.CreatedByEmpNameShow;

    this.PreShiftNote=empShiftScheduleHdr.PreShiftNote;
    this.PostShiftNote=empShiftScheduleHdr.PostShiftNote;

    EmpShiftScheduleDtlContainer.Clear();
    for (int i=0; i < empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Count;i++) {
        EmpShiftScheduleDtl empShiftScheduleDtl = new EmpShiftScheduleDtl();
        empShiftScheduleDtl.copy(empShiftScheduleHdr.EmpShiftScheduleDtlContainer[i]);
        EmpShiftScheduleDtlContainer.Add(empShiftScheduleDtl);        
    }

    EmpShiftScheduleNotesContainer.Clear();
    for (int i=0; i < empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count;i++) {
        EmpShiftScheduleNotes empShiftScheduleNotes = new EmpShiftScheduleNotes();
        empShiftScheduleNotes.copy(empShiftScheduleHdr.EmpShiftScheduleNotesContainer[i]);
        this.EmpShiftScheduleNotesContainer.Add(empShiftScheduleNotes);
    }	
}


} // class
} // package