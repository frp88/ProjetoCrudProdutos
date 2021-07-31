using System;

namespace ProjetoCrudProdutos.Domain {
    public class Produto {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        
        private decimal _valor;
        public decimal Valor {
            get { return _valor; }
            // Implementação para o valor do produto não ser negativo
            set { _valor = value < 0 ? 0 : value; }
        }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Produto() {
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Produto(string nome, int estoque, decimal valor) {
            Id = null;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void AtualizarProduto(string nome, int estoque, decimal valor) {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataAtualizacao = DateTime.Now;
        }
    }
}
