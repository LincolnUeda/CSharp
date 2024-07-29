
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
            TEntity existe = _dbcontext.Set<TEntity>().Find(obj);
            if ( existe != null)
            {
                _dbcontext.Set<TEntity>().Remove(existe);
                _dbcontext.SaveChanges();
            }
            
        }

        public void Editar(TEntity obj)
        {
            _dbcontext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbcontext.SaveChanges();
        }

        public TEntity? ListarId(int id)
        {
            var existe = _dbcontext.Set<TEntity>().Find(id);
            
            return existe;
        }

        public List<TEntity> ListarTodos()
        {
            return _dbcontext.Set<TEntity>().ToList();
        }
    }
}
