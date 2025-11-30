using DDD.Infrastructure.Entities;
using DDD.Presentation.Services;
using DDD.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly CidadeService _service;
        public CidadeController(CidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidades()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
            var cidade = await _service.GetByIdAsync(id);
            if (cidade == null) return NotFound();
            return cidade;
        }

        [HttpPost]
        public async Task<ActionResult<Cidade>> AddCidade(CidadeDto dto)
        {
            var cidade = new Cidade { CIDNOME = dto.CIDNOME, CIDUF = dto.CIDUF };
            var created = await _service.AddAsync(cidade);
            return CreatedAtAction(nameof(GetCidade), new { id = created.CIDID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cidade>> UpdateCidade(int id, CidadeDto dto)
        {
            var cidade = new Cidade { CIDNOME = dto.CIDNOME, CIDUF = dto.CIDUF };
            var updated = await _service.UpdateAsync(id, cidade);
            if (updated == null) return NotFound();
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
