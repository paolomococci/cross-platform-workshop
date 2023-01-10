namespace Pivot.Mvc.Feather.Models;

public record CoordsModel
{
  public DateOnly Session { get; set; }
  public List<int>? HyperDots { get; set; }

  public CoordsModel(DateOnly session) {
    this.Session = session;
  }
}
