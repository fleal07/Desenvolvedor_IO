using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaDemoMvc.Models;

namespace MinhaDemoMvc.Controllers
{
    // [Route("")]
    // [Route("gestao")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [Route("")]
        // [Route("pagina-inicial")]
        // [Route("pagina-inicial/{id:int}/{categoria:guid}")]
        public IActionResult Index(int id, Guid categoria)
        {
            // var filme  = new Filme
            // {
            //     Titulo = "Oi",
            //     DataLancamento = DateTime.Now,
            //     Genero = null,
            //     Valor = 20000,
            //     Avaliacao = 10
            // };

            // return RedirectToAction("Privacy",filme);
            return View();
        }

        // [Route("privacidade")]
        // [Route("politica-de-privacidade")]
        // public IActionResult Privacy(Filme filme)
        public IActionResult Privacy()
        {

            // if(!ModelState.IsValid)
            // {
            //     foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
            //     {
            //         Console.WriteLine(error.ErrorMessage);
            //     }
            // }

            //retorna a view
            return View();

            //retorna um json
            //return Json("{'nome':'Felipe Leal'}");

            //retorna um arquivo txt para download
            // var fileBytes = System.IO.File.ReadAllBytes(@"/home/fleal07/Documentos/arquivo_teste.txt");
            // return File(fileBytes,System.Net.Mime.MediaTypeNames.Application.Octet,"ola.txt");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
