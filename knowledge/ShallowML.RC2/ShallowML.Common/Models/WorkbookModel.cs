using ClosedXML.Excel;

namespace ShallowML.Common.Models;

public class WorkbookModel
{
  public List<DataSheetModel> Sheets { get; set; } = new();
  public XLWorkbook xlWorkbook { get; set; } = new();
}
