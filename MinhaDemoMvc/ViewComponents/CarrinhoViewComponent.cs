using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinhaDemoMvc.ViewComponents
{
    [ViewComponent(Name = "Carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        
        public int ItensCarrinho { get; set; }

        //Simula buscar os itens em um carrinho de compras de uma tabela no banco
        public CarrinhoViewComponent()
        {
            ItensCarrinho = 3;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensCarrinho);
        }
    }
}