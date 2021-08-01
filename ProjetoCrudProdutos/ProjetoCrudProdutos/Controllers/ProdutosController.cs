using Microsoft.AspNetCore.Mvc;
using ProjetoCrudProdutos.Application;
using ProjetoCrudProdutos.Domain;

namespace ProjetoCrudProdutos.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase {

        private readonly IProdutoService _produtosService;
        #region CONSTRUTOR
        public ProdutosController(IProdutoService produtosService) {
            _produtosService = produtosService;
        }
        #endregion

        #region APIs
        // GET: api/produtos
        [HttpGet]
        public IActionResult Get() {
            var produtos = _produtosService.Buscar();
            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        // GET api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var produto = _produtosService.BuscarPorId(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // GET api/produtos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public IActionResult Get(string nome) {
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

            return Created("", produtoAdicionado);
        }

        // PUT api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Produto produtoAtualizado) {
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

        }
        #endregion
    }
}

