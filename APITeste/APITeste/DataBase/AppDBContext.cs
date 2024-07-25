using APITeste.Model;
using Microsoft.EntityFrameworkCore;

namespace APITeste.DataBase
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }


        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
