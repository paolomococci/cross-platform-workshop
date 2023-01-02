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
    items.Add(new ItemModel());
    items.Add(new ItemModel());
    items.Add(new ItemModel());
    items.Add(new ItemModel());
    items.Add(new ItemModel());
    items.Add(new ItemModel());
    items.Add(new ItemModel());
  }
}
