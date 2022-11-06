using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Category")]
[Index("Name", Name = "IDX_CategoryName")]
public partial class Category
{
    [Key]
    [Column(TypeName = "BIGINT")]
    [RegularExpression("[0-9]{1,9}")]
    public long Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    [RegularExpression("[a-zA-Z]{1,32}")]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
