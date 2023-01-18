using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Address")]
[Index("City", Name = "IDX_AddressCity")]
[Index("Country", Name = "IDX_AddressCountry")]
[Index("District", Name = "IDX_AddressDistrict")]
[Index("Name", Name = "IDX_AddressName")]
[Index("Postcode", Name = "IDX_AddressPostcode")]
public partial class Address
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,31})$")]
  public string? Name { get; set; }

  [Column(TypeName = "varchar(16)")]
  [RegularExpression(@"[a-zA-Z0-9\s\-\/]{1,16}")]
  public string? Civic { get; set; }

  [Column(TypeName = "varchar(16)")]
  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,15})$")]
  public string? City { get; set; }

  [Column(TypeName = "varchar(16)")]
  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,15})$")]
  public string? District { get; set; }

  [Column(TypeName = "varchar(8)")]
  [RegularExpression("[0-9]{1,8}")]
  public string? Postcode { get; set; }

  [Column(TypeName = "varchar(16)")]
  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,]{1,15})$")]
  public string? Country { get; set; }

  [InverseProperty("LocNavigation")]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("LocNavigation")]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("LocNavigation")]
  public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

  [InverseProperty("LocNavigation")]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
