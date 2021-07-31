namespace ProjetoCrudProdutos.Domain {
    public class Produto {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        //public int EstoqueMinimo { get; private set; }
        //public decimal Valor { get; set; }

        private decimal _valor;
        public decimal Valor {
            get { return _valor; }
            // Implementação para o valor do produto não ser negativo
            set { _valor = value < 0 ? 0 : value; }
        }

        //public bool Disponivel{ get; private set; }
        //public DateTime DataCadastro { get; private set; }

        public Produto() { }

        public Produto(string nome, int estoque, decimal valor) {
            Id = null;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
        }

        public Produto(long id, string nome, int estoque, decimal valor) {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
        }

        public void AtualizarProduto(string nome, int estoque, decimal valor) {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
        }
    }
}
