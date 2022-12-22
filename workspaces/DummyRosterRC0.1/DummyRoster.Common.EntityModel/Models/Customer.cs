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
  [RegularExpression(@"[a-zA-Z0-9\s\-]{1,32}")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "DATETIME")]
  public DateTime? FoundationDate { get; set; }

  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,63})$")]
  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "varchar(8)")]
  public string? Belonging { get; set; }

  [Column(TypeName = "INT")]
  public int? Contact { get; set; }

  [Column(TypeName = "INT")]
  public int? Loc { get; set; }

  [Column(TypeName = "INT")]
  public int? Ref { get; set; }

  [ForeignKey("Contact")]
  [InverseProperty("Customers")]
  public virtual Employee? ContactNavigation { get; set; }

  [InverseProperty("Customer")]
  public virtual ICollection<Form> Forms { get; } = new List<Form>();

  [ForeignKey("Loc")]
  [InverseProperty("Customers")]
  public virtual Address? LocNavigation { get; set; }

  [ForeignKey("Ref")]
  [InverseProperty("Customers")]
  public virtual Credential? RefNavigation { get; set; }
}
