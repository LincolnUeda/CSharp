using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public class UsuarioRepository : IUsuarioInterface
    {

        private readonly AppDBContext _context;
        public UsuarioRepository(AppDBContext context)
        {
            _context = context;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Apagar(int id)
        {
            var usuarioDeletar = _context.Usuarios.Find(id);

            if (usuarioDeletar != null)
            {
                _context.Usuarios.Remove(usuarioDeletar);
                _context.SaveChanges();
            }

            return usuarioDeletar;
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioUpdate = ListarPorId(usuario.Id);
            
            if (usuarioUpdate != null)
            {
                usuarioUpdate.Nome = usuario.Nome;
                usuarioUpdate.Login = usuario.Login;
                usuarioUpdate.Email = usuario.Email;
                usuarioUpdate.Perfil = usuario.Perfil;
                usuarioUpdate.DataAlteracao = DateTime.Now;

                _context.Usuarios.Update(usuarioUpdate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }

            return usuario;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public List<UsuarioModel> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public UsuarioModel BuscarLogin (string login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Login == login);
            return usuario;
        }
    }
}
