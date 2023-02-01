namespace Template.Common.Models;

public class DataSheetModel
{
  public string Label { get; set; } = string.Empty;
  public List<SchemeModel> Schemes { get; set; } = new();
}
