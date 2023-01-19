namespace Knowledge.Common.Models;

public class DataSheetModel
{
  public string Label { get; set; } = string.Empty;
  public List<AssetModel> Assets { get; set; } = new();
}
