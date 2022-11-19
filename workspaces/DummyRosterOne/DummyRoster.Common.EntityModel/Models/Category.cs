using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Category")]
[Index("Name", Name = "IDX_CategoryName")]
public partial class Category
{
  [Key]
  [Column(TypeName = "INT")]
  [Range(0, 2147483647)]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(32)")]
  [RegularExpression("[a-zA-Z]{1,32}")]
  public string Name { get; set; } = null!;

  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,63})$")]
  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "DATETIME")]
  public DateTime? RegistrationDate { get; set; }

  [InverseProperty("Category")]
  public virtual ICollection<Product> Products { get; } = new List<Product>();

  private const int seed = 31;
  private Random random = new Random(seed);

  public int generateRandomId()
  {
    return this.random.Next();
  }
}
