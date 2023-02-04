using Microsoft.ML;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public MLContext? mlContext;

  public ReportModel CreateMLContext(
    DomainModel[] dataset,
    DomainModel disposition
  )
  {
    this.mlContext = new MLContext();
    /* loading dataset step */
    IDataView dataView = this.mlContext.Data.LoadFromEnumerable(dataset);

    /* create pipeline step */

    /* training step */

    /* prediction step */

    return new ReportModel()
    {
      Name = this.Id
    };
  }

  public ReportModel CreateMLContextAndSaveSchema(
    DomainModel[] dataset,
    DomainModel disposition,
    string schemePath
  )
  {
    this.mlContext = new MLContext();
    /* loading dataset step */
    IDataView dataView = this.mlContext.Data.LoadFromEnumerable(dataset);

    /* create pipeline step */

    /* training step */

    /* prediction step */

    /* persist step */

    return new ReportModel()
    {
      Name = this.Id
    };
  }
}
