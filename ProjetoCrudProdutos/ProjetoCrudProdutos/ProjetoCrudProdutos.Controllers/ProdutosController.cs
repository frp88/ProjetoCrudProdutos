using Microsoft.AspNetCore.Mvc;
using ProjetoCrudProdutos.Data.Context;
using ProjetoCrudProdutos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoCrudProdutos.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase {

        private readonly ProjetoCrudProdutosContext _context;
         #region CONSTRUTOR
        public ProdutosController(ProjetoCrudProdutosContext context) {
            _context = context;
            
            // Verifica se já tem produtos cadastrados na tabela do BD
            int totalProdutosCadastrados = _context.Produtos.Count();
            if (totalProdutosCadastrados == 0) {
                // Retorna 5 produtos criados previamente na classe em que foi implementado o padrão "Singleton"
                List<Produto> listaProdutos = CriaProdutosSingleton.ProdutosCriados();
                foreach (Produto produto in listaProdutos) {
                    // Salva cada Produto na tabela do BD
                    _context.Add(produto);
                    _context.SaveChanges();
                }
            }
        }
        #endregion

        #region APIs
        // GET: api/produtos
        [HttpGet]
        public IActionResult Get() {
            var produtos = _context.Produtos;
            return Ok(produtos);
        }

        // GET api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var produto = _context.Produtos.FirstOrDefault(
                        p => p.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // GET api/produtos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public IActionResult Get(string nome) {
            var produtos = _context.Produtos.Where(
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
                    return Ok(ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Nome) : _context.Produtos.OrderBy(p => p.Nome));
                case "estoque":
                    return Ok(ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Estoque) : _context.Produtos.OrderBy(p => p.Estoque));
                case "valor":
                    return Ok(ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Valor) : _context.Produtos.OrderBy(p => p.Valor));
                default:
                    return Ok(ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Id) : _context.Produtos.OrderBy(p => p.Id));
            }
        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto) {

            var produto = new Produto(novoProduto.Nome, novoProduto.Estoque, novoProduto.Valor);

            // Salva o Produto no BD
            _context.Add(produto);
            _context.SaveChanges();

            return Created("", produto);
        }

        // PUT api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Produto produtoAtualizado) {
            var produto = _context.Produtos.FirstOrDefault(
                  p => p.Id == id);

            if (produto == null)
                return NotFound();

            produto.AtualizarProduto(produtoAtualizado.Nome, produtoAtualizado.Estoque, produtoAtualizado.Valor);

            _context.Update(produto);
            // Atualiza o Produto no BD
            _context.SaveChanges();

            return Ok(produto);
        }

        // DELETE api/produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var produto = _context.Produtos.FirstOrDefault(
                   p => p.Id == id);

            if (produto == null)
                return NotFound();

            _context.Remove(produto);
            // Remove o Produto do BD
            _context.SaveChanges();

            return NoContent();
        }
        #endregion
    }
}

