﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Supplier")]
[Index("Name", Name = "IDX_SupplierName")]
public partial class Supplier
{
    [Key]
    public long Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "DATETIME")]
    public byte[]? FoundationDate { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "INT")]
    public long? Contact { get; set; }

    [Column(TypeName = "INT")]
    public long? Location { get; set; }

    [ForeignKey("Contact")]
    [InverseProperty("Suppliers")]
    public virtual Employee? ContactNavigation { get; set; }

    [ForeignKey("Location")]
    [InverseProperty("Suppliers")]
    public virtual Address? LocationNavigation { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
