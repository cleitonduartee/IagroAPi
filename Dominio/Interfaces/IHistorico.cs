using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Interfaces.InterfaceCrud;

namespace Dominio.Interfaces
{
    public interface IHistorico { 
        Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(Expression<Func<HistoricoMovimentacao, bool>> expression);
        Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(Expression<Func<HistoricoMovimentacao, bool>> expression);
        Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(Expression<Func<HistoricoMovimentacao, bool>> expression);
        Task<HistoricoMovimentacao> BuscarPorCodigo(string codigoMovimentacao);
        Task CriarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao);
        Task AtualizarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao);
    }
}
