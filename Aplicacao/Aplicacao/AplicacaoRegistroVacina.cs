using Aplicacao.Interfaces;
using Dominio.Dto.RegistroVacinaDTO;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoRegistroVacina : IAplicacaoRegistroVacina
    {
        private readonly IServicoRegistroVacina _IServicoRegistroVacina;

        public AplicacaoRegistroVacina(IServicoRegistroVacina IServicoRegistroVacina)
        {
            _IServicoRegistroVacina = IServicoRegistroVacina;
        }
        public async Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroVacinaDto)
        {
            await _IServicoRegistroVacina.AdicionarRegistroVacina(registroVacinaDto);
        }

        public async Task CancelarRegistroVacina(int idRegistroVacina)
        {
            await _IServicoRegistroVacina.CancelarRegistroVacina(idRegistroVacina);
        }
    }
}
