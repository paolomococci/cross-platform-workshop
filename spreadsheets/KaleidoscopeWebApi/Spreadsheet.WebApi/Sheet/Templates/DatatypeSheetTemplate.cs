using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class DatatypeSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook)
  {
    int row = 2;
    int column = 2;
    /* adds data to the spreadsheet named DatatypeSheet */
    var datatypeSheet = xLWorkbook.Worksheet("DatatypeSheet");

    datatypeSheet.Cell(row, column).SetValue<string>("Simple text examples:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<string>("Hello everyone!");
    datatypeSheet.Cell(++row, (column + 1)).SetValue<string>("Happy New Year.");

    datatypeSheet.Cell(++row, column).SetValue<string>("Date examples:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<DateTime>(new DateTime(2023, 1, 1));
    datatypeSheet.Cell(++row, (column + 1)).SetValue<DateTime>(new DateTime(2023, 1, 2));

    datatypeSheet.Cell(++row, column).SetValue<string>("Examples of date and time:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<DateTime>(new DateTime(2023, 1, 2, 2, 0, 0));
    datatypeSheet.Cell(++row, (column + 1)).SetValue<DateTime>(new DateTime(2023, 1, 2, 3, 0, 0));

    datatypeSheet.Cell(++row, column).SetValue<string>("Examples of Boolean values:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<bool>(true);
    datatypeSheet.Cell(++row, (column + 1)).SetValue<bool>(false);

    datatypeSheet.Cell(++row, column).SetValue<string>("Examples of numeric values:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<int>(10);
    datatypeSheet.Cell(++row, (column + 1)).SetValue<float>(10.25f);
    datatypeSheet.Cell(++row, (column + 1)).SetValue<double>(10.25);
    datatypeSheet.Cell(++row, (column + 1)).SetValue<decimal>(10.25m);

    datatypeSheet.Cell(++row, column).SetValue<string>("Examples of time span:");
    datatypeSheet.Cell(row, (column + 1)).SetValue<TimeSpan>(new TimeSpan(0, 15, 0));
    datatypeSheet.Cell(++row, (column + 1)).SetValue<TimeSpan>(new TimeSpan(1, 30, 30));

    datatypeSheet.Cell(++row, column).SetValue<string>("Set Hyperlinks:");
    datatypeSheet.Cell(row, (column + 1)).SetHyperlink(new XLHyperlink(@"http://127.0.0.1:8080"));
    datatypeSheet.Cell(++row, (column + 1)).SetHyperlink(new XLHyperlink(@"http://127.0.0.1:8081"));
  }
}
