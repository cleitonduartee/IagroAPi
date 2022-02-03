using Aplicacao.Dto.ProdutorDTO;
using Aplicacao.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoProdutor 
    {
        Task CadastrarProdutor(Produtor produtor);
        Task EditarProdutor(Produtor produtor);
        Task<ProdutorResponseDTO> BuscarPorCpf(string cpf);
        Task<Produtor> BuscarPorId(int id);
        Task<List<ProdutorResponseDTO>> BuscarTodos();
        bool ValidarCpf(string cpf);

    }
}
