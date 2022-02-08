using Aplicacao.Interfaces;
using Dominio.Dto.RegistroVacinaDTO;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
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

        public async Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(int idPropriedade)
        {
            return await _IServicoRegistroVacina.BuscarRegistrosPorPropriedadeId(idPropriedade);
        }

        public async Task CancelarRegistroVacina(string codigoRegistro)
        {
            await _IServicoRegistroVacina.CancelarRegistroVacina(codigoRegistro);
        }
    }
}
