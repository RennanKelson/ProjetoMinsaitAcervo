using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Repositories;

namespace ProjetoMinsait.Models
{
    public class RegistrosContext : DbContext
    {
        public RegistrosContext(DbContextOptions<RegistrosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public static implicit operator RegistrosContext(LivrosRepositorio v)
        {
            throw new NotImplementedException();
        }
        public static implicit operator RegistrosContext(UsuariosRepositorio v)
        {
            throw new NotImplementedException();
        }
    }
}
