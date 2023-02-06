using Microsoft.ML.Data;

namespace AttitudeML.Common.Models;

public class DomainModel
{
  [LoadColumn(0)]
  [ColumnName(@"Sentiment")]
  public int Sentiment { get; set; } = 0;

  [LoadColumn(1)]
  [ColumnName(@"Comment")]
  public string Comment { get; set; } = string.Empty;
  
  public bool Logged { get; set; } = false;
}
