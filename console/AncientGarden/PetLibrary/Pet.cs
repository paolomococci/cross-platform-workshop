namespace PetLibrary;
public class Pet : object
{
    public string Id { get; init; } = "";
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Cub? Progeny { get; set; }
    public event EventHandler? Caress;
    public int DocilityLevel;

    public static Pet? Procreate()
    {
        return null;
    }

    public Pet? ProcreateWith()
    {
        return null;
    }

    public static int? Factorial()
    {
        return null;
    }

    public void Cuddles() { }

    public int? CompareTo(Pet? other)
    {
        return null;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
