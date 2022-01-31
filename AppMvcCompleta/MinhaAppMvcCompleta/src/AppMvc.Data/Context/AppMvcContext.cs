using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Data.Context
{
    public class AppMvcContext : DbContext
    {
        public AppMvcContext(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppMvcContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
