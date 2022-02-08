using Dominio.Dto.RegistroVacinaDTO;
using Entidades.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoRegistroVacina
    {
        Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroVacinaDto);
        Task CancelarRegistroVacina(int idRegistroVacina);
    }
}
