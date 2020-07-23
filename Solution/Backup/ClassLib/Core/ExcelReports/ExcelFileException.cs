using System;

namespace Nujit.NujitERP.ClassLib.Core.ExcelReports{

public
class ExcelFileException : ExcelException{

public
ExcelFileException(string message) : base(message){
}

public
ExcelFileException(string message, System.Exception innerException) : base(message, innerException){
}

} // class 

} // namespace
