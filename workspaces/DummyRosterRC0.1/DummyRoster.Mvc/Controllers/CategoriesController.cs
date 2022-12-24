using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class CategoriesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/categories";
  private readonly ILogger<CategoriesController> _logger;
  private readonly HttpClient httpClient;

  public CategoriesController(
    ILogger<CategoriesController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    HttpClientHandler httpClientHandler = new HttpClientHandler();
    httpClientHandler.ServerCertificateCustomValidationCallback += (
      sender,
      certificate,
      chain,
      error
    ) =>
    {
      return true;
    };
    this.httpClient = new HttpClient(httpClientHandler);
  }
}
