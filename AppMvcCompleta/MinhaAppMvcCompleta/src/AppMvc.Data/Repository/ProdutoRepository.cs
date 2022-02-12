using AppMvc.Business.Interfaces;
using AppMvc.Data.Context;
using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppMvcContext context) : base(context)
        {

        }

        public async Task<Produto> ObterProdutoFornecedor(Guid Id)
        {
            return await Context.Produtos.AsNoTracking()
                                         .Include(f => f.Fornecedor)
                                         .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Context.Produtos.AsNoTracking()
                                         .Include(f => f.Fornecedor)
                                         .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
