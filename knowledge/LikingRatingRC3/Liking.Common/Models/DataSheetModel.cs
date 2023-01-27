namespace Liking.Common.Models;

public class DataSheetModel
{
  public string Label { get; set; } = string.Empty;
  public List<SchemeModel> Assets { get; set; } = new();
}
