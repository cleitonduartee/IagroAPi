using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoRebanho
    {
        Task EntradaAnimais(Rebanho rebanho);
        Task CancelarEntrada(Rebanho rebanho);
        Task<List<Rebanho>> BuscarPorProdutor(string produtor);
        Task<Rebanho> BuscarPorPropriedade(string propriedade);
        Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId);

    }
}
