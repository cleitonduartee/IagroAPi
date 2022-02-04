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
        Task CancelarEntrada(Rebanho rebanho);
        Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor);
        Task<RebanhoResponseDTO> BuscarPorPropriedade(string propriedade);
       // Dictionary<string, string> ValidacoesEntradaDeAnimais(RebanhoInsertDTO rebanhoDTO) ;


    }
}
