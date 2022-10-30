namespace Sample.Shared;
public record FlightPlan
{
    public int Id { get; init; }
    public string? Company { get; init; }
    public string? Brand { get; init; }
    public int? Armchairs { get; init; }
    public int? Berths { get; init; }
}
