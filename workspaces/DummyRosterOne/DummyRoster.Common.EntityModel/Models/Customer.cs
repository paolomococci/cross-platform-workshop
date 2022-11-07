﻿using System.ComponentModel.DataAnnotations;
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
    [Range(1, 18446744073709551615)]
    public UInt64 Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(32)")]
    [RegularExpression("[a-zA-Z]{1,32}")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "DATETIME")]
    public DateTime? FoundationDate { get; set; }

    [RegularExpression(@"^([A-Z]{1,}+[a-zA-Z0-9\s\.\,]{1,63})$")]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "BIGINT")]
    public long? Contact { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? RegistrationDate { get; set; }

    [Column(TypeName = "varchar(64)")]
    [RegularExpression(@"[a-zA-Z0-9\s\-\,\.]{3,64}")]
    public string? Address { get; set; }

    [Column(TypeName = "varchar(16)")]
    [RegularExpression(@"[a-zA-Z\s\-]{3,16}")]
    public string? City { get; set; }

    [Column(TypeName = "varchar(16)")]
    [RegularExpression(@"[a-zA-Z0-9\s\-]{3,16}")]
    public string? District { get; set; }

    [Column(TypeName = "varchar(8)")]
    [RegularExpression("[a-zA-Z0-9]{1,8}")]
    public string? Postcode { get; set; }

    [Column(TypeName = "varchar(16)")]
    [RegularExpression(@"[a-zA-Z\-]{3,16}")]
    public string? Country { get; set; }

    [Column(TypeName = "varchar(48)")]
    [RegularExpression(@"^([a-zA-Z0-9\.\-]{2,27}+@+[a-zA-Z0-9\.]{2,20})$")]
    public string? Email { get; set; }

    [Column(TypeName = "varchar(24)")]
    [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
    public string? Phone { get; set; }

    [Column(TypeName = "varchar(24)")]
    [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
    public string? Fax { get; set; }

    [ForeignKey("Contact")]
    [InverseProperty("Customers")]
    public virtual Employee? ContactNavigation { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Form> Forms { get; } = new List<Form>();
}
