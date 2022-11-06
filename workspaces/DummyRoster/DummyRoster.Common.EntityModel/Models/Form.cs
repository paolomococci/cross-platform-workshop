using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Form")]
[Index("CarrierId", Name = "IDX_CarrierId")]
[Index("CustomerId", Name = "IDX_CustomerId")]
[Index("EmployeeId", Name = "IDX_EmployeeId")]
[Index("FormDate", Name = "IDX_FormDate")]
[Index("Id", Name = "IDX_FormId")]
[Index("PromisedDate", Name = "IDX_PromisedDate")]
[Index("RequiredDate", Name = "IDX_RequiredDate")]
public partial class Form
{
    [Key]
    [Column(TypeName = "BIGINT")]
    [Range(1, 18446744073709551615)]
    public UInt64 Id { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "BIGINT")]
    [Range(1, 18446744073709551615)]
    public UInt64? CustomerId { get; set; }

    [Column(TypeName = "BIGINT")]
    [Range(1, 18446744073709551615)]
    public UInt64? CarrierId { get; set; }

    [Column(TypeName = "BIGINT")]
    [Range(1, 18446744073709551615)]
    public UInt64? EmployeeId { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? FormDate { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? RequiredDate { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? PromisedDate { get; set; }

    public decimal? ShippingCost { get; set; }

    [ForeignKey("CarrierId")]
    [InverseProperty("Forms")]
    public virtual Carrier? Carrier { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Forms")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Forms")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("Form")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
