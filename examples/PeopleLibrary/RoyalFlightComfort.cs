namespace Sample.Shared;
public class RoyalClass
{
    public int LoyaltyPoints { get; set; }

    public override string ToString()
    {
        return $"royal class with {LoyaltyPoints:N0} air miles";
    }
}
