using DDD.Infrastructure;
using DDD.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Presentation.Services
{
    public class CidadeService
    {
        private readonly WebLocalizeDbContext _context;
        public CidadeService(WebLocalizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cidade>> GetAllAsync()
        {
            return await _context.Cidades.Include(c => c.Estado).ToListAsync();
        }

        public async Task<Cidade?> GetByIdAsync(int id)
        {
            return await _context.Cidades.Include(c => c.Estado).FirstOrDefaultAsync(c => c.CIDID == id);
        }

        public async Task<Cidade> AddAsync(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();
            return cidade;
        }

        public async Task<Cidade?> UpdateAsync(int id, Cidade cidade)
        {
            var existing = await _context.Cidades.FindAsync(id);
            if (existing == null) return null;
            existing.CIDNOME = cidade.CIDNOME;
            existing.CIDUF = cidade.CIDUF;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null) return false;
            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
