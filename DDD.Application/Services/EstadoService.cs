using DDD.Infrastructure;
using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Application.Services
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

		public async Task<List<Estado>> GetAllAtivosAsync()
		{
			return await _context.Estados
				.Where(e => e.UFSITUACAO == 'A')
				.ToListAsync();
		}

		public async Task<Estado?> GetByIdAsync(int id)
		{
			return await _context.Estados.FindAsync(id);
		}

		public async Task<Estado?> GetByIdAtivoAsync(int id)
		{
			return await _context.Estados
				.FirstOrDefaultAsync(e => e.UFID == id && e.UFSITUACAO == 'A');
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

		public async Task<bool> DesativarAsync(int id, char situacao)
		{
			var estado = await _context.Estados.FindAsync(id);
			if (estado == null) return false;
			estado.UFSITUACAO = situacao;
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
