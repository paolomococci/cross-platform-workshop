using ClosedXML.Excel;

namespace ShallowML.Common.Models;

public class WorkbookModel
{
  public static DomainModel[] GetDataset(string datasetPath)
  {
    XLWorkbook xlWorkbook = new XLWorkbook(datasetPath);
    throw new NotImplementedException();
  }
}
