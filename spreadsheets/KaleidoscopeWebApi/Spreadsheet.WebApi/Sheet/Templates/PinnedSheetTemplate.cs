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
      "10111142",
      650,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10911113",
      105,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10111217",
      206,
      false,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10133311",
      451,
      true,
      new DateTime(2010, 1, 1)
    ));
    items.Add(new ItemModel(
      "10132211",
      305,
      false,
      new DateTime(2010, 1, 1)
    ));
  }
}
