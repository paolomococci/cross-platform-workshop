using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace DummyRoster.Common.EntityModel.Models;

[Table("Employee")]
[Index("Name", Name = "IDX_EmployeeName")]
public partial class Employee
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string Name { get; set; } = null!;

  [Column(TypeName = "DATETIME")]
  public DateTime? BirthDate { get; set; }

  public string? Description { get; set; }

  public byte[]? Picture { get; set; }

  [Column(TypeName = "varchar(32)")]
  public string? Role { get; set; }

  [Column(TypeName = "INT")]
  public int? Location { get; set; }

  [InverseProperty("ContactNavigation")]
  [XmlIgnore]
  public virtual ICollection<Carrier> Carriers { get; } = new List<Carrier>();

  [InverseProperty("ContactNavigation")]
  [XmlIgnore]
  public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

  [InverseProperty("Employee")]
  [XmlIgnore]
  public virtual ICollection<Form> Forms { get; } = new List<Form>();

  [ForeignKey("Location")]
  [InverseProperty("Employees")]
  public virtual Address? LocationNavigation { get; set; }

  [InverseProperty("ContactNavigation")]
  [XmlIgnore]
  public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
