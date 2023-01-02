namespace Spreadsheet.WebApi.Models;

public class ItemModel
{
  public string Name { get; set; } = string.Empty;
  public int Orders { get; set; }
  public string Quarter { get; set; } = string.Empty;
  public string Year { get; set; } = string.Empty;

  public ItemModel() { }

  public ItemModel(
    string Name
  )
  {
    this.Name = Name;
  }

  public ItemModel(
    string Name,
    int Orders
  )
  {
    this.Name = Name;
    this.Orders = Orders;
  }

  public ItemModel(
    string Name,
    int Orders,
    string Quarter
  )
  {
    this.Name = Name;
    this.Orders = Orders;
    this.Quarter = Quarter;
  }

  public ItemModel(
    string Name,
    int Orders,
    string Quarter,
    string Year
  )
  {
    this.Name = Name;
    this.Orders = Orders;
    this.Quarter = Quarter;
    this.Year = Year;
  }
}
