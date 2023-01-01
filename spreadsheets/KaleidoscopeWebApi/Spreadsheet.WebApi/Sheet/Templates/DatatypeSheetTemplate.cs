using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class DatatypeSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook) {
    /* adds data and formulas to the spreadsheet named DatatypeSheet */
    var formulaSheet = xLWorkbook.Worksheet("DatatypeSheet");
  }
}
