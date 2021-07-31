using System.Collections.Generic;
using ProjetoCrudProdutos.Models;

namespace ProjetoCrudProdutos.Data.Repositories {
    public interface IProdutosRepository {
        void Adicionar(Produto produto);
        
        IEnumerable<Produto> Buscar();

        Produto BuscarPorId(long id);
        
        IEnumerable<Produto> BuscarPorNome(string nome);

        IEnumerable<Produto> BuscarOrdenado(string ordenadoPor, string ordem);

        void Atualizar(string id, Produto produtoAtualizado);

        void Remover(string id);
    }
}
