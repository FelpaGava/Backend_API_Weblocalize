using DDD.Infrastructure.Entities;
using DDD.Presentation.Services;
using DDD.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _service;
        public EstadoController(EstadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var estado = await _service.GetByIdAsync(id);
            if (estado == null) return NotFound();
            return estado;
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> AddEstado(EstadoDto dto)
        {
            var estado = new Estado { UFNOME = dto.UFNOME, UFSIGLA = dto.UFSIGLA, UFSITUACAO = dto.UFSITUACAO};
            var created = await _service.AddAsync(estado);
            return CreatedAtAction(nameof(GetEstado), new { id = created.UFID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Estado>> UpdateEstado(int id, EstadoDto dto)
        {
            var estado = new Estado { UFNOME = dto.UFNOME, UFSIGLA = dto.UFSIGLA };
            var updated = await _service.UpdateAsync(id, estado);
            if (updated == null) return NotFound();
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
