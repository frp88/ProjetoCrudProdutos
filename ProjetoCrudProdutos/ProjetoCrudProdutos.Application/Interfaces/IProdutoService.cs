using ProjetoCrudProdutos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCrudProdutos.Application {
    public interface IProdutoService {
        bool temProdutosNoDb();

        void SalvaCincoProdutosNoDb();

        IEnumerable<Produto> Buscar();

        Produto BuscarPorId(long id);

        IEnumerable<Produto> BuscarPorNome(string nome);

        IEnumerable<Produto> OrdenarProdutos(string ordenarPor, string crescenteOuDescrescente);

        Produto Adicionar(Produto novoProduto);

        Produto Atualizar(long id, Produto produtoAtualizado);

        bool Remover(long id);

    }
}
