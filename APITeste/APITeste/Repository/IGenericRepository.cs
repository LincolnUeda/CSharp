using APITeste.DTO;
using APITeste.Model;

namespace APITeste.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Editar(TEntity obj);
        void Apagar(TEntity id);
        TEntity? ListarId(int id);
        List<TEntity> ListarTodos();
    }
}
