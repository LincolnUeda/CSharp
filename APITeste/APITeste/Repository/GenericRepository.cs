
using APITeste.DataBase;

namespace APITeste.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {


        private readonly AppDBContext _dbcontext;

        public GenericRepository(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Adicionar(TEntity obj)
        {
            _dbcontext.Set<TEntity>().Add(obj);
            _dbcontext.SaveChanges();
        }

        public void Apagar(TEntity obj)
        {
            _dbcontext.Set<TEntity>().Remove(obj);
        }

        public void Editar(TEntity obj)
        {
            _dbcontext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public TEntity ListarId(object id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> ListarTodos()
        {
            return _dbcontext.Set<TEntity>().ToList();
        }
    }
}
