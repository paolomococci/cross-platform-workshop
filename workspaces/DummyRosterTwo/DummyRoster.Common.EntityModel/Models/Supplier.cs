using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Supplier")]
[Index("City", Name = "IDX_SupplierCity")]
[Index("District", Name = "IDX_SupplierDistrict")]
[Index("Name", Name = "IDX_SupplierName")]
[Index("Postcode", Name = "IDX_SupplierPostcode")]
public partial class Supplier
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "DATETIME")]
    public DateTime? FoundationDate { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "INT")]
    public int? Contact { get; set; }

    [Column(TypeName = "varchar(64)")]
    public string? Address { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? City { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? District { get; set; }

    [Column(TypeName = "varchar(8)")]
    public string? Postcode { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? Country { get; set; }

    [Column(TypeName = "varchar(48)")]
    public string? Email { get; set; }

    [Column(TypeName = "varchar(24)")]
    public string? Phone { get; set; }

    [Column(TypeName = "varchar(24)")]
    public string? Fax { get; set; }

    [ForeignKey("Contact")]
    [InverseProperty("Suppliers")]
    public virtual Employee? ContactNavigation { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
