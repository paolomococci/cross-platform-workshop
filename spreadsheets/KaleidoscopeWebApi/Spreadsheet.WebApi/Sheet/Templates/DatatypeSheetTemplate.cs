using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class DatatypeSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook) {
    var formulaSheet = xLWorkbook.Worksheet("DatatypeSheet");
  }
}
