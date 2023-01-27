using Microsoft.ML.Data;

namespace Liking.Common.Models;

public class DatasetRawModel {
  
  [LoadColumn(0)]
  public bool Label { get; set; }
}
