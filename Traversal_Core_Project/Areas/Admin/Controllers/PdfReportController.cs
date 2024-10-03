using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    public class PdfReportController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("PdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soy Adı");
            pdfPTable.AddCell("Misafir T.C.");

            pdfPTable.AddCell("Kadir");
            pdfPTable.AddCell("Yıldız");
            pdfPTable.AddCell("12345678910");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yıldırım");
            pdfPTable.AddCell("12345678910");

            pdfPTable.AddCell("Aslı");
            pdfPTable.AddCell("Elmacık");
            pdfPTable.AddCell("12345678910"); 

            document.Add(pdfPTable);

            document.Close();
            return File("PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
