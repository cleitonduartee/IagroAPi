using Dominio.Dto.RegistroVacinaDTO;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoRegistroVacina
    {
        Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroVacinaDto);
        Task CancelarRegistroVacina(string codigoRegistro);
        Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(int idPropriedade);
    }
}
