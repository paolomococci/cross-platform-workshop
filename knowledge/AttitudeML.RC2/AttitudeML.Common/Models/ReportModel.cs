namespace AttitudeML.Common.Models;

[Serializable]
public class ReportModel
{
  public bool Disposition { get; set; } = false;

  public string GetResponse()
  {
    return this.Disposition ? "" : "";
  }
}
