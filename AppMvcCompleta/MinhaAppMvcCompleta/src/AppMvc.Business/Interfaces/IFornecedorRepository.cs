using AppMvcBasica.Models;
using System;
using System.Threading.Tasks;

namespace AppMvc.Business.Interfaces
{
    public interface IFornecedorRepository: IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id);
    }
}
