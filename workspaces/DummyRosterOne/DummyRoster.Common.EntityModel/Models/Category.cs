﻿using System;
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
    public long Id { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    [Column(TypeName = "DATETIME")]
    public byte[]? RegistrationDate { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
