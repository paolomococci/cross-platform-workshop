namespace Pivot.Mvc.Feather.Models;

public class WorkbookModel
{
  public List<DataSheetModel> SheetBinder { get; set; } = new();

  internal void Sift(string[] subdivided)
  {
    var coords = new CoordsModel(
          DateTime.Parse(subdivided[0]),
          new List<int> {
            int.Parse(subdivided[2]),
            int.Parse(subdivided[3]),
            int.Parse(subdivided[4]),
            int.Parse(subdivided[5]),
            int.Parse(subdivided[6])
          }
        );
        this.SheetBinder.Find(
          temp => temp.Id == subdivided[1]
        );
  }
}
