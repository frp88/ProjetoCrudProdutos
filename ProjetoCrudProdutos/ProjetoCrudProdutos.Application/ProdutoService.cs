using ProjetoCrudProdutos.Data.Context;
using ProjetoCrudProdutos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoCrudProdutos.Application {

    public class ProdutoService : IProdutoService {

        private readonly ProjetoCrudProdutosContext _context;               

        public ProdutoService(ProjetoCrudProdutosContext context) {
            _context = context;
            // Verifica se já tem produtos cadastrados na tabela do BD
            temProdutosNoDb();
        }

        public bool temProdutosNoDb() {
            // Verifica quantos produtos estão cadastrados na tabela do BD
            int totalProdutosCadastrados = _context.Produtos.Count();
            if (totalProdutosCadastrados == 0) {
                SalvaCincoProdutosNoDb();
                return false;
            }
            return true;
        }

        public void SalvaCincoProdutosNoDb() {
            // Retorna 5 produtos criados previamente na classe em que foi implementado o padrão "Singleton"
            List<Produto> listaProdutos = CriaProdutosSingleton.ProdutosCriados();
            foreach (Produto produto in listaProdutos) {
                // Salva cada Produto na tabela do BD
                _context.Add(produto);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Produto> Buscar() {
            var produtos = _context.Produtos;
            if (produtos == null || produtos.ToList().Count == 0)
                return null;
            return produtos;
        }

        public Produto BuscarPorId(long id) {
            //var produto = _produtosContext.BuscarPorId(id);
            var produto = _context.Produtos.FirstOrDefault(
                        p => p.Id == id);
            return produto;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome) {
            var produtos = _context.Produtos.Where(
                         p => p.Nome.Contains(nome));
            if (produtos == null || produtos.ToList().Count == 0)
                return null;
            return produtos;
        }

        public IEnumerable<Produto> OrdenarProdutos(string ordenarPor, string crescenteOuDescrescente) {
            char ordem = (string.IsNullOrEmpty(crescenteOuDescrescente) ? 'C' : crescenteOuDescrescente.ToUpper()[0]);
            switch (ordenarPor) {
                case "nome":
                    return (ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Nome) : _context.Produtos.OrderBy(p => p.Nome));
                case "estoque":
                    return (ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Estoque) : _context.Produtos.OrderBy(p => p.Estoque));
                case "valor":
                    return (ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Valor) : _context.Produtos.OrderBy(p => p.Valor));
                default:
                    return (ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Id) : _context.Produtos.OrderBy(p => p.Id));
            }
        }

        public Produto Adicionar(Produto novoProduto) {
            var produto = new Produto(novoProduto.Nome, novoProduto.Estoque, novoProduto.Valor);

            // Salva o Produto no BD
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto Atualizar(long id, Produto produtoAtualizado) {
          
            var produto = _context.Produtos.FirstOrDefault(
                p => p.Id == id);

            if (produto == null)
                return null;           

            produto.AtualizarProduto(produtoAtualizado.Nome, produtoAtualizado.Estoque, produtoAtualizado.Valor);

            _context.Update(produto);
            // Atualiza o Produto no BD
            _context.SaveChanges();

            return produto;
        }

        public bool Remover(long id) {

            var produto = _context.Produtos.FirstOrDefault(
                p => p.Id == id);

            if (produto == null)
                return false;

            _context.Remove(produto);
            // Remove o Produto do BD
            _context.SaveChanges();

            return true;
        }
    }
}
