using Aplicacao.Interfaces.InterfaceCrud;
using Dominio.Dto.Movimentacao.HistoricoDTO;
using Dominio.Dto.RebanhoDTO;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoRebanho
    {
        Task EntradaAnimais(RebanhoInsertDTO rebanho);
        Task CancelarEntrada(string codigoMovimentacaoEntrada);
        Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor);
        Task<List<HistoricoTodosTipoResponseDTO>> BuscarEntradasPorPropriedadeId(int propriedadeId);
        Task<RebanhoResponseDTO> BuscarRebanhoPorNomePropriedade(string propriedade);


    }
}
