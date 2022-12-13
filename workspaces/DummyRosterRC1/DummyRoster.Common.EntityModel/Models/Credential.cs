﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Credential")]
[Index("Email", Name = "IDX_CredentialEmail")]
public partial class Credential
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(48)")]
  [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$")]
  public string? Email { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
  public string? Phone { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
  public string? Fax { get; set; }

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
