using Aplicacao.Aplicacao;
using Aplicacao.Interfaces;
using Dominio.Dto.VendaDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IAplicacaoVenda _AplicacaoVenda;
        public VendaController(IAplicacaoVenda IAplicacaoVenda)
        {
             _AplicacaoVenda = IAplicacaoVenda;
        }

        [HttpPost("RealizarVenda")]
        public async Task<ActionResult> RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            try
            {
                await _AplicacaoVenda.RealizarVenda(vendaInsertDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RealizarVenda/{codigoMovimentacao}")]
        public async Task<ActionResult> RealizarVenda(string codigoMovimentacao)
        {
            try
            {
                await _AplicacaoVenda.CancelarVenda(codigoMovimentacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
