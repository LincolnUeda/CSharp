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


        [HttpGet("ListarId")]
        public ProdutoModel ListarId(int id)
        {
            ProdutoModel produto = _produtorepository.ListarId(id);
            if (produto == null)
            {
                produto = new ProdutoModel { Id = 0, descricao = "produto não encontrado", valor = 0};
            }
            return produto;
        }


        [HttpGet("RelatorioCadastral")]
        public IActionResult RelCadastral()
        {
            string titulo = "Produtos";
            var produtos = _produtorepository.ListarProdutos();
            string[,]? produtoscolunas = new string[produtos.Count(), 4];
            int i = 0;
            foreach (ProdutoModel produto in produtos)
            {
                produtoscolunas[i, 0] = produto.Id.ToString();
                produtoscolunas[i, 1] = produto.descricao;
                produtoscolunas[i, 2] = produto.valor.ToString();
                produtoscolunas[i, 3] = "coluna teste";
                i++;

            }

            PDFItens itens = new PDFItens
            {

                columnwitdh = [80, 100, 100,50],
                titulos = ["Código", "Descrição", "Valor", "Teste"],
                itens = produtoscolunas
            };
            byte[] pdfBytes = PDFRepository.RelCadastral(titulo, itens);


            return File(pdfBytes, "application/pdf", "teste.pdf");


        }



    }
}
