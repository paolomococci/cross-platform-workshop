namespace Spreadsheet.WebApi.Models;

public class OrderModel {
  public int Id { get; set; }
  public int TableId { get; set; }
  public int MenuId { get; set; }
  public int NumberOfServings { get; set; }
  public decimal PartialAccount { get; set; }
  public decimal Total { get; set; }
}
