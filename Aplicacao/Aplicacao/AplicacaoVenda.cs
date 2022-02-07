using Aplicacao.Interfaces;
using Dominio.Dto.HistoricoDTO;
using Dominio.Dto.VendaDTO;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Dto.Movimentacao.HistoricoDTO;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoVenda : IAplicacaoVenda
    {
        private readonly IServicoVenda _IServicoVenda;
        private readonly IServicoHistorico _IServicoMovimentacao;
        public AplicacaoVenda(IServicoVenda IServicoVenda, IServicoHistorico IServicoMovimentacao)
        {
            _IServicoVenda = IServicoVenda;
            _IServicoMovimentacao = IServicoMovimentacao;
        }

        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarComprasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoMovimentacao.BuscarComprasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<HistoricoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoCompraVendaResponseDTO(mov)));
            return movimentacoesDtoList;
        }
        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoMovimentacao.BuscarVendasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<HistoricoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoCompraVendaResponseDTO(mov)));
            return movimentacoesDtoList;
        }

        public async Task<List<HistoricoTodosTipoResponseDTO>> BuscarMovimentacoesPorPropriedade(int idPropriedade)
        {            
            var movemntacoesList = await _IServicoMovimentacao.BuscarPorIdPropriedade(idPropriedade);
            var movimentacoesDtoList = new List<HistoricoTodosTipoResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoTodosTipoResponseDTO(mov)));
            return movimentacoesDtoList;
        }

        

        public async Task CancelarVenda(string codigoMovimentacao)
        {
            await _IServicoVenda.CancelarVenda(codigoMovimentacao);
        }

        public async Task RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            await _IServicoVenda.RealizarVenda(vendaInsertDto);
        }
    }
}
