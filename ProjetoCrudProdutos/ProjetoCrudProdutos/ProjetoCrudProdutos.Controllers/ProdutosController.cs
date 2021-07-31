using Microsoft.AspNetCore.Mvc;
using ProjetoCrudProdutos.Domain;
using ProjetoCrudProdutos.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoCrudProdutos.Data;

namespace ProjetoCrudProdutos.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase {

        private readonly ProdutosContext _produtosContext;

        #region CONSTRUTOR
        public ProdutosController(ProdutosContext produtosContext) {
            this._produtosContext = produtosContext;

            // Verifica se já tem produtos cadastrados na tabela do BD
            int totalProdutosCadastrados = _produtosContext.Produtos.Count();
            if (totalProdutosCadastrados == 0) {
                // Retorna 5 produtos criados previamente na classe em que foi implementado o padrão "Singleton"
                List<Produto> listaProdutos = CriaProdutosSingleton.ProdutosCriados();
                foreach (Produto produto in listaProdutos) {
                    // Salva cada Produto na tabela do BD
                    _produtosContext.Add(produto);
                    _produtosContext.SaveChanges();
                }
            }
        }
        #endregion

        #region APIs
        // GET: api/produtos
        [HttpGet]
        public IActionResult Get() {
            //    return _produtosRepository.BuscarTodos();
            var produtos = _produtosContext.Produtos; ;
            return Ok(produtos);
        }

        // GET api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            //var produto = _produtosRepository.Buscar(id);
            var produto = _produtosContext.Produtos.FirstOrDefault(
                        p => p.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // GET api/produtos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public IActionResult Get(string nome) {
            //var produtos = _produtosRepository.BuscarPorNome(id);
            var produtos = _produtosContext.Produtos.Where(
                 p => p.Nome.Contains(nome));
            
            if (produtos == null || produtos.ToList().Count == 0)
                return NotFound();

            return Ok(produtos);
        }

        // GET: api/produtos/ordenar/{ordenarPor}
        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult Get(string ordenarPor, string crescenteOuDescrescente) {

            char ordem = (string.IsNullOrEmpty(crescenteOuDescrescente) ? 'C' : crescenteOuDescrescente.ToUpper()[0]);
            switch (ordenarPor) {
                case "nome":
                    return Ok(ordem == 'D' ? _produtosContext.Produtos.OrderByDescending(p => p.Nome) : _produtosContext.Produtos.OrderBy(p => p.Nome));
                case "estoque":
                    return Ok(ordem == 'D' ? _produtosContext.Produtos.OrderByDescending(p => p.Estoque) : _produtosContext.Produtos.OrderBy(p => p.Estoque));
                case "valor":
                    return Ok(ordem == 'D' ? _produtosContext.Produtos.OrderByDescending(p => p.Valor) : _produtosContext.Produtos.OrderBy(p => p.Valor));
                default:
                    return Ok(ordem == 'D' ? _produtosContext.Produtos.OrderByDescending(p => p.Id) : _produtosContext.Produtos.OrderBy(p => p.Id));
            }
        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto) {

            var produto = new Produto(novoProduto.Nome, novoProduto.Estoque, novoProduto.Valor);

            // _produtosRepository.Adicionar(produto);

            // Salva o Produto no BD
            _produtosContext.Add(produto);
            _produtosContext.SaveChanges();

            //return produto;
            return Created("", produto);
        }

        // PUT api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Produto produtoAtualizado) {
            //var produto = _produtosRepository.BuscarPorId(id);
            var produto = _produtosContext.Produtos.FirstOrDefault(
                   p => p.Id == id);

            if (produto == null)
                return NotFound();

            produto.AtualizarProduto(produtoAtualizado.Nome, produtoAtualizado.Estoque, produtoAtualizado.Valor);

            //_produtosRepository.Atualizar(produto);
            _produtosContext.Update(produto);
            // Atualiza o Produto no BD
            _produtosContext.SaveChanges();

            return Ok(produto);
        }

        // DELETE api/produtos/{id}
        [HttpDelete("{id}")]
        //public Produto Delete(long id) {
        public IActionResult Delete(long id) {
            //var produto = _produtosRepository.BuscarPorId(id);
            var produto = _produtosContext.Produtos.FirstOrDefault(
                   p => p.Id == id);

            if (produto == null)
                return NotFound();

            //_produtosRepository.Remover(produto);
            _produtosContext.Remove(produto);
            // Atualiza o Produto no BD
            _produtosContext.SaveChanges();

            //return produto;
            return NoContent();
        }
        #endregion
    }
}
