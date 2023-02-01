using Microsoft.ML.Data;

namespace Template.Common.Models;

public class DatasetCookedModel
{

  [ColumnName("Label")]
  public bool Label { get; set; } = false;

  public decimal Likelihood { get; set; } = 0.0M;

  public decimal Score { get; set; } = 0.0M;
}
