namespace Sample.Shared;
public class PersonalBooking
{

}

public record Pet {
    string Name;
    string Species;

    public Pet(
        string name,
        string species
    ) {
        Name = name;
        Species = species;
    }

    public void Deconstruct() {}
}
