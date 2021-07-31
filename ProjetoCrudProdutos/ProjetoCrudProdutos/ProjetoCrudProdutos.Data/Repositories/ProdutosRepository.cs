using System;
using System.Collections.Generic;
using ProjetoCrudProdutos.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrudProdutos.Data.Repositories {
    public class ProdutosRepository : IProdutosRepository {
        //public DbSet<Produto> Produtos { get; set; }

        //public ProdutosRepository(DbContextOptions<ProdutosRepository> options) : base(options) { }


        public void Adicionar(Produto produto) {
            throw new NotImplementedException();
        }

        public void Atualizar(string id, Produto produtoAtualizado) {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Buscar() {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarOrdenado(string ordenadoPor, string ordem) {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(long id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarPorNome(string nome) {
            throw new NotImplementedException();
        }

        public void Remover(string id) {
            throw new NotImplementedException();
        }
    }
}
