using Dominio.Dto.RegistroVacinaDTO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoRegistroVacina
    {
        Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroVacinaDto);
        Task CancelarRegistroVacina(string codigoRegistro);
        Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(int idPropriedade);
    }
}
