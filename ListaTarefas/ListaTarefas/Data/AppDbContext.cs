using ListaTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel { CategoriaId = 1, CategoriaNome="Trabalho"},
                new CategoriaModel { CategoriaId = 2, CategoriaNome = "Casa" },
                new CategoriaModel { CategoriaId = 3, CategoriaNome = "Faculdade" },
                new CategoriaModel { CategoriaId = 4, CategoriaNome = "Compras" }
                );


            modelBuilder.Entity<StatusModel>().HasData(
                new StatusModel { StatusId = 1, StatusName = "Aberto" },
                new StatusModel { StatusId = 2, StatusName = "Completo" }
                );
        }

    }
}
