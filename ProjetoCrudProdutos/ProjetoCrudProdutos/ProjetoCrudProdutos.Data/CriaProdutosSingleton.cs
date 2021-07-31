using ProjetoCrudProdutos.Models;
using System.Collections.Generic;

namespace ProjetoCrudProdutos.Data {
    public class CriaProdutosSingleton {

        private CriaProdutosSingleton() { }

        private static CriaProdutosSingleton _instance;
        public static CriaProdutosSingleton GetInstance() {
            if (_instance == null) {
                _instance = new CriaProdutosSingleton();
            }
            return _instance;
        }

        /// <summary>
        /// Retorna uma lista de produtos gerados previamente
        /// </summary>
        /// <returns></returns>
        public static List<Produto> ProdutosCriados() {
            List<Produto> listaProdutos = new List<Produto>();

            listaProdutos.Add(new Produto() { Nome = "Camisa Polo", Estoque = 20, Valor = (decimal)73.99 });
            listaProdutos.Add(new Produto() { Nome = "Camiseta", Estoque = 10, Valor = (decimal)47.58 });
            listaProdutos.Add(new Produto() { Nome = "Tênis", Estoque = 15, Valor = (decimal)259.23 });
            listaProdutos.Add(new Produto() { Nome = "Bermuda", Estoque = 12, Valor = (decimal)81.18 });
            listaProdutos.Add(new Produto() { Nome = "Jaqueta", Estoque = 5, Valor = (decimal)182.35 });

            return listaProdutos;
        }
    }
}
