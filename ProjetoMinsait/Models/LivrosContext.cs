using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Repositories;

namespace ProjetoMinsait.Models
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Livros> Livros { get; set; }

        public static implicit operator LivrosContext(LivrosRepositorio v)
        {
            throw new NotImplementedException();
        }
    }
}
