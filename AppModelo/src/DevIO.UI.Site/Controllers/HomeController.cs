using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevIO.UI.Site.Models;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Services;
using System;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public OperacaoService _operacaoService {get; }
        public OperacaoService _operacaoService2 {get; }


        public HomeController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            _operacaoService  = operacaoService;
            _operacaoService2 = operacaoService2;
        }

        // private readonly IPedidoRepository _pedidoRepository;

        // public HomeController(IPedidoRepository pedidoRepository)
        // {
        //     _pedidoRepository = pedidoRepository;
        // }

        //****** Não é recomendado ******
        //Caso vocẽ não consiga alterar o construtor
        //outra maneira é injetar dependência é direto no método.
        //public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
        //*******************************

        // public IActionResult Index()
        // {
        //     // var pedido = _pedidoRepository.ObterPedido();

        //     // return View();
        // }

        public string Index()
        {
            // var pedido = _pedidoRepository.ObterPedido();

            // return View();

            return
                    "Primeira Instância: " + Environment.NewLine +
                    _operacaoService.Transient.OperacaoId + Environment.NewLine +
                    _operacaoService.Scoped.OperacaoId + Environment.NewLine +
                    _operacaoService.Singleton.OperacaoId + Environment.NewLine +
                    _operacaoService.SingletonInstace.OperacaoId + Environment.NewLine +

                    Environment.NewLine +
                    Environment.NewLine +

                    "Segunda Instância: " + Environment.NewLine +
                    _operacaoService2.Transient.OperacaoId + Environment.NewLine +
                    _operacaoService2.Scoped.OperacaoId + Environment.NewLine +
                    _operacaoService2.Singleton.OperacaoId + Environment.NewLine +
                    _operacaoService2.SingletonInstace.OperacaoId + Environment.NewLine;

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
    }
}
