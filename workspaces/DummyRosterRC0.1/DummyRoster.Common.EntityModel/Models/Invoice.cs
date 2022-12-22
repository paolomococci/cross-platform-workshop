using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Invoice")]
[Index("Id", Name = "IDX_InvoiceId")]
[Index("ProductId", Name = "IDX_ProductId")]
public partial class Invoice
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "INT")]
  public int? FormId { get; set; }

  [Column(TypeName = "INT")]
  public int? ProductId { get; set; }

  public string? Note { get; set; }

  [Column(TypeName = "NUMERIC")]
  public decimal UnitPrice { get; set; }

  [Column(TypeName = "SMALLINT")]
  public int Quantity { get; set; }

  [Column(TypeName = "NUMERIC")]
  public decimal PriceCut { get; set; }

  [ForeignKey("FormId")]
  [InverseProperty("Invoices")]
  public virtual Form? Form { get; set; }

  [ForeignKey("ProductId")]
  [InverseProperty("Invoices")]
  public virtual Product? Product { get; set; }
}
