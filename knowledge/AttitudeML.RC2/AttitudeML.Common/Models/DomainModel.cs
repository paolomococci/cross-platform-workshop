namespace AttitudeML.Common.Models;

public class DomainModel
{
  public int Sentiment { get; set; } = 0;
  public string Comment { get; set; } = string.Empty;
  public bool Logged { get; set; } = false;
}
