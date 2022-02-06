using Dominio.Dto.Movimentacao.MovimentacaoDTO;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoMovimentacao
    {
        Task CancelarMovimentacaoDeEntrada(string codigoMovimentacao);
        Task CancelarMovimentacaoDeVenda(string codigoMovimentacao);
        Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade);
        Task<List<HistoricoMovimentacao>> BuscarPorIdProdutor(int idProdutor);
        Task CriarHistoricoDeMovimentacao(HistoricoMovimentacao historicoMovimentacao);
        Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(int idProdutor);
        Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(int idProdutor);

    }
}
