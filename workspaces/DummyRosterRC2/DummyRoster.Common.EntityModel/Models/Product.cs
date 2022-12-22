using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Product")]
[Index("CategoryId", Name = "IDX_CategoryId")]
[Index("CategoryId", Name = "IDX_ProductBelongingCategory")]
[Index("Name", Name = "IDX_ProductName")]
[Index("SupplierId", Name = "IDX_ProductSuppliedBy")]
[Index("SupplierId", Name = "IDX_SupplierId")]
public partial class Product
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  [RegularExpression(@"[a-zA-Z0-9\s\-]{1,32}")]
  public string Name { get; set; } = null!;

  public string? Description { get; set; }

  [Column(TypeName = "varchar(8)")]
  public string? Belonging { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "INT")]
  public int? CategoryId { get; set; }

  [Column(TypeName = "INT")]
  public int? SupplierId { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? QuantityPerUnit { get; set; }

  [Column(TypeName = "NUMERIC")]
  public decimal? UnitPrice { get; set; }

  [Column(TypeName = "SMALLINT")]
  public int? UnitsInStock { get; set; }

  [Column(TypeName = "SMALLINT")]
  public int? UnitsOnOrder { get; set; }

  [Column(TypeName = "SMALLINT")]
  public int? ReorderLevel { get; set; }

  [Column(TypeName = "BOOLEAN")]
  public bool Discontinued { get; set; }

  [ForeignKey("CategoryId")]
  [InverseProperty("Products")]
  public virtual Category? Category { get; set; }

  [InverseProperty("Product")]
  public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

  [ForeignKey("SupplierId")]
  [InverseProperty("Products")]
  public virtual Supplier? Supplier { get; set; }
}
