using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class DatatypeSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook)
  {
    int row = 2;
    int column = 2;
    /* adds data and formulas to the spreadsheet named DatatypeSheet */
    var datatypeSheet = xLWorkbook.Worksheet("DatatypeSheet");
    
    datatypeSheet.Cell(row, column).SetValue<string>("Sample text data type:");
  }
}
