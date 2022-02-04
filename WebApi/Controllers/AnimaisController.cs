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
        [HttpGet("BuscarPorProdutor/{produtor}")]
        public async Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor)
        {
            return await _IAplicacaoRebanho.BuscarPorProdutor(produtor);
        }
        [HttpGet("BuscarPorPropriedade/{propriedade}")]
        public async Task<ActionResult<RebanhoResponseDTO>> BuscarPorPropriedade(string propriedade)
        {
            var rebanhoResponseDto = await _IAplicacaoRebanho.BuscarRebanhoPorNomePropriedade(propriedade);

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
            catch (EntradaAnimalException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return NotFound("Erro ao realizar entrada de animais. Tente novamente. Caso o problema persista, entre em contato com o suporte.");
            }
        }
        [HttpPost("CancelamentoEntradaAnimais")]
        public async Task CancelamentoEntradaAnimais(Rebanho rebanho)
        {
            await _IAplicacaoRebanho.CancelarEntrada(rebanho);
        }

    }
}
