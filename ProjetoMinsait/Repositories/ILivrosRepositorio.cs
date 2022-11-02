using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repositories
{
    public interface ILivrosRepositorio
    {
        Task<IEnumerable<Livros>> Get();
        Task<Livros> Get(int Id);
        Task<Livros> Create(Livros livros);
        Task Update(Livros livros);
        Task Delete(int Id);
    }
}
