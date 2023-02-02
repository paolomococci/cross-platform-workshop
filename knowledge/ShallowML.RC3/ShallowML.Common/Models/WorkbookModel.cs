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
          Area = float.Parse((string)item.Cell(1).Value),
          Price = float.Parse((string)item.Cell(2).Value)
        }
      );
      System.Console.WriteLine($"area: {float.Parse((string)item.Cell(1).Value)}, price: {float.Parse((string)item.Cell(2).Value)}");
    }
    return domains.ToArray();
  }
}
