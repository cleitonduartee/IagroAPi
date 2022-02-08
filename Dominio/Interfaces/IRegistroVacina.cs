using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRegistroVacina
    {
        Task AdicionarRegistroVacina(RegistroVacina registroVacina);
        Task CancelarRegistroVacina(RegistroVacina registroVacina);
        Task<RegistroVacina> BuscarRegistroVacinaPorId(int idRegistroVacina);
    }
}
