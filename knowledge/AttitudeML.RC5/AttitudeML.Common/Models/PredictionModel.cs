using Microsoft.ML.Data;

namespace AttitudeML.Common.Models;

public class PredictionModel
{
  [ColumnName(@"Sentiment")]
  public int Sentiment { get; set; } = 0;

  [ColumnName(@"Comment")]
  public string Comment { get; set; } = string.Empty;

  [ColumnName(@"Registered")]
  public bool Registered { get; set; } = false;

  [ColumnName(@"PredictedLabel")]
  public float PredictedLabel { get; set; } = 0.0F;

  [ColumnName(@"Score")]
  public float Score { get; set; } = 0.0F;
}
