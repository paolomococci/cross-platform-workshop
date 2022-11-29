﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Customer")]
[Index("Name", Name = "IDX_CustomerName")]
public partial class Customer
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

  [Column(TypeName = "INT")]
  public int? Location { get; set; }

  [ForeignKey("Contact")]
  [InverseProperty("Customers")]
  public virtual Employee? ContactNavigation { get; set; }

  [InverseProperty("Customer")]
  public virtual ICollection<Form> Forms { get; } = new List<Form>();

  [ForeignKey("Location")]
  [InverseProperty("Customers")]
  public virtual Address? LocationNavigation { get; set; }
}
