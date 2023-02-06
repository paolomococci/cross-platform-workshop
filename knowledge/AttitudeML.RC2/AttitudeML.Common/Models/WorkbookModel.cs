using ClosedXML.Excel;

namespace AttitudeML.Common.Models;

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
          Sentiment = item.Cell(1).GetValue<int>(),
          Comment = item.Cell(2).GetValue<string>()
        }
      );
    }
    return domains.ToArray();
  }
}
