using Microsoft.ML.Data;

namespace Liking.Common.Models;

public class DatasetCookedModel
{

  [ColumnName("Label")]
  public bool Label { get; set; } = false;

  public decimal Likelihood { get; set; } = 0.0M;
}
