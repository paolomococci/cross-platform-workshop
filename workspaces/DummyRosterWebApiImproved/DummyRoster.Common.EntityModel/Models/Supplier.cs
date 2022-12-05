using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Supplier")]
[Index("Name", Name = "IDX_SupplierName")]
public partial class Supplier
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "DATETIME")]
  public DateTime? FoundationDate { get; set; }

  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "INT")]
  public int? Contact { get; set; }

  [Column(TypeName = "INT")]
  public int? Location { get; set; }

  [ForeignKey("Contact")]
  [InverseProperty("Suppliers")]
  public virtual Employee? ContactNavigation { get; set; }

  [ForeignKey("Location")]
  [InverseProperty("Suppliers")]
  public virtual Address? LocationNavigation { get; set; }

  [InverseProperty("Supplier")]
  [XmlIgnore]
  public virtual ICollection<Product> Products { get; } = new List<Product>();
}
