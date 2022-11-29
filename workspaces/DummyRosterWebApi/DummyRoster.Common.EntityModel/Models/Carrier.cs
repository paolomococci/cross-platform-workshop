﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Carrier")]
[Index("Name", Name = "IDX_CarrierName")]
public partial class Carrier
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "DATETIME")]
    public byte[]? FoundationDate { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "INT")]
    public int? Contact { get; set; }

    [Column(TypeName = "INT")]
    public int? Location { get; set; }

    [ForeignKey("Contact")]
    [InverseProperty("Carriers")]
    public virtual Employee? ContactNavigation { get; set; }

    [InverseProperty("Carrier")]
    public virtual ICollection<Form> Forms { get; } = new List<Form>();

    [ForeignKey("Location")]
    [InverseProperty("Carriers")]
    public virtual Address? LocationNavigation { get; set; }
}
