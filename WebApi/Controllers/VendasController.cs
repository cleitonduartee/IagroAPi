using Aplicacao.Aplicacao;
using Aplicacao.Interfaces;
using Dominio.Dto.Movimentacao.MovimentacaoDTO;
using Dominio.Dto.VendaDTO;
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
    public class VendasController : ControllerBase
    {
        private readonly IAplicacaoVenda _AplicacaoVenda;
        public VendasController(IAplicacaoVenda IAplicacaoVenda)
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
        [HttpPost("CancelarVenda/{codigoMovimentacao}")]
        public async Task<ActionResult> CancelarVenda(string codigoMovimentacao)
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
        [HttpGet("BuscarMovimentacoesPorPropriedade/{propriedadeId:int}")]
        public async Task<List<MovimentacaoResponseDTO>> BuscarMovimentacoesPorPropriedade(int propriedadeId)
        {
            return await _AplicacaoVenda.BuscarMovimentacoesPorPropriedade(propriedadeId);
        }
        [HttpGet("BuscarVendasPorProdutor/{produtorId:int}")]
        public async Task<List<MovimentacaoResponseDTO>> BuscarVendasPorProdutor(int produtorId)
        {
            return await _AplicacaoVenda.BuscarVendasPorProdutor(produtorId);          
          
        }
        [HttpGet("BuscarComprasPorProdutor/{produtorId:int}")]
        public async Task<List<MovimentacaoResponseDTO>> BuscarComprasPorProdutor(int produtorId)
        {
            return await _AplicacaoVenda.BuscarComprasPorProdutor(produtorId);
        }

    }
}
