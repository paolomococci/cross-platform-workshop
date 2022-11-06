using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Carrier")]
[Index("City", Name = "IDX_CarrierCity")]
[Index("District", Name = "IDX_CarrierDistrict")]
[Index("Name", Name = "IDX_CarrierName")]
[Index("Postcode", Name = "IDX_CarrierPostcode")]
public partial class Carrier
{
    [Key]
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{9}")]
    public long Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    [RegularExpression("[a-zA-Z]{32}")]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{9}")]
    public long? Contact { get; set; }

    [Column(TypeName = "varchar(64)")]
    public string? Address { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? City { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? District { get; set; }

    [Column(TypeName = "varchar(8)")]
    [RegularExpression("[a-zA-Z0-9]{8}")]
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
    [InverseProperty("Carriers")]
    public virtual Employee? ContactNavigation { get; set; }

    [InverseProperty("Carrier")]
    public virtual ICollection<Form> Forms { get; } = new List<Form>();
}
