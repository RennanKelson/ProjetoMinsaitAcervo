using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Context;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repositories.Interfaces;

namespace ProjetoMinsait.Repositories
{
    public class LivrosRepositorio : BaseRepositorio,ILivrosRepositorio
    {
        public LivrosRepositorio(RegistrosContext context) : base(context)
        {
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
            if (livrosDelete == null)
            {
                throw new Exception($"Id: {id} não encontrado");
            }
            _context.Livros.Remove(livrosDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livros>> Get()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livros> Get(int id)
        {
            var livrosProcurar = await _context.Livros.FindAsync(id);
            if (livrosProcurar == null)
            {
                throw new Exception($"Id: {id} não encontrado");
            }
            return livrosProcurar;
        }

        public async Task Update(Livros livros)
        {
            _context.Entry(livros).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
