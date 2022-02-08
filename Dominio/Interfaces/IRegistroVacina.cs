using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRegistroVacina
    {
        Task<RegistroVacina> AdicionarRegistroVacina(RegistroVacina registroVacina);
        Task CancelarRegistroVacina(RegistroVacina registroVacina);
        Task<RegistroVacina> BuscarRegistroVacinaPorCodigo(string codigoRegistro);
        Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(Expression<Func<RegistroVacina, bool>> expression);
    }
}
