using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[PrimaryKey("FormId", "ProductId")]
[Table("Invoice")]
[Index("ProductId", Name = "IDX_ProductId")]
public partial class Invoice
{
    public string? Note { get; set; }

    [Key]
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{1,9}")]
    public long FormId { get; set; }

    [Key]
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{1,9}")]
    public long ProductId { get; set; }

    public double UnitPrice { get; set; }

    [Column(TypeName = "SMALLINT")]
    public long Quantity { get; set; }

    public decimal PriceCut { get; set; }

    [ForeignKey("FormId")]
    [InverseProperty("Invoices")]
    public virtual Form Form { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Invoices")]
    public virtual Product Product { get; set; } = null!;
}
