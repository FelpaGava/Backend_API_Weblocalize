using DDD.Infrastructure;
using DDD.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Presentation.Services
{
    public class EstadoService
    {
        private readonly WebLocalizeDbContext _context;
        public EstadoService(WebLocalizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> GetAllAsync()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task<Estado?> GetByIdAsync(int id)
        {
            return await _context.Estados.FindAsync(id);
        }

        public async Task<Estado> AddAsync(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<Estado?> UpdateAsync(int id, Estado estado)
        {
            var existing = await _context.Estados.FindAsync(id);
            if (existing == null) return null;
            existing.UFNOME  = estado.UFNOME;
            existing.UFSIGLA = estado.UFSIGLA;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null) return false;
            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
