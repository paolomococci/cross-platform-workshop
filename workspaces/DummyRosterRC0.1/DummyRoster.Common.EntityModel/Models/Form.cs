using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Form")]
[Index("CarrierId", Name = "IDX_CarrierId")]
[Index("CustomerId", Name = "IDX_CustomerId")]
[Index("EmployeeId", Name = "IDX_EmployeeId")]
[Index("FormDate", Name = "IDX_FormDate")]
[Index("Id", Name = "IDX_FormId")]
[Index("PromisedDate", Name = "IDX_PromisedDate")]
[Index("RequiredDate", Name = "IDX_RequiredDate")]
public partial class Form
{
  [Key]
  public long Id { get; set; }

  public string? Description { get; set; }

  [Column(TypeName = "INT")]
  public long? CustomerId { get; set; }

  [Column(TypeName = "INT")]
  public long? CarrierId { get; set; }

  [Column(TypeName = "INT")]
  public long? EmployeeId { get; set; }

  [Column(TypeName = "DATETIME")]
  public byte[]? FormDate { get; set; }

  [Column(TypeName = "DATETIME")]
  public byte[]? RequiredDate { get; set; }

  [Column(TypeName = "DATETIME")]
  public byte[]? PromisedDate { get; set; }

  [Column(TypeName = "NUMERIC")]
  public byte[]? ShippingCost { get; set; }

  [ForeignKey("CarrierId")]
  [InverseProperty("Forms")]
  public virtual Carrier? Carrier { get; set; }

  [ForeignKey("CustomerId")]
  [InverseProperty("Forms")]
  public virtual Customer? Customer { get; set; }

  [ForeignKey("EmployeeId")]
  [InverseProperty("Forms")]
  public virtual Employee? Employee { get; set; }

  [InverseProperty("Form")]
  public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
