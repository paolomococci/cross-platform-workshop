﻿using System.ComponentModel.DataAnnotations;
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
  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(32)")]
  [RegularExpression("[a-zA-Z]{1,32}")]
  public string Name { get; set; } = null!;

  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,63})$")]
  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "DATETIME")]
  public DateTime? RegistrationDate { get; set; }

  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int? CategoryId { get; set; }

  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int? SupplierId { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? QuantityPerUnit { get; set; }

  public double? UnitPrice { get; set; }

  [Column(TypeName = "SMALLINT")]
  [Range(0, 65535)]
  public UInt16? UnitsInStock { get; set; }

  [Column(TypeName = "SMALLINT")]
  [Range(0, 65535)]
  public UInt16? UnitsOnOrder { get; set; }

  [Column(TypeName = "SMALLINT")]
  [Range(0, 65535)]
  public UInt16? ReorderLevel { get; set; }

  [Column(TypeName = "TINYINT")]
  public long Discontinued { get; set; }

  [ForeignKey("CategoryId")]
  [InverseProperty("Products")]
  public virtual Category? Category { get; set; }

  [InverseProperty("Product")]
  public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

  [ForeignKey("SupplierId")]
  [InverseProperty("Products")]
  public virtual Supplier? Supplier { get; set; }

  private const int seed = 12345;
  private Random random = new Random(seed);

  public int generateRandomId()
  {
    return this.random.Next();
  }
}
