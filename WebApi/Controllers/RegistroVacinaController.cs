using Aplicacao.Interfaces;
using Dominio.Dto.RegistroVacinaDTO;
using Dominio.ExceptionPersonalizada;
using Entidades.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpPost("RegistrarVacinacao")]
        public async Task<ActionResult> RegistrarVacinacao(RegistroVacinaInsertDTO registroVacinaInsertDTO)
        {
            try
            {
                await _IAplicacaoRegistroVacina.AdicionarRegistroVacina(registroVacinaInsertDTO);
                return Ok("Registro de vacina cadastrado com sucesso.");
            }
            catch (ExceptionGenerica ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return NotFound("Erro ao registrar Vacinação. ");
            }
        }
        [HttpPost("CancelarRegistroVacinacao/{codigoRegistro}")]
        public async Task<ActionResult> CancelarRegistroVacinacao(string codigoRegistro)
        {
            try
            {
                await _IAplicacaoRegistroVacina.CancelarRegistroVacina(codigoRegistro);
                return Ok("Registro cancelado com sucesso.");
            }
            catch (ExceptionGenerica ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound("Erro ao cancelar registrar de vacinação. ");
            }
        }
        [HttpGet("BuscarRegistrosPorIdPropriedade/{idPropriedade:int}")]
        public async Task<List<RegistroVacina>> BuscarRegistrosPorIdPropriedade(int idPropriedade)
        {
            return await _IAplicacaoRegistroVacina.BuscarRegistrosPorPropriedadeId(idPropriedade);
        }
    }
}
