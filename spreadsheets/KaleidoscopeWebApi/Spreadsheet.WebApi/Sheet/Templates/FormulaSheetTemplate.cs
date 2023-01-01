using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class FormulaSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook) {
    /* adds data and formulas to the spreadsheet named FormulaSheet */
    var formulaSheet = xLWorkbook.Worksheet("FormulaSheet");
  }
}
