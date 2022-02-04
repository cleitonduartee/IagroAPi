using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioHistoricoMovimentacao : IHistoricoMovimentacao
    {
        private readonly ApiContext _ApiContext;
        public RepositorioHistoricoMovimentacao(ApiContext ApiContext) 
        {
            _ApiContext = ApiContext;
        }
        public async Task CancelarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao)
        {
            _ApiContext.Movimentacoes.Update(historicoMovimentacao);
            await _ApiContext.SaveChangesAsync();
        }

        public async Task CriarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao)
        {
            await _ApiContext.Movimentacoes.AddAsync(historicoMovimentacao);
            await _ApiContext.SaveChangesAsync();
        }
    }
}
