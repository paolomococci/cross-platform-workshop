﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Employee")]
[Index("Name", Name = "IDX_EmployeeName")]
public partial class Employee
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(16)")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "varchar(16)")]
  public string Surname { get; set; } = null!;

  [Column(TypeName = "varchar(16)")]
  public string? Nickname { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string? Username { get; set; }

  [Column(TypeName = "DATETIME")]
  public DateTime? BirthDate { get; set; }

  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string? Role { get; set; }

  [Column(TypeName = "varchar(8)")]
  public string? Belonging { get; set; }

  [Column(TypeName = "INT")]
  public int? Loc { get; set; }

  [Column(TypeName = "INT")]
  public int? Ref { get; set; }

  [InverseProperty("ContactNavigation")]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("ContactNavigation")]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("Employee")]
  public virtual ICollection<Form> Forms { get; } = new List<Form>();

  [ForeignKey("Loc")]
  [InverseProperty("Employees")]
  public virtual Address? LocNavigation { get; set; }

  [ForeignKey("Ref")]
  [InverseProperty("Employees")]
  public virtual Credential? RefNavigation { get; set; }

  [InverseProperty("ContactNavigation")]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
