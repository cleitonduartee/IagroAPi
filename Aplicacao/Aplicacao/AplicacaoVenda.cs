using Aplicacao.Interfaces;
using Dominio.Dto.Movimentacao.MovimentacaoDTO;
using Dominio.Dto.MovimentacaoDTO;
using Dominio.Dto.VendaDTO;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoVenda : IAplicacaoVenda
    {
        private readonly IServicoVenda _IServicoVenda;
        private readonly IServicoMovimentacao _IServicoMovimentacao;
        public AplicacaoVenda(IServicoVenda IServicoVenda, IServicoMovimentacao IServicoMovimentacao)
        {
            _IServicoVenda = IServicoVenda;
            _IServicoMovimentacao = IServicoMovimentacao;
        }

        public async Task<List<MovimentacaoCompraVendaResponseDTO>> BuscarComprasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoMovimentacao.BuscarComprasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<MovimentacaoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new MovimentacaoCompraVendaResponseDTO(mov)));
            return movimentacoesDtoList;
        }
        public async Task<List<MovimentacaoCompraVendaResponseDTO>> BuscarVendasPorProdutor(int idProdutor)
        {
            var movemntacoesList = await _IServicoMovimentacao.BuscarVendasPorProdutor(idProdutor);
            var movimentacoesDtoList = new List<MovimentacaoCompraVendaResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new MovimentacaoCompraVendaResponseDTO(mov)));
            return movimentacoesDtoList;
        }

        public async Task<List<MovimentacaoResponseDTO>> BuscarMovimentacoesPorPropriedade(int idPropriedade)
        {            
            var movemntacoesList = await _IServicoMovimentacao.BuscarPorIdPropriedade(idPropriedade);
            var movimentacoesDtoList = new List<MovimentacaoResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new MovimentacaoResponseDTO(mov)));
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
