using ClosedXML.Excel;
using Spreadsheet.WebApi.Models;

namespace Spreadsheet.WebApi.Sheet.Templates;

public class PinnedSheetTemplate
{
  internal static void Transcribe(XLWorkbook xLWorkbook)
  {
    List<ItemModel> items = new();
    items.Add(new ItemModel(
      "10111111",
      150,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10111121",
      230,
      false,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10111131",
      510,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10111321",
      240,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10145111",
      70,
      false,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10111111",
      650,
      true,
      new DateTime(2010, 2, 1)
    ));
    items.Add(new ItemModel(
      "10111121",
      105,
      true,
      new DateTime(2010, 2, 1)
    ));
    items.Add(new ItemModel(
      "10111131",
      206,
      false,
      new DateTime(2010, 2, 1)
    ));
    items.Add(new ItemModel(
      "10111321",
      451,
      true,
      new DateTime(2010, 2, 1)
    ));
    items.Add(new ItemModel(
      "10145111",
      305,
      false,
      new DateTime(2010, 2, 1)
    ));
    items.Add(new ItemModel(
      "10111111",
      560,
      true,
      new DateTime(2010, 3, 1)
    ));
    items.Add(new ItemModel(
      "10111121",
      307,
      true,
      new DateTime(2010, 3, 1)
    ));
    items.Add(new ItemModel(
      "10111131",
      412,
      false,
      new DateTime(2010, 3, 1)
    ));
    items.Add(new ItemModel(
      "10111321",
      230,
      true,
      new DateTime(2010, 3, 1)
    ));
    items.Add(new ItemModel(
      "10145111",
      505,
      false,
      new DateTime(2010, 3, 1)
    ));

    var pinnedSheet = xLWorkbook.Worksheet("PinnedSheet");
    
  }
}
