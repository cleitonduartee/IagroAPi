using Dominio.Dto.HistoricoDTO;
using Dominio.Dto.Movimentacao.HistoricoDTO;
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
        Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorProdutor(int idProdutor);
        Task<List<HistoricoCompraVendaResponseDTO>> BuscarComprasPorProdutor(int idProdutor);
        Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorPropriedade(int idPropriedade);
    }
}
