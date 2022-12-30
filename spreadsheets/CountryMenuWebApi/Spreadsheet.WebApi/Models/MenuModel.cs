namespace Spreadsheet.WebApi.Models;

public class MenuModel
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public string Description { get; set; } = string.Empty;
}
