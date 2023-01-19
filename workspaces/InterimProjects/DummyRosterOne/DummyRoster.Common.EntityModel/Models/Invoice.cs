using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[PrimaryKey("FormId", "ProductId")]
[Table("Invoice")]
[Index("ProductId", Name = "IDX_ProductId")]
public partial class Invoice
{
  [RegularExpression(@"[a-zA-Z0-1\s\-\,\.]{3,64}")]
  public string? Note { get; set; }

  [Key]
  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int FormId { get; set; }

  [Key]
  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int ProductId { get; set; }

  [Column(TypeName = "DATETIME")]
  public DateTime? RegistrationDate { get; set; }

  public double UnitPrice { get; set; }

  [Column(TypeName = "SMALLINT")]
  [Range(0, 65535)]
  public UInt16 Quantity { get; set; }

  [Range(0, 1)]
  public decimal PriceCut { get; set; }

  [ForeignKey("FormId")]
  [InverseProperty("Invoices")]
  public virtual Form Form { get; set; } = null!;

  [ForeignKey("ProductId")]
  [InverseProperty("Invoices")]
  public virtual Product Product { get; set; } = null!;
}
