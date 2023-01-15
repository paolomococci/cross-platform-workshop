using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using Pivot.Mvc.Feather.Models;
using ClosedXML.Excel;

namespace Pivot.Mvc.Feather.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;

  public HomeController(
    ILogger<HomeController> logger,
    IWebHostEnvironment webHostEnvironment
  )
  {
    _logger = logger;
    this.webHostEnvironment = webHostEnvironment;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Upload()
  {
    return View(new PostModel());
  }

  [HttpPost]
  public IActionResult Upload(PostModel postModel)
  {
    if (postModel.Caption != null && postModel.Description != null && postModel.Concept != null)
    {
      var caption = postModel.Caption;
      var description = postModel.Description;
      var concept = postModel.Concept;
      var conceptName = Path.GetFileName(concept.FileName);
      var conceptContentType = concept.ContentType;
      var unique = this.AppendDateTime(conceptName);
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/datasets"
      );
      var path = Path.Combine(upload, unique);
      postModel.Concept.CopyTo(
        new FileStream(path, FileMode.Create)
      );
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  public IActionResult Uploaded()
  {
    List<string> listOfUploadedDataset = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/datasets"
      );
    var uploadedFiles = Directory.GetFiles(store);
    foreach (var item in uploadedFiles)
    {
      var itemName = Path.GetFileName(item);
      listOfUploadedDataset.Add(itemName);
      ViewData["datasetList"] = listOfUploadedDataset;
    }
    return View();
  }

  [HttpPost]
  public IActionResult Process(string unique)
  {
    if (unique != null && unique != string.Empty)
    {
      var environmentPath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/datasets"
      );
      string path = Path.Combine(environmentPath, unique);
      var workBook = this.DataCollection(path);
      // compiling a workbook in .xlsx format using the data just collected
      XLWorkbook xLWorkbook = new();
      foreach (var worksheet in workBook.SheetBinder)
      {
        var currentWorkSheet = xLWorkbook.Worksheets.Add(worksheet.Id);
        currentWorkSheet.Cell(1, 1).InsertData(this.SetDataTable(worksheet));
      }
      // save Ledger Workbook
      var workbooksPath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
      workbooksPath = Path.Combine(
        workbooksPath,
        this.AppendDateTime("Ledger.xlsx")
      );
      xLWorkbook.SaveAs(
        workbooksPath
      );
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(
      new ErrorViewModel
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      }
    );
  }

  private string AppendDateTime(string file)
  {
    var name = Path.GetFileName(file);
    return Path.GetFileNameWithoutExtension(name) + $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" + Path.GetExtension(name);
  }

  private WorkbookModel DataCollection(string path)
  {
    WorkbookModel workbook = new();
    AssetModel assetModel = new();
    foreach (string line in System.IO.File.ReadLines(path))
    {
      var subdivided = this.SplitLineOfData(line);
      if (assetModel.ItWasNotAdded(subdivided[1]))
      {
        workbook.Initialize(subdivided);
      }
      else
      {
        workbook.Sift(subdivided);
      }
    }
    return workbook;
  }

  private string[] SplitLineOfData(string line)
  {
    return line.Split('\t');
  }

  private DataTable SetDataTable(DataSheetModel worksheet) {
    DataTable dataTable = new();
    dataTable.Columns.Add("Session", typeof(DateTime));
    dataTable.Columns.Add("DotOne", typeof(int));
    dataTable.Columns.Add("DotTwo", typeof(int));
    dataTable.Columns.Add("DotThree", typeof(int));
    dataTable.Columns.Add("DotFour", typeof(int));
    dataTable.Columns.Add("DotFive", typeof(int));
    worksheet.Items.ForEach(
      item => {
        if (item.HyperDots != null)
        {
          dataTable.Rows.Add(
          item.Session,
          item.HyperDots[0],
          item.HyperDots[1],
          item.HyperDots[2],
          item.HyperDots[3],
          item.HyperDots[4]
        );
        }
      }
    );
    return dataTable;
  }
}
