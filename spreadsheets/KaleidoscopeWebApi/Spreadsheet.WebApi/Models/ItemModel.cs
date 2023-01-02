namespace Spreadsheet.WebApi.Models;

public class ItemModel
{
  public string Code { get; set; } = string.Empty;
  public int Orders { get; set; }
  public string Quarter { get; set; } = string.Empty;
  public string Year { get; set; } = string.Empty;

  public ItemModel() { }

  public ItemModel(
    string Code
  )
  {
    this.Code = Code;
  }

  public ItemModel(
    string Code,
    int Orders
  )
  {
    this.Code = Code;
    this.Orders = Orders;
  }

  public ItemModel(
    string Code,
    int Orders,
    string Quarter
  )
  {
    this.Code = Code;
    this.Orders = Orders;
    this.Quarter = Quarter;
  }

  public ItemModel(
    string Code,
    int Orders,
    string Quarter,
    string Year
  )
  {
    this.Code = Code;
    this.Orders = Orders;
    this.Quarter = Quarter;
    this.Year = Year;
  }
}
