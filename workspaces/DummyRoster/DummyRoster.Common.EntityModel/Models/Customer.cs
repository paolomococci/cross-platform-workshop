﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Customer")]
[Index("City", Name = "IDX_CustomerCity")]
[Index("District", Name = "IDX_CustomerDistrict")]
[Index("Name", Name = "IDX_CustomerName")]
[Index("Postcode", Name = "IDX_CustomerPostcode")]
public partial class Customer
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

    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{,9}")]
    public long? Contact { get; set; }

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
    [InverseProperty("Customers")]
    public virtual Employee? ContactNavigation { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Form> Forms { get; } = new List<Form>();
}
