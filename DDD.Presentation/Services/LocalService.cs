using DDD.Infrastructure;
using DDD.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Presentation.Services
{
    public class LocalService
    {
        private readonly WebLocalizeDbContext _context;
        public LocalService(WebLocalizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Local>> GetAllAsync()
        {
            return await _context.Locais.Include(l => l.Cidade).Include(l => l.Estado).ToListAsync();
        }

        public async Task<List<Local>> GetAllAtivosAsync()
        {
            return await _context.Locais
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .Where(l => l.LOCSITUACAO == 'A')
                .ToListAsync();
        }

        public async Task<Local?> GetByIdAsync(int id)
        {
            return await _context.Locais.Include(l => l.Cidade).Include(l => l.Estado).FirstOrDefaultAsync(l => l.LOCID == id);
        }

        public async Task<Local?> GetByIdAtivoAsync(int id)
        {
            return await _context.Locais
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .FirstOrDefaultAsync(l => l.LOCID == id && l.LOCSITUACAO == 'A');
        }

        public async Task<List<Local>> SearchByNomeAsync(string termo)
        {
            if (string.IsNullOrEmpty(termo))
            {
                return new List<Local>();
            }

            return await _context.Locais
                .Include(l => l.Cidade) 
                .Include(l => l.Estado)
                .Where(l => l.LOCNOME.Contains(termo)) 
                .ToListAsync();
        }

        public async Task<Local> AddAsync(Local local)
        {
            _context.Locais.Add(local);
            await _context.SaveChangesAsync();
            return local;
        }

        public async Task<Local?> UpdateAsync(int id, string nome, string endereco, string descricao)
        {
            var existing = await _context.Locais.FindAsync(id);
            if (existing == null) return null;

            existing.LOCNOME = nome;
            existing.LOCENDERECO = endereco;
            existing.LOCDESCRICAO = descricao;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local == null) return false;
            _context.Locais.Remove(local);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DesativarAsync(int id, char situacao)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local == null) return false;
            local.LOCSITUACAO = situacao;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
