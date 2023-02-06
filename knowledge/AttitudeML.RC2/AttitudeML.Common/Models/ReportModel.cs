namespace AttitudeML.Common.Models;

[Serializable]
public class ReportModel
{
  public string Comment { get; set; } = string.Empty;
  public bool Disposition { get; set; } = false;

  public string GetResponse()
  {
    return this.Disposition ? "Unpleasant" : "Pleasant";
  }
}
