using Aplicacao.Interfaces.InterfaceCrud;
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
        Task<RebanhoResponseDTO> BuscarRebanhoPorNomePropriedade(string propriedade);


    }
}
