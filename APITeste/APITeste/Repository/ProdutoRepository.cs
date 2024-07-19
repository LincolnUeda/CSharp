using APITeste.DataBase;
using APITeste.DTO;
using APITeste.Model;

namespace APITeste.Repository
{
    public class ProdutoRepository : IProdutoInterface
    {

        private readonly AppDBContext _dbcontext;

        public ProdutoRepository(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ProdutoModel Adicionar(ProdutoDTO novoproduto)
        {
            ProdutoModel produto = new ProdutoModel()
            {
                descricao = novoproduto.descricao,
                valor = novoproduto.valor
            };

            if (novoproduto != null) {
                _dbcontext.Add(produto);
                _dbcontext.SaveChanges();
                
            }

            return produto;
        }

        public ProdutoModel Apagar(int IdProduto)
        {
            var prodBanco = _dbcontext.Produtos.FirstOrDefault(prod => prod.Id == IdProduto);
            if (prodBanco != null) { 
                _dbcontext.Remove(prodBanco);
                _dbcontext.SaveChanges();
            }
            return prodBanco;
        }

        public ProdutoModel Editar(ProdutoModel produto)
        {
            var prodBanco = _dbcontext.Produtos.FirstOrDefault(prod=> prod.Id == produto.Id);

            if (produto.descricao != null)
            {
                prodBanco.descricao = produto.descricao;
            }
            if (produto.valor != null)
            {
                prodBanco.valor = produto.valor;
            }
            _dbcontext.Update(prodBanco);
            _dbcontext.SaveChanges();

            return produto;
        }

        public List<ProdutoModel> ListarProdutos()
        {
            return _dbcontext.Produtos.ToList();
        }
    }
}
