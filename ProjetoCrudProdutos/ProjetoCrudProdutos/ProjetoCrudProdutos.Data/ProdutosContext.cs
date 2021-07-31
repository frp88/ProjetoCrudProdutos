using ProjetoCrudProdutos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoCrudProdutos.Data.Context {
    public class ProdutosContext : DbContext {

        private readonly ICollection<Produto> _produtos;

        public DbSet<Produto> Produtos { get; set; }

        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options) { }

        //public void Adicionar(Produto produto) {
        //    _produtos.Add(produto);

        //}

        //public IEnumerable<Produto> BuscarTodos() {
        //    // return _produtos.Where(p => true).ToList();
        //    return Produtos;
        //}

        //public Produto? BuscarPorId(long id) {
        //    return _produtos.FirstOrDefault(p => p.Id == id);
        //    //return _produtos.Find(p >p.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome) {
        //    return _produtos.Where(p => p.Nome == nome).ToList();
        //}

        //public IEnumerable<Produto> BuscarOrdenado(string parametro) {
        //    return _produtos.Where(p => true).OrderBy(p => parametro).ToList();
        //}

        //public void Atualizar(Produto produtoAtualizado) {
        //    //_produtos.Update(produtoAtualizado);
        //}

        //public void Remover(Produto produto) {
        //    _produtos.Remove(produto);
        //}
    }
}
