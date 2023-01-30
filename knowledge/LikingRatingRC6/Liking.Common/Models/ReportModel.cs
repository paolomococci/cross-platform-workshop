namespace Liking.Common.Models;

public class ReportModel {
  public string Name { get; set; } = string.Empty;
  public string Accuracy { get; set; } = string.Empty;
  public string AreaUnderRocCurve { get; set; } = string.Empty;
  public string AreaUnderPrecisionRecallCurve { get; set; } = string.Empty;
  public string F1Score { get; set; } = string.Empty;
  public string LogLoss { get; set; } = string.Empty;
  public string LogLossReduction { get; set; } = string.Empty;
  public string PositivePrecision { get; set; } = string.Empty;
  public string PositiveRecall { get; set; } = string.Empty;
}
