namespace ShallowML.Common.Models;

public class DataSheetModel
{
  public string Label { get; set; } = string.Empty;
  public List<DomainModel> Domains { get; set; } = new();
}
