﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Supplier")]
[Index("Name", Name = "IDX_SupplierName")]
public partial class Supplier
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  [RegularExpression(@"[a-zA-Z0-9\s\-]{1,32}")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "DATETIME")]
  public DateTime? FoundationDate { get; set; }

  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,63})$")]
  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "varchar(8)")]
  [RegularExpression(@"[A-Z\-]{1,8}")]
  public string? Belonging { get; set; }

  [Column(TypeName = "INT")]
  public int? Contact { get; set; }

  [Column(TypeName = "INT")]
  public int? Loc { get; set; }

  [Column(TypeName = "INT")]
  public int? Ref { get; set; }

  [ForeignKey("Contact")]
  [InverseProperty("Suppliers")]
  public virtual Employee? ContactNavigation { get; set; }

  [ForeignKey("Loc")]
  [InverseProperty("Suppliers")]
  public virtual Address? LocNavigation { get; set; }

  [InverseProperty("Supplier")]
  [XmlIgnore]
  public virtual ICollection<Product> Products { get; } = new List<Product>();

  [ForeignKey("Ref")]
  [InverseProperty("Suppliers")]
  public virtual Credential? RefNavigation { get; set; }
}
