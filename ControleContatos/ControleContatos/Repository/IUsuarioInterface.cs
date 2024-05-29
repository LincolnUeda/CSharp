using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IUsuarioInterface
    {

        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel Apagar(int id);

        List<UsuarioModel> ListarTodos();
        UsuarioModel ListarPorId(int id);
        UsuarioModel BuscarLogin(string login);
    }
}
