namespace PetLibrary;
public class Pet : object, IComparable<Pet?>
{
  public Guid? Id { get; set; }
  public string? Owned { get; set; }
  public string? Name { get; set; }
  public string? Parents { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public Cub Progeny = new();
  public event EventHandler? Caress;
  public int DocilityLevel;

  public static Pet? Procreate(
    Pet mom,
    Pet dad
  ) {
    Pet newborn = new() 
    {
      Id = Guid.NewGuid(),
      Parents = $"cub of {mom.Name} and {dad.Name}",
      DateOfBirth = DateTime.Today
    };
    mom.Progeny.Progeny.Add(newborn);
    dad.Progeny.Progeny.Add(newborn);
    return newborn;
  }

  public Pet? ProcreateWith() {
    return null;
  }

  public static int? Factorial() {
    return null;
  }

  public void Cuddles() { }

  public void Adoption() {}

  public int CompareTo(Pet? other) {
    return 1;
  }

  public void Weaning(DateTime when) {}

  public override string? ToString() {
    return base.ToString();
  }
}
