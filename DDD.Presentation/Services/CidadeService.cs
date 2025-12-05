using DDD.Infrastructure;
using DDD.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            // .AsNoTracking() melhora performance para listas apenas de leitura
            return await _context.Cidades
                .AsNoTracking()
                .Include(c => c.Estado)
                .ToListAsync();
        }

        public async Task<List<Cidade>> GetAllAtivosAsync()
        {
            return await _context.Cidades
                .AsNoTracking()
                .Include(c => c.Estado)
                .Where(c => c.CIDSITUACAO == 'A') // Apenas ativos
                .ToListAsync();
        }

        // Adicione a interrogação '?' aqui no retorno V
        public async Task<Cidade?> GetByNomeAndUfAsync(string nome, int ufId)
        {
            if (string.IsNullOrWhiteSpace(nome)) return null;

            var nomeBusca = nome.ToLower().Trim();

            return await _context.Cidades
                .FirstOrDefaultAsync(c => c.CIDNOME.ToLower() == nomeBusca && c.CIDUF == ufId);
        }

        public async Task<Cidade?> GetByIdAsync(int id)
        {
            return await _context.Cidades
                .AsNoTracking()
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(c => c.CIDID == id);
        }

        public async Task<Cidade?> GetByIdAtivoAsync(int id)
        {
            return await _context.Cidades
                .AsNoTracking()
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(c => c.CIDID == id && c.CIDSITUACAO == 'A'); // Apenas ativo
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

            // Atualiza situação se válida
            if (cidade.CIDSITUACAO != '\0' && cidade.CIDSITUACAO != ' ')
            {
                existing.CIDSITUACAO = cidade.CIDSITUACAO;
            }

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

        public async Task<bool> DesativarAsync(int id, char situacao)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null) return false;
            cidade.CIDSITUACAO = situacao; // Atualiza situação
            await _context.SaveChangesAsync();
            return true;
        }
    }
}