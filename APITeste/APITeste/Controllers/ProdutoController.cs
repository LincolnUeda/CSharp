using APITeste.Model;
using APITeste.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APITeste.DTO;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtorepository;

        public ProdutoController(IProdutoInterface produtoInterface) {
            _produtorepository = produtoInterface;
        }

        [HttpGet("Listar")]
        public List<ProdutoModel> Listar()
        {
           List<ProdutoModel> produtos = _produtorepository.ListarProdutos();



            return produtos;
        }
        [HttpPost("Adicionar")]
        public ProdutoModel Adicionar(ProdutoDTO produto)
        {
            ProdutoModel produtoModel = new ProdutoModel();
            produtoModel = _produtorepository.Adicionar(produto);

            return produtoModel;
        }

        [HttpPut("Editar")]
        public ProdutoModel Editar(ProdutoModel produto)
        {
            ProdutoModel prodUpdate = _produtorepository.Editar(produto);
            return prodUpdate;
        }

        [HttpDelete("Apagar")]
        public ProdutoModel Apagar(int IdProduto)
        {

            return _produtorepository.Apagar(IdProduto);
        }
    }
}
