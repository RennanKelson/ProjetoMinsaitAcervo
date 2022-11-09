using ProjetoMinsait.Context;

namespace ProjetoMinsait.Repositories
{
    public class BaseRepositorio
    {
        public readonly RegistrosContext _context;

        public BaseRepositorio(RegistrosContext context)
        {
            _context = context;
        }
    }
}
