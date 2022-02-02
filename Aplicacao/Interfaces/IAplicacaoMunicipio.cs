using Aplicacao.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoMunicipio 
    { 
        Task<List<Municipio>> BuscarTodos();
        Task Adicionar(Municipio municipio);
    }
}
