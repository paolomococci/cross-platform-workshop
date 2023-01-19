using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Supplier")]
[Index("City", Name = "IDX_SupplierCity")]
[Index("District", Name = "IDX_SupplierDistrict")]
[Index("Name", Name = "IDX_SupplierName")]
[Index("Postcode", Name = "IDX_SupplierPostcode")]
public partial class Supplier
{
  [Key]
  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(32)")]
  [RegularExpression("[a-zA-Z]{1,32}")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "DATETIME")]
  public DateTime? FoundationDate { get; set; }

  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,63})$")]
  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "INT")]
  public int? Contact { get; set; }

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
  [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$")]
  public string? Email { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\?\d{0,2}\-?\d{7,11}")]
  public string? Phone { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\?\d{0,2}\-?\d{7,11}")]
  public string? Fax { get; set; }

  [ForeignKey("Contact")]
  [InverseProperty("Suppliers")]
  public virtual Employee? ContactNavigation { get; set; }

  [InverseProperty("Supplier")]
  public virtual ICollection<Product> Products { get; } = new List<Product>();

  private const int seed = 2147483647;
  private Random random = new Random(seed);

  public int generateRandomId()
  {
    return this.random.Next();
  }
}
