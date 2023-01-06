namespace Sample.Shared;
public class TouristClass
{
    public double CostAdditionalBaggage { get; set; }

    public override string ToString()
    {
        return $"tourist class with {CostAdditionalBaggage:N2} Kg carry on weight";
    }
}
