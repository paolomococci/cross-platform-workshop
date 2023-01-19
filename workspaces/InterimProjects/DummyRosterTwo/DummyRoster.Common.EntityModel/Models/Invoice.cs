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
    [Column(TypeName = "INT")]
    public int FormId { get; set; }

    [Key]
    [Column(TypeName = "INT")]
    public int ProductId { get; set; }

    [Column(TypeName = "NUMERIC")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "SMALLINT")]
    public int Quantity { get; set; }

    [Column(TypeName = "NUMERIC")]
    public decimal PriceCut { get; set; }

    [ForeignKey("FormId")]
    [InverseProperty("Invoices")]
    public virtual Form Form { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Invoices")]
    public virtual Product Product { get; set; } = null!;
}
