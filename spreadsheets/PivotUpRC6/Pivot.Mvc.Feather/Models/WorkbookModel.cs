namespace Pivot.Mvc.Feather.Models;

public class WorkbookModel
{
  public List<DataSheetModel> SheetBinder { get; set; } = new();

  internal void Initialize(string[] subdivided)
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
  }

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
    foreach (var item in this.SheetBinder)
    {
      if (item.Id == subdivided[1])
      {
        if (item.Items != null)
        {
          item.Items.Add(coords);
        }
      }
    }
  }
}
