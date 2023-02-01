using Microsoft.ML.Data;

namespace ShallowML.Common.Models;

public class PredictionModel
{

  [ColumnName("Score")]
  public float Price { get; set; } = 0.0F;
}
