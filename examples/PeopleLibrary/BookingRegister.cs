namespace Sample.Shared;
public class PersonalBooking
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public record Pet
{
    string Name;
    string Species;

    public Pet(
        string name,
        string species
    )
    {
        Name = name;
        Species = species;
    }

    public void Deconstruct(
        out string name,
        out string species
    )
    {
        name = Name;
        species = Species;
    }
}

public record Animal(
    string Name,
    string Species
);
