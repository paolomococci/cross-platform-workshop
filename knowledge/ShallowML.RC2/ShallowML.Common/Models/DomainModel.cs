using Microsoft.ML.Data;

namespace ShallowML.Common.Models;

[Serializable]
public class DomainModel
{

  [LoadColumn(0)]
  public float Area { get; set; } = 0.0F;

  [LoadColumn(1)]
  public float Price { get; set; } = 0.0F;
}
