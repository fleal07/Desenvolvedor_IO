using Microsoft.AspNetCore.Mvc;
using MinhaDemoMvc.Models;

namespace MinhaDemoMvc.Controllers
{

    public class FilmeController : Controller
    {

        [HttpGet]
        public IActionResult Adicionar()
        {
            //Não precisa retornar View("Adicionar")
            //Pois já temos a view com o mesmo nome do método
            return View();
        }
        
        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            if(ModelState.IsValid)
            {

            }
            
            return View(filme);
        }
        
    }
    
}