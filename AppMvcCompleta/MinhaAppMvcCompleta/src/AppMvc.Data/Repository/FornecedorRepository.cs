using AppMvc.Business.Interfaces;
using AppMvc.Data.Context;
using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMvc.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppMvcContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Context.Fornecedores.AsNoTracking()
                                             .Include(f => f.Endereco)
                                             .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id)
        {
            return await Context.Fornecedores.AsNoTracking()
                                             .Include(f => f.Produtos)
                                             .Include(f => f.Endereco)
                                             .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
