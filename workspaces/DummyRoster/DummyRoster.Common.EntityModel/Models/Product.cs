using System;
using System.Collections.Generic;
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
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{1,9}")]
    public long Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(32)")]
    [RegularExpression("[a-zA-Z]{1,32}")]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{,9}")]
    public long? CategoryId { get; set; }

    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{,9}")]
    public long? SupplierId { get; set; }

    [Column(TypeName = "varchar(24)")]
    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "SMALLINT")]
    public long? UnitsInStock { get; set; }

    [Column(TypeName = "SMALLINT")]
    public long? UnitsOnOrder { get; set; }

    [Column(TypeName = "SMALLINT")]
    public long? ReorderLevel { get; set; }

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
}
