namespace Pivot.Mvc.Feather.Models;

public class PostModel
{
  public string Caption { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public IFormFile? Concept { get; set; }
}
