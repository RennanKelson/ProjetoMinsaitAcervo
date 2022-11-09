using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repositories.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        public UsuariosController (IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }
        [HttpGet]
        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _usuariosRepositorio.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            return await _usuariosRepositorio.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios([FromBody] Usuarios usuarios)
        {
            var newUsuarios = await _usuariosRepositorio.Create(usuarios);
            return CreatedAtAction(nameof(GetUsuarios), new { id = newUsuarios.Id }, newUsuarios);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuariosDelete = await _usuariosRepositorio.Get(id);
            if (usuariosDelete == null)
                return NotFound();

            await _usuariosRepositorio.Delete(usuariosDelete.Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> PutUsuarios(int id, [FromBody] Usuarios usuarios)
        {
            if (id != usuarios.Id)
                return BadRequest();

            await _usuariosRepositorio.Update(usuarios);

            return NoContent();
        }
    }
}
