using Microsoft.AspNetCore.Mvc;
using ProjetoCrudProdutos.Application;
using ProjetoCrudProdutos.Data.Context;
using ProjetoCrudProdutos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoCrudProdutos.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase {

        private readonly ProjetoCrudProdutosContext _context;
        private ProdutosService _produtosService;
        #region CONSTRUTOR
        public ProdutosController(ProjetoCrudProdutosContext context) {
            _context = context;
            _produtosService = new ProdutosService(_context);


            //// Verifica se já tem produtos cadastrados na tabela do BD
            //int totalProdutosCadastrados = _context.Produtos.Count();
            //if (totalProdutosCadastrados == 0) {
            //    // Retorna 5 produtos criados previamente na classe em que foi implementado o padrão "Singleton"
            //    List<Produto> listaProdutos = CriaProdutosSingleton.ProdutosCriados();
            //    foreach (Produto produto in listaProdutos) {
            //        // Salva cada Produto na tabela do BD
            //        _context.Add(produto);
            //        _context.SaveChanges();
            //    }
            //}
        }
        #endregion

        #region APIs
        // GET: api/produtos
        [HttpGet]
        public IActionResult Get() {
            //var produtos = _context.Produtos;
            var produtos = _produtosService.Buscar();
            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        // GET api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            //var produto = _context.Produtos.FirstOrDefault(
            //            p => p.Id == id);
            var produto = _produtosService.BuscarPorId(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // GET api/produtos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public IActionResult Get(string nome) {
            //var produtos = _context.Produtos.Where(
            //     p => p.Nome.Contains(nome));
            //if (produtos == null || produtos.ToList().Count == 0)
            var produtos = _produtosService.BuscarPorNome(nome);
            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        // GET: api/produtos/ordenar/{ordenarPor}
        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult Get(string ordenarPor, string crescenteOuDescrescente) {
            var produtosOrdenados = _produtosService.OrdenarProdutos(ordenarPor, crescenteOuDescrescente);
            if (produtosOrdenados == null)
                return NotFound();

            return Ok(produtosOrdenados);

        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto) {
            Produto produtoAdicionado = _produtosService.Adicionar(novoProduto);
            //var produto = new Produto(novoProduto.Nome, novoProduto.Estoque, novoProduto.Valor);

            // Salva o Produto no BD
            //_context.Add(produto);
            //_context.SaveChanges();

            return Created("", produtoAdicionado);
        }

        // PUT api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Produto produtoAtualizado) {
            //var produto = _context.Produtos.FirstOrDefault(
            //      p => p.Id == id);

            //if (produto == null)
            //    return NotFound();

            //produto.AtualizarProduto(produtoAtualizado.Nome, produtoAtualizado.Estoque, produtoAtualizado.Valor);

            //_context.Update(produto);
            //// Atualiza o Produto no BD
            //_context.SaveChanges();

            produtoAtualizado = _produtosService.Atualizar(id, produtoAtualizado); 
            if (produtoAtualizado == null)
                return NotFound();

            return Ok(produtoAtualizado);
        }

        // DELETE api/produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            bool remocaoOk = _produtosService.Remover(id);
            if (remocaoOk == false)
                return NotFound();

            return NoContent();

            //var produto = _context.Produtos.FirstOrDefault(
            //       p => p.Id == id);

            //if (produto == null)
            //    return NotFound();

            //_context.Remove(produto);
            //// Remove o Produto do BD
            //_context.SaveChanges();

            //return NoContent();
        }
        #endregion
    }
}

