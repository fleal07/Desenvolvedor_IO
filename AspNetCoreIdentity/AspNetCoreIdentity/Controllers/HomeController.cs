using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize] //Autenticação somente
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            throw new Exception("erro");
            return View();
        }

        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "Ler")]
        public IActionResult SecretClaimPolicy()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult SecretClaimCustom()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Menssagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelError.Titulo = "Ocorreu um erro!";
                modelError.ErroCode = id;
            }
            else if (id == 404)
            {
                modelError.Menssagem = "A página que está procurando não existe!<br /> Em caso de dúvida entre em contato com nosso suporte.";
                modelError.Titulo = "Ops! Página não encontrada.";
                modelError.ErroCode = id;

            }
            else if (id == 403)
            {
                modelError.Menssagem = "Você não tem permissão para realizar esta operação.";
                modelError.Titulo = "Acesso Negado!";
                modelError.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error",modelError);
        }
    }
}
