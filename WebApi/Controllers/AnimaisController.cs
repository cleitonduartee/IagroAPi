using Aplicacao.Interfaces;
using Dominio.Dto.RebanhoDTO;
using Dominio.ExceptionPersonalizada;
using Entidades.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{    
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly IAplicacaoRebanho _IAplicacaoRebanho;
        public AnimaisController(IAplicacaoRebanho IAplicacaoRebanho)
        {
            _IAplicacaoRebanho = IAplicacaoRebanho;
        }
        [HttpGet("BuscarPorProdutor/{nomeProdutor}")]
        public async Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string nomeProdutor)
        {
            return await _IAplicacaoRebanho.BuscarPorProdutor(nomeProdutor);
        }
        [HttpGet("BuscarPorPropriedade/{nomePropriedade}")]
        public async Task<ActionResult<RebanhoResponseDTO>> BuscarPorPropriedade(string nomePropriedade)
        {
            var rebanhoResponseDto = await _IAplicacaoRebanho.BuscarRebanhoPorNomePropriedade(nomePropriedade);

            if (rebanhoResponseDto != null)
                return Ok(rebanhoResponseDto);
            else
                return NotFound("Não foi localizado nenhum rebanho para a propriedade informada.");
        }
        [HttpPost("EntradaAnimais")]
        public async Task<ActionResult> EntradaAnimais(RebanhoInsertDTO rebanhoInsertDTO)
        {
            if (!ModelState.IsValid) { }

            try
            {
                await _IAplicacaoRebanho.EntradaAnimais(rebanhoInsertDTO);
                return Ok("Entrada de animais realizada com sucesso.");

            }
            catch (ExceptionGenerica ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return NotFound("Erro ao realizar entrada de animais. Tente novamente. Caso o problema persista, entre em contato com o suporte.");
            }
        }
        [HttpPost("CancelamentoEntradaAnimais/{codigoMovimentacaoEntrada}")]
        public async Task<ActionResult> CancelamentoEntradaAnimais(string codigoMovimentacaoEntrada)
        {
            try
            {
                await _IAplicacaoRebanho.CancelarEntrada(codigoMovimentacaoEntrada);
                return Ok("Cancelamento realizado com sucesso.");

            }
            catch (ExceptionGenerica ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound("Erro ao realizar cancelamento. Tente novamente. Caso o problema persista, entre em contato com o suporte.");
            }
        }

    }
}
