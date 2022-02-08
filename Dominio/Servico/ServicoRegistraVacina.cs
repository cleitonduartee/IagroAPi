using Dominio.Dto.RegistroVacinaDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoRegistraVacina : IServicoRegistroVacina
    {
        private readonly IRegistroVacina _IRegistroVacina;

        public ServicoRegistraVacina(IRegistroVacina IRegistroVacina)
        {
            _IRegistroVacina = IRegistroVacina;
        }
        public async Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroDto)
        {
            var registroVacina = new RegistroVacina(registroDto.PropriedadeId,
                                                    registroDto.TipoVacina, 
                                                    registroDto.QtdBovinoVacinado, 
                                                    registroDto.QtdBubalinoVacinado);

            await _IRegistroVacina.AdicionarRegistroVacina(registroVacina);
        }

        public async Task CancelarRegistroVacina(int idRegistroVacina)
        {

            // Verificar pois deve estornar o saldo vacinado e tbam verificar se ouve venda posterior a dt de vacina
            var registroVacina = await _IRegistroVacina.BuscarRegistroVacinaPorId(idRegistroVacina);
            if (registroVacina == null)
                throw new ExceptionGenerica("Não foi localizado o registro de vacinação com o id informado.");


            registroVacina.Ativo = false;
            registroVacina.DataCancelamento = DateTime.Now;
            await _IRegistroVacina.CancelarRegistroVacina(registroVacina);
        }
    }
}
