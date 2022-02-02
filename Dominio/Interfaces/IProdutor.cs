using Dominio.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IProdutor : ICrud<Produtor>
    {
        Task<Produtor> BuscarPorCpf(Expression<Func<Produtor, bool>> expression);
    }
}
