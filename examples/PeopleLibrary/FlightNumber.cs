namespace Sample.Shared;
public record FlightPlan
{
    public int Id { get; init; }
    public string? Company { get; set; } = "someone";
    public string? Brand { get; set; } = "someone";
    public int? Armchairs { get; set; } = 0;
    public int? Berths { get; set; } = 0;
}
