using Dominio.Dto.Movimentacao.MovimentacaoDTO;
using Dominio.Dto.VendaDTO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoVenda
    {
        Task RealizarVenda(VendaInsertDTO vendaInsertDto);
        Task CancelarVenda(string codigoMovimentacao);
        Task<List<MovimentacaoResponseDTO>> BuscarVendasPorProdutor(int idProdutor);
        Task<List<MovimentacaoResponseDTO>> BuscarComprasPorProdutor(int idProdutor);
        Task<List<MovimentacaoResponseDTO>> BuscarMovimentacoesPorPropriedade(int idPropriedade);
    }
}
