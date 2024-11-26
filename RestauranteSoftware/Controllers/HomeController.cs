using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RestauranteSoftware.Models;
using System.Diagnostics;

namespace RestauranteSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConverter _converter;
        public HomeController(ILogger<HomeController> logger, IConverter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        public IActionResult VistaParaPDF()
        {
            return View();
        }

        public IActionResult DescargarPDF()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Home/VistaParaPDF";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }


       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        //public IActionResult MostrarPDFenPagina()
        //{
        //    string pagina_actual = HttpContext.Request.Path;
        //    string url_pagina = HttpContext.Request.GetEncodedUrl();
        //    url_pagina = url_pagina.Replace(pagina_actual, "");
        //    url_pagina = $"{url_pagina}/Home/VistaParaPDF";


        //    var pdf = new HtmlToPdfDocument()
        //    {
        //        GlobalSettings = new GlobalSettings()
        //        {
        //            PaperSize = PaperKind.A4,
        //            Orientation = Orientation.Portrait
        //        },
        //        Objects = {
        //            new ObjectSettings(){
        //                Page = url_pagina
        //            }
        //        }

        //    };

        //    var archivoPDF = _converter.Convert(pdf);


        //    return File(archivoPDF, "application/pdf");
        //}
    }
}
