using Dominio.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IPropriedade : ICrud<Propriedade>
    {
        Task<Propriedade> BuscarPorIE(Expression<Func<Propriedade, bool>> expression);
        Task<List<Propriedade>> BuscarPorProdutor(Expression<Func<Propriedade, bool>> expression);
    }
}
