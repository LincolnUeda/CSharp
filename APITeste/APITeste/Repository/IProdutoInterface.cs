using APITeste.DTO;
using APITeste.Model;

namespace APITeste.Repository
{
    public interface IProdutoInterface
    {

        ProdutoModel Adicionar(ProdutoDTO produto);
        ProdutoModel Editar(ProdutoModel produto);
        ProdutoModel Apagar (int IdProduto);
        List<ProdutoModel> ListarProdutos();
    }
}
