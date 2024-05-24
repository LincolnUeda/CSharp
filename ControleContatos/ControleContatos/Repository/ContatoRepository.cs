using ControleContatos.Data;
using ControleContatos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleContatos.Repository
{
    public class ContatoRepository : IContatoInterface
    {

        private readonly AppDBContext _context;
        public ContatoRepository(AppDBContext context)
        {
            _context = context;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contato.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Apagar(int id)
        {
            
            var contatoDeletar = _context.Contato.Find(id);
            
            if (contatoDeletar != null){
                _context.Contato.Remove(contatoDeletar);
                _context.SaveChanges();
            }

            return contatoDeletar;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoUpdate = ListarPorId(contato.Id);
            if (contatoUpdate != null) {
                contatoUpdate.Nome = contato.Nome;
                contatoUpdate.Email = contato.Email;
                contatoUpdate.Celular = contato.Celular;
                _context.Contato.Update(contatoUpdate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            return contato;
           
           
        }

        public List<ContatoModel> ListarTodos()
        {
            return _context.Contato.ToList();
           
        }

        public ContatoModel ListarPorId(int id)
        {
            return _context.Contato.FirstOrDefault(c => c.Id == id);
        }
    }
}
