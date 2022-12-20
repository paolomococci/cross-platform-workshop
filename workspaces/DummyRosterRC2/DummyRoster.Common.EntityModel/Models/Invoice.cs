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
    public long Id { get; set; }

    [Column(TypeName = "INT")]
    public long? FormId { get; set; }

    [Column(TypeName = "INT")]
    public long? ProductId { get; set; }

    [Column(TypeName = "DATETIME")]
    public byte[]? IssuingDate { get; set; }

    public string? Note { get; set; }

    [Column(TypeName = "NUMERIC")]
    public byte[] UnitPrice { get; set; } = null!;

    [Column(TypeName = "SMALLINT")]
    public long Quantity { get; set; }

    [Column(TypeName = "NUMERIC")]
    public byte[] PriceCut { get; set; } = null!;

    [ForeignKey("FormId")]
    [InverseProperty("Invoices")]
    public virtual Form? Form { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Invoices")]
    public virtual Product? Product { get; set; }
}
