using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TallComponents.PDF.Base.DocumentStructure;
using TallComponents.PDF.Base.Navigation;
using Base = TallComponents.PDF.Base;

namespace PdfFiddle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreatePdf(string content)
        {
            // create pdf
            Document pdf = new Document();
            Pages pages = new Pages();
            pdf.Catalog.Pages = pages;
            Page page = new Page(200, 200);
            pages.Add(page);
            Base.Graphics.Content stream = new Base.Graphics.Content(content);
            page.Contents = stream;

            ViewerPreferences prefs = new ViewerPreferences();
            Base.Array destination = new Base.Array();
            destination.Add(new Base.IndirectReference(page));
            destination.Add(new Base.Name("Fit"));
            pdf.Catalog.OpenAction = destination;

            Guid guid = Guid.NewGuid();
            string path = Server.MapPath(string.Format("~/temp/{0}.pdf", guid));
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                pdf.Write(file);
            }

            return Content(guid.ToString());
        }
    }
}