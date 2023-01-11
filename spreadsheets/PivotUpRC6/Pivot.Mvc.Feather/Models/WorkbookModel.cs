namespace Pivot.Mvc.Feather.Models;

public class WorkbookModel
{
  public List<DataSheetModel> SheetBinder { get; set; } = new();

  internal void Sift(string[] subdivided)
  {
    throw new NotImplementedException();
  }
}
