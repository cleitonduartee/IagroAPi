using Dominio.Dto.RebanhoDTO;
using Dominio.Dto.VendaDTO;
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
    public interface IServicoHistorico
    {
        // Deve ter so um método cancelar que recebe o historico e atualiza no banco
        //Task CancelarMovimentacaoDeEntrada(string codigoMovimentacao);
        Task CancelarHistorico(HistoricoMovimentacao historico);
        Task<HistoricoMovimentacao> BuscarPorCodigoHistorico(string codigohistorico);
        Task<List<HistoricoMovimentacao>> BuscarTodosPorIdPropriedade(int idPropriedade);
        Task<List<HistoricoMovimentacao>> BuscarTodosPorIdProdutor(int idProdutor);
        Task<HistoricoMovimentacao> CriarHistoricoDeCompra(int produtorOrigemId, int produtorDestinoId, VendaInsertDTO vendaInsertDto);
        Task<HistoricoMovimentacao> CriarHistoricoDeVenda(string codigoHistorico,int produtorOrigemId, int produtorDestinoId, VendaInsertDTO vendaInsertDto);
        Task CriarHistoricoDeEntrada(int idProdutor, RebanhoInsertDTO rebanhoInsertDto);
        Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(int idProdutor);
        Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(int idProdutor);

    }
}
