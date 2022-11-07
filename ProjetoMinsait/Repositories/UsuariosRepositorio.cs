using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repositories
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        public readonly RegistrosContext _context;
        public UsuariosRepositorio(RegistrosContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> Create(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return usuarios;
        }

        public async Task Delete(int id)
        {
            var usuariosDelete = await _context.Usuarios.FindAsync(id);
            if (usuariosDelete == null)
            {
                throw new Exception($"Id: {id} não encontrado");
            }
            _context.Usuarios.Remove(usuariosDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuarios>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> Get(int id)
        {
            var usuariosProcurar = await _context.Usuarios.FindAsync(id);
            if (usuariosProcurar == null)
            {
                throw new Exception($"Id: {id} não encontrado");
            }
            return usuariosProcurar;
        }

        public async Task Update(Usuarios usuarios)
        {
            _context.Entry(usuarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
