using Aplicacao.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoPropriedade
    {
        Task CadastrarPropriedade(Propriedade propriedade);
        Task EditarPropriedade(Propriedade propriedade);
        Task<Propriedade> BuscarPorIE(int ie);
        Task<Propriedade> BuscarPorId(int id);
        Task<List<Propriedade>> BuscarTodos();

    }
}
