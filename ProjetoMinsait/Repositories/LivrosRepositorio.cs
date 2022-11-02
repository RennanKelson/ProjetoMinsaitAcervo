using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repositories
{
    public class LivrosRepositorio : ILivrosRepositorio
    {
        public readonly LivrosContext _context;

        public LivrosRepositorio(LivrosContext context)
        {
            _context = context;
        }
        public async Task<Livros> Create(Livros livros)
        {
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();

            return livros;
        }

        public async Task Delete(int id)
        {
            var livrosDelete = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livrosDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livros>> Get()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livros> Get(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task Update(Livros livros)
        {
            _context.Entry(livros).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
