using Aplicacao.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoMovimentacao : IAplicacaoMovimentacao
    {
        private readonly IServicoHistorico _IServicoMovimentacao;
        public AplicacaoMovimentacao(IServicoHistorico IServicoMovimentacao)
        {
            _IServicoMovimentacao = IServicoMovimentacao;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int propriedadeId)
        {
            return await _IServicoMovimentacao.BuscarPorIdPropriedade(propriedadeId);
        }

        public async Task CancelarMovimentacao(string codigoMovimentacao)
        {
            await _IServicoMovimentacao.CancelarMovimentacaoDeEntrada(codigoMovimentacao);
        }
    }
}
