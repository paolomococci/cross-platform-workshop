using ClosedXML.Excel;

namespace ShallowML.Common.Models;

public class WorkbookModel
{
  public static DomainModel[] GetDataset(string datasetPath)
  {
    List<DomainModel> domains = new();
    XLWorkbook xlWorkbook = new XLWorkbook(datasetPath);
    var sheet = xlWorkbook.Worksheet(1);
    var rows = sheet.RangeUsed().RowsUsed().Skip(1);
    foreach (var item in rows)
    {
      domains.Add(
        new DomainModel() {
          Area = item.Cell(1).GetValue<float>(),
          Price = item.Cell(2).GetValue<float>()
        }
      );
      System.Console.WriteLine($"area: {item.Cell(1).GetValue<float>()}, price: {item.Cell(2).GetValue<float>()}");
    }
    return domains.ToArray();
  }
}
