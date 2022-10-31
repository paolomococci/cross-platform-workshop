namespace PetLibrary;
public class Pet
{
  public string Id { get; init; } = "";
  public string? Name { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public Cub? Progeny { get; set; }

  public static Pet? Procreate() {
    return null;
  }

  public Pet? ProcreateWith() {
    return null;
  }
}
