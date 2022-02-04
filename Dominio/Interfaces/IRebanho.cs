using Dominio.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRebanho : ICrud<Rebanho>
    {
        Task<List<Rebanho>> BuscarPorProdutor(Expression<Func<Rebanho, bool>> expression);
        Task<Rebanho> BuscarRebanhoPorNomePropriedade(Expression<Func<Rebanho, bool>> expression);

        Task<Rebanho> BuscarRebanhoPorPropriedadeId(Expression<Func<Rebanho, bool>> expression);
    }
}
