using Microsoft.EntityFrameworkCore;
using ProjetoCrudProdutos.Domain;

namespace ProjetoCrudProdutos.Data.Context {
    public class ProjetoCrudProdutosContext : DbContext {
        public ProjetoCrudProdutosContext(DbContextOptions<ProjetoCrudProdutosContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
