using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IContatoInterface
    {

        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        ContatoModel Apagar(int id);

        List<ContatoModel> ListarTodos();
        ContatoModel ListarPorId(int id);
    }
}
