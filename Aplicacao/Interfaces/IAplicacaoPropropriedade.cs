using Aplicacao.Interfaces.InterfaceCrud;
using Dominio.Dto.PropriedadeDTO;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoPropriedade
    {
        Task CadastrarPropriedade(Propriedade propriedade);
        Task EditarPropriedade(Propriedade propriedade);
        Task<PropriedadeResponseDTO> BuscarPorIE(int ie);
        Task<List<PropriedadeResponseDTO>> BuscarPorProdutor(string produtor);
        Task<Propriedade> BuscarPorId(int id);
        Task<List<PropriedadeResponseDTO>> BuscarTodos();

    }
}
