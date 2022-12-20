using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Credential")]
[Index("Email", Name = "IDX_CredentialEmail")]
public partial class Credential
{
  [Key]
  public long Id { get; set; }

  [Column(TypeName = "varchar(48)")]
  public string? Email { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? Phone { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? Fax { get; set; }

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

  [InverseProperty("RefNavigation")]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
