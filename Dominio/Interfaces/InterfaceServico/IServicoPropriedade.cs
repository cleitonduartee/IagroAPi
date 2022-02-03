using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoPropriedade
    {
        Task CadastrarPropriedade(Propriedade propriedade);
        Task EditarPropriedade(Propriedade propriedade);
        Task<Propriedade> BuscarPorIE(int ie);
        Task<List<Propriedade>> BuscarPorProdutor(string produtor);
        Task<Propriedade> BuscarPorId(int id);
        Task<List<Propriedade>> BuscarTodos();

    }
}
