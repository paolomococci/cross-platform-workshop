namespace Pivot.Common.Models;

public class ItemModel
{
  public string Code { get; set; } = string.Empty;
  public int Orders { get; set; }
  public bool Delivered { get; set; } = false;
  public DateTime Period { get; set; }

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
    bool Delivered
  )
  {
    this.Code = Code;
    this.Orders = Orders;
    this.Delivered = Delivered;
  }

  public ItemModel(
    string Code,
    int Orders,
    bool Delivered,
    DateTime Period
  )
  {
    this.Code = Code;
    this.Orders = Orders;
    this.Delivered = Delivered;
    this.Period = Period;
  }
}
