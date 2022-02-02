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
        Task<Produtor> BuscarPorCpf(string cpf);
        Task<List<Produtor>> BuscarTodos();
        bool ValidarCpf(string cpf);

    }
}
