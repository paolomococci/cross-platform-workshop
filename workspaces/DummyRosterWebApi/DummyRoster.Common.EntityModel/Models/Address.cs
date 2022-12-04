using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Address")]
[Index("City", Name = "IDX_AddressCity")]
[Index("Country", Name = "IDX_AddressCountry")]
[Index("District", Name = "IDX_AddressDistrict")]
[Index("Postcode", Name = "IDX_AddressPostcode")]
public partial class Address
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string? StreetOrSquare { get; set; }

  [Column(TypeName = "varchar(16)")]
  public string? Civic { get; set; }

  [Column(TypeName = "varchar(16)")]
  public string? City { get; set; }

  [Column(TypeName = "varchar(16)")]
  public string? District { get; set; }

  [Column(TypeName = "varchar(8)")]
  public string? Postcode { get; set; }

  [Column(TypeName = "varchar(16)")]
  public string? Country { get; set; }

  [Column(TypeName = "varchar(48)")]
  public string? Email { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? Phone { get; set; }

  [Column(TypeName = "varchar(24)")]
  public string? Fax { get; set; }

  [InverseProperty("LocationNavigation")]
  [XmlIgnore]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("LocationNavigation")]
  [XmlIgnore]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("LocationNavigation")]
  [XmlIgnore]
  public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

  [InverseProperty("LocationNavigation")]
  [XmlIgnore]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
