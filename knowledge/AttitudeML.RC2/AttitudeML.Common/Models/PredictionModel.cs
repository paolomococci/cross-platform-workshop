using Microsoft.ML.Data;

namespace AttitudeML.Common.Models;

public class PredictionModel
{
  [ColumnName("Logged")]
  public bool Logged { get; set; } = false;

  [ColumnName("PredictedLabel")]
  public float PredictedLabel { get; set; } = 0.0F;

  [ColumnName("Score")]
  public float Score { get; set; } = 0.0F;
}
