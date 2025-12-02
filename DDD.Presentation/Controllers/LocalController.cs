using DDD.Infrastructure.Entities;
using DDD.Presentation.Services;
using DDD.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly LocalService _service;
        public LocalController(LocalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocais()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _service.GetByIdAsync(id);
            if (local == null) return NotFound();
            return local;
        }

        [HttpPost]
        public async Task<ActionResult<Local>> AddLocal(LocalDto dto)
        {
            var local = new Local { LOCNOME = dto.LOCNOME, LOCDESCRICAO = dto.LOCDESCRICAO, LOCENDERECO = dto.LOCENDERECO, LOCCID = dto.LOCCID, LOCUF = dto.LOCUF };
            var created = await _service.AddAsync(local);
            return CreatedAtAction(nameof(GetLocal), new { id = created.LOCID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Local>> UpdateLocal(int id, LocalDto dto)
        {
            var local = new Local { LOCNOME = dto.LOCNOME, LOCCID = dto.LOCCID, LOCUF = dto.LOCUF };
            var updated = await _service.UpdateAsync(id, local);
            if (updated == null) return NotFound();
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("busca/{termo}")]
        public async Task<ActionResult<IEnumerable<Local>>> Search(string termo)
        {
            var resultados = await _service.SearchByNomeAsync(termo);
            return Ok(resultados);
        }
    }
}
