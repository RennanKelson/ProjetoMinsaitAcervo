using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repositories.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace ProjetoMinsait.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivrosRepositorio _livrosRepositorio;
        public LivrosController(ILivrosRepositorio livrosRepositorio)
        {
            _livrosRepositorio = livrosRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Livros>> GetLivros()
        {
            return await _livrosRepositorio.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLivros (int id)
        {
            return await _livrosRepositorio.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivros([FromBody] Livros livros)
        {
            var newLivro = await _livrosRepositorio.Create(livros);
            return CreatedAtAction(nameof(GetLivros), new { id = newLivro.Id }, newLivro);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var livroDelete = await _livrosRepositorio.Get(id);
            if (livroDelete == null)
                return NotFound();

            await _livrosRepositorio.Delete(livroDelete.Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> PutLivros(int id, [FromBody] Livros livros)
        {
            if (id != livros.Id)
                return BadRequest();

            await _livrosRepositorio.Update(livros);

            return NoContent();
        }
    }
}
