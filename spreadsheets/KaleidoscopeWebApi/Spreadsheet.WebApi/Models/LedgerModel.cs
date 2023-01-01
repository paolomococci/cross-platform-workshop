using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Models;

public class LedgerModel
{
  internal static byte[] Perform(MemoryStream memoryStream)
  {
    
    /* generate the workbook */
    XLWorkbook ledger = new XLWorkbook();

    /* adds three spreadsheets */
    List<string> sheetNames = new List<string>() {
        "FormulaSheet",
        "DatatypeSheet"
      };
    foreach (var sheetName in sheetNames)
    {
      var sheet = ledger.Worksheets.Add(sheetName);
      sheet.Cell("A1").Value = sheetName;
    }

    /* adds data and formulas to a specific spreadsheet */
    var formulaSheet = ledger.Worksheet("FormulaSheet");
    formulaSheet.Cell("B1").SetValue("Values");
    formulaSheet.Cell("B2").SetValue(4.55);
    formulaSheet.Cell("B3").SetValue(2.55);
    formulaSheet.Cell("B4").SetValue(4.2);
    formulaSheet.Cell("B5").SetValue(3.33);
    formulaSheet.Cell("A6").SetValue("Sum");
    formulaSheet.Cell("A7").SetValue("Average");
    formulaSheet.Cell("B6").FormulaA1 = "SUM(B2:B5)";
    formulaSheet.Cell("B7").FormulaA1 = "AVERAGE(B2:B5)";
    /* performs calculations programmatically */
    List<decimal> decimalNumbers = new();
    decimalNumbers.Add(formulaSheet.Cell("B2").GetValue<decimal>());
    decimalNumbers.Add(formulaSheet.Cell("B3").GetValue<decimal>());
    decimalNumbers.Add(formulaSheet.Cell("B4").GetValue<decimal>());
    decimalNumbers.Add(formulaSheet.Cell("B5").GetValue<decimal>());
    formulaSheet.Cell("C1").SetValue("compute programmatically");
    formulaSheet.Cell("C6").SetValue(
      decimalNumbers.Sum()
    );
    formulaSheet.Cell("C7").SetValue(
      decimalNumbers.Sum() / decimalNumbers.Count()
    );

    /* pack it all up */
    ledger.SaveAs(memoryStream);
    memoryStream.Seek(
      0,
      SeekOrigin.Begin
    );
    return memoryStream.ToArray();
  }
}
