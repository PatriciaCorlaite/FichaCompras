using FichaCompras.Data;
using FichaCompras.Models;

namespace FichaCompras.Business
{
    public class SolicitacaoService
    {
        private readonly SolicitacaoRepository _repository;

        public SolicitacaoService(SolicitacaoRepository repository)
        {
            _repository = repository;
        }

        // Listar todas
        public async Task<List<Solicitacao>> ObterTodasSolicitacoesAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Buscar por ID
        public async Task<Solicitacao?> ObterPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Adicionar
        public async Task AdicionarSolicitacaoAsync(Solicitacao solicitacao)
        {
            if (string.IsNullOrWhiteSpace(solicitacao.Material))
                throw new Exception("O material é obrigatório.");

            if (solicitacao.Quantidade <= 0)
                throw new Exception("A quantidade deve ser maior que zero.");

            solicitacao.DataSolicitacao = DateTime.Now;
            solicitacao.Status = "Pendente";

            await _repository.AddAsync(solicitacao);
        }

        // Atualizar
        public async Task AtualizarSolicitacaoAsync(Solicitacao solicitacao)
        {
            await _repository.UpdateAsync(solicitacao);
        }

        // Atualizar apenas o status
        public async Task AtualizarStatusAsync(int id, string status)
        {
            var solicitacao = await _repository.GetByIdAsync(id);
            if (solicitacao == null)
                throw new Exception("Solicitação não encontrada.");

            solicitacao.Status = status;
            await _repository.UpdateAsync(solicitacao);
        }

        // Remover
        public async Task RemoverSolicitacaoAsync(int id)
        {
            var solicitacao = await _repository.GetByIdAsync(id);
            if (solicitacao != null)
            {
                await _repository.DeleteAsync(solicitacao);
            }
        }
    }
}