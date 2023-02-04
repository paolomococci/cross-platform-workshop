using Microsoft.ML.Data;

namespace AttitudeML.Common.Models;

public class PredictionModel
{

  [ColumnName("Score")]
  public float Score { get; set; } = 0.0F;
}
