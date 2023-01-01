using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class FormulaSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook) {
    var formulaSheet = xLWorkbook.Worksheet("FormulaSheet");
  }
}
