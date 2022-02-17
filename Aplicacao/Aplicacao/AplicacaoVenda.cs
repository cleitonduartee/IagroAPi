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
        private readonly IServicoHistorico _IServicoHistorico;
        private readonly IServicoPropriedade _IServicoPropriedade;
        public AplicacaoVenda(IServicoVenda IServicoVenda, IServicoHistorico IServicoMovimentacao, IServicoPropriedade IServicoPropriedade)
        {
            _IServicoVenda = IServicoVenda;
            _IServicoHistorico = IServicoMovimentacao;
            _IServicoPropriedade = IServicoPropriedade;
        }

        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarComprasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoHistorico.BuscarComprasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<HistoricoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoCompraVendaResponseDTO(mov)));
            await buscaPropriedadesDeOrigemEDestino(movimentacoesDtoList);
            return movimentacoesDtoList;
        }
        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoHistorico.BuscarVendasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<HistoricoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoCompraVendaResponseDTO(mov)));
            await buscaPropriedadesDeOrigemEDestino(movimentacoesDtoList);
            return movimentacoesDtoList;
        }

        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorPropriedade(int idPropriedade)
        {            
            var movemntacoesList = await _IServicoHistorico.BuscarVendasPorIdPropriedade(idPropriedade);
            var movimentacoesDtoList = new List<HistoricoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new HistoricoCompraVendaResponseDTO(mov)));
            await buscaPropriedadesDeOrigemEDestino(movimentacoesDtoList);
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
        private async Task buscaPropriedadesDeOrigemEDestino(List<HistoricoCompraVendaResponseDTO> listDto)
        {
            foreach (var item in listDto)
            {
                var propOrigem = await _IServicoPropriedade.BuscarPorId(item.PropriedadeOrigemId);
                var propDestino = await _IServicoPropriedade.BuscarPorId(item.PropriedadeDestinoId);
                item.NomePropriedadeOrigem = propOrigem.Nome;
                item.NomePropriedadeDestino = propDestino.Nome;
            }
        }

    }
}
