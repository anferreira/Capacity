using System;

namespace  Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel{

public
class ExcelPersistenceException : PersistenceException{

public
ExcelPersistenceException(string message) : base(message){
}

public
ExcelPersistenceException(string message, System.Exception innerException) : base(message, innerException){
}

}

}
