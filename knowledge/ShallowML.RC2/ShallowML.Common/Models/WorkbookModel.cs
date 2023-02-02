using ClosedXML.Excel;

namespace ShallowML.Common.Models;

public class WorkbookModel
{
  public static DomainModel[] GetDataset(string datasetPath)
  {
    XLWorkbook xlWorkbook = new XLWorkbook(datasetPath);
    var sheet = xlWorkbook.Worksheet(1);
    throw new NotImplementedException();
  }
}
