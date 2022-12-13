using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

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
  [RegularExpression(@"^([A-Z]{1,}[a-zA-Z0-9\s\.\,\/]{1,15})$")]
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

  [Column(TypeName = "varchar(48)")]
  [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$")]
  public string? Email { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
  public string? Phone { get; set; }

  [Column(TypeName = "varchar(24)")]
  [RegularExpression(@"^\+?\d{0,2}\-?\d{7,11}")]
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
