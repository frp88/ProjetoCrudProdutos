using ProjetoCrudProdutos.Domain;
using System.Collections.Generic;

namespace ProjetoCrudProdutos.Application {
    public interface IProdutoService {
        bool temProdutosNoDB();

        void SalvaCincoProdutosNoDB();

        IEnumerable<Produto> Buscar();

        Produto BuscarPorId(long id);

        IEnumerable<Produto> BuscarPorNome(string nome);

        IEnumerable<Produto> OrdenarProdutos(string ordenarPor, string crescenteOuDescrescente);

        Produto Adicionar(Produto novoProduto);

        Produto Atualizar(long id, Produto produtoAtualizado);

        bool Remover(long id);

    }
}
