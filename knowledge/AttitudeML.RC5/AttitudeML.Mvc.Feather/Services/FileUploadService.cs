namespace AttitudeML.Mvc.Feather.Services;

public class FileUploadService
{
  public static async Task<bool> UploadFile(
    IFormFile formFile,
    string datasetPath
  )
  {
    try
    {
      if (formFile.Length > 0)
      {
        if (!Directory.Exists(datasetPath))
        {
          Directory.CreateDirectory(datasetPath);
        }
        using (var fileStream = new FileStream(
          Path.Combine(datasetPath, formFile.FileName),
          FileMode.Create
        ))
        {
          await formFile.CopyToAsync(fileStream);
        }
        return true;
      }
      else
      {
        return false;
      }
    }
    catch (System.Exception ex)
    {
      throw new Exception("File upload failed.", ex);
    }
  }
}
