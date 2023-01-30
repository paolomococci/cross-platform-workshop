using Microsoft.ML.Data;

namespace Liking.Common.Probes;

public class ConsoleProbe
{
  public static void BinaryClassificationMetricsProbe(
    string? name,
    CalibratedBinaryClassificationMetrics calibratedBinaryClassificationMetrics
  )
  {
    System.Console.WriteLine("________________________________________________________________________________________________");
    System.Console.WriteLine();
    System.Console.WriteLine($"Metrics: {name} Binary Classification Metrics");
    System.Console.WriteLine("________________________________________________________________________________________________");
    System.Console.WriteLine($"Accuracy:___________________________________ {calibratedBinaryClassificationMetrics.Accuracy:P3}");
    System.Console.WriteLine($"Area Under Roc Curve:_______________________ {calibratedBinaryClassificationMetrics.AreaUnderRocCurve:P3}");
    System.Console.WriteLine($"Area Under Precision Recall Curve:__________ {calibratedBinaryClassificationMetrics.AreaUnderPrecisionRecallCurve:P3}");
    System.Console.WriteLine($"F1 Score:___________________________________ {calibratedBinaryClassificationMetrics.F1Score:P3}");
    System.Console.WriteLine($"Log Loss:___________________________________ {calibratedBinaryClassificationMetrics.LogLoss:#.###}");
    System.Console.WriteLine($"Log Loss Reduction:_________________________ {calibratedBinaryClassificationMetrics.LogLossReduction:#.###}");
    System.Console.WriteLine($"Positive Precision:_________________________ {calibratedBinaryClassificationMetrics.PositivePrecision:#.###}");
    System.Console.WriteLine($"Positive Recall:____________________________ {calibratedBinaryClassificationMetrics.PositiveRecall:#.###}");
    System.Console.WriteLine($"Negative Precision:_________________________ {calibratedBinaryClassificationMetrics.NegativePrecision:#.###}");
    System.Console.WriteLine($"Negative Recall:____________________________ {calibratedBinaryClassificationMetrics.NegativeRecall:P3}");
    System.Console.WriteLine();
    System.Console.WriteLine("________________________________________________________________________________________________");
  }
}
