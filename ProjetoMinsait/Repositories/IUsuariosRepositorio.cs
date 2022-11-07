using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repositories
{
    public interface IUsuariosRepositorio
    {
        Task<IEnumerable<Usuarios>> Get();
        Task<Usuarios> Get(int Id);
        Task<Usuarios> Create(Usuarios usuarios);
        Task Update(Usuarios usuarios);
        Task Delete(int Id);
    }
}
