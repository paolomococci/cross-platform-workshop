﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Employee")]
[Index("City", Name = "IDX_EmployeeCity")]
[Index("District", Name = "IDX_EmployeeDistrict")]
[Index("Name", Name = "IDX_EmployeeName")]
[Index("Postcode", Name = "IDX_EmployeePostcode")]
public partial class Employee
{
    [Key]
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{1,9}")]
    public long Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(32)")]
    [RegularExpression("[a-zA-Z]{1,32}")]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string? Role { get; set; }

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
    [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}")]
    public string? Phone { get; set; }

    [Column(TypeName = "varchar(24)")]
    public string? Fax { get; set; }

    [InverseProperty("ContactNavigation")]
    public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

    [InverseProperty("ContactNavigation")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    [InverseProperty("Employee")]
    public virtual ICollection<Form> Forms { get; } = new List<Form>();

    [InverseProperty("ContactNavigation")]
    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
