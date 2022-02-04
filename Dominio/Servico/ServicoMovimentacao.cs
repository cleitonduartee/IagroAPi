using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoMovimentacao : IServicoMovimentacao
    {
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        public ServicoMovimentacao(IHistoricoMovimentacao IHistoricoMovimentacao)
        {
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade)
        {
             return await _IHistoricoMovimentacao.BuscarPorIdPropriedade(m => m.PropriedadeId.Equals(idPropriedade));
        }

        public async Task CancelarMovimentacao(string codigoMovimentacao)
        {
            HistoricoMovimentacao historico = await _IHistoricoMovimentacao.BuscarPorCodigo(codigoMovimentacao);
        }
    }
}
