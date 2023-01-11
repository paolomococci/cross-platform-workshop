namespace Pivot.Mvc.Feather.Models;

public record CoordsModel
{
  public DateTime Session { get; set; }
  public List<int>? HyperDots { get; set; }

  public CoordsModel(DateTime session)
  {
    this.Session = session;
  }

  public CoordsModel(
    DateTime session,
    List<int> hyperDots
  )
  {
    this.Session = session;
    this.HyperDots = hyperDots;
  }
}
