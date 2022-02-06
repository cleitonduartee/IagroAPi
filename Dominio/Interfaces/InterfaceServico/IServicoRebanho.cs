using Dominio.Dto.RebanhoDTO;
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
        Task EntradaAnimais(RebanhoInsertDTO rebanho);      
        Task<List<Rebanho>> BuscarPorProdutor(string produtor);
        Task<Rebanho> BuscarRebanhoPorNomePropriedade(string propriedade);
        Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId);   
    }
}
