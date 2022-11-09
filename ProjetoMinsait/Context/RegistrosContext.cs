using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repositories;

namespace ProjetoMinsait.Context
{
    public class RegistrosContext : DbContext
    {
        public RegistrosContext(DbContextOptions<RegistrosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
