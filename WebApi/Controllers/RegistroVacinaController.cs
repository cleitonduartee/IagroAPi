using Aplicacao.Interfaces;
using Dominio.Dto.RegistroVacinaDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RegistroVacinaController : ControllerBase
    {
        private readonly IAplicacaoRegistroVacina _IAplicacaoRegistroVacina;

        public RegistroVacinaController(IAplicacaoRegistroVacina IAplicacaoRegistroVacina)
        {
            _IAplicacaoRegistroVacina = IAplicacaoRegistroVacina;
        }

        [HttpPost]
        public async Task<ActionResult> RegistraVacinacao(RegistroVacinaInsertDTO registroVacinaInsertDTO)
        {
            try
            {
                await _IAplicacaoRegistroVacina.AdicionarRegistroVacina(registroVacinaInsertDTO);
                return Ok("Registro de vacina cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                return NotFound("Erro ao registrar Vacinação. ");
            }
        }
    }
}
