using FichaCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace FichaCompras.Data
{
    public class SolicitacaoRepository
    {
        private readonly AppDbContext _context;

        public SolicitacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Listar todas as solicitações
        public async Task<List<Solicitacao>> GetAllAsync()
        {
            return await _context.Solicitacoes.ToListAsync();
        }

        // Buscar por ID
        public async Task<Solicitacao?> GetByIdAsync(int id)
        {
            return await _context.Solicitacoes.FindAsync(id);
        }

        // Adicionar nova solicitação
        public async Task AddAsync(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();
        }

        // Atualizar solicitação existente
        public async Task UpdateAsync(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Update(solicitacao);
            await _context.SaveChangesAsync();
        }

        // Remover solicitação
        public async Task DeleteAsync(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();
        }
    }
}