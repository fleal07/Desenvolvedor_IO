using AppMvc.Business.Interfaces;
using AppMvc.Data.Context;
using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AppMvc.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppMvcContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Context.Enderecos.AsNoTracking()
                                          .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
