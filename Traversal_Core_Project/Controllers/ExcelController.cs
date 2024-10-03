using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Ink;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Traversal_Core_Project.Models;

namespace Traversal_Core_Project.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> models = new();
            using var c = new Context();
            models = c.Destinations.Select(x => new DestinationModel
            {
                City = x.City,
                LengthOfStay = x.LengthOfStay,
                Price = x.Price,
                Capacity = x.Capacity
            }).ToList();

            return models;
        }

        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
            // application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        }

        public IActionResult DestinationExcelReport()
        {
            XLWorkbook workbook = new();
            var workSheet = workbook.Worksheets.Add("Tur Listesi");
            workSheet.Cell(1, 1).Value = "Şehir";
            workSheet.Cell(1, 2).Value = "Konaklama Süresi";
            workSheet.Cell(1, 3).Value = "Fiyat";
            workSheet.Cell(1, 4).Value = "Kapasite";

            int rowCount = 2;

            foreach(var item in DestinationList())
            {
                workSheet.Cell(rowCount, 1).Value = item.City;
                workSheet.Cell(rowCount, 2).Value = item.LengthOfStay;
                workSheet.Cell(rowCount, 3).Value = item.Price;
                workSheet.Cell(rowCount, 4).Value = item.Capacity;
                rowCount++;
            }

            MemoryStream memoryStream = new();
            workbook.SaveAs(memoryStream);
            var content = memoryStream.ToArray();


            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TurListesi.xlsx");
        }
    }
}
